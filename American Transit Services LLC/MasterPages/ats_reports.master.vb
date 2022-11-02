Public Class ats_reports
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub ddl_report_TextChanged(sender As Object, e As EventArgs) Handles ddl_report.TextChanged
        If ddl_report.Text = "Transport" Then
            Response.Redirect("~/Content/Reports/Transport/Transport_Reports.aspx")
        End If
    End Sub
End Class