Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class ATS
    Inherits System.Web.UI.MasterPage
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Dim DSerror As New DataSet
    Dim DTerror As New DataTable

    Dim administration As String
    Dim client As String
    Dim proforma As String
    Dim reservation As String
    Dim invoice As String
    Dim rrhh As String
    Dim finance As String
    Dim settings As String


    Dim error_message As String

    Private Sub Apply_Restrictions()
        If administration = "Yes" Then
            ll_admin.Enabled = True
            ll_admin.ForeColor = System.Drawing.Color.White
        Else
            ll_admin.Enabled = False
            ll_admin.ForeColor = System.Drawing.Color.Gray
        End If

        If client = "Yes" Then
            ll_client.Enabled = True
            ll_client.ForeColor = System.Drawing.Color.White
        Else
            ll_client.Enabled = False
            ll_client.ForeColor = System.Drawing.Color.Gray
        End If

        If proforma = "Yes" Then
            ll_proforma.Enabled = True
            ll_proforma.ForeColor = System.Drawing.Color.White
        Else
            ll_proforma.Enabled = False
            ll_proforma.ForeColor = System.Drawing.Color.Gray
        End If

        If reservation = "Yes" Then
            ll_reservation.Enabled = True
            ll_reservation.ForeColor = System.Drawing.Color.White
        Else
            ll_reservation.Enabled = False
            ll_reservation.ForeColor = System.Drawing.Color.Gray
        End If

        If invoice = "Yes" Then
            ll_invoice.Enabled = True
            ll_invoice.ForeColor = System.Drawing.Color.White
        Else
            ll_invoice.Enabled = False
            ll_invoice.ForeColor = System.Drawing.Color.Gray
        End If

        Session.Add("rrhh", lbl_rrhh.Text)
        Session.Add("finance", lbl_finance.Text)
        Session.Add("settings", lbl_settings.Text)
    End Sub

    Private Sub Clear_error()
        DSerror.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Error_Message ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSerror, "Error_Message")
    End Sub

    Private Sub Extract_Autorization()
        administration = grd_autorization.Rows.Item(0).Cells(2).Text
        client = grd_autorization.Rows.Item(0).Cells(3).Text
        proforma = grd_autorization.Rows.Item(0).Cells(4).Text
        reservation = grd_autorization.Rows.Item(0).Cells(5).Text
        invoice = grd_autorization.Rows.Item(0).Cells(6).Text
        lbl_rrhh.Text = grd_autorization.Rows.Item(0).Cells(7).Text
        lbl_finance.Text = grd_autorization.Rows.Item(0).Cells(8).Text
        lbl_settings.Text = grd_autorization.Rows.Item(0).Cells(9).Text
        Apply_Restrictions()
    End Sub

    Private Sub Extract_name()
        lbl_employe.Text = grd_employe.Rows.Item(0).Cells(1).Text & " " & grd_employe.Rows.Item(0).Cells(3).Text
        Dim firstname As String = Mid(grd_employe.Rows.Item(0).Cells(1).Text, 1, 1)
        Dim lastname As String = Mid(grd_employe.Rows.Item(0).Cells(3).Text, 1, 1)

        lbl_user_info.Text = firstname + lastname
        lbl_employe_credentials.Text = lbl_employe.Text
    End Sub

    Private Sub Extract_Role()
        lbl_role.Text = grd_user.Rows.Item(0).Cells(3).Text
        Load_Autorization()
    End Sub

    Private Sub Load_Autorization()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Autorization where role='" & lbl_role.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_autorization.DataSource = reader
            grd_autorization.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Authorization"

            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        Extract_Autorization()
    End Sub

    Private Sub Load_Employe()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Employe where employe_id='" & lbl_employe_id.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_employe.DataSource = reader
            grd_employe.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Employe"

            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        Extract_name()
    End Sub

    Private Sub Load_User()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from e_User where employe_id='" & lbl_employe_id.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_user.DataSource = reader
            grd_user.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        Extract_Role()
    End Sub

    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub

    Private Sub Save_Error()
        Open_Connection()
        Connection.Open()
        Dim edate As Date = FormatDateTime(Today, DateFormat.ShortDate)
        Dim etime As Date = FormatDateTime(Now, DateFormat.LongTime)
        Dim page As String = "Authorization"
        Dim user As String = Session("Employe")
        Dim status As String = "Open"


        Try
            Command = New SqlCommand("Insert into Error_Message values('" & edate & "', '" & etime & "', '" & page & "', '" & user & "', '" & error_message & "', '" & status & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_error()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim expire_password As String = Session("Expired Password")
        If expire_password = "Yes" Then
            Exit Sub
        End If

        If IsPostBack Then
            Session.Add("Credentials", lbl_employe_credentials.Text)
            Session.Add("Employe ID", lbl_employe_id.Text)
            Session.Add("Employe", lbl_employe.Text)
            Session.Add("rrhh", lbl_rrhh.Text)
            Session.Add("finance", lbl_finance.Text)
            Session.Add("settings", lbl_settings.Text)
        Else
            lbl_employe_id.Text = Session("Employe ID")
            lbl_employe_credentials.Text = Session("Credentials")
            Load_Employe()
            Load_User()

        End If
    End Sub

    Private Sub ll_dashboard_Click(sender As Object, e As EventArgs) Handles ll_dashboard.Click
        Response.Redirect("~/Content/Dashboard/Dashboard.aspx")
    End Sub

    Private Sub ll_admin_Click(sender As Object, e As EventArgs) Handles ll_admin.Click
        Response.Redirect("~/Content/Administration/Administration.aspx")
    End Sub

    Private Sub ll_client_Click(sender As Object, e As EventArgs) Handles ll_client.Click
        Response.Redirect("~/Content/Client/Client.aspx")
    End Sub

    Private Sub ll_invoice_Click(sender As Object, e As EventArgs) Handles ll_invoice.Click
        Response.Redirect("~/Content/invoice/Invoice_Database.aspx")
    End Sub

    Private Sub ll_proforma_Click(sender As Object, e As EventArgs) Handles ll_proforma.Click
        Response.Redirect("~/Content/Proforma/Proforma_Database.aspx")
    End Sub

    Private Sub ll_account_Click(sender As Object, e As EventArgs) Handles ll_account.Click
        Response.Redirect("~/Content/My Account/Account/MyAccount.aspx")
    End Sub

    Private Sub ll_reservation_Click(sender As Object, e As EventArgs) Handles ll_reservation.Click
        Response.Redirect("~/Content/Reservation/Calendar.aspx")
    End Sub

    Private Sub ll_logout_Click(sender As Object, e As EventArgs) Handles ll_logout.Click
        Response.Redirect("https://www.google.com")
    End Sub

    Private Sub ll_reports_Click(sender As Object, e As EventArgs) Handles ll_reports.Click
        Response.Redirect("~/Content/Reports/Reports.aspx")
    End Sub
End Class