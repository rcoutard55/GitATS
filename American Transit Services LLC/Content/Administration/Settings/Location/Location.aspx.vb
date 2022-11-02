Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Location
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Dim DSlocation As New DataSet
    Dim DTlocation As New DataTable


    Private Sub Clear_location()
        ''To clean the datasource and the datatable
        DSlocation.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Location ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSlocation, "Location")
    End Sub

    Private Sub Delete_Location()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("Delete Location  where id='" & lbl_location_id.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_location()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.Green
        row_comment.Visible = True
        ll_ok1.Visible = True
        lbl_comment.Text = "Home Point deleted from database"

    End Sub

    Private Sub Format_Location()
        If Len(txt_location.Text) > 1 Then
            txt_location.Text = txt_location.Text.Substring(0, 1).ToUpper() + txt_location.Text.Substring(1)
        ElseIf Len(txt_location.Text) = 1 Then
            txt_location.Text = txt_location.Text.ToUpper()
        End If


        If lbl_choice.Text = "modify" Then
            Update_Location
        Else
            Save_Location
        End If


    End Sub

    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub

    Private Sub Load_Location()
        'To lod the Users list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Location", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_location.DataSource = reader
            grd_location.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Save_Location()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("Insert into Location values('" & txt_location.Text & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_location()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.Green
        row_comment.Visible = True
        ll_ok1.Visible = True
        ll_ok2.Visible = False
        lbl_comment.Text = "New Home Point registered in database"


    End Sub

    Private Sub Update_Location()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("UPDATE Location set location='" & txt_location.Text & "' where id='" & lbl_location_id.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_location()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.Green
        row_comment.Visible = True
        ll_ok1.Visible = True
        lbl_comment.Text = "Home Point updated in database"
    End Sub

    Private Sub Validate_Location()
        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed

        If txt_location.Text = "" Then

            row_comment.Visible = True
            ll_ok2.Visible = True
            lbl_comment.Text = "Please enter Home Point before saving"
            ll_ok2.Focus()
            Exit Sub
        End If

        Dim i As Integer
        Dim a As String

        For i = 0 To grd_location.Rows.Count - 1
            a = grd_location.Rows.Item(i).Cells(1).Text

            If a = txt_location.Text Then
                row_comment.Visible = True
                ll_ok2.Visible = True
                lbl_comment.Text = "Home Point exist already in database"
                ll_ok2.Focus()
                Exit Sub
            End If
        Next


        Format_Location()

    End Sub




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then

        Else
            Load_Location()
        End If
    End Sub

    Protected Sub ll_modify_Click(sender As Object, e As EventArgs)
        Dim ll As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(ll.Parent.Parent, GridViewRow)
        Dim idx As Integer = row.RowIndex

        lbl_choice.Text = "modify"


        lbl_location_id.Text = grd_location.Rows.Item(idx).Cells(0).Text
        txt_location.Text = grd_location.Rows.Item(idx).Cells(1).Text
    End Sub

    Protected Sub ll_delete_Click(sender As Object, e As EventArgs)
        Dim ll As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(ll.Parent.Parent, GridViewRow)
        Dim idx As Integer = row.RowIndex

        lbl_choice.Text = "Delete"


        lbl_location_id.Text = grd_location.Rows.Item(idx).Cells(0).Text

        row_comment.Visible = True
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed
        lbl_comment.Text = "Are you sure you want to delete that Home Point"
        ll_ok1.Visible = True
        ll_ok2.Visible = True
    End Sub

    Private Sub ll_ok1_Click(sender As Object, e As EventArgs) Handles ll_ok1.Click
        If lbl_choice.Text = "Delete" Then
            Delete_Location()
            Load_Location()
        End If
        lbl_comment.Text = ""
        row_comment.Visible = False
        ll_ok1.Visible = False
        ll_ok2.Visible = False
    End Sub

    Private Sub ll_ok2_Click(sender As Object, e As EventArgs) Handles ll_ok2.Click
        lbl_comment.Text = ""
        row_comment.Visible = False
        ll_ok1.Visible = False
        ll_ok2.Visible = False
    End Sub

    Private Sub lbl_save_Click(sender As Object, e As EventArgs) Handles lbl_save.Click
        Validate_Location()
        Load_Location()
    End Sub
End Class