Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Client
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Private Sub Filter_Client()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT client_id, first_name, last_name, telephone, email from Client where first_name like '%" & txt_search.Text & "%' or last_name like '%" & txt_search.Text & "%' or telephone like '%" & txt_search.Text & "%'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_client.DataSource = reader
            grd_client.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Load_Client()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT client_id, first_name, last_name, telephone, email from Client", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_Client.DataSource = reader
            grd_Client.DataBind()
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
            Filter_Client()
        Else
            Open_Connection()
            Load_Client()
        End If
    End Sub

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        Filter_Client()
    End Sub

    Private Sub ll_add_new_Click(sender As Object, e As EventArgs) Handles ll_add_new.Click
        Response.Redirect("~/Content/Client/Client_add.aspx")
    End Sub

    Protected Sub ll_view_Click(sender As Object, e As EventArgs)
        Dim ll As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(ll.Parent.Parent, GridViewRow)
        Dim idx As Integer = row.RowIndex




        lbl_client_id.Text = grd_Client.Rows.Item(idx).Cells(0).Text
        Session.Add("Client ID", lbl_client_id.Text)
        Response.Redirect("~/Content/Client/Client_View.aspx")
    End Sub
End Class