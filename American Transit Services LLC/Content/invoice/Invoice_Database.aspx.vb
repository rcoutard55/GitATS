Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Invoice_Database
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Private Sub Load_Invoice()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Invoice ORDER BY [invoice_id] DESC", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_invoice.DataSource = reader
            grd_invoice.DataBind()
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
            Load_Invoice()
        End If
    End Sub

    Protected Sub ll_view_Click(sender As Object, e As EventArgs)
        Dim ll As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(ll.Parent.Parent, GridViewRow)
        Dim idx As Integer = row.RowIndex

        lbl_invoice_id.Text = grd_invoice.Rows.Item(idx).Cells(0).Text
        Session.Add("Reservation ID", lbl_invoice_id.Text)
        Response.Redirect("~/Content/invoice/Invoice.aspx")
    End Sub
End Class