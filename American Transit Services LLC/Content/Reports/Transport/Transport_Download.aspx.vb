Public Class Transport_Download
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub lbl_close_Click(sender As Object, e As EventArgs) Handles lbl_close.Click
        Response.Redirect("~/Content/Reports/Transport/Transport_Reports.aspx")
    End Sub
End Class