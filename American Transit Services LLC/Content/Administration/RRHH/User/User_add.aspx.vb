Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class User_add
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection


    Dim DSuser As New DataSet
    Dim DTuser As New DataTable
    Dim DSerror As New DataSet
    Dim DTerror As New DataTable
    Dim error_message As String


    Private Sub Clean()
        txt_first_name.Text = ""
        txt_lastname.Text = ""
        txt_password.Text = ""
        txt_username.Text = ""

    End Sub

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

    Private Sub Create_User()
        Dim a As String
        Dim username As String
        a = Microsoft.VisualBasic.Left(txt_first_name.Text, 1)

        username = LCase(a & "" & txt_lastname.Text)

        txt_username.Text = Trim(username)
        txt_password.Text = "ChangeIt"

    End Sub

    Private Sub Extract_data()
        Dim i As Integer
        Dim id As String
        Dim firstname As String
        Dim lastname As String
        Dim a As String

        For i = 1 To Len(ddl_employe.Text)
            a = Mid(ddl_employe.Text, i, 1)
            If a = "," Then
                Exit For
            End If
            id = id + a
        Next
        lbl_employe_ID.Text = Trim(id)
        a = ""
        For i = (i + 1) To Len(ddl_employe.Text)
            a = Mid(ddl_employe.Text, i, 1)
            If a = "," Then
                Exit For
            End If
            firstname = firstname + a
        Next
        txt_first_name.Text = Trim(firstname)
        a = ""
        For i = (i + 1) To Len(ddl_employe.Text)
            a = Mid(ddl_employe.Text, i, 1)
            If a = "," Then
                Exit For
            End If
            lastname = lastname + a
        Next
        txt_lastname.Text = Trim(lastname)
    End Sub

    Private Sub Load_Employe()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Employe", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_employe.DataSource = reader
            grd_employe.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()

        Publish_employe()
    End Sub

    Private Sub Load_Role()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Role", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_role.DataSource = reader
            grd_role.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()

        Publish_Role()
    End Sub

    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub

    Private Sub Publish_employe()
        Dim i As Integer
        Dim a As String
        Dim b As String
        Dim c As String

        For i = 0 To grd_employe.Rows.Count - 1
            a = grd_employe.Rows.Item(i).Cells(0).Text
            b = grd_employe.Rows.Item(i).Cells(1).Text
            c = grd_employe.Rows.Item(i).Cells(2).Text
            ddl_employe.Items.Add(a & ", " & b & ", " & c)
        Next

    End Sub

    Private Sub Save_Error()
        Open_Connection()
        Connection.Open()
        Dim edate As Date = FormatDateTime(Today, DateFormat.ShortDate)
        Dim etime As Date = FormatDateTime(Now, DateFormat.LongTime)
        Dim page As String = "Add User"
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

    Private Sub Save_User()
        Open_Connection()
        Connection.Open()
        Dim status As String = "Activate"
        Dim expiration_date As Date = Today.AddDays(1)

        Try
            Command = New SqlCommand("Insert into e_User values('" & lbl_employe_ID.Text & "', '" & txt_username.Text & "', '" & txt_password.Text & "', '" & ddl_role.Text & "', '" & ddl_status.Text & "', '" & expiration_date & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_User()
        Catch ex As Exception
            error_message = ex.Message
            lbl_comment.Text = "unexpected Error. Please try again later or contact your system administrator"
            lbl_comment.Visible = True
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()


        lbl_comment.Text = "New User Registered in database"
        lbl_comment.ForeColor = System.Drawing.Color.DarkGreen
        lbl_comment.BackColor = System.Drawing.Color.LightGreen

    End Sub

    Private Sub Publish_Role()

        Dim i As Integer
        Dim a As String
        ddl_role.Items.Add("--Select--")
        ddl_role.Items.Add("Add New")

        For i = 0 To grd_role.Rows.Count - 1
            a = grd_role.Rows.Item(i).Cells(0).Text
            ddl_role.Items.Add(a)
        Next
    End Sub

    Private Sub Validate_User()
        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed

        If txt_username.Text = "" Then
            lbl_comment.Text = "You need to create the username first. please select the employe and then create the username"
            lbl_comment.Visible = True
            Exit Sub

        End If

        If ddl_role.Text = "--Select--" Or ddl_role.Text = "Add New" Then
            lbl_comment.Text = "Please select a role for that employe or create a new one"
            lbl_comment.Visible = True
            Exit Sub
        End If

        If ddl_status.Text = "--Select--" Then
            lbl_comment.Text = "Please select a status for that employe "
            lbl_comment.Visible = True
            Exit Sub
        End If

        Save_User()
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
        Else
            Load_Employe()
            Load_Role()

        End If

    End Sub

    Private Sub ll_close_Click(sender As Object, e As EventArgs) Handles ll_close.Click
        Response.Redirect("~/Content/Administration/RRHH/User/User_Database.aspx")
    End Sub

    Private Sub ddl_employe_TextChanged(sender As Object, e As EventArgs) Handles ddl_employe.TextChanged
        Clean()
        Extract_data()
    End Sub

    Private Sub ddl_role_TextChanged(sender As Object, e As EventArgs) Handles ddl_role.TextChanged
        lbl_comment.Visible = False
        If ddl_role.Text = "Add New" Then
            Session.Add("Place", "User")
            Response.Redirect("~/Content/Administration/Settings/Authorization/Authorization.aspx")
        End If
    End Sub

    Private Sub btn_create_Click(sender As Object, e As EventArgs) Handles btn_create.Click
        lbl_comment.Visible = False
        Create_User()
    End Sub

    Private Sub ll_save_Click(sender As Object, e As EventArgs) Handles ll_save.Click
        lbl_comment.Visible = False
        Validate_User()
    End Sub

    Private Sub ll_cancel_Click(sender As Object, e As EventArgs) Handles ll_cancel.Click
        lbl_comment.Visible = False
        Clean()
    End Sub
End Class