Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Reservation
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Dim DSreservation As New DataSet
    Dim DTreservation As New DataTable
    Dim DSclient As New DataSet
    Dim DTclient As New DataTable
    Dim DSerror As New DataSet
    Dim DTerror As New DataTable

    Dim error_message As String

    Dim period As String
    Dim pdate As Date

    Dim month As String
    Dim year As String

    Private Sub Clear_Client()
        ''To clean the datasource and the datatable
        DSclient.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Client ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSclient, "Client")
    End Sub

    Private Sub Clear_error()
        DSerror.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Error_Message ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSerror, "Error_Message")
    End Sub

    Private Sub Clear_Reservation()
        ''To clean the datasource and the datatable
        DSreservation.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Reservation ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSreservation, "Reservation")
    End Sub

    Private Sub Delete_Reservation()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("Delete Reservation  where reservation_id = '" & lbl_reservation_id.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Reservation()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Delete Reservation"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Extract_date()
        pdate = FormatDateTime(txt_pickup_date2.Text, DateFormat.ShortDate)
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

    Private Sub Format_Reservation()
        If Len(txt_firstname.Text) > 1 Then
            txt_firstname.Text = txt_firstname.Text.Substring(0, 1).ToUpper() + txt_firstname.Text.Substring(1)
        ElseIf Len(txt_firstname.Text) = 1 Then
            txt_firstname.Text = txt_firstname.Text.ToUpper()
        End If

        If Len(txt_middlename.Text) > 1 Then
            txt_middlename.Text = txt_middlename.Text.Substring(0, 1).ToUpper() + txt_middlename.Text.Substring(1)
        ElseIf Len(txt_middlename.Text) = 1 Then
            txt_middlename.Text = txt_middlename.Text.ToUpper()
        End If

        If Len(txt_lastname.Text) > 1 Then
            txt_lastname.Text = txt_lastname.Text.Substring(0, 1).ToUpper() + txt_lastname.Text.Substring(1)
        ElseIf Len(txt_lastname.Text) = 1 Then
            txt_lastname.Text = txt_lastname.Text.ToUpper()
        End If

        If Len(txt_reason.Text) > 1 Then
            txt_reason.Text = txt_reason.Text.Substring(0, 1).ToUpper() + txt_reason.Text.Substring(1)
        ElseIf Len(txt_reason.Text) = 1 Then
            txt_reason.Text = txt_reason.Text.ToUpper()
        End If

        If Len(txt_telephone.Text) = 10 Then
            Dim a As String = Microsoft.VisualBasic.Left(txt_telephone.Text, 3)
            Dim b As String = Mid(txt_telephone.Text, 4, 3)
            Dim c As String = Microsoft.VisualBasic.Right(txt_telephone.Text, 4)

            txt_telephone.Text = "(" + a + ") " + b + "-" + c
        End If

        Save_Reservation()
    End Sub

    Private Sub Generate_ClientID()
        ''To generate new Employe ID

        Dim Reader As SqlDataReader

        If Connection.State = ConnectionState.Closed Then
            Open_Connection()
            Connection.Open()
        End If
        Try

            Dim cmd As SqlCommand = New SqlCommand("select client_id from client where client_id=(select max(client_id) from Client) ", Connection)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If Reader.Read Then
                lbl_client_id.Text = Reader("client_id").ToString()
                New_Client_ID()
                Exit Sub
            Else
                lbl_client_id.Text = "CL-ATS-001"
            End If
        Catch ex As Exception
            error_message = ex.Message & " - " & "Generate Client ID"
            Unexpected_Error()
            Save_Error()
            Response.Write(ex.Message.ToString())
        End Try
        Reader.Close()
        Connection.Close()

    End Sub

    Private Sub Generate_Reservation_ID()
        Dim year As Integer = Today.Year

        lbl_reservation_id.Text = year & "ATS" & lbl_proforma_id.Text
    End Sub

    Private Sub Load_Client()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Client ", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_client.DataSource = reader
            grd_client.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load_Client"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()

    End Sub

    Private Sub Load_Proforma()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Proforma where proforma_id='" & lbl_proforma_id.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_proforma.DataSource = reader
            grd_proforma.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Proforma"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()

        Publish_Proforma()
    End Sub

    Private Sub Load_Reservation()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Reservation ", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_reservation.DataSource = reader
            grd_reservation.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Reservation"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Load_Time()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Time", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_time.DataSource = reader
            grd_time.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Time"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()

        Publish_Time()
    End Sub

    Private Sub New_Client_ID()
        ''To increment the client ID by 1

        Dim I As Integer
        Dim a As String
        Dim b As String
        Dim c As Integer

        b = Right(lbl_client_id.Text, 3)


        c = b + 1

        Me.lbl_client_id.Text = c
        If Len(Me.lbl_client_id.Text) = 1 Then
            Me.lbl_client_id.Text = "CL-ATS-00" & "" & c
        ElseIf Len(Me.lbl_client_id.Text) = 2 Then
            Me.lbl_client_id.Text = "CL-ATS-0" & "" & c
        ElseIf Len(Me.lbl_client_id.Text) = 3 Then
            Me.lbl_client_id.Text = "CL-ATS-" & "" & c


        End If
    End Sub

    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub

    Private Sub Publish_Proforma()
        If grd_proforma.Rows.Count <= 0 Then
            Exit Sub
        End If
        txt_pickup_date2.Text = grd_proforma.Rows.Item(0).Cells(1).Text
        ddl_pickup_time.Text = grd_proforma.Rows.Item(0).Cells(2).Text
        txt_transport_type.Text = grd_proforma.Rows.Item(0).Cells(3).Text
        txt_pick_up_1.Text = grd_proforma.Rows.Item(0).Cells(5).Text
        txt_dropoff_1.Text = grd_proforma.Rows.Item(0).Cells(6).Text
        txt_pick_up_2.Text = grd_proforma.Rows.Item(0).Cells(9).Text
        txt_dropoff_2.Text = grd_proforma.Rows.Item(0).Cells(10).Text
        txt_pick_up_3.Text = grd_proforma.Rows.Item(0).Cells(13).Text
        txt_dropoff_3.Text = grd_proforma.Rows.Item(0).Cells(14).Text

    End Sub

    Private Sub Publish_Time()
        Dim i As Integer
        Dim a As String

        For i = 0 To grd_time.Rows.Count - 1
            a = grd_time.Rows.Item(i).Cells(1).Text

            ddl_pickup_time.Items.Add(a)
        Next
    End Sub

    Private Sub Save_Client()
        Dim i As Integer
        Dim a As String
        Dim b As String
        Dim c As String

        For i = 0 To grd_client.Rows.Count - 1
            a = grd_client.Rows.Item(i).Cells(1).Text
            b = grd_client.Rows.Item(i).Cells(2).Text
            c = grd_client.Rows.Item(i).Cells(3).Text
            If a = txt_firstname.Text And b = txt_middlename.Text And c = txt_lastname.Text Then
                Exit Sub
            End If
        Next


        Generate_ClientID()
        Open_Connection()
        Connection.Open()

        Dim firstname As String = txt_firstname.Text
        Dim middlename As String = txt_middlename.Text
        Dim lastname As String = txt_lastname.Text
        Dim address1 As String = "-"
        Dim address2 As String = "-"
        Dim city As String = "-"
        Dim state As String = "-"
        Dim zipcode As Integer = 0
        Dim telephone As String = txt_telephone.Text
        Dim email As String = txt_email.Text


        Try
            Command = New SqlCommand("Insert into Client values('" & lbl_client_id.Text & "','" & firstname & "', '" & middlename & "', '" & lastname & "', '" & address1 & "', '" & address2 & "', '" & city & "', '" & state & "', '" & zipcode & "', '" & telephone & "', '" & email & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Client()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Client"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        Load_Client()
    End Sub

    Private Sub Save_Error()
        Open_Connection()
        Connection.Open()
        Dim edate As Date = FormatDateTime(Today, DateFormat.ShortDate)
        Dim etime As Date = FormatDateTime(Now, DateFormat.LongTime)
        Dim page As String = "Reservation"
        Dim user As String = Session("Employe")
        Dim status As String = "Open"


        Try
            Command = New SqlCommand("Insert into Error_Message values('" & edate & "', '" & etime & "', '" & page & "', '" & user & "', '" & error_message & "', '" & status & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_error()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Save_Reservation()
        Open_Connection()
        Connection.Open()

        Dim firstname As String = txt_firstname.Text
        Dim middlename As String = txt_middlename.Text
        Dim lastname As String = txt_lastname.Text
        Dim telephone As String = txt_telephone.Text
        Dim email As String = txt_email.Text
        Dim pickupdate As Date = txt_pickup_date2.Text
        Dim pickuptime As String = ddl_pickup_time.Text
        Dim reason As String = txt_reason.Text
        Dim title As String = "New Transport" & " " & firstname & " " & middlename & " " & lastname & " " & reason
        Dim status As String = "Open"
        Extract_date()

        Try
            Command = New SqlCommand("Insert into Reservation values('" & lbl_reservation_id.Text & "', '" & title & "', '" & firstname & "', '" & middlename & "', '" & lastname & "', '" & telephone & "', '" & email & "', '" & pickupdate & "', '" & pickuptime & "', '" & reason & "', '" & status & "', '" & period & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Reservation()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Reservation"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        If cbx_save_client.Checked = True Then
            Save_Client()
        End If

        Save_Reservation_Comment()


        lbl_comment.Text = "New reservation saved in database"
        lbl_comment.ForeColor = System.Drawing.Color.Green


    End Sub

    Private Sub Save_Reservation_Comment()
        Open_Connection()
        Connection.Open()

        Dim reservation_id As String = lbl_reservation_id.Text
        Dim rdate As Date = FormatDateTime(Today.ToShortDateString)
        Dim status As String = "Open"
        Dim comment As String = "New Reservation open"
        Dim user As String = Session("Employe")


        Try
            Command = New SqlCommand("Insert into Reservation_Comment values('" & reservation_id & "', '" & rdate & "', '" & status & "', '" & comment & "', '" & user & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Reservation()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Reservation Comment"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Unexpected_Error()
        lbl_comment.Visible = True
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed
        lbl_comment.BackColor = System.Drawing.Color.LightPink
        lbl_comment.Text = "Unexpected error. Please try again later or contact your system administrator"
    End Sub

    Private Sub Validate_Reservation()
        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed

        If txt_firstname.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please enter the client name or import it from the database"

            Exit Sub

        End If

        If txt_lastname.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please enter the client name or import it from the database"

            Exit Sub

        End If

        If txt_reason.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please provide transportation reason"

            Exit Sub
        End If
        Format_Reservation()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then

        Else
            lbl_proforma_id.Text = Session("Proforma ID")
            Load_Reservation()
            Load_Time()

            If lbl_reservation_id.Text = "" Then
                Generate_Reservation_ID()

                Load_Proforma()
                Load_Client()
            End If
            cbx_save_client.Checked = True
        End If
    End Sub

    Private Sub ll_close_Click(sender As Object, e As EventArgs) Handles ll_close.Click
        Response.Redirect("~/Content/Reservation/Calendar.aspx")
    End Sub

    Private Sub lbl_save_Click(sender As Object, e As EventArgs) Handles lbl_save.Click
        lbl_comment.Visible = False
        Validate_Reservation()
    End Sub

    Private Sub ll_import_Click(sender As Object, e As EventArgs) Handles ll_import.Click
        lbl_comment.Visible = False
        row_client.Visible = True
    End Sub

    Private Sub ll_close2_Click(sender As Object, e As EventArgs) Handles ll_close2.Click
        lbl_comment.Visible = False
        row_client.Visible = False
    End Sub

    Private Sub ll_modify_date_Click(sender As Object, e As EventArgs) Handles ll_modify_date.Click
        lbl_comment.Visible = False
        txt_pickup_date.Visible = True
        txt_pickup_date2.Visible = False
        ll_save_date.Visible = True
        ll_modify_date.Visible = False

    End Sub

    Private Sub ll_save_date_Click(sender As Object, e As EventArgs) Handles ll_save_date.Click
        lbl_comment.Visible = False
        txt_pickup_date2.Text = txt_pickup_date.Text
        txt_pickup_date2.Visible = True
        txt_pickup_date.Visible = False
        ll_modify_date.Visible = True
        ll_save_date.Visible = False
    End Sub

    Private Sub ll_cancel_date_Click(sender As Object, e As EventArgs) Handles ll_cancel_date.Click
        lbl_comment.Visible = False
        txt_pickup_date2.Visible = True
        txt_pickup_date.Visible = False
        ll_modify_date.Visible = True
        ll_save_date.Visible = False
    End Sub


    Private Sub Reservation_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        If txt_reason.Text = "" Then
            Delete_Reservation()
        End If
    End Sub

    Protected Sub ll_choice_Click(sender As Object, e As EventArgs)
        lbl_comment.Visible = False
        Dim ll As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(ll.Parent.Parent, GridViewRow)
        Dim idx As Integer = row.RowIndex

        lbl_client_id.Text = grd_client.Rows.Item(idx).Cells(0).Text
        txt_firstname.Text = grd_client.Rows.Item(idx).Cells(1).Text
        txt_middlename.Text = grd_client.Rows.Item(idx).Cells(2).Text
        txt_lastname.Text = grd_client.Rows.Item(idx).Cells(3).Text
        txt_telephone.Text = grd_client.Rows.Item(idx).Cells(4).Text
        txt_email.Text = grd_client.Rows.Item(idx).Cells(5).Text

        cbx_save_client.Enabled = False
        row_client.Visible = False
    End Sub
End Class