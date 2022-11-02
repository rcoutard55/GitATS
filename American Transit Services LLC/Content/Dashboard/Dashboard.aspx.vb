Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.UI.WebControls
Public Class Dashboard
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection


    Dim DSreservationpoint As New DataSet
    Dim DTreservationpoint As New DataTable

    Dim period As String
    Dim pdate As Date

    Dim month As String
    Dim year As String
    Dim expiration As DateTime

    Dim Reservation_total As Integer
    Dim Reservation_Cancel As Integer
    Dim Reservation_Close As Integer



    Private Sub Calculate_Reservation()
        Reservation_total = grd_reservation.Rows.Count

        Dim i As Integer
        Dim a As Integer
        Dim b As Integer
        Dim status As String

        For i = 0 To grd_reservation.Rows.Count - 1
            status = grd_reservation.Rows.Item(i).Cells(10).Text
            If status = "Close" Then
                a = 1
                Reservation_Close = Reservation_Close + a
            ElseIf status = "Canceled" Then
                b = 1
                Reservation_Cancel = Reservation_Cancel + b
            End If


        Next
    End Sub

    Private Sub check_expiration_date()
        Dim dtoday As DateTime = Today
        Dim a As TimeSpan
        Dim i As Integer = 0
        Dim b As String = ""
        Dim c As String = ""
        expiration = grd_user.Rows.Item(0).Cells(5).Text

        a = expiration - dtoday
        lbl_days.Text = (a).ToString
        For i = 1 To Len(lbl_days.Text)
            b = Mid(lbl_days.Text, i, 1)
            If b = "." Or b = ":" Then
                Exit For
            End If
            c = c + b
        Next

        lbl_days.Text = c
        If lbl_days.Text <= "0" Then
            Session.Add("Expired Password", "Yes")
            Response.Redirect("~/Content/Error Page/Error_Page.aspx")
        Else
            lbl_days.Text = c * (-1)
            If lbl_days.Text <= 5 And lbl_days.Text >= 5 Then
                If lbl_days.Text = "-1" Then
                    lbl_days.Text = lbl_days.Text + " day. "
                Else
                    lbl_days.Text = lbl_days.Text + " days. "
                End If

                card_password.Visible = True

            End If
        End If



    End Sub

    Private Sub Check_reservation_date()

        Dim tdate As Date = FormatDateTime(Today, DateFormat.ShortDate)
        Dim i As Integer
        Dim a As Integer
        Dim b As String
        Dim rdate As Date
        Dim tday As String
        Dim tday2 As String
        Dim status As String
        tday2 = ""
        For i = 0 To grd_reservation.Rows.Count - 1
            rdate = grd_reservation.Rows.Item(i).Cells(7).Text
            status = grd_reservation.Rows.Item(i).Cells(10).Text
            tday = (tdate - rdate).ToString
            If status = "Close" Then
                GoTo point1
            End If
            For a = 1 To Len(tday)
                b = Mid(tday, a, 1)
                If b = "." Or b = ":" Then
                    Exit For

                End If
                tday2 = tday2 + b

            Next
            If tday2 = "00" Then
                tday2 = 0
            Else
                tday2 = (tday2) * (-1)
            End If

            If Val(tday2) <= 5 AndAlso Val(tday2) >= 0 And status = "Open" Then
                lbl_info.Text = tday2
                card_contract.Visible = True
                Exit Sub
            ElseIf val(tday2) < 0 And status = "Open" Then
                card_contract2.Visible = True
                Exit Sub
            Else
                card_contract.Visible = False
                card_contract2.Visible = False
            End If

