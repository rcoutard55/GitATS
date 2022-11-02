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
Public Class Employe_Download
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then

        Else
            lbl_employe_id.Text = Session("Employe ID")
        End If
    End Sub

    Private Sub ll_close_Click(sender As Object, e As EventArgs) Handles ll_close.Click
        Session.Add("Employe ID", lbl_employe_id.Text)
        Response.Redirect("~/Content/Administration/RRHH/Employe/Employe_View.aspx")
    End Sub
End Class