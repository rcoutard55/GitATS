Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Password
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Dim DSuser As New DataSet
    Dim DTuser As New DataTable
    Dim DSpassword As New DataSet
    Dim DTpassword As New DataTable


    Dim b As String = 0
    Dim pdate As Date
    Dim pyear As DateTime = Today.AddYears(-1)

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

    Private Sub Clear_Password()
        ''To clean the datasource and the datatable
        DSpassword.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from password_saver ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSpassword, "password_saver")
    End Sub

    Private Sub Invalid_password()

        lbl_comment.Text = "Invalid Password. Please try again"
        lbl_comment.Visible = True
    End Sub

    Private Sub Load_Password()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from e_User where employe_id='" & lbl_employe_ID.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_user.DataSource = reader
            grd_user.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Password"


            Save_Error()
            unexpected_error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()

        lbl_password.Text = grd_user.Rows.Item(0).Cells(2).Text
    End Sub

    Private Sub Load_Password_Saver()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from password_saver where employe_id='" & lbl_employe_ID.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_password_saver.DataSource = reader
            grd_password_saver.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Loaad Password Saver"


            Save_Error()
            unexpected_error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        scann_password_saver()
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
        Dim page As String = "Change Password"
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

    Private Sub save_Password()
        Open_Connection()
        Connection.Open()

        Dim expiration_date As Date = Today.AddMonths(3)

        Try
            Command = New SqlCommand("Update e_User set password = '" & txt_new_password.Text & "', password_expiration= '" & expiration_date & "' where employe_id='" & lbl_employe_ID.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_User()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Password"


            Save_Error()
            unexpected_error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        Save_Password_Saver()


        lbl_comment.ForeColor = System.Drawing.Color.DarkGreen
        lbl_comment.Text = "New password saved in Database"
        lbl_comment.BackColor = System.Drawing.Color.LightGreen
        lbl_comment.Visible = True
    End Sub

    Private Sub Save_Password_Saver()
        Open_Connection()
        Connection.Open()
        Dim status As String = "Activate"
        Dim date_changed As Date = Today
        Dim expiration_date As Date = Today.AddMonths(3)

        Try
            Command = New SqlCommand("Insert into password_saver values('" & lbl_employe_ID.Text & "', '" & txt_new_password.Text & "', '" & date_changed & "', '" & expiration_date & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_password
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Password Saver"


            Save_Error()
            unexpected_error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Scann_Password()
        Dim i As Integer
        Dim a As String



        For i = 1 To Len(txt_new_password.Text)
            a = Mid(txt_new_password.Text, i, 1)
            If a = "!" Or a = "@" Or a = "#" Or a = "$" Or a = "%" Or a = "^" Or a = "&" Or a = "*" Or a = "(" Or a = ")" Or a = "+" Or a = "=" Or a = "?" Or a = "1" Or a = "2" Or a = "3" Or a = "4" Or a = "5" Or a = "6" Or a = "7" Or a = "8" Or a = "9" Or a = "0" Then
                b = b + 1
            End If
        Next

    End Sub

    Private Sub scann_password_saver()
        If grd_password_saver.Rows.Count < 1 Then
            Exit Sub
        Else
            Dim a As String
            Dim i As Integer


            For i = 0 To grd_password_saver.Rows.Count - 1
                a = grd_password_saver.Rows.Item(i).Cells(2).Text
                If a = txt_new_password.Text Then
                    pdate = grd_password_saver.Rows.Item(i).Cells(3).Text
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub unexpected_error()
        lbl_comment.Text = "unexpected Error. Please try again later or contact your system administrator"
        lbl_comment.Visible = True
    End Sub

    Private Sub Validate_password()
        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed
        lbl_comment.BackColor = System.Drawing.Color.LightPink
        If txt_password.Text = "" Then

            txt_password.Text = "Please enter your current password"
            lbl_comment.Visible = True
            Exit Sub
        End If

        If txt_new_password.Text = "" Then

            txt_password.Text = "Please enter your New password"
            lbl_comment.Visible = True
            Exit Sub
        End If

        If txt_confirm_password.Text = "" Then

            txt_password.Text = "Please Confirm your New password"
            lbl_comment.Visible = True
            Exit Sub
        End If

        If txt_password.Text <> lbl_password.Text Then
            Invalid_password()
            txt_confirm_password.Text = ""
            txt_new_password.Text = ""
            txt_password.Text = ""
            Exit Sub
        ElseIf txt_password.Text = lbl_password.Text Then
            If txt_new_password.Text = txt_password.Text Then

                lbl_comment.Text = "Please choose a new password. This password is outdated"
                lbl_comment.Visible = True
                txt_new_password.Text = ""
                txt_confirm_password.Text = ""
                Exit Sub
            ElseIf txt_new_password.Text <> txt_password.Text Then
                If txt_new_password.Text <> txt_confirm_password.Text Then

                    lbl_comment.ForeColor = System.Drawing.Color.DarkRed
                    lbl_comment.Text = "The new password and it's confirmation are not the same. Please try again"
                    lbl_comment.Visible = True
                    txt_new_password.Text = ""
                    txt_confirm_password.Text = ""
                ElseIf txt_new_password.Text = txt_confirm_password.Text Then
                    If Len(txt_new_password.Text) < 8 Then

                        lbl_comment.ForeColor = System.Drawing.Color.DarkRed
                        lbl_comment.Text = "Please create a strong password with 8 characters minimum including special characters."
                        lbl_comment.Visible = True
                        txt_new_password.Text = ""
                        txt_confirm_password.Text = ""
                    ElseIf Len(txt_new_password.Text) >= 8 Then
                        Scann_Password()

                        If b <= 0 Then

                            lbl_comment.ForeColor = System.Drawing.Color.DarkRed
                            lbl_comment.Text = "Your password is not strong enough. please include characters and/or numbers"
                            lbl_comment.Visible = True
                            txt_new_password.Text = ""
                            txt_confirm_password.Text = ""
                            Exit Sub
                        ElseIf b > 0 Then
                            Load_Password_Saver()

                            If pdate >= pyear And pdate <= Today Then

                                lbl_comment.ForeColor = System.Drawing.Color.DarkRed
                                lbl_comment.Text = "This New password has been used in less than a year. Please change It"
                                lbl_comment.Visible = True
                                txt_new_password.Text = ""
                                txt_confirm_password.Text = ""
                                Exit Sub
                            Else
                                save_Password()
                            End If

                        End If
                    End If
                End If

            End If
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then

        Else

            lbl_employe_ID.Text = Session("Employe ID")

            Load_Password()
        End If
    End Sub

    Private Sub ll_close_Click(sender As Object, e As EventArgs) Handles ll_close.Click
        lbl_comment.Visible = False
        Response.Redirect("~/Content/My Account/Account/MyAccount.aspx")
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        lbl_comment.Visible = False
        Validate_password()

    End Sub


End Class