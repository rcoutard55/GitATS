Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Proforma_Database
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Private Sub Filter_Proforma()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Proforma where proforma_id='%" & txt_search.Text & "%'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_proforma.DataSource = reader
            grd_proforma.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Load_proforma()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Proforma ORDER BY [proforma_id] DESC", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_proforma.DataSource = reader
            grd_proforma.DataBind()
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


        Else
            Open_Connection()
            Load_proforma()
            grd_proforma.PageSize = 5
        End If
    End Sub

    Private Sub ll_add_new_Click(sender As Object, e As EventArgs) Handles ll_add_new.Click
        Dim place As String = "Database"
        lbl_proforma_id.Text = ""
        Session.Add("Place", place)
        Session.Add("Proforma ID", lbl_proforma_id.Text)
        Response.Redirect("~/Content/Proforma/Proforma.aspx")
    End Sub

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        Filter_Proforma()
    End Sub

    Protected Sub ll_view_Click(sender As Object, e As EventArgs)
        Dim ll As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(ll.Parent.Parent, GridViewRow)
        Dim idx As Integer = row.RowIndex

        lbl_proforma_id.Text = grd_proforma.Rows.Item(idx).Cells(0).Text
        Dim place As String = "Database"
        Session.Add("Place", place)
        Session.Add("Proforma ID", lbl_proforma_id.Text)
        Response.Redirect("~/Content/Proforma/Proforma.aspx")

    End Sub
End Class