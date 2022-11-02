Public Class ats_rrhh
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub ll_admin_Click(sender As Object, e As EventArgs) Handles ll_admin.Click
        Response.Redirect("~/Content/Administration/Administration.aspx")
    End Sub

    Private Sub ll_employe_Click(sender As Object, e As EventArgs) Handles ll_employe.Click
        Response.Redirect("~/Content/Administration/RRHH/Employe/Employe_Database.aspx")
    End Sub

    Private Sub ll_user_Click(sender As Object, e As EventArgs) Handles ll_user.Click
        Response.Redirect("~/Content/Administration/RRHH/User/User_Database.aspx")
    End Sub
End Class