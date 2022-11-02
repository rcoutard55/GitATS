Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Calendar
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Dim Title As String

    Private Sub Filter_Reservation2()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Reservation where title='" & Title & "' ORDER BY [Pickup_time] ASC ", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_reservation2.DataSource = reader
            grd_reservation2.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try

        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Filter_Reservation()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Reservation where pickup_date='" & lbl_date.Text & "' ORDER BY [Pickup_time] ASC ", Connection)
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
    End Sub

    Private Sub Load_Reservation()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Reservation ORDER BY [Pickup_time] ASC ", Connection)
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
    End Sub

    Private Sub Load_Reservation2()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Reservation ORDER BY [Pickup_time] ASC ", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader

            grd_reservation2.DataSource = reader
            grd_reservation2.DataBind()
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

    Private Sub Calendar_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then

        Else
            Open_Connection()
            Load_Reservation()

            Calendar1.SelectedDate = Today
            lbl_date.Text = Calendar1.SelectedDate

            Filter_Reservation()

        End If
    End Sub

    Private Sub Calendar1_SelectionChanged(sender As Object, e As EventArgs) Handles Calendar1.SelectionChanged
        lbl_date.Text = Calendar1.SelectedDate
        Filter_Reservation()
    End Sub

    Private Sub ll_previous_Click(sender As Object, e As EventArgs) Handles ll_previous.Click
        Dim pdate As Date = lbl_date.Text
        pdate = pdate.AddDays(-1)
        lbl_date.Text = pdate
        Calendar1.SelectedDate = pdate
        Filter_Reservation()
    End Sub

    Private Sub ll_next_Click(sender As Object, e As EventArgs) Handles ll_next.Click
        Dim pdate As Date = lbl_date.Text
        pdate = pdate.AddDays(+1)
        lbl_date.Text = pdate
        Calendar1.SelectedDate = pdate
        Filter_Reservation()
    End Sub

    Private Sub ll_list_Click(sender As Object, e As EventArgs) Handles ll_list.Click
        Response.Redirect("~/Content/Reservation/Database.aspx")
    End Sub

    Protected Sub Calendar1_DayRender(sender As Object, e As DayRenderEventArgs)
        If IsPostBack Then
            Dim i As Integer
            Dim rdate As DateTime
            Load_Reservation2()
            For i = 0 To grd_reservation2.Rows.Count - 1
                If e.Day.Date <= Convert.ToDateTime(grd_reservation2.Rows.Item(i).Cells(7).Text) AndAlso e.Day.Date >= Convert.ToDateTime(grd_reservation2.Rows.Item(i).Cells(7).Text) Then
                    e.Cell.BackColor = System.Drawing.Color.Black
                    e.Cell.ForeColor = System.Drawing.Color.White
                    e.Cell.BorderColor = System.Drawing.Color.White
                    e.Cell.BorderWidth = New Unit(1)
                End If
            Next

        Else
            Dim i As Integer
            Dim rdate As DateTime
            Load_Reservation2()
            For i = 0 To grd_reservation2.Rows.Count - 1
                rdate = grd_reservation2.Rows.Item(i).Cells(7).Text
                If e.Day.Date <= Convert.ToDateTime(grd_reservation2.Rows.Item(i).Cells(7).Text) AndAlso e.Day.Date >= Convert.ToDateTime(grd_reservation2.Rows.Item(i).Cells(7).Text) Then
                    e.Cell.BackColor = System.Drawing.Color.Black
                    e.Cell.ForeColor = System.Drawing.Color.White
                    e.Cell.BorderColor = System.Drawing.Color.White
                    e.Cell.BorderWidth = New Unit(1)
                End If
            Next

        End If

    End Sub

    Protected Sub ll_title_Click(sender As Object, e As EventArgs)
        Dim ll_title As LinkButton = CType(sender, LinkButton)

        Title = ll_title.Text
        Filter_Reservation2()

        Session.Add("Reservation ID", grd_reservation2.Rows.Item(0).Cells(0).Text)
        Session.Add("Place", "Calendar")
        Response.Redirect("~/Content/Reservation/View_Reservation.aspx")

    End Sub

    Private Sub ll_add_new_Click(sender As Object, e As EventArgs) Handles ll_add_new.Click
        Dim place As String = "Calendar"
        Session.Add("Place", place)
        Dim proforma_id As String = ""
        Session.Add("Proforma ID", proforma_id)
        Response.Redirect("~/Content/Proforma/Proforma.aspx")
    End Sub
End Class