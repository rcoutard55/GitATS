Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Client_add
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Dim DSclient As New DataSet
    Dim DTclient As New DataTable
    Dim DSclient_add As New DataSet
    Dim DTclient_add As New DataTable





    Private Sub Clean()
        txt_address1.Text = ""
        txt_address2.Text = ""
        txt_age.Text = ""
        txt_city.Text = ""
        txt_dob.Text = Today
        txt_email.Text = ""
        txt_firstname.Text = ""
        txt_lastname.Text = ""
        txt_medication.Text = ""
        txt_middlename.Text = ""
        txt_name.Text = ""
        txt_telephone.Text = ""
        txt_telephone2.Text = ""
        txt_zipcode.Text = ""
        ddl_bloodtype.Text = "--Select--"
        ddl_state.Text = "--Select--"
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
        DSclient_add.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Client_Additionnal ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSclient_add, "Client_Additionnal")
    End Sub

    Private Sub Generate_ClientID()
        ''To generate new Employe ID

        Dim Reader As SqlDataReader

        If Connection.State = ConnectionState.Closed Then
            Open_Connection()
            Connection.Open()
        End If
        Try

            Dim cmd As SqlCommand = New SqlCommand("select client_id from client where client_id=(select max(client_id) from Client) ", Connection)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If Reader.Read Then
                lbl_client_id.Text = Reader("client_id").ToString()
                New_Client_ID()
                Exit Sub
            Else
                lbl_client_id.Text = "CL-ATS-001"
            End If
        Catch ex As Exception
            Response.Write(ex.Message.ToString())
        End Try
        Reader.Close()
        Connection.Close()

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

        txt_name.Text = StrConv(txt_name.Text, VbStrConv.ProperCase)
        txt_medication.Text = StrConv(txt_medication.Text, VbStrConv.ProperCase)

        If Len(txt_telephone2.Text) = 10 Then
            Dim a As String = Microsoft.VisualBasic.Left(txt_telephone2.Text, 3)
            Dim b As String = Mid(txt_telephone2.Text, 4, 3)
            Dim c As String = Microsoft.VisualBasic.Right(txt_telephone2.Text, 4)

            txt_telephone2.Text = "(" + a + ") " + b + "-" + c
        End If

        Save_Client
    End Sub

    Private Sub Load_Client()
        'To lod the clients list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Client", Connection)
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

    Private Sub New_Client_ID()
        ''To increment the client ID by 1

        Dim I As Integer
        Dim a As String
        Dim b As String
        Dim c As Integer

        b = Right(lbl_client_id.Text, 3)


        c = b + 1

        Me.lbl_client_id.Text = c
        If Len(Me.lbl_client_id.Text) = 1 Then
            Me.lbl_client_id.Text = "CL-ATS-00" & "" & c
        ElseIf Len(Me.lbl_client_id.Text) = 2 Then
            Me.lbl_client_id.Text = "CL-ATS-0" & "" & c
        ElseIf Len(Me.lbl_client_id.Text) = 3 Then
            Me.lbl_client_id.Text = "CL-ATS-" & "" & c


        End If
    End Sub

    Private Sub Open_Error_row()
        'To view the error once the data is not filled
        lbl_comment.Visible = True
    End Sub

    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub

    Private Sub Publish_States()
        Dim i As Integer
        Dim a As String
        For i = 0 To grd_state.Rows.Count - 1
            a = grd_state.Rows.Item(i).Cells(1).Text

            ddl_state.Items.Add(a)
        Next

    End Sub

    Private Sub Save_Client()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("Insert into Client values('" & lbl_client_id.Text & "', '" & txt_firstname.Text & "', '" & txt_middlename.Text & "', '" & txt_lastname.Text & "', '" & txt_address1.Text & "', '" & txt_address2.Text & "', '" & txt_city.Text & "', '" & ddl_state.Text & "', '" & txt_zipcode.Text & "', '" & txt_telephone.Text & "', '" & txt_email.Text & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Client()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        Save_Client_Additionnel()


        lbl_comment.Text = "New Client registered in database"
        lbl_comment.ForeColor = System.Drawing.Color.DarkGreen
        lbl_comment.BackColor = System.Drawing.Color.LightGreen

    End Sub

    Private Sub Save_Client_Additionnel()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("Insert into Client_Additionnal values('" & lbl_client_id.Text & "', '" & ddl_gender.Text & "', '" & ddl_bloodtype.Text & "', '" & txt_dob.Text & "', '" & txt_age.Text & "', '" & txt_medication.Text & "', '" & txt_name.Text & "', '" & txt_telephone2.Text & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Client_Additional()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()
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

        If ddl_state.Text = "" Then
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

        If ddl_bloodtype.Text = "" Then
            ddl_bloodtype.Text = "-"
        End If

        If txt_dob.Text = "" Then
            txt_dob.Text = "1/1/1900"
            txt_age.Text = "0"
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

        Format_Client
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
        Else
            Open_Connection()
            Load_Client
            Generate_ClientID()
            Load_State()


        End If
    End Sub

    Private Sub ll_close_Click(sender As Object, e As EventArgs) Handles ll_close.Click
        Response.Redirect("~/Content/Client/Client.aspx")
    End Sub




    Private Sub ll_save_Click(sender As Object, e As EventArgs) Handles ll_save.Click
        lbl_comment.Visible = False
        Validate_Client()
    End Sub


End Class