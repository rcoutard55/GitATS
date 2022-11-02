Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Department
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Dim DSdepartment As New DataSet
    Dim DTdepartment As New DataTable


    Private Sub Clear_department()
        ''To clean the datasource and the datatable
        DSdepartment.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Department ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSdepartment, "Department")
    End Sub

    Private Sub Delete_Department()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("Delete Department  where id='" & ll_department_id.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_department()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.Green

        lbl_comment.Text = "Department deleted from database"

    End Sub

    Private Sub Format_Department()
        If Len(txt_department.Text) > 1 Then
            txt_department.Text = txt_department.Text.Substring(0, 1).ToUpper() + txt_department.Text.Substring(1)
        ElseIf Len(txt_department.Text) = 1 Then
            txt_department.Text = txt_department.Text.ToUpper()
        End If


        If lbl_choice.Text = "modify" Then
            Update_Department()
        Else
            Save_Department()
        End If


    End Sub

    Private Sub Load_department()
        'To lod the Users list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Department", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_department.DataSource = reader
            grd_department.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub

    Private Sub Save_Department()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("Insert into Department values('" & txt_department.Text & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Department
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.Green

        lbl_comment.Text = "New Department registered in database"


    End Sub

    Private Sub Update_Department()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("UPDATE Department set department='" & txt_department.Text & "' where id='" & ll_department_id.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_department()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.Green

        lbl_comment.Text = "Department updated in database"
    End Sub

    Private Sub Validate_Department()
        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed

        If txt_department.Text = "" Then


            lbl_comment.Text = "Please enter AddressOf Department NameOf before saving"

            Exit Sub
        End If

        Dim i As Integer
        Dim a As String

        For i = 0 To grd_department.Rows.Count - 1
            a = grd_department.Rows.Item(i).Cells(1).Text

            If a = txt_department.Text Then

                lbl_comment.Text = "Department exist already in database"

                Exit Sub
            End If
        Next


        Format_Department()

    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then

        Else
            Load_department()
        End If
    End Sub

    Private Sub lbl_save_Click(sender As Object, e As EventArgs) Handles lbl_save.Click

        Validate_Department()
        Load_department()
    End Sub

    Protected Sub lbl_modify_Click(sender As Object, e As EventArgs)
        Dim ll As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(ll.Parent.Parent, GridViewRow)
        Dim idx As Integer = row.RowIndex

        lbl_choice.Text = "modify"


        ll_department_id.Text = grd_department.Rows.Item(idx).Cells(0).Text
        txt_department.Text = grd_department.Rows.Item(idx).Cells(1).Text


    End Sub

    Protected Sub ll_delete_Click(sender As Object, e As EventArgs)
        Dim ll As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(ll.Parent.Parent, GridViewRow)
        Dim idx As Integer = row.RowIndex

        lbl_choice.Text = "Delete"


        ll_department_id.Text = grd_department.Rows.Item(idx).Cells(0).Text


        lbl_comment.ForeColor = System.Drawing.Color.DarkRed
        lbl_comment.Text = "Are you sure you want to delete that department"

    End Sub


End Class