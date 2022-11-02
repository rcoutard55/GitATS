Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Employe_View
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
    Dim DSdepartment As New DataSet
    Dim DTdepartment As New DataTable
    Dim DSReport_Employe As New DataSet
    Dim DTReport_Employe As New DataTable
    Dim DSReport_Employe_Comment As New DataSet
    Dim DTReport_Employe_Comment As New DataTable
    Dim error_message As String


    Private Sub Clean_Employe()
        lbl_address1.Text = ""
        lbl_address2.Text = ""
        lbl_city.Text = ""
        lbl_email.Text = ""
        lbl_firstname.Text = ""
        lbl_lastname.Text = ""
        lbl_middlename.Text = ""
        lbl_state.Text = ""
        lbl_zipcode.Text = ""
        lbl_telephone.Text = ""
        lbl_status.Text = ""
        txt_address1.Text = ""
        txt_address2.Text = ""
        txt_city.Text = ""
        txt_email.Text = ""
        txt_firstname.Text = ""
        txt_lastname.Text = ""
        txt_middlename.Text = ""
        txt_telephone.Text = ""
        txt_zipcode.Text = ""
        ddl_state.Text = "--Select--"
        ddl_status.Text = "--Select--"
    End Sub

    Private Sub Clean_Employement()
        lbl_employement_date.Text = ""
        lbl_department.Text = ""
        lbl_position.Text = ""
        lbl_salary.Text = ""
        txt_employement_date.Text = Today
        ddl_department.Text = "--Select--"
        txt_position.Text = ""
        txt_salary.Text = ""
    End Sub

    Private Sub Clear_Department()
        ''To clean the datasource and the datatable
        DSdepartment.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Department ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSdepartment, "Department")
    End Sub

    Private Sub Clear_Employement()
        ''To clean the datasource and the datatable
        DSemployement.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Employement ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSemployement, "Employement")
    End Sub

    Private Sub Clear_Employe()
        ''To clean the datasource and the datatable
        DSemploye.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from employe ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSemploye, "employe")
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

    Private Sub Clear_Report_Employe()
        DSReport_Employe.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Report_Employe ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSReport_Employe, "Report_Employe")
    End Sub

    Private Sub Clear_Report_Employe_Comment()
        DSReport_Employe_Comment.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Report_Employe_Comment ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSReport_Employe_Comment, "Report_Employe_Comment")
    End Sub

    Private Sub Delete_Report_Employe()

        Open_Connection()
        Connection.Open()
        Try
            Command = New SqlCommand("DELETE from report_employe ", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Employe()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Delete Report Employe"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Delete_Report_Employe_Comment()
        Open_Connection()
        Connection.Open()
        Try
            Command = New SqlCommand("DELETE from report_employe_Comment ", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Employe()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Delete Report Employe Comment"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Format_Comment()
        If Len(txt_comments.Text) > 1 Then
            txt_comments.Text = txt_comments.Text.Substring(0, 1).ToUpper() + txt_comments.Text.Substring(1)
        ElseIf Len(txt_comments.Text) = 1 Then
            txt_comments.Text = txt_comments.Text.ToUpper()
        End If

        Save_Comment()
    End Sub

    Private Sub Format_Department()
        If Len(txt_department.Text) > 1 Then
            txt_department.Text = txt_department.Text.Substring(0, 1).ToUpper() + txt_department.Text.Substring(1)
        ElseIf Len(txt_department.Text) = 1 Then
            txt_department.Text = txt_department.Text.ToUpper()
        End If

        Save_Department
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

        Update_Employe()
    End Sub

    Private Sub Format_Employement()
        If Len(txt_position.Text) > 1 Then
            txt_position.Text = txt_position.Text.Substring(0, 1).ToUpper() + txt_position.Text.Substring(1)
        ElseIf Len(txt_position.Text) = 1 Then
            txt_position.Text = txt_position.Text.ToUpper()
        End If

        txt_salary.Text = FormatNumber(txt_salary.Text, 2)

        Update_Employement
    End Sub

    Private Sub Hide_Emloye_Label()
        lbl_address1.Visible = False
        lbl_address2.Visible = False
        lbl_city.Visible = False
        lbl_email.Visible = False
        lbl_firstname.Visible = False
        lbl_lastname.Visible = False
        lbl_middlename.Visible = False
        lbl_state.Visible = False
        lbl_zipcode.Visible = False
        lbl_telephone.Visible = False
        lbl_status.Visible = False
    End Sub

    Private Sub Hide_Employe_Textbox()
        txt_address1.Visible = False
        txt_address2.Visible = False
        txt_city.Visible = False
        txt_email.Visible = False
        txt_firstname.Visible = False
        txt_lastname.Visible = False
        txt_middlename.Visible = False
        txt_telephone.Visible = False
        txt_zipcode.Visible = False
        ddl_state.Visible = False
        ddl_status.Visible = False
    End Sub

    Private Sub Hide_Employement_Label()
        lbl_employement_date.Visible = False
        lbl_department.Visible = False
        lbl_position.Visible = False
        lbl_salary.Visible = False
    End Sub

    Private Sub Hide_Employement_Textbox()
        txt_employement_date.Visible = False
        ddl_department.Visible = False
        txt_position.Visible = False
        txt_salary.Visible = False
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
        Publish_Department
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
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        Publish_Employe
    End Sub

    Private Sub Load_Employement()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Employement where employe_id='" & lbl_employe_id.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_employement.DataSource = reader
            grd_employement.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Employement"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        Publish_Employement()
    End Sub

    Private Sub Load_Employe_Comment()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Employe_Comments where employe_id='" & lbl_employe_id.Text & "' ORDER BY [date] DESC", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_employe_comment.DataSource = reader
            grd_employe_comment.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Employe_Comments"
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
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        Publish_State
    End Sub

    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub

    Private Sub Pass_Employe_Data_To_Textbox()
        txt_firstname.Text = lbl_firstname.Text
        txt_middlename.Text = lbl_middlename.Text
        txt_lastname.Text = lbl_lastname.Text
        txt_address1.Text = lbl_address1.Text
        txt_address2.Text = lbl_address2.Text
        txt_city.Text = lbl_city.Text
        ddl_state.Text = "--Select--"
        txt_zipcode.Text = lbl_zipcode.Text
        txt_telephone.Text = lbl_telephone.Text
        txt_email.Text = lbl_email.Text
        ddl_status.Text = lbl_status.Text

    End Sub

    Private Sub Pass_Employement_Data_to_Textbox()
        txt_employement_date.Text = Today
        ddl_department.Text = "--Select--"
        txt_position.Text = lbl_position.Text
        txt_salary.Text = lbl_salary.Text
    End Sub

    Private Sub Publish_Department()
        ddl_department.Items.Clear()
        Dim i As Integer
        Dim a As String

        ddl_department.Items.Add("--Select--")
        ddl_department.Items.Add("Add New")
        For i = 0 To grd_department.Rows.Count - 1
            a = grd_department.Rows.Item(i).Cells(1).Text

            ddl_department.Items.Add(Trim(a))
        Next
    End Sub

    Private Sub Publish_Employe()
        lbl_employe_id2.Text = grd_employe.Rows.Item(0).Cells(0).Text
        lbl_firstname.Text = grd_employe.Rows.Item(0).Cells(1).Text
        lbl_middlename.Text = grd_employe.Rows.Item(0).Cells(2).Text
        lbl_lastname.Text = grd_employe.Rows.Item(0).Cells(3).Text
        lbl_address1.Text = grd_employe.Rows.Item(0).Cells(4).Text
        lbl_address2.Text = grd_employe.Rows.Item(0).Cells(5).Text
        lbl_city.Text = grd_employe.Rows.Item(0).Cells(6).Text
        lbl_state.Text = grd_employe.Rows.Item(0).Cells(7).Text
        lbl_zipcode.Text = grd_employe.Rows.Item(0).Cells(8).Text
        lbl_telephone.Text = grd_employe.Rows.Item(0).Cells(9).Text
        lbl_email.Text = grd_employe.Rows.Item(0).Cells(10).Text
        lbl_status.Text = grd_employe.Rows.Item(0).Cells(11).Text
    End Sub

    Private Sub Publish_Employement()
        lbl_employement_date.Text = FormatDateTime(grd_employement.Rows.Item(0).Cells(1).Text, DateFormat.ShortDate)
        lbl_department.Text = grd_employement.Rows.Item(0).Cells(2).Text
        lbl_position.Text = grd_employement.Rows.Item(0).Cells(3).Text
        lbl_salary.Text = grd_employement.Rows.Item(0).Cells(4).Text
    End Sub

    Private Sub Publish_State()
        Dim i As Integer
        Dim a As String
        For i = 0 To grd_state.Rows.Count - 1
            a = grd_state.Rows.Item(i).Cells(2).Text

            ddl_state.Items.Add(Trim(a))
        Next
    End Sub

    Private Sub Save_Comment()
        Open_Connection()
        Connection.Open()
        Dim c_date As Date = FormatDateTime(Today, DateFormat.ShortDate)
        Dim comment As String = txt_comments.Text
        Dim user As String = Session("Credentials")

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

    Private Sub Save_Department()
        Open_Connection()
        Connection.Open()

        Try
            Command = New SqlCommand("Insert into Department values('" & txt_department.Text & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Department
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Department"
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
        Dim page As String = "View Employe"
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

    Private Sub Save_Employe_Comments()
        Open_Connection()
        Connection.Open()
        Dim c_date As Date = FormatDateTime(Today, DateFormat.ShortDate)
        Dim comment As String = "Employe Information Modification" & " (" & lbl_firstname.Text + ", " + lbl_middlename.Text + ", " + lbl_lastname.Text + ", " + lbl_address1.Text + ", " + lbl_address2.Text + ", " + lbl_city.Text + ", " + lbl_state.Text + ", " + lbl_zipcode.Text + ", " + lbl_telephone.Text + ", " + lbl_email.Text & ")" _
            & " => (" & txt_firstname.Text + ", " + txt_lastname.Text + ", " + txt_address1.Text + ", " + txt_address2.Text + ", " + txt_city.Text + ", " + ddl_state.Text + ", " + txt_zipcode.Text + ", " + txt_telephone.Text + ", " + txt_email.Text + ", " + ddl_status.Text & ")"
        Dim user As String = Session("Credentials")

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

    Private Sub Save_Employement_Comment()
        Open_Connection()
        Connection.Open()
        Dim c_date As Date = FormatDateTime(Today, DateFormat.ShortDate)
        Dim comment As String = "Employement Information Modification" & " (" & lbl_employement_date.Text + ", " + lbl_department.Text + ", " + lbl_position.Text + ", " + lbl_salary.Text + ")" _
            & " => (" & txt_employement_date.Text + ", " + ddl_department.Text + ", " + txt_position.Text + ", " + txt_salary.Text & ")"
        Dim user As String = Session("Credentials")

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

    Private Sub Save_Report_Employe()
        Dim employe_id As String = lbl_employe_id.Text
        Dim firstname As String = lbl_firstname.Text
        Dim middlename As String = lbl_middlename.Text
        Dim lastname As String = lbl_lastname.Text
        Dim address1 As String = lbl_address1.Text
        Dim address2 As String = lbl_address2.Text
        Dim city As String = lbl_city.Text
        Dim state As String = lbl_state.Text
        Dim zipcode As String = lbl_zipcode.Text
        Dim telephone As String = lbl_telephone.Text
        Dim employementdate As String = lbl_employement_date.Text
        Dim department As String = lbl_department.Text
        Dim position As String = lbl_position.Text
        Dim salary As String = lbl_salary.Text
        Dim status As String = lbl_status.Text
        Dim Email As String = lbl_email.Text



        Open_Connection()
        Connection.Open()
        Try
            Command = New SqlCommand("Insert into Report_Employe values('" & employe_id & "', '" & firstname & "', '" & middlename & "', '" & lastname & "', '" & address1 & "', '" & address2 & "', '" & city & "', '" & state & "', '" & zipcode & "', '" & telephone & "', '" & Email & "', '" & status & "',  '" & employementdate & "', '" & department & "', '" & position & "', '" & salary & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Report_Employe()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Report Employe "
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        Save_Report_Employe_Comment()

        Session.Add("Employe ID", lbl_employe_id2.Text)
        Response.Redirect("~/Content/Administration/RRHH/Employe/Employe_Download.aspx")

    End Sub

    Private Sub Save_Report_Employe_Comment()
        Load_Employe_Comment()
        Dim employe_id As String = lbl_employe_id.Text
        Dim rdate As String
        Dim comment As String
        Dim e_user As String
        For i = 0 To grd_employe_comment.Rows.Count - 2
            rdate = grd_employe_comment.Rows.Item(i).Cells(0).Text
            comment = grd_employe_comment.Rows.Item(i).Cells(1).Text
            e_user = grd_employe_comment.Rows.Item(i).Cells(2).Text

            Open_Connection()
            Connection.Open()
            Try
                Command = New SqlCommand("Insert into Report_Employe_Comment values('" & employe_id & "', '" & rdate & "', '" & comment & "', '" & e_user & "')", Connection)
                Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
                Clear_Report_Employe_Comment()
            Catch ex As Exception
                error_message = ex.Message & " - " & "Save Report Employe Comment"
                Unexpected_Error()
                Save_Error()
                Connection.Close()
                Exit Sub
            End Try
            Connection.Close()
            Connection.Dispose()
        Next
    End Sub

    Private Sub Show_Employe_Label()
        lbl_address1.Visible = True
        lbl_address2.Visible = True
        lbl_city.Visible = True
        lbl_email.Visible = True
        lbl_firstname.Visible = True
        lbl_lastname.Visible = True
        lbl_middlename.Visible = True
        lbl_state.Visible = True
        lbl_zipcode.Visible = True
        lbl_telephone.Visible = True
        lbl_status.Visible = True
    End Sub

    Private Sub Show_Employe_Textbox()
        txt_address1.Visible = True
        txt_address2.Visible = True
        txt_city.Visible = True
        txt_email.Visible = True
        txt_firstname.Visible = True
        txt_lastname.Visible = True
        txt_middlename.Visible = True
        txt_telephone.Visible = True
        txt_zipcode.Visible = True
        ddl_state.Visible = True
        ddl_status.Visible = True
    End Sub

    Private Sub Show_Employement_Label()
        lbl_employement_date.Visible = True
        lbl_department.Visible = True
        lbl_position.Visible = True
        lbl_salary.Visible = True
    End Sub

    Private Sub Show_Employement_Textbox()
        txt_employement_date.Visible = True
        ddl_department.Visible = True
        txt_position.Visible = True
        txt_salary.Visible = True
    End Sub

    Private Sub Unexpected_Error()
        lbl_comment.Visible = True
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed
        lbl_comment.BackColor = System.Drawing.Color.LightPink
        lbl_comment.Text = "Unexpected error. Please try again later or contact your system administrator"
    End Sub

    Private Sub Update_Employe()

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

        Open_Connection()
        Connection.Open()
        Try
            Command = New SqlCommand("UPDATE employe set first_name= '" & txt_firstname.Text & "', middle_name= '" & txt_middlename.Text & "', last_name= '" & txt_lastname.Text & "', address1= '" & txt_address1.Text & "', address2= '" & txt_address2.Text & "', city= '" & txt_city.Text & "', state = '" & states & "', zip_code = '" & txt_zipcode.Text & "', telephone = '" & txt_telephone.Text & "', email= '" & txt_email.Text & "', status= '" & ddl_status.Text & "' where employe_id='" & lbl_employe_id.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Employe()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Update Employe"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        Save_Employe_Comments()

        lbl_comment.Text = "Employe information modified in database"
        lbl_comment.ForeColor = System.Drawing.Color.DarkGreen
        lbl_comment.BackColor = System.Drawing.Color.LightGreen
        lbl_comment.Visible = True



    End Sub

    Private Sub Update_Employement()
        Open_Connection()
        Connection.Open()
        Try
            Command = New SqlCommand("UPDATE employement set employement_date= '" & txt_employement_date.Text & "', department= '" & ddl_department.Text & "', position= '" & txt_position.Text & "', salary= '" & txt_salary.Text & "' where employe_id='" & lbl_employe_id.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Employement
        Catch ex As Exception
            error_message = ex.Message & " - " & "Update Employement"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        Save_Employement_Comment()
        row_comment.Visible = True
        lbl_comment.Text = "Employement information modified in database"
        lbl_comment.ForeColor = System.Drawing.Color.DarkGreen
        lbl_comment.BackColor = System.Drawing.Color.LightGreen
        lbl_comment.Visible = True
    End Sub

    Private Sub Validate_Comment()
        lbl_comment.Text = ""

        If txt_comments.Text = "" Then
            lbl_comment.Text = "Please insert a comment"
            Exit Sub
        End If
        Format_Comment()
    End Sub

    Private Sub Validate_Department()
        lbl_comment.Text = ""

        If txt_department.Text = "" Then
            lbl_comment.Text = "Please insert new Department"
            lbl_comment.Visible = True
            Exit Sub
        End If

        Dim i As Integer
        Dim a As String
        For i = 0 To grd_department.Rows.Count - 1
            a = grd_department.Rows.Item(i).Cells(1).Text
            If a = txt_department.Text Then
                lbl_comment.Text = "Department already registered in Database"
                lbl_comment.Visible = True
            End If
        Next

        Format_Department()
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

        Format_Employe()
    End Sub

    Private Sub Validate_Employement()
        lbl_comment.Text = ""

        If txt_employement_date.Text > Today.AddDays(1) Then
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

        Format_Employement

    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
        Else
            lbl_employe_id.Text = Session("Employe ID")
            Load_Employe()
            Load_Employement()
            Load_Employe_Comment()
            Load_State()
            Load_Department()
        End If
    End Sub

    Private Sub ll_close_Click(sender As Object, e As EventArgs) Handles ll_close.Click
        Response.Redirect("~/Content/Administration/RRHH/Employe/Employe_Database.aspx")
    End Sub

    Private Sub ll_modify_employe_Click(sender As Object, e As EventArgs) Handles ll_modify_employe.Click
        lbl_comment.Visible = False
        ll_modify_employe.Visible = False
        ll_save_employe.Visible = True
        ll_cancel_employe.Visible = True
        Pass_Employe_Data_To_Textbox()
        Hide_Emloye_Label()
        Show_Employe_Textbox()
    End Sub

    Private Sub ll_save_employe_Click(sender As Object, e As EventArgs) Handles ll_save_employe.Click
        lbl_comment.Visible = False
        validate_Employe()
        ll_save_employe.Visible = False
        ll_cancel_employe.Visible = False
        ll_modify_employe.Visible = True
        Clean_Employe()
        Hide_Employe_Textbox()
        Show_Employe_Label()
        Load_Employe()
        Load_Employe_Comment()
    End Sub

    Private Sub ll_cancel_employe_Click(sender As Object, e As EventArgs) Handles ll_cancel_employe.Click
        lbl_comment.Visible = False
        ll_save_employe.Visible = False
        ll_cancel_employe.Visible = False
        ll_modify_employe.Visible = True
        Clean_Employe()
        Hide_Employe_Textbox()
        Show_Employe_Label()
        Load_Employe()
        Load_Employe_Comment()
    End Sub

    Private Sub ll_modify_employement_Click(sender As Object, e As EventArgs) Handles ll_modify_employement.Click
        lbl_comment.Visible = False
        ll_modify_employement.Visible = False
        ll_save_employement.Visible = True
        ll_cancel_employement.Visible = True
        Pass_Employement_Data_to_Textbox()
        Hide_Employement_Label()
        Show_Employement_Textbox()


    End Sub

    Private Sub ddl_department_TextChanged(sender As Object, e As EventArgs) Handles ddl_department.TextChanged
        If ddl_department.Text = "Add New" Then
            ddl_department.Visible = False
            ll_save_department.Visible = True
            txt_department.Visible = True
            ll_cancel_department.Visible = True
        End If
    End Sub

    Private Sub ll_cancel_department_Click(sender As Object, e As EventArgs) Handles ll_cancel_department.Click
        lbl_comment.Visible = False
        lbl_comment.Text = ""
        ll_cancel_department.Visible = False
        ll_save_department.Visible = False

        txt_department.Visible = False
        ddl_department.Visible = True
        Load_Department()
    End Sub

    Private Sub ll_save_employement_Click(sender As Object, e As EventArgs) Handles ll_save_employement.Click
        lbl_comment.Text = ""
        Validate_Employement()
        ll_modify_employement.Visible = True
        ll_save_employement.Visible = False
        ll_cancel_employement.Visible = False
        Clean_Employement()
        Hide_Employement_Textbox()
        Show_Employement_Label()
        Load_Employement()
        Load_Employe_Comment()


    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        lbl_comment.Text = ""
        lbl_comment.Visible = False
        Validate_Comment()
        Load_Employe_Comment()
        row_comment.Visible = False
    End Sub

    Private Sub ll_save_department_Click(sender As Object, e As EventArgs) Handles ll_save_department.Click
        lbl_comment.Text = ""
        lbl_comment.Visible = False
        Validate_Department()
        txt_department.Visible = False
        ddl_department.Visible = True
        Load_Department()
        ll_cancel_department.Visible = False
    End Sub

    Private Sub ll_download_Click(sender As Object, e As EventArgs) Handles ll_download.Click
        Delete_Report_Employe()
        Delete_Report_Employe_Comment()
        Save_Report_Employe()
    End Sub
End Class