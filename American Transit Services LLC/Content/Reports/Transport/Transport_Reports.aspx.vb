Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class Reports
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Dim DSerror As New DataSet
    Dim DTerror As New DataTable
    Dim DSrep_transdport As New DataSet
    Dim DTrep_transport As New DataTable

    Dim error_message As String
    Dim company As String
    Dim services As String


    Private Sub Calculate_Total_Row()
        lbl_total_entry.Text = grd_transport.Rows.Count
    End Sub

    Private Sub Clear_error()
        DSerror.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Error_Message ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSerror, "Error_Message")
    End Sub

    Private Sub Clear_Report_Transport()
        DSrep_transdport.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Report_Transport ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSrep_transdport, "Report_Transport")
    End Sub

    Private Sub Delete_Transport_Report()
        Open_Connection()
        Connection.Open()
        Try
            Command = New SqlCommand("DELETE from Report_Transport ", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Report_Transport
        Catch ex As Exception
            error_message = ex.Message & " - " & "Delete Report Transport"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        Save_Report_Transport()
    End Sub

    Private Sub Filter_Company()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Transport where company like '%" & company & "%'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_transport.DataSource = reader
            grd_transport.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Filter Company"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        Calculate_Total_Row()
    End Sub

    Private Sub Filter_Date()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Transport where pickup_date BETWEEN @from and @to", Connection)
            Command.Parameters.AddWithValue("@from", Convert.ToDateTime(txt_initial_date.Text))
            Command.Parameters.AddWithValue("@to", Convert.ToDateTime(txt_final_date.Text))
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_transport.DataSource = reader
            grd_transport.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Filter Date"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        Calculate_Total_Row()
    End Sub

    Private Sub Filter_Services()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Transport where company like '%" & services & "%'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_transport.DataSource = reader
            grd_transport.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Filter_Services"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        Calculate_Total_Row()
    End Sub

    Private Sub Load_Company()
        'To lod the employe list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Company", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_company.DataSource = reader
            grd_company.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Company"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Load_Transport()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Transport", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_transport.DataSource = reader
            grd_transport.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Transport"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        Calculate_Total_Row()
    End Sub

    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub

    Private Sub Save_Error()
        Open_Connection()
        Connection.Open()
        Dim edate As Date = FormatDateTime(Today, DateFormat.ShortDate)
        Dim etime As Date = FormatDateTime(Now, DateFormat.LongTime)
        Dim page As String = "Transport Report"
        Dim user As String = Session("Credentials")
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

    Private Sub Save_Report_Transport()
        Dim i As Integer
        Dim transport_id As String
        Dim title As String
        Dim legs As Integer
        Dim total As String
        Dim company As String
        Dim services As String
        Dim tdate As Date
        Dim ttime As String
        Dim origin As String
        Dim destination As String
        Dim trip_type As String
        Dim waittime As Integer

        For i = 0 To grd_transport.Rows.Count - 1
            transport_id = grd_transport.Rows.Item(i).Cells(0).Text
            title = grd_transport.Rows.Item(i).Cells(1).Text
            legs = grd_transport.Rows.Item(i).Cells(2).Text
            total = grd_transport.Rows.Item(i).Cells(3).Text
            company = grd_transport.Rows.Item(i).Cells(4).Text
            services = grd_transport.Rows.Item(i).Cells(5).Text
            tdate = FormatDateTime(grd_transport.Rows.Item(i).Cells(6).Text, DateFormat.ShortDate)
            ttime = grd_transport.Rows.Item(i).Cells(7).Text
            origin = grd_transport.Rows.Item(i).Cells(8).Text
            destination = grd_transport.Rows.Item(i).Cells(9).Text
            trip_type = grd_transport.Rows.Item(i).Cells(10).Text
            waittime = grd_transport.Rows.Item(i).Cells(11).Text

            Open_Connection()
            Connection.Open()


            Try
                Command = New SqlCommand("Insert into Report_transport values('" & transport_id & "', '" & title & "', '" & legs & "', '" & total & "', '" & company & "', '" & services & "', '" & tdate & "', '" & ttime & "', '" & origin & "', '" & destination & "', '" & trip_type & "', '" & waittime & "')", Connection)
                Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
                Clear_Report_Transport()
            Catch ex As Exception
                error_message = ex.Message & " - " & "Save Employe Comments"
                Unexpected_Error()
                Save_Error()
                Connection.Close()
                Exit Sub
            End Try
            Connection.Close()
            Connection.Dispose()
        Next

        Response.Redirect("~/Content/Reports/Transport/Transport_Download.aspx")
    End Sub

    Private Sub Unexpected_Error()
        lbl_comment.Visible = True
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed
        lbl_comment.BackColor = System.Drawing.Color.LightPink
        lbl_comment.Text = "Unexpected error. Please try again later or contact your system administrator"
    End Sub

    Private Sub validate_date_search()
        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed
        lbl_comment.BackColor = System.Drawing.Color.LightPink

        If txt_initial_date.Text = "jj/mm/aaaa" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please select initial date"
            Exit Sub
        End If

        If txt_final_date.Text = "jj/mm/aaaa" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please select Final date"
            Exit Sub
        End If

        If txt_initial_date.Text > txt_final_date.Text Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Initial date can't be greater than Final date"
            Exit Sub
        End If

        Filter_Date()
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
        Else
            Load_Transport
            Load_Company()
        End If
    End Sub

    Protected Sub ll_select_Click(sender As Object, e As EventArgs)
        lbl_comment.Visible = False
        Dim ll As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(ll.Parent.Parent, GridViewRow)
        Dim idx As Integer = row.RowIndex

        company = grd_company.Rows.Item(idx).Cells(2).Text
        Filter_Company()
    End Sub

    Private Sub rbtn_all_CheckedChanged(sender As Object, e As EventArgs) Handles rbtn_all.CheckedChanged
        lbl_comment.Visible = False
        Filter_Company()
    End Sub

    Private Sub rbtn_ambulatory_CheckedChanged(sender As Object, e As EventArgs) Handles rbtn_ambulatory.CheckedChanged
        lbl_comment.Visible = False
        services = rbtn_ambulatory.Text
        Filter_Services()
    End Sub

    Private Sub rbtn_strecher_CheckedChanged(sender As Object, e As EventArgs) Handles rbtn_strecher.CheckedChanged
        lbl_comment.Visible = False
        services = rbtn_strecher.Text
        Filter_Services()
    End Sub

    Private Sub rbtn_wheelchair_CheckedChanged(sender As Object, e As EventArgs) Handles rbtn_wheelchair.CheckedChanged
        lbl_comment.Visible = False
        services = rbtn_wheelchair.Text
        Filter_Services()
    End Sub

    Private Sub txt_final_date_TextChanged(sender As Object, e As EventArgs) Handles txt_final_date.TextChanged
        lbl_comment.Visible = False
        validate_date_search()
    End Sub

    Private Sub txt_initial_date_TextChanged(sender As Object, e As EventArgs) Handles txt_initial_date.TextChanged
        lbl_comment.Visible = False
    End Sub

    Private Sub ll_download_Click(sender As Object, e As EventArgs) Handles ll_download.Click
        lbl_comment.Visible = False
        Delete_Transport_Report()
    End Sub
End Class