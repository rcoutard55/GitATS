Public Class Error_Page
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
        Else
            Dim ll_dashboard As LinkButton = CType(Master.FindControl("ll_dashboard"), LinkButton)
            ll_dashboard.Enabled = False
            ll_dashboard.ForeColor = System.Drawing.Color.Gray

            Dim ll_client As LinkButton = CType(Master.FindControl("ll_client"), LinkButton)
            ll_client.Enabled = False
            ll_client.ForeColor = System.Drawing.Color.Gray

            Dim ll_proforma As LinkButton = CType(Master.FindControl("ll_proforma"), LinkButton)
            ll_proforma.Enabled = False
            ll_proforma.ForeColor = System.Drawing.Color.Gray

            Dim ll_administration As LinkButton = CType(Master.FindControl("ll_admin"), LinkButton)
            ll_administration.Enabled = False
            ll_administration.ForeColor = System.Drawing.Color.Gray

            Dim ll_reservation As LinkButton = CType(Master.FindControl("ll_reservation"), LinkButton)
            ll_reservation.Enabled = False
            ll_reservation.ForeColor = System.Drawing.Color.Gray

            Dim ll_invoice As LinkButton = CType(Master.FindControl("ll_invoice"), LinkButton)
            ll_invoice.Enabled = False
            ll_invoice.ForeColor = System.Drawing.Color.Gray

            Dim ll_account As LinkButton = CType(Master.FindControl("ll_account"), LinkButton)
            ll_account.Enabled = False
            ll_account.ForeColor = System.Drawing.Color.Gray

            Dim ll_report As LinkButton = CType(Master.FindControl("ll_reports"), LinkButton)
            ll_report.Enabled = False
            ll_report.ForeColor = System.Drawing.Color.Gray
        End If


    End Sub

End Class