Public Class Administration
    Inherits System.Web.UI.Page
    Dim rrhh As String
    Dim finance As String
    Dim settigs As String

    Private Sub Apply_Authorization()
        If rrhh = "Yes" Then
            ll_rrhh.Enabled = True
            ll_rrhh.ForeColor = System.Drawing.Color.White
        Else
            ll_rrhh.Enabled = False
            ll_rrhh.ForeColor = System.Drawing.Color.Gray
        End If

        If finance = "Yes" Then
            ll_finance.Enabled = True
            ll_finance.ForeColor = System.Drawing.Color.White
        Else
            ll_finance.Enabled = False
            ll_finance.ForeColor = System.Drawing.Color.Gray
        End If

        If settigs = "Yes" Then
            ll_settings.Enabled = True
            ll_settings.ForeColor = System.Drawing.Color.White
        Else
            ll_settings.Enabled = False
            ll_settings.ForeColor = System.Drawing.Color.Gray
        End If
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            rrhh = Session("rrhh")
            finance = Session("finance")
            settigs = Session("settings")
            Apply_Authorization()
        Else
            rrhh = Session("rrhh")
            finance = Session("finance")
            settigs = Session("settings")
            Apply_Authorization()
        End If
    End Sub

    Private Sub ll_settings_Click(sender As Object, e As EventArgs) Handles ll_settings.Click
        Response.Redirect("~/Content/Administration/Settings/Settings.aspx")
    End Sub

    Private Sub ll_rrhh_Click(sender As Object, e As EventArgs) Handles ll_rrhh.Click
        Response.Redirect("~/Content/Administration/RRHH/rrhh.aspx")
    End Sub
End Class