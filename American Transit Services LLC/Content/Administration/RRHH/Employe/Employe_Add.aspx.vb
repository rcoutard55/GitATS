Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class Employe_Add
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Dim DSemploye As New DataSet
    Dim DTemploye As New DataTable
    Dim DSemployement As New DataSet
    Dim DTemployement As New DataTable
    Dim DSemploye_comment As New DataSet
    Dim DTemploye_comment As New DataTable
    Dim DSerror As New DataSet
    Dim DTerror As New DataTable


    Dim error_message As String

    Private Sub Clean()
        txt_address1.Text = ""
        txt_address2.Text = ""
        txt_city.Text = ""
        txt_email.Text = ""
        txt_employementdate.Text = Today
        txt_firstname.Text = ""
        txt_lastname.Text = ""
        txt_middlename.Text = ""
        txt_position.Text = ""
        txt_salary.Text = ""
        txt_telephone.Text = ""
        txt_zipcode.Text = ""
        ddl_department.Text = "--Select--"
        ddl_state.Text = "--Select--"
        lbl_employe_id.Text = ""
        lbl_comment.Text = ""
    End Sub

    Private Sub Clear_Employe()
        ''To clean the datasource and the datatable
        DSemploye.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from employe ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSemploye, "employe")
    End Sub

    Private Sub Clear_Employement()
        ''To clean the datasource and the datatable
        DSemployement.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Employement ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSemployement, "Employement")
    End Sub

    Private Sub Clear_Employe_Comments()
        ''To clean the datasource and the datatable
        DSemploye_comment.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Employe_Comments ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSemploye_comment, "Employe_Comments")
    End Sub

    Private Sub Clear_error()
        DSerror.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Error_Message ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSerror, "Error_Message")
    End Sub

    Private Sub Format_Employe()
        If Len(txt_firstname.Text) > 1 Then
            txt_firstname.Text = txt_firstname.Text.Substring(0, 1).ToUpper() + txt_firstname.Text.Substring(1)
        ElseIf Len(txt_firstname.Text) = 1 Then
            txt_firstname.Text = txt_firstname.Text.ToUpper()
        End If

        If Len(txt_middlename.Text) > 1 Then
            txt_middlename.Text = txt_middlename.Text.Substring(0, 1).ToUpper() + txt_middlename.Text.Substring(1)
        ElseIf Len(txt_middlename.Text) = 1 Then
            txt_middlename.Text = txt_middlename.Text.ToUpper()
        End If

        If Len(txt_lastname.Text) > 1 Then
            txt_lastname.Text = txt_lastname.Text.Substring(0, 1).ToUpper() + txt_lastname.Text.Substring(1)
        ElseIf Len(txt_lastname.Text) = 1 Then
            txt_lastname.Text = txt_lastname.Text.ToUpper()
        End If

        If Len(txt_city.Text) > 1 Then
            txt_city.Text = txt_city.Text.Substring(0, 1).ToUpper() + txt_city.Text.Substring(1)
        ElseIf Len(txt_city.Text) = 1 Then
            txt_city.Text = txt_city.Text.ToUpper()
        End If

        If Len(txt_telephone.Text) = 10 Then
            Dim a As String = Microsoft.VisualBasic.Left(txt_telephone.Text, 3)
            Dim b As String = Mid(txt_telephone.Text, 4, 3)
            Dim c As String = Microsoft.VisualBasic.Right(txt_telephone.Text, 4)

            txt_telephone.Text = "(" + a + ") " + b + "-" + c
        End If

        Save_Employe()
    End Sub

    Private Sub Generate_EmployeID()
        ''To generate new Employe ID

        Dim Reader As SqlDataReader

        If Connection.State = ConnectionState.Closed Then
            Open_Connection()
            Connection.Open()
        End If
        Try

            Dim cmd As SqlCommand = New SqlCommand("select employe_id from employe where employe_id=(select max(employe_id) from employe) ", Connection)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If Reader.Read Then
                lbl_employe_id.Text = Reader("employe_id").ToString()
                New_Employe_ID()
                Exit Sub
            Else
                lbl_employe_id.Text = "ATS-001"
            End If
        Catch ex As Exception
            error_message = ex.Message & " - " & "Generate Employe ID"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Reader.Close()
        Connection.Close()

    End Sub

    Private Sub Load_Department()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Department", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_department.DataSource = reader
            grd_department.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Department"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        Publish_Department()
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
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Load_State()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from States", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_state.DataSource = reader
            grd_state.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load States"
            Unexpected_Error()
            Save_Error()
        End Try
        Connection.Close()
        Connection.Dispose()

        Publish_States()
    End Sub

    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub

    Private Sub New_Employe_ID()
        ''To increment the client ID by 1

        Dim I As Integer
        Dim a As String
        Dim b As String
        Dim c As Integer

        b = Right(lbl_employe_id.Text, 3)


        c = b + 1

        Me.lbl_employe_id.Text = c
        If Len(Me.lbl_employe_id.Text) = 1 Then
            Me.lbl_employe_id.Text = "ATS-00" & "" & c
        ElseIf Len(Me.lbl_employe_id.Text) = 2 Then
            Me.lbl_employe_id.Text = "ATS-0" & "" & c
        ElseIf Len(Me.lbl_employe_id.Text) = 3 Then
            Me.lbl_employe_id.Text = "ATS-" & "" & c


        End If
    End Sub

    Private Sub Publish_Department()
        Dim i As Integer
        Dim a As String

        ddl_department.Items.Add("--Select--")
        ddl_department.Items.Add("Add New")
        For i = 0 To grd_department.Rows.Count - 1
            a = grd_department.Rows.Item(i).Cells(1).Text

            ddl_department.Items.Add(a)
        Next
    End Sub

    Private Sub Publish_States()
        Dim i As Integer
        Dim a As String
        For i = 0 To grd_state.Rows.Count - 1
            a = grd_state.Rows.Item(i).Cells(2).Text

            ddl_state.Items.Add(Trim(a))
        Next

    End Sub

    Private Sub Save_Employe()
        Open_Connection()
        Connection.Open()
        Dim states As String
        Dim i As Integer = 0
        Dim a As String = ""
        Dim b As String = ""
        For i = 1 To Len(ddl_state.Text)
            a = Mid(ddl_state.Text, i, 1)
            If a = "vbCr" Then
                Exit For
            End If
            b = b + a
            If Len(b) = 2 Then
                Exit For
            End If
        Next
        states = Trim(b)
        Dim status As String = "Activate"

        Try
            Command = New SqlCommand("Insert into employe values('" & lbl_employe_id.Text & "', '" & txt_firstname.Text & "', '" & txt_middlename.Text & "', '" & txt_lastname.Text & "', '" & txt_address1.Text & "', '" & txt_address2.Text & "', '" & txt_city.Text & "', '" & states & "', '" & txt_zipcode.Text & "', '" & txt_telephone.Text & "', '" & txt_email.Text & "', '" & status & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Employe()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Employe"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        Save_Employement()
        Save_Employe_Comments()

        lbl_comment.Text = "New employe registered in database"
        lbl_comment.ForeColor = System.Drawing.Color.DarkGreen
        lbl_comment.BackColor = System.Drawing.Color.LightGreen
        lbl_comment.Visible = True


    End Sub

    Private Sub Save_Employement()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("Insert into Employement values('" & lbl_employe_id.Text & "', '" & txt_employementdate.Text & "', '" & ddl_department.Text & "', '" & txt_position.Text & "', '" & txt_salary.Text & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Employement()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Employement"
            Unexpected_Error()
            Save_Error()
            Connection.Close()

            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Save_Employe_Comments()
        Open_Connection()
        Connection.Open()
        Dim c_date As Date = FormatDateTime(Today, DateFormat.ShortDate)
        Dim comment As String = "New Employe Registered"
        Dim user As String = Session("Employe")

        Try
            Command = New SqlCommand("Insert into Employe_Comments values('" & lbl_employe_id.Text & "', '" & c_date & "', '" & comment & "', '" & user & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Employe_Comments()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Employe Comments"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()




    End Sub

    Private Sub Save_Error()
        Open_Connection()
        Connection.Open()
        Dim edate As Date = FormatDateTime(Today, DateFormat.ShortDate)
        Dim etime As Date = FormatDateTime(Now, DateFormat.LongTime)
        Dim page As String = "Add Employe"
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

    Private Sub validate_Employe()
        'Process to validate all textbox before saving
        lbl_comment.Text = ""


        If txt_firstname.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please insert employe's first name"

            Exit Sub
        End If

        If txt_middlename.Text = "" Then
            txt_middlename.Text = "-"
        End If

        If txt_lastname.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please insert employe's last name"

            Exit Sub
        End If

        If txt_address1.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please insert employe's house, condo, apartment name and number"

            Exit Sub
        End If

        If txt_address2.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please insert employe's street name"

            Exit Sub
        End If

        If txt_city.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please insert employe's city"

            Exit Sub
        End If

        If ddl_state.Text = "--Select--" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please select employe's state"

            Exit Sub
        End If

        If txt_zipcode.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please select employe's zip code"

            Exit Sub
        End If

        If txt_telephone.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please enter employe's telephone number"

            Exit Sub
        End If

        If Len(txt_telephone.Text) <> 10 Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Invalid telephone number. Please follow example: 0000000000"

            Exit Sub
        End If

        If txt_email.Text = "" Then
            txt_email.Text = "-"
        End If

        If txt_employementdate.Text > Today Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Invalid employement date. Please select employe employement date"

            Exit Sub
        End If

        If ddl_department.Text = "--Select--" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please select Employe's department affectation"

            Exit Sub
        End If

        If txt_position.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please insert employe's new position"

            Exit Sub
        End If

        If txt_salary.Text = "" Then
            txt_salary.Text = "0"
        End If

        Format_Employe
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
        Else
            Open_Connection()
            Load_Employe()
            Generate_EmployeID()
            Load_State()
            Load_Department()

        End If
    End Sub

    Private Sub ll_close_Click(sender As Object, e As EventArgs) Handles ll_close.Click
        Response.Redirect("~/Content/Administration/RRHH/Employe/Employe_Database.aspx")
    End Sub

    Private Sub ll_save_Click(sender As Object, e As EventArgs) Handles ll_save.Click
        lbl_comment.Visible = False
        validate_Employe()
    End Sub

    Private Sub ll_cancel_Click(sender As Object, e As EventArgs) Handles ll_cancel.Click
        lbl_comment.Visible = False
        Clean()
    End Sub

    Private Sub ll_cancel_department_Click(sender As Object, e As EventArgs) Handles ll_cancel_department.Click
        lbl_comment.Visible = False
        ddl_department.Visible = True
        txt_department.Visible = False
        ll_save_department.Visible = False
        ll_cancel_department.Visible = False
    End Sub
End Class