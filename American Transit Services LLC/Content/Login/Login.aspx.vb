Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Login
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection


    Dim DSerror As New DataSet
    Dim DTerror As New DataTable
    Dim DSlog As New DataSet
    Dim DTlog As New DataTable

    Dim expiration As DateTime
    Dim error_message As String
    Private Sub Admin_contact()

        lbl_comment.ForeColor = System.Drawing.Color.DarkRed
        lbl_comment.Text = "Please contact your system Administrator"

    End Sub

    Private Sub check_expiration_date()
        Dim dtoday As DateTime = Today
        Dim a As TimeSpan
        Dim i As Integer = 0
        Dim b As String = ""
        Dim c As String = ""
        expiration = grd_user.Rows.Item(0).Cells(5).Text

        a = expiration - dtoday
        lbl_days.Text = (a).ToString
        For i = 1 To Len(lbl_days.Text)
            b = Mid(lbl_days.Text, i, 1)
            If b = "." Or b = ":" Then
                Exit For
            End If
            c = c + b
        Next

        lbl_days.Text = c




    End Sub

    Private Sub Clear_error()
        DSerror.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Error_Message ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSerror, "Error_Message")
    End Sub

    Private Sub Clear_Log()
        ''To clean the datasource and the datatable
        DSlog.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from log_history ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSlog, "log_history")
    End Sub

    Private Sub Invalid_Message()
        lbl_comment.Visible = True
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed
        lbl_comment.Text = "Invalid Username and/or password"

    End Sub

    Private Sub invalid_Password()
        lbl_comment.Visible = True
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed
        lbl_comment.Text = "Invalid password. Please try again"

    End Sub

    Private Sub Filter_User()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from e_User where username ='" & txt_username.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_user.DataSource = reader
            grd_user.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Filter User"


            Save_Error()
            unexpected_error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Load_Employe()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Employe", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_employe.DataSource = reader
            grd_employe.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Employe"


            Save_Error()
            unexpected_error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Load_User()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from e_User", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_user.DataSource = reader
            grd_user.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load User"


            Save_Error()
            unexpected_error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub

    Private Sub unexpected_error()
        lbl_comment.Text = "unexpected Error. Please try again later or contact your system administrator"
        lbl_comment.Visible = True
    End Sub

    Private Sub Save_Error()
        Open_Connection()
        Connection.Open()
        Dim edate As Date = FormatDateTime(Today, DateFormat.ShortDate)
        Dim etime As Date = FormatDateTime(Now, DateFormat.LongTime)
        Dim page As String = "LogIn"
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

    Private Sub Save_Log_history()
        Open_Connection()
        Connection.Open()
        Dim ldate As Date = FormatDateTime(Today, DateFormat.ShortDate)
        Dim ltime As Date = FormatDateTime(Now, DateFormat.LongTime)

        Try
            Command = New SqlCommand("Insert into log_history values('" & lbl_employe_id.Text & "', '" & ldate & "', '" & ltime & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Log()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Log"


            Save_Error()
            unexpected_error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Validate_Login()
        Filter_User()

        If grd_user.Rows.Count < 1 Then
            Invalid_Message()
            txt_username.Text = ""
            txt_password.Text = ""
            Exit Sub
        ElseIf grd_user.Rows.Count = 1 Then
            Dim username As String = grd_user.Rows.Item(0).Cells(1).Text
            If txt_username.Text <> username Then
                Invalid_Message()
                txt_username.Text = ""
                txt_password.Text = ""
                Exit Sub
            ElseIf txt_username.Text = username Then
                Dim password As String = grd_user.Rows.Item(0).Cells(2).Text
                If txt_password.Text <> password Then
                    invalid_Password()
                    txt_password.Text = ""
                    Exit Sub
                ElseIf txt_password.Text = password Then
                    Dim status As String = grd_user.Rows.Item(0).Cells(4).Text
                    If status = "Desactivate" Then
                        Admin_contact()
                        txt_password.Text = ""
                        txt_username.Text = ""
                        Exit Sub
                    ElseIf status <> "Desactivate" Then
                        lbl_employe_id.Text = grd_user.Rows.Item(0).Cells(0).Text
                        Save_Log_history()
                        Session.Add("Credentials", lbl_employe_id.Text)
                        Session.Add("Employe ID", lbl_employe_id.Text)
                        Session.Add("Password", txt_password.Text)
                        check_expiration_date()
                        If lbl_days.Text <= "0" Then
                            Session.Add("Expired Password", "Yes")
                            Response.Redirect("~/Content/Error Page/Error_Page.aspx")
                        Else
                            If txt_password.Text = "ChangeIt" Then
                                check_expiration_date()

                                Response.Redirect("~/Content/My Account/Account/Password.aspx")

                            Else
                                Response.Redirect("~/Content/Dashboard/Dashboard.aspx")
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Validate_User()
        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed

        If txt_username.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please enter your username"

            Exit Sub
        End If

        If txt_password.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please enter your password"

            Exit Sub
        End If
        Validate_Login()
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
        Else

        End If
    End Sub

    Private Sub btn_enter_Click(sender As Object, e As EventArgs) Handles btn_enter.Click
        lbl_comment.Visible = False
        Validate_User()
    End Sub


End Class