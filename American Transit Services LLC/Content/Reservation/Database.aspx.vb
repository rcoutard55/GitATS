Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Database
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection





    Private Sub Filter_reservation()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * From Reservation where firstname like '%" & txt_search.Text & "%' or lastname like '%" & txt_search.Text & "%' or reservation_id like '%" & txt_search.Text & "%' ORDER BY [reservation_id] DESC", Connection)
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
            Command = New SqlCommand("SELECT * from Reservation ORDER BY [reservation_id] DESC", Connection)
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

    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Filter_reservation()
        Else
            Open_Connection()
            Load_Reservation()
        End If
    End Sub

    Private Sub ll_add_new_Click(sender As Object, e As EventArgs) Handles ll_add_new.Click
        Dim place As String = "Calendar Database"
        Dim proforma_id As String = ""
        Session.Add("Proforma ID", proforma_id)
        Session.Add("Place", place)
        Response.Redirect("~/Content/Proforma/Proforma.aspx")
        Response.Redirect("~/Content/Proforma/Proforma.aspx")
    End Sub

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        Filter_reservation()
    End Sub

    Private Sub ll_calendar_Click(sender As Object, e As EventArgs) Handles ll_calendar.Click
        Response.Redirect("~/Content/Reservation/Calendar.aspx")
    End Sub

    Protected Sub lbl_select_Click(sender As Object, e As EventArgs)
        Dim ll As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(ll.Parent.Parent, GridViewRow)
        Dim idx As Integer = row.RowIndex

        lbl_reservation_id.Text = grd_reservation.Rows.Item(idx).Cells(0).Text
        Session.Add("Reservation ID", lbl_reservation_id.Text)
        Session.Add("Place", "Database")
        Response.Redirect("~/Content/Reservation/View_Reservation.aspx")
    End Sub
End Class