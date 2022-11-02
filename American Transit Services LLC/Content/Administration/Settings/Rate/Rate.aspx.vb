Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Rate1
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Dim DScompany As New DataSet
    Dim DTcompany As New DataTable
    Dim DSSubcompany As New DataSet
    Dim DTSubcompany As New DataTable

    Dim r As Integer = 0


    Private Sub add_row()

        If Val(lbl_number.Text) = grd_subcompany.Rows.Count Then
            ll_fwd.Enabled = False
            ll_back.Enabled = True
            Exit Sub
        Else

            ll_fwd.Enabled = True
            lbl_number.Text = Val(lbl_number.Text) + 1
            r = Val(lbl_number.Text) - 1
            Publish_SubCompany()
        End If

    End Sub

    Private Sub Clean()
        txt_afterhours.Text = ""
        txt_attendant.Text = ""
        txt_bariatric.Text = ""
        txt_deadmiles.Text = ""
        txt_leg.Text = ""
        txt_loadedmiles.Text = ""
        txt_name.Text = ""
        txt_other.Text = ""
        txt_rental.Text = ""
        txt_rush.Text = ""
        txt_stairs.Text = ""
        txt_waittime.Text = ""
    End Sub

    Private Sub Clear_SubCompany()
        ''To clean the datasource and the datatable
        DSSubcompany.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from SubCompany ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSSubcompany, "SubCompany")
    End Sub

    Private Sub Close_textbox()
        txt_afterhours.Enabled = False
        txt_attendant.Enabled = False
        txt_bariatric.Enabled = False
        txt_deadmiles.Enabled = False
        txt_leg.Enabled = False
        txt_loadedmiles.Enabled = False
        txt_name.Enabled = False
        txt_other.Enabled = False
        txt_rental.Enabled = False
        txt_rush.Enabled = False
        txt_stairs.Enabled = False
        txt_waittime.Enabled = False
    End Sub

    Private Sub Filter_SubCompany()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from SubCompany where company_id='" & lbl_company_ID.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_subcompany.DataSource = reader
            grd_subcompany.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()


    End Sub

    Private Sub Format_SubRate()
        If Len(txt_name.Text) > 1 Then
            txt_name.Text = txt_name.Text.Substring(0, 1).ToUpper() + txt_name.Text.Substring(1)
        ElseIf Len(txt_name.Text) = 1 Then
            txt_name.Text = txt_name.Text.ToUpper()
        End If

        txt_deadmiles.Text = FormatNumber(txt_deadmiles.Text, 2)
        txt_loadedmiles.Text = FormatNumber(txt_loadedmiles.Text, 2)
        txt_leg.Text = FormatNumber(txt_leg.Text, 2)
        txt_waittime.Text = FormatNumber(txt_waittime.Text, 2)
        txt_attendant.Text = FormatNumber(txt_attendant.Text, 2)
        txt_rental.Text = FormatNumber(txt_rental.Text, 2)
        txt_bariatric.Text = FormatNumber(txt_bariatric.Text, 2)
        txt_stairs.Text = FormatNumber(txt_stairs.Text, 2)
        txt_rush.Text = FormatNumber(txt_rush.Text, 2)
        txt_other.Text = FormatNumber(txt_other.Text, 2)
        txt_afterhours.Text = FormatNumber(txt_afterhours.Text, 2)


        If lbl_choice.Text = "modify" Then
            Update_SubCompany()
        Else
            Save_SubCompany()
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

    Private Sub Load_SubCompany()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from SubCompany where company_id='" & lbl_company_ID.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_subcompany.DataSource = reader
            grd_subcompany.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()

        Dim n As Integer = grd_subcompany.Rows.Count
        lbl_total.Text = n
        If n = 0 Then
            lbl_number.Text = "0"
            open_text_box()
            ll_back.Enabled = False
            ll_fwd.Enabled = False
        Else
            lbl_number.Text = "1"
            ll_back.Enabled = True
            ll_fwd.Enabled = True
            r = 0
            Publish_SubCompany()
        End If

    End Sub

    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub

    Private Sub open_text_box()
        txt_afterhours.Enabled = True
        txt_attendant.Enabled = True
        txt_bariatric.Enabled = True
        txt_deadmiles.Enabled = True
        txt_leg.Enabled = True
        txt_loadedmiles.Enabled = True
        txt_name.Enabled = True
        txt_other.Enabled = True
        txt_rental.Enabled = True
        txt_rush.Enabled = True
        txt_stairs.Enabled = True
        txt_waittime.Enabled = True

    End Sub

    Private Sub Publish_SubCompany()

        lbl_subcompany_ID.Text = grd_subcompany.Rows.Item(r).Cells(0).Text
        txt_name.Text = grd_subcompany.Rows.Item(r).Cells(2).Text
        txt_deadmiles.Text = grd_subcompany.Rows.Item(r).Cells(3).Text
        txt_loadedmiles.Text = grd_subcompany.Rows.Item(r).Cells(4).Text
        txt_leg.Text = grd_subcompany.Rows.Item(r).Cells(5).Text
        txt_waittime.Text = grd_subcompany.Rows.Item(r).Cells(6).Text
        txt_attendant.Text = grd_subcompany.Rows.Item(r).Cells(7).Text
        txt_rental.Text = grd_subcompany.Rows.Item(r).Cells(8).Text
        txt_bariatric.Text = grd_subcompany.Rows.Item(r).Cells(9).Text
        txt_stairs.Text = grd_subcompany.Rows.Item(r).Cells(10).Text
        txt_rush.Text = grd_subcompany.Rows.Item(r).Cells(11).Text
        txt_other.Text = grd_subcompany.Rows.Item(r).Cells(12).Text
        txt_afterhours.Text = grd_subcompany.Rows.Item(r).Cells(13).Text
    End Sub

    Private Sub remove_Row()
        If Val(lbl_number.Text) = 1 Then
            ll_back.Enabled = False
            ll_fwd.Enabled = True
            Exit Sub
        Else
            ll_back.Enabled = True

            lbl_number.Text = Val(lbl_number.Text) - 1
            r = Val(lbl_number.Text) - 1
            Publish_SubCompany()
        End If
    End Sub

    Private Sub Save_SubCompany()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("Insert into SubCompany values('" & lbl_company_ID.Text & "', '" & txt_name.Text & "', '" & txt_deadmiles.Text & "', '" & txt_loadedmiles.Text & "', '" & txt_leg.Text & "', '" & txt_waittime.Text & "', '" & txt_attendant.Text & "', '" & txt_rental.Text & "', '" & txt_bariatric.Text & "', '" & txt_stairs.Text & "', '" & txt_rush.Text & "', '" & txt_other.Text & "', '" & txt_afterhours.Text & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_SubCompany()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.Green

        lbl_comment.Text = "SubCompany and Rates registered in database"

        Close_textbox()
    End Sub

    Private Sub Update_SubCompany()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("UPDATE SubCompany set name= '" & txt_name.Text & "', deadmiles = '" & txt_deadmiles.Text & "', loadedmiles = '" & txt_loadedmiles.Text & "', leg = '" & txt_leg.Text & "', waittime = '" & txt_waittime.Text & "', attendant = '" & txt_attendant.Text & "', rental = '" & txt_rental.Text & "', bariatric = '" & txt_bariatric.Text & "', stairs = '" & txt_stairs.Text & "', rush = '" & txt_rush.Text & "', other = '" & txt_other.Text & "', afterhours = '" & txt_afterhours.Text & "' where sub_company_id='" & lbl_subcompany_ID.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_SubCompany()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.Green

        lbl_comment.Text = "SubCompany and Rates updated in database"

        Close_textbox()
    End Sub

    Private Sub validate_SubCompany()
        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed

        If txt_name.Text = "" Then

            lbl_comment.Text = "Input a subname for that company before saving"

            Exit Sub
        End If

        If txt_deadmiles.Text = "" Then
            txt_deadmiles.Text = "0"
        End If

        If txt_loadedmiles.Text = "" Then
            txt_loadedmiles.Text = "0"
        End If

        If txt_leg.Text = "" Then
            txt_leg.Text = "0"
        End If

        If txt_waittime.Text = "" Then
            txt_waittime.Text = "0"
        End If

        If txt_attendant.Text = "" Then
            txt_attendant.Text = "0"
        End If

        If txt_rental.Text = "" Then
            txt_rental.Text = "0"
        End If

        If txt_bariatric.Text = "" Then
            txt_bariatric.Text = "0"
        End If

        If txt_stairs.Text = "" Then
            txt_stairs.Text = "0"
        End If

        If txt_rush.Text = "" Then
            txt_rush.Text = "0"
        End If

        If txt_other.Text = "" Then
            txt_other.Text = "0"
        End If

        If txt_afterhours.Text = "" Then
            txt_afterhours.Text = "0"
        End If

        Format_SubRate
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then

        Else
            lbl_company_ID.Text = Session("Company ID")
            lbl_company.Text = Session("Company")

            Load_Company()
            Load_SubCompany()
            Close_textbox()
        End If
    End Sub

    Private Sub ll_close_Click(sender As Object, e As EventArgs) Handles ll_close.Click
        Response.Redirect("~/Content/Administration/Settings/Rate/Company.aspx")
    End Sub

    Private Sub ll_add_Click(sender As Object, e As EventArgs) Handles ll_add.Click
        open_text_box()
        Clean()
        ll_save.Visible = True
    End Sub

    Private Sub ll_modify_Click(sender As Object, e As EventArgs) Handles ll_modify.Click
        open_text_box()
        lbl_choice.Text = "modify"
        ll_save.Visible = True
    End Sub

    Private Sub ll_save_Click(sender As Object, e As EventArgs) Handles ll_save.Click
        validate_SubCompany()
        Load_SubCompany()
        ll_save.Visible = False
        Close_textbox()
    End Sub

    Private Sub ll_fwd_Click(sender As Object, e As EventArgs) Handles ll_fwd.Click
        add_row()
    End Sub

    Private Sub ll_back_Click(sender As Object, e As EventArgs) Handles ll_back.Click
        remove_Row()
    End Sub
End Class