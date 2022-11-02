Public Class ats_settings
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub ll_admin_Click(sender As Object, e As EventArgs) Handles ll_admin.Click
        Response.Redirect("~/Content/Administration/Administration.aspx")
    End Sub

    Private Sub ll_rate_Click(sender As Object, e As EventArgs) Handles ll_rate.Click
        Response.Redirect("~/Content/Administration/Settings/Rate/Company.aspx")
    End Sub

    Private Sub ll_department_Click(sender As Object, e As EventArgs) Handles ll_department.Click
        Response.Redirect("~/Content/Administration/Settings/Department/Department.aspx")
    End Sub

    Private Sub ll_error_Click(sender As Object, e As EventArgs) Handles ll_error.Click
        Response.Redirect("~/Content/Administration/Settings/Error List/Error_List.aspx")
    End Sub

    Private Sub ll_log_history_Click(sender As Object, e As EventArgs) Handles ll_log_history.Click
        Response.Redirect("~/Content/Administration/Settings/Log History/Log History.aspx")
    End Sub

    Private Sub ll_password_reset_Click(sender As Object, e As EventArgs) Handles ll_password_reset.Click
        Response.Redirect("~/Content/Administration/Settings/Password Reset/Password_Reset.aspx")
    End Sub

    Private Sub ll_location_center_Click(sender As Object, e As EventArgs) Handles ll_location_center.Click
        Response.Redirect("~/Content/Administration/Settings/Location/Location.aspx")
    End Sub

    Private Sub ll_role_Click(sender As Object, e As EventArgs) Handles ll_role.Click
        Response.Redirect("~/Content/Administration/Settings/Authorization/Authorization.aspx")
    End Sub
End Class