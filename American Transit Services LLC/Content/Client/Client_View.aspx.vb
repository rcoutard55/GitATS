Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class Client_View
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection


    Dim DSclient As New DataSet
    Dim DTclient As New DataTable
    Dim DSclient_additionnal As New DataSet
    Dim DTclient_additionnal As New DataTable


    Private Sub Calculate_age()
        Dim dob As Date = txt_dob.Text
        Dim year As Integer = dob.Year
        Dim actual As Integer = Today.Year

        txt_age.Text = actual - year
    End Sub

    Private Sub Clear_Client()
        ''To clean the datasource and the datatable
        DSclient.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Client ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSclient, "Client")
    End Sub

    Private Sub Clear_Client_Additional()
        ''To clean the datasource and the datatable
        DSclient_additionnal.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Client_Additionnal ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSclient_additionnal, "Client_Additionnal")
    End Sub

    Private Sub Format_Client()
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



        Update_Client
    End Sub

    Private Sub Format_Client_Additionnal()
        txt_name.Text = StrConv(txt_name.Text, VbStrConv.ProperCase)
        txt_medication.Text = StrConv(txt_medication.Text, VbStrConv.ProperCase)

        If Len(txt_telephone2.Text) = 10 Then
            Dim a As String = Microsoft.VisualBasic.Left(txt_telephone2.Text, 3)
            Dim b As String = Mid(txt_telephone2.Text, 4, 3)
            Dim c As String = Microsoft.VisualBasic.Right(txt_telephone2.Text, 4)

            txt_telephone2.Text = "(" + a + ") " + b + "-" + c
        End If

        Update_Client_Additionnal

    End Sub

    Private Sub label_to_textbox_client()
        txt_address1.Text = lbl_address1.Text
        txt_address2.Text = lbl_address2.Text
        txt_city.Text = lbl_city.Text
        txt_email.Text = lbl_email.Text
        txt_firstname.Text = lbl_firstname.Text
        txt_lastname.Text = lbl_lastname.Text
        txt_medication.Text = lbl_middlename.Text
        txt_telephone.Text = lbl_telephone.Text
        txt_zipcode.Text = lbl_zipcode.Text
    End Sub

    Private Sub Label_to_texbox_client_additionnal()
        If lbl_gender.Text = "-" Then
            ddl_gender.Text = "--Select--"
        Else
            ddl_gender.Text = lbl_gender.Text
        End If
        If lbl_bloodtype.Text = "-" Then
            ddl_bloodtype.Text = "--Select--"
        Else
            ddl_bloodtype.Text = lbl_bloodtype.Text
        End If

        txt_dob.Text = lbl_dob.Text
        txt_age.Text = lbl_age.Text
        txt_medication.ReadOnly = False
        txt_name.Text = lbl_name.Text
        txt_telephone2.Text = lbl_telephone2.Text
    End Sub

    Private Sub Load_Client()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Client where client_id='" & lbl_client_id.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_client.DataSource = reader
            grd_client.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()

    End Sub

    Private Sub Load_Client_Additionnal()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Client_Additionnal where client_id='" & lbl_client_id.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_client_additionnal.DataSource = reader
            grd_client_additionnal.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()

        Publish_Client_Additionnal
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
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()

        Publish_States()
    End Sub

    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub

    Private Sub Publish_Client()
        lbl_firstname.Text = grd_client.Rows.Item(0).Cells(1).Text
        lbl_middlename.Text = grd_client.Rows.Item(0).Cells(2).Text
        lbl_lastname.Text = grd_client.Rows.Item(0).Cells(3).Text
        lbl_address1.Text = grd_client.Rows.Item(0).Cells(4).Text
        lbl_address2.Text = grd_client.Rows.Item(0).Cells(5).Text
        lbl_city.Text = grd_client.Rows.Item(0).Cells(6).Text
        lbl_state.Text = grd_client.Rows.Item(0).Cells(7).Text
        lbl_zipcode.Text = grd_client.Rows.Item(0).Cells(8).Text
        lbl_telephone.Text = grd_client.Rows.Item(0).Cells(9).Text
        lbl_email.Text = grd_client.Rows.Item(0).Cells(10).Text

    End Sub

    Private Sub Publish_Client_Additionnal()
        lbl_gender.Text = grd_client_additionnal.Rows.Item(0).Cells(1).Text
        lbl_bloodtype.Text = grd_client_additionnal.Rows.Item(0).Cells(2).Text
        lbl_dob.Text = FormatDateTime(grd_client_additionnal.Rows.Item(0).Cells(3).Text, DateFormat.ShortDate)
        lbl_age.Text = grd_client_additionnal.Rows.Item(0).Cells(4).Text

        txt_medication.Text = grd_client_additionnal.Rows.Item(0).Cells(5).Text
        lbl_name.Text = grd_client_additionnal.Rows.Item(0).Cells(6).Text
        lbl_telephone2.Text = grd_client_additionnal.Rows.Item(0).Cells(7).Text

    End Sub

    Private Sub Publish_States()
        Dim i As Integer
        Dim a As String
        For i = 0 To grd_state.Rows.Count - 1
            a = grd_state.Rows.Item(i).Cells(1).Text

            dll_state.Items.Add(a)
        Next

    End Sub

    Private Sub Update_Client()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("UPDATE Client set first_name =  '" & txt_firstname.Text & "', middle_name = '" & txt_middlename.Text & "', last_name = '" & txt_lastname.Text & "', address1 = '" & txt_address1.Text & "', address2 = '" & txt_address2.Text & "', city = '" & txt_city.Text & "', state = '" & dll_state.Text & "', zip_code = '" & txt_zipcode.Text & "', telephone = '" & txt_telephone.Text & "', email = '" & txt_email.Text & "' where client_id = '" & lbl_client_id.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Client()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()




        lbl_comment.Text = "Client Updated in database"
        lbl_comment.ForeColor = System.Drawing.Color.DarkGreen
        lbl_comment.BackColor = System.Drawing.Color.LightGreen
    End Sub

    Private Sub Update_Client_additionnal()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("UPDATE Client_Additionnal set gender='" & ddl_gender.Text & "', bloodtype = '" & ddl_bloodtype.Text & "', dob = '" & txt_dob.Text & "', age = '" & txt_age.Text & "', medication = '" & txt_medication.Text & "', name = '" & txt_name.Text & "', telephone = '" & txt_telephone2.Text & "' where client_id = '" & lbl_client_id.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Client_Additional()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()


        lbl_comment.ForeColor = System.Drawing.Color.Green

    End Sub

    Private Sub View_Client_Label()
        txt_address1.Visible = False
        txt_address2.Visible = False
        txt_city.Visible = False
        txt_email.Visible = False
        txt_firstname.Visible = False
        txt_lastname.Visible = False
        txt_medication.Visible = False
        txt_telephone.Visible = False
        txt_zipcode.Visible = False


        lbl_address1.Visible = True
        lbl_address2.Visible = True
        lbl_city.Visible = True
        lbl_email.Visible = True
        lbl_firstname.Visible = True
        lbl_lastname.Visible = True
        lbl_middlename.Visible = True
        lbl_telephone.Visible = True
        lbl_zipcode.Visible = True
    End Sub

    Private Sub View_Client_Textbox()
        txt_address1.Visible = True
        txt_address2.Visible = True
        txt_city.Visible = True
        txt_email.Visible = True
        txt_firstname.Visible = True
        txt_lastname.Visible = True
        txt_medication.Visible = True
        txt_telephone.Visible = True
        txt_zipcode.Visible = True


        lbl_address1.Visible = False
        lbl_address2.Visible = False
        lbl_city.Visible = False
        lbl_email.Visible = False
        lbl_firstname.Visible = False
        lbl_lastname.Visible = False
        lbl_middlename.Visible = False
        lbl_telephone.Visible = False
        lbl_zipcode.Visible = False

    End Sub

    Private Sub View_client_additionnal_label()
        ddl_gender.Visible = False
        ddl_bloodtype.Visible = False
        txt_dob.Visible = False
        txt_age.Visible = False
        txt_medication.ReadOnly = True
        txt_name.Visible = False
        txt_telephone2.Visible = False

        lbl_gender.Visible = True
        lbl_bloodtype.Visible = True
        lbl_dob.Visible = True
        lbl_age.Visible = True
        lbl_name.Visible = True
        lbl_telephone2.Visible = True
        txt_medication.ReadOnly = True
    End Sub

    Private Sub View_Client_Additionnal_Textbox()
        ddl_gender.Visible = True
        ddl_bloodtype.Visible = True
        txt_dob.Visible = True
        txt_age.Visible = True
        txt_medication.Visible = True
        txt_name.Visible = True
        txt_telephone2.Visible = True

        lbl_gender.Visible = False
        lbl_bloodtype.Visible = False
        lbl_age.Visible = False
        lbl_name.Visible = False
        lbl_telephone2.Visible = False
        lbl_dob.Visible = False
    End Sub

    Private Sub Validate_Client()
        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed

        If txt_firstname.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please enter Client First Name"

            Exit Sub
        End If

        If txt_middlename.Text = "" Then
            txt_middlename.Text = "-"
        End If

        If txt_lastname.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please enter Client Last Name"

            Exit Sub
        End If

        If txt_address1.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please enter Client house, apartment, condo number"

            Exit Sub
        End If

        If txt_address2.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please enter Client street name"

            Exit Sub
        End If

        If txt_city.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please enter Client City"

            Exit Sub
        End If

        If dll_state.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please enter Client State"

            Exit Sub
        End If

        If txt_zipcode.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please enter Client Zip Code"

            Exit Sub
        End If

        If txt_telephone.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please enter Client Telephone Number"

            Exit Sub
        End If

        Dim i As Integer
        Dim a As String
        Dim b As String
        Dim c As String
        For i = 0 To grd_client.Rows.Count - 1
            If grd_client.Rows.Count <= 0 Then
                Exit For
            End If
            a = grd_client.Rows.Item(i).Cells(1).Text
            b = grd_client.Rows.Item(i).Cells(3).Text
            c = grd_client.Rows.Item(i).Cells(9).Text

            If txt_firstname.Text = a And txt_lastname.Text = b And txt_telephone.Text = c Then
                lbl_comment.Visible = True
                lbl_comment.Text = "This client is already registered into the database"

                Exit Sub
            End If
        Next



        Format_Client
    End Sub

    Private Sub validate_Client_Additionnal()
        If ddl_bloodtype.Text = "" Then
            ddl_bloodtype.Text = "-"
        End If

        If txt_dob.Text = "" Then
            txt_dob.Text = "1/1/1900"
            txt_age.Text = "0"
        Else
            Calculate_age()
        End If
        If txt_medication.Text = "" Then
            txt_medication.Text = "-"
        End If

        If txt_name.Text = "" Then
            txt_name.Text = "-"
        End If

        If txt_telephone2.Text = "" Then
            txt_telephone2.Text = "0000000000"
        End If

        Format_Client_Additionnal

    End Sub




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then

        Else
            lbl_client_id.Text = Session("Client ID")
            Load_Client()
            Load_Client_Additionnal()

        End If
    End Sub

    Private Sub ll_close_Click(sender As Object, e As EventArgs) Handles ll_close.Click
        Response.Redirect("~/Content/Client/Client.aspx")
    End Sub

    Private Sub ll_modify_client_Click(sender As Object, e As EventArgs) Handles ll_modify_client.Click
        lbl_comment.Visible = False
        ll_modify_client.Visible = False
        ll_save_client.Visible = True
        ll_cancel_client.Visible = True
        label_to_textbox_client()
        View_Client_Textbox()
    End Sub

    Private Sub ll_save_client_Click(sender As Object, e As EventArgs) Handles ll_save_client.Click
        lbl_comment.Visible = False
        Validate_Client()
        ll_save_client.Visible = False
        ll_cancel_client.Visible = False
        ll_modify_client.Visible = True
        Load_Client()
        View_Client_Label()

    End Sub

    Private Sub ll_cancel_client_Click(sender As Object, e As EventArgs) Handles ll_cancel_client.Click
        lbl_comment.Visible = False
        ll_save_client.Visible = False
        ll_cancel_client.Visible = False
        ll_modify_client.Visible = True
        Load_Client()
        View_Client_Label()
    End Sub

    Private Sub ll_modify_additionnal_Click(sender As Object, e As EventArgs) Handles ll_modify_additionnal.Click
        lbl_comment.Visible = False
        ll_modify_additionnal.Visible = False
        ll_save_additionnal.Visible = True
        ll_cancel_additionnal.Visible = True
        Label_to_texbox_client_additionnal()
        View_Client_Additionnal_Textbox()
    End Sub

    Private Sub ll_save_additionnal_Click(sender As Object, e As EventArgs) Handles ll_save_additionnal.Click
        validate_Client_Additionnal()
        ll_modify_additionnal.Visible = True
        ll_save_additionnal.Visible = False
        ll_cancel_additionnal.Visible = False
        Load_Client_Additionnal()
        View_client_additionnal_label()
        lbl_comment.Visible = False
    End Sub

    Private Sub ll_cancel_additionnal_Click(sender As Object, e As EventArgs) Handles ll_cancel_additionnal.Click
        ll_modify_additionnal.Visible = True
        ll_save_additionnal.Visible = False
        ll_cancel_additionnal.Visible = False
        Load_Client_Additionnal()
        View_client_additionnal_label()
        lbl_comment.Visible = False
    End Sub

End Class