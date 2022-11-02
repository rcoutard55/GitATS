Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Authorization
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection


    Dim DSerror As New DataSet
    Dim DTerror As New DataTable
    Dim DSrole As New DataSet
    Dim DTrole As New DataTable
    Dim DSautorization As New DataSet
    Dim DTautorization As New DataTable

    Dim error_message As String

    Dim administration As String
    Dim client As String
    Dim proforma As String
    Dim reservation As String
    Dim invoice As String
    Dim rrhh As String
    Dim finance As String
    Dim settings As String


    Private Sub Clean()
        txt_role.Text = ""
        cbx_administration.Checked = False
        cbx_client.Checked = False
        cbx_invoice.Checked = False
        cbx_proforma.Checked = False
        cbx_reservation.Checked = False
        cbx_finances.Checked = False
        cbx_rrhh.Checked = False
        cbx_settings.Checked = False
    End Sub

    Private Sub Clear_Autorization()
        ''To clean the datasource and the datatable
        DSautorization.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Autorization ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSautorization, "Autorization")
    End Sub

    Private Sub Clear_error()
        DSerror.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Error_Message ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSerror, "Error_Message")
    End Sub

    Private Sub Clear_Role()
        ''To clean the datasource and the datatable
        DSrole.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Role ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSrole, "Role")
    End Sub

    Private Sub Delete_Autorization()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("Delete Autorisation  where role_id= '" & lbl_rolse_id.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Autorization()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Delete Authorization"

            Save_Error()
            unexpected_error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Filter_Authorization()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Autorization where role = '" & txt_role.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_authorization.DataSource = reader
            grd_authorization.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Filter Authorization"

            Save_Error()
            unexpected_error()

            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        publish_autorization

    End Sub

    Private Sub Format_Role()
        If Len(txt_role.Text) > 1 Then
            txt_role.Text = txt_role.Text.Substring(0, 1).ToUpper() + txt_role.Text.Substring(1)
        ElseIf Len(txt_role.Text) = 1 Then
            txt_role.Text = txt_role.Text.ToUpper()
        End If

        Save_Role

    End Sub

    Private Sub Load_Autorization()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Autorization", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_authorization.DataSource = reader
            grd_authorization.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
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
            error_message = ex.Message & " - " & "Load Role"

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

    Private Sub Publish_Autorization()
        If grd_authorization.Rows.Count <= 0 Then
            Exit Sub
        End If

        administration = grd_authorization.Rows.Item(0).Cells(2).Text
        client = grd_authorization.Rows.Item(0).Cells(3).Text
        proforma = grd_authorization.Rows.Item(0).Cells(4).Text
        reservation = grd_authorization.Rows.Item(0).Cells(5).Text
        invoice = grd_authorization.Rows.Item(0).Cells(6).Text
        rrhh = grd_authorization.Rows.Item(0).Cells(7).Text
        finance = grd_authorization.Rows.Item(0).Cells(8).Text
        settings = grd_authorization.Rows.Item(0).Cells(9).Text

        If administration = "Yes" Then
            cbx_administration.Checked = True
        Else
            cbx_administration.Checked = False
        End If

        If client = "Yes" Then
            cbx_client.Checked = True
        Else
            cbx_client.Checked = False
        End If

        If proforma = "Yes" Then
            cbx_proforma.Checked = True
        Else
            cbx_proforma.Checked = False
        End If

        If invoice = "Yes" Then
            cbx_invoice.Checked = True
        Else
            cbx_invoice.Checked = False
        End If

        If reservation = "Yes" Then
            cbx_reservation.Checked = True
        Else
            cbx_reservation.Checked = False
        End If

        If rrhh = "Yes" Then
            cbx_rrhh.Checked = True
        Else
            cbx_rrhh.Checked = False
        End If

        If finance = "Yes" Then
            cbx_finances.Checked = True
        Else
            cbx_finances.Checked = False
        End If

        If settings = "Yes" Then
            cbx_settings.Checked = True
        Else
            cbx_settings.Checked = False
        End If
    End Sub

    Private Sub Save_Autorization()

        Delete_Autorization()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("Insert into Autorization values('" & txt_role.Text & "', '" & administration & "', '" & client & "', '" & proforma & "', '" & reservation & "', '" & invoice & "', '" & rrhh & "', '" & finance & "', '" & settings & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Autorization()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Authorization"


            Save_Error()
            unexpected_error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        lbl_comment.Text = "Authorization updated in database"
        lbl_comment.BackColor = System.Drawing.Color.LightGreen
        lbl_comment.ForeColor = System.Drawing.Color.DarkGreen
        lbl_comment.Visible = True

        Clean()
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

    Private Sub Save_Role()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("Insert into Role values('" & txt_role.Text & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Role
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Role"


            Save_Error()
            unexpected_error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        lbl_comment.Text = "New Role Registered in database"
        lbl_comment.BackColor = System.Drawing.Color.LightGreen
        lbl_comment.ForeColor = System.Drawing.Color.DarkGreen
        lbl_comment.Visible = True


    End Sub

    Private Sub unexpected_error()
        lbl_comment.Text = "unexpected Error. Please try again later or contact your system administrator"
        lbl_comment.Visible = True
    End Sub

    Private Sub Update_Role()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("Update Role set role ='" & txt_role.Text & "' where role_id= '" & lbl_rolse_id.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Role()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Update Role"

            Save_Error()
            unexpected_error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        lbl_comment.Text = "Role updated in database"
        lbl_comment.BackColor = System.Drawing.Color.LightGreen
        lbl_comment.ForeColor = System.Drawing.Color.DarkGreen
        lbl_comment.Visible = True

    End Sub

    Private Sub validate_Autorization()

        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed


        If txt_role.Text = "" Then

            lbl_comment.Text = "Please Select a Role "

            Exit Sub
        End If

        If cbx_administration.Checked = True Then
            administration = "Yes"
        Else
            cbx_rrhh.Checked = False
            cbx_settings.Checked = False
            cbx_finances.Checked = False
            rrhh = "No"
            finance = "No"
            settings = "NO"


            administration = "No"
        End If

        If cbx_client.Checked = True Then
            client = "Yes"
        Else
            client = "No"
        End If

        If cbx_invoice.Checked = True Then
            invoice = "Yes"
        Else
            invoice = "No"
        End If

        If cbx_proforma.Checked = True Then
            proforma = "Yes"
        Else
            proforma = "No"
        End If

        If cbx_reservation.Checked = True Then
            reservation = "Yes"
        Else
            reservation = "No"
        End If

        If cbx_rrhh.Checked = True Then
            rrhh = "Yes"
        Else
            rrhh = "No"
        End If
    End Sub

    Private Sub Validate_Role()
        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed


        If txt_role.Text = "" Then

            lbl_comment.Text = "Please insert a Role name"

            Exit Sub
        End If
        Format_Role()

    End Sub





    Private Sub Authorization_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then

        Else
            lbl_place.Text = Session("Place")
            Load_Role()
        End If
    End Sub

    Private Sub ll_save_Click(sender As Object, e As EventArgs) Handles ll_save.Click
        lbl_comment.Visible = False
        Validate_Role()
    End Sub

    Protected Sub ll_edit_Click(sender As Object, e As EventArgs)
        Dim ll As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(ll.Parent.Parent, GridViewRow)
        Dim idx As Integer = row.RowIndex
        lbl_comment.Visible = False
        lbl_option.Text = "Edit"
        Clean()

        lbl_rolse_id.Text = grd_role.Rows.Item(idx).Cells(0).Text
        txt_role.Text = grd_role.Rows.Item(idx).Cells(1).Text

        Filter_Authorization()
    End Sub

    Private Sub ll_save_authorization_Click(sender As Object, e As EventArgs) Handles ll_save_authorization.Click
        lbl_comment.Visible = False
        validate_Autorization()
    End Sub

    Private Sub ll_close_Click(sender As Object, e As EventArgs) Handles ll_close.Click
        lbl_comment.Visible = False
        If lbl_place.Text = "User" Then
            Response.Redirect("~/Content/Administration/RRHH/User/User_add.aspx")
        ElseIf lbl_place.Text = "Settings" Then
            Response.Redirect("~/Content/Administration/Settings/Settings.aspx")
        End If
    End Sub

    Private Sub cbx_administration_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_administration.CheckedChanged
        lbl_comment.Text = ""
        If cbx_administration.Checked = False Then
            cbx_finances.Checked = False
            cbx_rrhh.Checked = False
            cbx_settings.Checked = False
        End If
    End Sub

    Private Sub cbx_finances_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_finances.CheckedChanged
        lbl_comment.Text = ""
        If cbx_finances.Checked = True Then
            cbx_administration.Checked = True
        End If
    End Sub

    Private Sub cbx_rrhh_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_rrhh.CheckedChanged
        lbl_comment.Text = ""
        If cbx_rrhh.Checked = True Then
            cbx_administration.Checked = True
        End If
    End Sub

    Private Sub cbx_settings_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_settings.CheckedChanged
        lbl_comment.Text = ""
        If cbx_settings.Checked = True Then
            cbx_administration.Checked = True
        End If
    End Sub
End Class