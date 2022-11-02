Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html.simpleparser
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Threading.Tasks


Public Class Invoice
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Dim DSinvoice As New DataSet
    Dim DTinvoice As New DataTable

    Private Sub Clear_Invoice()
        ''To clean the datasource and the datatable
        DSinvoice.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Report_Invoice ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSinvoice, "Report_Invoice")
    End Sub

    Private Sub Delete_report_Invoice()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("DELETE from Report_Invoice ", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader

        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Load_client()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Client where client_id='" & lbl_client_id.Text & "' ", Connection)
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

    Private Sub Load_Invoice()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Invoice where invoice_id='" & lbl_invoice_id2.Text & "' ", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_invoice.DataSource = reader
            grd_invoice.DataBind()
        Catch ex As Exception
            MsgBox(ex)
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
    End Sub

    Private Sub Load_invoice_Detail()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Invoice_detail where invoice_id='" & lbl_invoice_id2.Text & "' ", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_invoice_detail.DataSource = reader
            grd_invoice_detail.DataBind()
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

    Private Sub Publish_Invoice()
        lbl_date.Text = FormatDateTime(grd_invoice.Rows.Item(0).Cells(1).Text, DateFormat.ShortDate)
        lbl_client_id.Text = grd_invoice.Rows.Item(0).Cells(3).Text
        lbl_firstname.Text = grd_invoice.Rows.Item(0).Cells(4).Text
        lbl_middlename.Text = grd_invoice.Rows.Item(0).Cells(5).Text
        lbl_lastname.Text = grd_invoice.Rows.Item(0).Cells(6).Text
        Load_client()
        lbl_telephone.Text = grd_client.Rows.Item(0).Cells(9).Text


        lbl_transport.Text = grd_invoice_detail.Rows.Item(0).Cells(1).Text
        lbl_service_fee.Text = grd_invoice_detail.Rows.Item(0).Cells(2).Text
        lbl_total.Text = grd_invoice_detail.Rows.Item(0).Cells(3).Text
    End Sub

    Private Sub Save_Invoice_Report()
        Open_Connection()
        Connection.Open()

        Dim invoice_id As String = lbl_invoice_id2.Text
        Dim rdate As String = lbl_date.Text
        Dim firstname As String = lbl_firstname.Text
        Dim middlename As String = lbl_middlename.Text
        Dim lastname As String = lbl_lastname.Text
        Dim telephone As String = lbl_telephone.Text
        Dim transport As String = lbl_transport.Text
        Dim services As String = lbl_service_fee.Text
        Dim amount As String = lbl_total.Text



        Try
            Command = New SqlCommand("Insert into Report_Invoice values('" & invoice_id & "', '" & rdate & "', '" & firstname & "', '" & middlename & "', '" & lastname & "', '" & telephone & "', '" & transport & "', '" & services & "', '" & amount & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Invoice()
        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

    End Sub

    Private Sub Send_Mail()
        Dim fromMail As String = "reginald.coutard1981@gmail.com"
        Dim fromPassword As String = "ndmjqcievwopscax"

        Dim message As MailMessage = New MailMessage
        message.From = New MailAddress(fromMail)
        message.Subject = "New ATS Invoice"
        message.To.Add(New MailAddress(txt_email.Text))
        message.Body = card_invoice.ToString
        message.IsBodyHtml = True

        Dim smtpClient = New SmtpClient("smtp.gmail.com", 587)
        smtpClient.Credentials = New System.Net.NetworkCredential(fromMail, fromPassword)

        smtpClient.Send(message)
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then

        Else
            lbl_invoice_id2.Text = Session("Reservation ID")
            Load_Invoice()
            Load_invoice_Detail()
            Publish_Invoice()
        End If
    End Sub

    Protected Sub cbx_additionnal_CheckedChanged(sender As Object, e As EventArgs)
        If cbx_additionnal.Checked = True Then
            row_fee.Visible = True
        ElseIf cbx_additionnal.Checked = False Then
            row_fee.Visible = False
        End If
    End Sub

    Private Sub lbl_close_Click(sender As Object, e As EventArgs) Handles lbl_close.Click
        Response.Redirect("~/Content/invoice/Invoice_Database.aspx")
    End Sub




    Private Sub ll_mail_Click(sender As Object, e As EventArgs) Handles ll_mail.Click
        txt_email.Visible = True
        txt_email.Text = ""
        btn_send.Visible = True
    End Sub

    Private Sub btn_send_Click(sender As Object, e As EventArgs) Handles btn_send.Click
        Send_Mail()
        txt_email.Text = ""
        txt_email.Visible = False
        btn_send.Visible = False

    End Sub

    Private Sub ll_download_Click(sender As Object, e As EventArgs) Handles ll_download.Click
        Delete_report_Invoice()
        Save_Invoice_Report()
        Response.Redirect("~/Content/invoice/View_Invoice.aspx")
    End Sub
End Class