point1:
            tday2 = ""

        Next


    End Sub

    Private Sub Clear_Reservation_Point()
        ''To clean the datasource and the datatable
        DSreservationpoint.Clear()
        Adapters = Nothing
        Command = New SqlCommand("Select * from Reservation_Point ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSreservationpoint, "Reservation_Point")
    End Sub

    Private Sub Delete_Reservation_Point()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("Delete from Reservation_Point", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Reservation_Point()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Extract_date()
        month = pdate.Month.ToString
        year = pdate.Year.ToString

        If month = "1" Or month = "01" Then
            period = "January"
        ElseIf month = "2" Or month = "02" Then
            period = "February"
        ElseIf month = "3" Or month = "03" Then
            period = "Mars"
        ElseIf month = "4" Or month = "04" Then
            period = "April"
        ElseIf month = "5" Or month = "05" Then
            period = "May"
        ElseIf month = "6" Or month = "06" Then
            period = "June"
        ElseIf month = "7" Or month = "07" Then
            period = "July"
        ElseIf month = "8" Or month = "08" Then
            period = "August"
        ElseIf month = "9" Or month = "09" Then
            period = "September"
        ElseIf month = "10" Then
            period = "October"
        ElseIf month = "11" Then
            period = "November"
        ElseIf month = "12" Then
            period = "December"
        End If
        period = period & " " & year
    End Sub

    Private Sub Filter_Reservation()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("Select * from Reservation where period='" & period & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_reservation.DataSource = reader
            grd_reservation.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()

        Calculate_Reservation()
    End Sub

    Private Sub Get_Chart_Data()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Reservation_Point", Connection)
            Dim reader As SqlDataReader
            Dim series1 As Series = chart_contract.Series("Series1")
            Dim series2 As Series = chart_contract.Series("Series2")
            Dim series3 As Series = chart_contract.Series("Series3")
            reader = Command.ExecuteReader
            While reader.Read
                series1.Points.AddXY(reader("Period").ToString, reader("Total").ToString)
                series2.Points.AddXY(reader("Period").ToString, reader("Closed").ToString)
                series3.Points.AddXY(reader("Period").ToString, reader("Canceled").ToString)
            End While
        Catch

        End Try

    End Sub

    Private Sub Load_User()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from e_User where employe_id='" & lbl_employe_ID.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_user.DataSource = reader
            grd_user.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        check_expiration_date()
    End Sub

    Private Sub Load_Reservation()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Reservation ORDER BY [pickup_date] ASC", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_reservation.DataSource = reader
            grd_reservation.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()

        Check_reservation_date()
    End Sub

    Private Sub Load_Reservation_Point()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Reservation_Point", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_reservation_point.DataSource = reader
            grd_reservation_point.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()


    End Sub


    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub

    Private Sub Save_Reservation_Point()
        Open_Connection()
        Connection.Open()
        Try
            Command = New SqlCommand("Insert into Reservation_Point values('" & period & "','" & Reservation_Close & "', '" & Reservation_Cancel & "', '" & Reservation_total & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Reservation_Point()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Search_Date()
        Dim tdate As Date = Today

        Dim a As Integer = 0

        For a = 0 To 6
            pdate = Today.AddMonths(-6 + a)
            Extract_date()
            Filter_Reservation()
            Save_Reservation_Point()
        Next
        Load_Reservation_Point()
        Get_Chart_Data()
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
        Else
            lbl_employe_ID.Text = Session("Employe ID")
            Load_User()
            Delete_Reservation_Point()
            Load_Reservation()
            Search_Date()
        End If
    End Sub

    Private Sub ll_password_Click(sender As Object, e As EventArgs) Handles ll_password.Click
        Response.Redirect("~/Content/My Account/Account/Password.aspx")
    End Sub

    Private Sub ll_close_Click(sender As Object, e As EventArgs) Handles ll_close.Click
        card_password.Visible = False
    End Sub

    Private Sub ll_close2_Click(sender As Object, e As EventArgs) Handles ll_close2.Click
        card_contract.Visible = False
    End Sub

    Private Sub ll_close3_Click(sender As Object, e As EventArgs) Handles ll_close3.Click
        card_contract2.Visible = False
    End Sub

    Private Sub ll_reservation1_Click(sender As Object, e As EventArgs) Handles ll_reservation1.Click
        Response.Redirect("~/Content/Reservation/Calendar.aspx")
    End Sub

    Private Sub ll_reservation2_Click(sender As Object, e As EventArgs) Handles ll_reservation2.Click
        Response.Redirect("~/Content/Reservation/Calendar.aspx")
    End Sub
End Class