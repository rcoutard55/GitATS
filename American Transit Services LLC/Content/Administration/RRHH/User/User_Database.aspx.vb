Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class User_Database
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Dim DSuser As New DataSet
    Dim DTuser As New DataTable
    Dim DSpassword As New DataSet
    Dim DTpassword As New DataTable
    Dim DSerror As New DataSet
    Dim DTerror As New DataTable
    Dim error_message As String

    Private Sub Clear_error()
        DSerror.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Error_Message ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSerror, "Error_Message")
    End Sub

    Private Sub Clear_User()
        ''To clean the datasource and the datatable
        DSuser.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from e_User ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSuser, "e_User")
    End Sub

    Private Sub Filter_User()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT employe_id, username, role, status from e_User where employe_id like '%" & txt_search.Text & "%' or username like '%" & txt_search.Text & "%'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_user.DataSource = reader
            grd_user.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Filter User"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Load_User()
        'To lod the Users list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT employe_id, username, role, status from e_User", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_user.DataSource = reader
            grd_user.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load User"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
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
        Dim page As String = "User Database"
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

    Private Sub Unexpected_Error()
        lbl_comment.Visible = True
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed
        lbl_comment.BackColor = System.Drawing.Color.LightPink
        lbl_comment.Text = "Unexpected error. Please try again later or contact your system administrator"
    End Sub

    Private Sub Update_Password()
        Open_Connection()
        Connection.Open()

        Dim password As String = "ChangeIt"
        Dim expiration_date As Date = Today.AddDays(7)

        Try
            Command = New SqlCommand("Update e_User set password = '" & password & "', password_expiration= '" & expiration_date & "' where employe_id='" & lbl_employe_ID.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_User()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Update Password"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()


        lbl_comment.Text = "Password have been reset for this user. Default password is 'ChangeIt' "


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Filter_User()
        Else
            Load_User()

        End If
    End Sub

    Private Sub ll_add_new_Click(sender As Object, e As EventArgs) Handles ll_add_new.Click
        Response.Redirect("~/Content/Administration/RRHH/User/User_add.aspx")
    End Sub

    Protected Sub ll_reset_Click(sender As Object, e As EventArgs)
        Dim ll As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(ll.Parent.Parent, GridViewRow)
        Dim idx As Integer = row.RowIndex




        lbl_employe_ID.Text = grd_user.Rows.Item(idx).Cells(0).Text
        Update_Password()

    End Sub



End Class