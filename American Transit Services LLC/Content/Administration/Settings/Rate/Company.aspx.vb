Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class rate
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Dim DScompany As New DataSet
    Dim DTcompany As New DataTable


    Private Sub Clear_company()
        ''To clean the datasource and the datatable
        DScompany.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Company ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DScompany, "Company")
    End Sub

    Private Sub Delete_Company()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("Delete Company  where company_id='" & lbl_company_id.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_company()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.Green

        lbl_comment.Text = "Company deleted from database"

    End Sub

    Private Sub Format_Company()
        If Len(txt_company.Text) > 1 Then
            txt_company.Text = txt_company.Text.Substring(0, 1).ToUpper() + txt_company.Text.Substring(1)
        ElseIf Len(txt_company.Text) = 1 Then
            txt_company.Text = txt_company.Text.ToUpper()
        End If


        If lbl_choice.Text = "modify" Then
            Update_Company
        Else
            Save_Company
        End If


    End Sub

    Private Sub Load_Company()
        'To lod the Users list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Company", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_company.DataSource = reader
            grd_company.DataBind()
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

    Private Sub Save_Company()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("Insert into Company values('" & txt_company.Text & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_company()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.Green

        lbl_comment.Text = "New Company registered in database"


    End Sub

    Private Sub Update_Company()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("UPDATE Company set company='" & txt_company.Text & "' where id='" & lbl_company_id.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_company()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.Green

        lbl_comment.Text = "Company updated in database"
    End Sub

    Private Sub Validate_Company()
        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed

        If txt_company.Text = "" Then


            lbl_comment.Text = "Please enter the name of a company before saving"

            Exit Sub
        End If

        Dim i As Integer
        Dim a As String

        For i = 0 To grd_company.Rows.Count - 1
            a = grd_company.Rows.Item(i).Cells(1).Text

            If a = txt_company.Text Then

                lbl_comment.Text = "Company exist already in database"

                Exit Sub
            End If
        Next


        Format_Company()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then

        Else
            Load_Company()
        End If
    End Sub

    Private Sub lbl_save_Click(sender As Object, e As EventArgs) Handles lbl_save.Click
        Validate_Company()
        Load_Company()
    End Sub

    Protected Sub lbl_modify_Click(sender As Object, e As EventArgs)
        Dim ll As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(ll.Parent.Parent, GridViewRow)
        Dim idx As Integer = row.RowIndex

        lbl_choice.Text = "modify"


        lbl_company_id.Text = grd_company.Rows.Item(idx).Cells(0).Text
        txt_company.Text = grd_company.Rows.Item(idx).Cells(1).Text
    End Sub

    Protected Sub ll_delete_Click(sender As Object, e As EventArgs)
        Dim ll As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(ll.Parent.Parent, GridViewRow)
        Dim idx As Integer = row.RowIndex

        lbl_choice.Text = "Delete"


        lbl_company_id.Text = grd_company.Rows.Item(idx).Cells(0).Text


        lbl_comment.Text = "Are you sure you want to delete that Company"

    End Sub





    Protected Sub ll_view_Click(sender As Object, e As EventArgs)
        Dim ll As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(ll.Parent.Parent, GridViewRow)
        Dim idx As Integer = row.RowIndex

        lbl_company_id.Text = grd_company.Rows.Item(idx).Cells(0).Text
        Dim company As String = grd_company.Rows.Item(idx).Cells(1).Text

        Session.Add("Company ID", lbl_company_id.Text)
        Session.Add("Company", company)
        Response.Redirect("~/Content/Administration/Settings/Rate/Rate.aspx")

    End Sub
End Class