Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Public Class View_Reservation
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Dim DSrcomment As New DataSet
    Dim DTrcomment As New DataTable
    Dim DSreservation As New DataSet
    Dim DTreservation As New DataTable
    Dim DSinvoice As New DataSet
    Dim DTinvoice As New DataTable
    Dim DSerror As New DataSet
    Dim DTerror As New DataTable
    Dim DSsales As New DataSet
    Dim DTsales As New DataTable


    Dim error_message As String




    Private Sub Clear_Comment()
        ''To clean the datasource and the datatable
        DSrcomment.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Reservation_Comment ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSrcomment, "Reservation_Comment")
    End Sub

    Private Sub Clear_error()
        DSerror.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Error_Message ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSerror, "Error_Message")
    End Sub

    Private Sub Clear_Invoice()
        ''To clean the datasource and the datatable
        DSinvoice.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Invoice ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSinvoice, "Invoice")
    End Sub

    Private Sub Clear_Reservation()
        ''To clean the datasource and the datatable
        DSreservation.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Reservation ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSreservation, "Reservation")
    End Sub

    Private Sub Clear_Sales()
        ''To clean the datasource and the datatable
        DSsales.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Transport ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSsales, "Transport")
    End Sub

    Private Sub Load_Client()
        Open_Connection()
        Connection.Open()

        Try
            Command = New SqlCommand("SELECT * from Client  where first_name='" & lbl_firstname.Text & "' and last_name= '" & lbl_lastname.Text & "' And telephone = '" & lbl_telephone.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_client.DataSource = reader
            grd_client.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Client"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Load_Proforma()
        Open_Connection()
        Connection.Open()

        Try
            Command = New SqlCommand("SELECT * from Proforma  where proforma_id='" & lbl_proforma_ID.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_proforma.DataSource = reader
            grd_proforma.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Proforma"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()

    End Sub

    Private Sub Load_Reservation()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Reservation  where reservation_id='" & lbl_reservation_id.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_reservation.DataSource = reader
            grd_reservation.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Reservation"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        Publish_Reservation()
    End Sub

    Private Sub Load_Reservation_comment()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Reservation_Comment where reservation_id='" & lbl_reservation_id.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_reservation_comment.DataSource = reader
            grd_reservation_comment.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Reservation Comment"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        Publish_Reservation()
    End Sub

    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub

    Private Sub Publish_Proforma()
        Dim origin As String
        lbl_origin0.Text = grd_proforma.Rows.Item(0).Cells(5).Text
        lbl_destination0.Text = grd_proforma.Rows.Item(0).Cells(6).Text

        origin = grd_proforma.Rows.Item(0).Cells(9).Text
        If origin <> "-" Then
            th_row1.Visible = True
            lbl_origin1.Text = grd_proforma.Rows.Item(0).Cells(9).Text
            lbl_destination1.Text = grd_proforma.Rows.Item(0).Cells(10).Text
        Else
            Exit Sub
        End If

        origin = ""
        origin = grd_proforma.Rows.Item(0).Cells(13).Text
        If origin <> "-" Then
            th_row2.Visible = True
            lbl_origin2.Text = grd_proforma.Rows.Item(0).Cells(13).Text
            lbl_destination2.Text = grd_proforma.Rows.Item(0).Cells(14).Text
        Else
            Exit Sub
        End If

        origin = ""
        origin = grd_proforma.Rows.Item(0).Cells(17).Text
        If origin <> "-" Then
            th_row3.Visible = True
            lbl_origin3.Text = grd_proforma.Rows.Item(0).Cells(17).Text
            lbl_destination3.Text = grd_proforma.Rows.Item(0).Cells(18).Text
        Else
            Exit Sub
        End If

        origin = ""
        origin = grd_proforma.Rows.Item(0).Cells(21).Text
        If origin <> "-" Then
            th_row4.Visible = True
            lbl_origin4.Text = grd_proforma.Rows.Item(0).Cells(21).Text
            lbl_destination4.Text = grd_proforma.Rows.Item(0).Cells(22).Text
        Else
            Exit Sub
        End If

    End Sub

    Private Sub Publish_Reservation()
        lbl_firstname.Text = grd_reservation.Rows.Item(0).Cells(2).Text
        lbl_middlename.Text = grd_reservation.Rows.Item(0).Cells(3).Text
        lbl_lastname.Text = grd_reservation.Rows.Item(0).Cells(4).Text
        lbl_telephone.Text = grd_reservation.Rows.Item(0).Cells(5).Text
        lbl_email.Text = grd_reservation.Rows.Item(0).Cells(6).Text
        lbl_pickup_date.Text = FormatDateTime(grd_reservation.Rows.Item(0).Cells(7).Text, DateFormat.ShortDate)

        lbl_pickup_time.Text = grd_reservation.Rows.Item(0).Cells(8).Text
        Load_Proforma()
        Publish_Proforma()
        lbl_total_distance.Text = grd_proforma.Rows.Item(0).Cells(28).Text
        lbl_total_time.Text = grd_proforma.Rows.Item(0).Cells(27).Text


    End Sub

    Private Sub Save_Comment()
        Open_Connection()
        Connection.Open()

        Dim reservation_id As String = lbl_reservation_id.Text
        Dim rdate As Date = FormatDateTime(Today.ToShortDateString)
        Dim status As String = ddl_status.Text
        Dim comment As String = txt_status.Text
        Dim user As String = Session("Employe")


        Try
            Command = New SqlCommand("Insert into Reservation_Comment values('" & reservation_id & "', '" & rdate & "', '" & status & "', '" & comment & "', '" & user & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Comment()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Comment"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()
        Update_Reservation()

        txt_status.Text = ""
        ddl_status.Text = "--Select--"
        Load_Reservation_comment()
    End Sub

    Private Sub Save_Error()
        Open_Connection()
        Connection.Open()
        Dim edate As Date = FormatDateTime(Today, DateFormat.ShortDate)
        Dim etime As Date = FormatDateTime(Now, DateFormat.LongTime)
        Dim page As String = "View Reservation"
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

    Private Sub Save_Invoice()


        Dim reservation_id As String = lbl_reservation_id.Text
        Dim rdate As Date = FormatDateTime(Today.ToShortDateString)
        Dim rtime As Date = FormatDateTime(Now.ToLongTimeString)
        Load_Client()
        Dim clientID As String = grd_client.Rows.Item(0).Cells(0).Text
        Dim firstname As String = lbl_firstname.Text
        Dim middlename As String = lbl_middlename.Text
        Dim lastname As String = lbl_lastname.Text
        Dim amount As Double = grd_proforma.Rows.Item(0).Cells(44).Text
        Dim status As String = "Open"

        Open_Connection()
        Connection.Open()

        Try
            Command = New SqlCommand("Insert into Invoice values('" & reservation_id & "', '" & rdate & "', '" & rtime & "', '" & clientID & "', '" & firstname & "', '" & middlename & "', '" & lastname & "', '" & amount & "', '" & status & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Invoice
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Invoice"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()
        Save_Invoice_Detail()
    End Sub

    Private Sub Save_Invoice_Detail()
        Open_Connection()
        Connection.Open()

        Dim reservation_id As String = lbl_reservation_id.Text
        Dim transportation As Double = grd_proforma.Rows.Item(0).Cells(42).Text
        Dim services As Double = grd_proforma.Rows.Item(0).Cells(43).Text
        Dim total_contract As Double = grd_proforma.Rows.Item(0).Cells(44).Text
        Dim cancel_contract As Double = grd_proforma.Rows.Item(0).Cells(45).Text
        Dim status As String = "Open"

        Try
            Command = New SqlCommand("Insert into invoice_detail values('" & reservation_id & "', '" & transportation & "', '" & services & "', '" & total_contract & "', '" & cancel_contract & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Invoice()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Invoice Detail"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Save_Transport()
        Dim transport_id As String = lbl_reservation_id.Text
        Dim title As String = grd_reservation.Rows.Item(0).Cells(1).Text
        Dim legs As Integer = grd_proforma.Rows.Item(0).Cells(31).Text
        Dim total_miles As String = lbl_total_distance.Text
        Dim company As String = grd_proforma.Rows.Item(0).Cells(40).Text
        Dim pickup_date As Date = FormatDateTime(lbl_pickup_date.Text, DateFormat.ShortDate)
        Dim pickup_time As String = lbl_pickup_time.Text
        Dim origin As String = lbl_origin0.Text
        Dim destination As String = lbl_destination0.Text
        Dim trip_type As String = grd_proforma.Rows.Item(0).Cells(3).Text
        Dim waittime As Integer = grd_proforma.Rows.Item(0).Cells(35).Text
        Dim services As String = grd_proforma.Rows.Item(0).Cells(44).Text


        Open_Connection()
        Connection.Open()

        Try
            Command = New SqlCommand("Insert into Transport values('" & transport_id & "', '" & title & "', '" & legs & "', '" & total_miles & "', '" & company & "', '" & services & "', '" & pickup_date & "', '" & pickup_time & "', '" & origin & "', '" & destination & "', '" & trip_type & "', '" & waittime & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Sales()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Invoice Detail"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

    End Sub

    Private Sub Unexpected_Error()
        lbl_comment.Visible = True
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed
        lbl_comment.BackColor = System.Drawing.Color.LightPink
        lbl_comment.Text = "Unexpected error. Please try again later or contact your system administrator"
    End Sub

    Private Sub Update_proforma()
        Open_Connection()
        Connection.Open()
        Dim status As String = "Close"

        Try
            Command = New SqlCommand("UPDATE proforma set status = '" & status & "' where proforma_id= '" & lbl_proforma_ID.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Reservation()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Update Proforma"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Update_Reservation()
        Open_Connection()
        Connection.Open()
        Dim status As String = ddl_status.Text

        Try
            Command = New SqlCommand("UPDATE Reservation set status = '" & status & "' where reservation_id= '" & lbl_reservation_id.Text & "'", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Reservation()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Update Reservation"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        Update_proforma()

    End Sub




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then

        Else
            lbl_reservation_id.Text = Session("Reservation ID")
            lbl_proforma_ID.Text = Microsoft.VisualBasic.Right(lbl_reservation_id.Text, 4)
            Open_Connection()
            Load_Reservation()

            Load_Reservation_comment()
            lbl_place.Text = Session("Place")

            Dim i As Integer
            Dim status As String = grd_reservation.Rows.Item(0).Cells(10).Text
            If status = "Close" Or status = "Canceled" Then
                ddl_status.Enabled = False
                txt_status.Enabled = False
                btn_save.Visible = False
            Else
                ddl_status.Enabled = True
                txt_status.Enabled = True
                btn_save.Visible = True
            End If


        End If
    End Sub

    Private Sub lbl_close_Click(sender As Object, e As EventArgs) Handles lbl_close.Click
        If lbl_place.Text = "Database" Then
            Response.Redirect("~/Content/Reservation/Database.aspx")
        ElseIf lbl_place.Text = "Calendar" Then
            Response.Redirect("~/Content/Reservation/Calendar.aspx")
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If ddl_status.Text = "Close" Then
            Save_Transport()
            Save_Comment()
            Save_Invoice()
            Session.Add("Reservation ID", lbl_reservation_id.Text)
            Response.Redirect("~/Content/invoice/Invoice.aspx")


        End If

        Save_Comment()
    End Sub
End Class