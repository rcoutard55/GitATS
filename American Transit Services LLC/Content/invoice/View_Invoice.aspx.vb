Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html.simpleparser
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Threading.Tasks
Public Class View_Invoice
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Dim DSinvoice As New DataSet
    Dim DTinvoice As New DataTable




    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
        Else
            Open_Connection()

        End If
    End Sub

    Private Sub lbl_close_Click(sender As Object, e As EventArgs) Handles lbl_close.Click
        Response.Redirect("~/Content/invoice/Invoice.aspx")
    End Sub
End Class