Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Error_List
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection



    Private Sub Load_Error_Message()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Error_Message ORDER BY [id] DESC", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_error_list.DataSource = reader
            grd_error_list.DataBind()
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


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then

        Else
            Open_Connection()
            Load_Error_Message()
        End If
    End Sub

End Class