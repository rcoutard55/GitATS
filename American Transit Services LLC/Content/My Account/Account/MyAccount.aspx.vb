
Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class MyAccount
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection


    Private Sub Extract_name()

        txt_firstname.Text = grd_employe.Rows.Item(0).Cells(1).Text
        txt_lastname.Text = grd_employe.Rows.Item(0).Cells(3).Text



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
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        Extract_name()
    End Sub

    Private Sub Load_User()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from e_User where employe_id='" & lbl_employe_id.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_user.DataSource = reader
            grd_user.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()

        txt_username.Text = grd_user.Rows.Item(0).Cells(1).Text

    End Sub

    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then

        Else
            lbl_employe_id.Text = Session("Employe ID")
            Load_Employe()
            Load_User()
        End If
    End Sub

    Private Sub ll_password_Click(sender As Object, e As EventArgs) Handles ll_password.Click
        Response.Redirect("~/Content/My Account/Account/Password.aspx")
    End Sub
End Class