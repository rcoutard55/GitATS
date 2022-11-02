Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Net
Imports System.IO
Imports System.Data

Public Class Proforma
    Inherits System.Web.UI.Page
    Dim Command As SqlCommand
    Dim Adapters As SqlDataAdapter
    Dim Connection As SqlConnection

    Dim DSproforma As New DataSet
    Dim DTproforma As New DataTable
    Dim DSerror As New DataSet
    Dim DTerror As New DataTable

    Dim error_message As String

    Dim hour0 As Integer
    Dim min0 As Integer

    Dim hour1 As Integer
    Dim min1 As Integer

    Dim hour2 As Integer
    Dim min2 As Integer

    Dim hour3 As Integer
    Dim min3 As Integer

    Dim hour4 As Integer
    Dim min4 As Integer

    Private Sub Add_row()
        If th_row0.Visible = False Then
            th_row0.Visible = True
            Exit Sub
        ElseIf th_row0.Visible = True Then
            If th_row1.Visible = False Then
                th_row1.Visible = True
                txt_pickup.Text = txt_dropoff.Text
                txt_dropoff.Text = ""
                Exit Sub
            ElseIf th_row1.Visible = True Then
                If th_row2.Visible = False Then
                    th_row2.Visible = True
                    txt_pickup.Text = txt_dropoff.Text
                    txt_dropoff.Text = ""
                    Exit Sub
                ElseIf th_row2.Visible = True Then
                    If th_row3.Visible = False Then
                        th_row3.Visible = True
                        txt_pickup.Text = txt_dropoff.Text
                        txt_dropoff.Text = ""
                        Exit Sub
                    ElseIf th_row3.Visible = True Then
                        If th_row4.Visible = False Then
                            th_row4.Visible = True
                            txt_pickup.Text = txt_dropoff.Text
                            txt_dropoff.Text = ""
                        ElseIf th_row4.Visible = True Then
                            MsgBox("Client should have called a cab or Uber instead of us. To many legs.", vbOKOnly, "Warning")
                            Exit Sub
                        End If
                    End If

                End If
            End If
        End If





    End Sub

    Private Sub Calculate_distance_and_time_Deadmiles()
        Dim origin As String = ddl_home.Text
        Dim destination As String = lbl_origin0.Text
        Dim url As String = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" & origin & "&destinations=" & destination & "&key=AIzaSyBDJoTcSeGRvKUADN5kcNGIEyiVEvFAHrI"
        Dim request As WebRequest = WebRequest.Create(url)
        Using response As WebResponse = CType(request.GetResponse(), HttpWebResponse)
            Using reader As StreamReader = New StreamReader(response.GetResponseStream(), Encoding.UTF8)
                Dim dsResult As DataSet = New DataSet()
                dsResult.ReadXml(reader)
                lbl_total_time_deadmile.Text = dsResult.Tables("duration").Rows(0)("text")
                lbl_total_distance_deadmile.Text = dsResult.Tables("distance").Rows(0)("text")
                Extract_Deadmiles()

            End Using
        End Using
    End Sub

    Private Sub calculate_distance_and_time_loaded_miles()


        Dim total_distance As TimeSpan = TimeSpan.Parse(lbl_time0.Text) + TimeSpan.Parse(lbl_time1.Text) + TimeSpan.Parse(lbl_time2.Text) + TimeSpan.Parse(lbl_time3.Text) + TimeSpan.Parse(lbl_time4.Text)
        lbl_total_time_loadedmiles.Text = total_distance.ToString

        lbl_total_distance_loaded_miles.Text = FormatNumber((Val(lbl_distance0.Text) + Val(lbl_distance1.Text) + Val(lbl_distance2.Text) + Val(lbl_distance3.Text) + Val(lbl_distance4.Text)) * 0.621371, 2)



        lbl_total_distance_loaded_miles.Text = Val(lbl_total_distance_loaded_miles.Text) & " " & "miles"



    End Sub

    Private Sub Calculate_distance_and_time_0()
        Dim origin As String = lbl_origin0.Text
        Dim destination As String = lbl_destination0.Text
        Dim url As String = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" & origin & "&destinations=" & destination & "&key=AIzaSyBDJoTcSeGRvKUADN5kcNGIEyiVEvFAHrI"
        Dim request As WebRequest = WebRequest.Create(url)
        Using response As WebResponse = CType(request.GetResponse(), HttpWebResponse)
            Using reader As StreamReader = New StreamReader(response.GetResponseStream(), Encoding.UTF8)
                Dim dsResult As DataSet = New DataSet()
                dsResult.ReadXml(reader)
                lbl_time0.Text = dsResult.Tables("duration").Rows(0)("text").ToString()
                lbl_distance0.Text = dsResult.Tables("distance").Rows(0)("text").ToString()
            End Using
        End Using

        Dim total_time As String = Replace(lbl_time0.Text, "hours", ":")
        total_time = Replace(total_time, "hour", ":")
        total_time = Replace(total_time, "mins", " ")

        Dim i As Integer
        Dim a As String
        Dim b As String
        Dim totaltime As String
        For i = 1 To Len(total_time)
            a = Mid(total_time, i, 1)
            If a = ":" Then
                b = 1
            ElseIf a = " " Then
                a = ""
            End If
            totaltime = totaltime + a
        Next
        If b >= 1 Then
            lbl_time0.Text = Trim(totaltime)
        Else
            lbl_time0.Text = "0:" & "" & Trim(totaltime)
        End If

    End Sub

    Private Sub Calculate_distance_and_time_1()
        Dim origin As String = lbl_origin1.Text
        Dim destination As String = lbl_destination1.Text
        Dim url As String = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" & origin & "&destinations=" & destination & "&key=AIzaSyBDJoTcSeGRvKUADN5kcNGIEyiVEvFAHrI"
        Dim request As WebRequest = WebRequest.Create(url)
        Using response As WebResponse = CType(request.GetResponse(), HttpWebResponse)
            Using reader As StreamReader = New StreamReader(response.GetResponseStream(), Encoding.UTF8)
                Dim dsResult As DataSet = New DataSet()
                dsResult.ReadXml(reader)
                lbl_time1.Text = dsResult.Tables("duration").Rows(0)("text").ToString()
                lbl_distance1.Text = dsResult.Tables("distance").Rows(0)("text").ToString()
            End Using
        End Using

        Dim total_time As String = Replace(lbl_time1.Text, "hours", ":")
        total_time = Replace(total_time, "hour", ":")
        total_time = Replace(total_time, "mins", " ")

        Dim i As Integer
        Dim a As String
        Dim b As String
        Dim totaltime As String
        For i = 1 To Len(total_time)
            a = Mid(total_time, i, 1)
            If a = ":" Then
                b = 1
            ElseIf a = " " Then
                a = ""
            End If
            totaltime = totaltime + a

        Next
        If b >= 1 Then
            lbl_time1.Text = Trim(totaltime)
        Else
            lbl_time1.Text = "0:" & "" & Trim(totaltime)
        End If
    End Sub

    Private Sub Calculate_distance_and_time_2()
        Dim origin As String = lbl_origin2.Text
        Dim destination As String = lbl_destination2.Text
        Dim url As String = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" & origin & "&destinations=" & destination & "&key=AIzaSyBDJoTcSeGRvKUADN5kcNGIEyiVEvFAHrI"
        Dim request As WebRequest = WebRequest.Create(url)
        Using response As WebResponse = CType(request.GetResponse(), HttpWebResponse)
            Using reader As StreamReader = New StreamReader(response.GetResponseStream(), Encoding.UTF8)
                Dim dsResult As DataSet = New DataSet()
                dsResult.ReadXml(reader)
                lbl_time2.Text = dsResult.Tables("duration").Rows(0)("text").ToString()
                lbl_distance2.Text = dsResult.Tables("distance").Rows(0)("text").ToString()
            End Using
        End Using

        Dim total_time As String = Replace(lbl_time2.Text, "hours", ":")
        total_time = Replace(total_time, "hour", ":")
        total_time = Replace(total_time, "mins", " ")

        Dim i As Integer
        Dim a As String
        Dim b As String
        Dim totaltime As String
        For i = 1 To Len(total_time)
            a = Mid(total_time, i, 1)
            If a = ":" Then
                b = 1
            ElseIf a = " " Then
                a = ""
            End If
            totaltime = totaltime + a
        Next
        If b >= 1 Then
            lbl_time2.Text = Trim(totaltime)
        Else
            lbl_time2.Text = "0:" & "" & Trim(totaltime)
        End If
    End Sub

    Private Sub Calculate_distance_and_time_3()
        Dim origin As String = lbl_origin3.Text
        Dim destination As String = lbl_destination3.Text
        Dim url As String = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" & origin & "&destinations=" & destination & "&key=AIzaSyBDJoTcSeGRvKUADN5kcNGIEyiVEvFAHrI"
        Dim request As WebRequest = WebRequest.Create(url)
        Using response As WebResponse = CType(request.GetResponse(), HttpWebResponse)
            Using reader As StreamReader = New StreamReader(response.GetResponseStream(), Encoding.UTF8)
                Dim dsResult As DataSet = New DataSet()
                dsResult.ReadXml(reader)
                lbl_time3.Text = dsResult.Tables("duration").Rows(0)("text").ToString()
                lbl_distance3.Text = dsResult.Tables("distance").Rows(0)("text").ToString()
            End Using
        End Using

        Dim total_time As String = Replace(lbl_time3.Text, "hours", ":")
        total_time = Replace(total_time, "hour", ":")
        total_time = Replace(total_time, "mins", " ")

        Dim i As Integer
        Dim a As String
        Dim b As String
        Dim totaltime As String
        For i = 1 To Len(total_time)
            a = Mid(total_time, i, 1)
            If a = ":" Then
                b = 1
            ElseIf a = " " Then
                a = ""
            End If
            totaltime = totaltime + a
        Next
        If b >= 1 Then
            lbl_time3.Text = Trim(totaltime)
        Else
            lbl_time3.Text = "0:" & "" & Trim(totaltime)
        End If
    End Sub

    Private Sub Calculate_distance_and_time_4()
        Dim origin As String = lbl_origin4.Text
        Dim destination As String = lbl_destination4.Text
        Dim url As String = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" & origin & "&destinations=" & destination & "&key=AIzaSyBDJoTcSeGRvKUADN5kcNGIEyiVEvFAHrI"
        Dim request As WebRequest = WebRequest.Create(url)
        Using response As WebResponse = CType(request.GetResponse(), HttpWebResponse)
            Using reader As StreamReader = New StreamReader(response.GetResponseStream(), Encoding.UTF8)
                Dim dsResult As DataSet = New DataSet()
                dsResult.ReadXml(reader)
                lbl_time4.Text = dsResult.Tables("duration").Rows(0)("text").ToString()
                lbl_distance4.Text = dsResult.Tables("distance").Rows(0)("text").ToString()
            End Using
        End Using

        Dim total_time As String = Replace(lbl_time4.Text, "hours", ":")
        total_time = Replace(total_time, "hour", ":")
        total_time = Replace(total_time, "mins", " ")

        Dim i As Integer
        Dim a As String
        Dim b As String
        Dim totaltime As String
        For i = 1 To Len(total_time)
            a = Mid(total_time, i, 1)
            If a = ":" Then
                b = 1
            ElseIf a = " " Then
                a = ""
            End If
            totaltime = totaltime + a
        Next
        If b >= 1 Then
            lbl_time4.Text = Trim(totaltime)
        Else
            lbl_time4.Text = "0:" & "" & Trim(totaltime)
        End If
    End Sub

    Private Sub calculate_Rate()
        'Lor Rate or Ambulatory
        txt_tot_lrate_deadmiles.Text = Val(txt_qte_deadmiles.Text) * Val(txt_lrate_deadmiles.Text)
        txt_tot_lrate_loadedmiles.Text = Val(txt_qte_loadedmiles.Text) * Val(txt_lrate_loadedmiles.Text)
        txt_tot_lrate_leg.Text = Val(txt_qte_leg.Text) * Val(txt_lrate_leg.Text)
        txt_tot_lrate_waittime.Text = Val(txt_qte_waittime.Text) * Val(txt_lrate_waittime.Text)
        txt_tot_lrate_attendant.Text = Val(txt_qte_attendant.Text) * Val(txt_lrate_attendant.Text)
        txt_tot_lrate_rental.Text = Val(txt_qte_rental.Text) * Val(txt_lrate_rental.Text)
        txt_tot_lrate_bariatic.Text = Val(txt_qte_bariatic.Text) * Val(txt_lrate_bariatic.Text)
        txt_tot_lrate_stairs.Text = Val(txt_qte_stairs.Text) * Val(txt_lrate_stairs.Text)
        txt_tot_lrate_rush.Text = Val(txt_qte_rush.Text) * Val(txt_lrate_rush.Text)
        txt_tot_lrate_other.Text = Val(txt_qte_other.Text) * Val(txt_lrate_other.Text)
        txt_tot_lrate_afterhours.Text = Val(txt_qte_afterhours.Text) * Val(txt_lrate_afterhours.Text)

        'Mid Rate or Wheelchair
        txt_tot_mrate_deadmiles.Text = Val(txt_qte_deadmiles.Text) * Val(txt_mrate_deadmiles.Text)
        txt_tot_mrate_loadedmiles.Text = Val(txt_qte_loadedmiles.Text) * Val(txt_mrate_loadedmiles.Text)
        txt_tot_mrate_leg.Text = Val(txt_qte_leg.Text) * Val(txt_mrate_leg.Text)
        txt_tot_mrate_waittime.Text = Val(txt_qte_waittime.Text) * Val(txt_mrate_waittime.Text)
        txt_tot_mrate_attendant.Text = Val(txt_qte_attendant.Text) * Val(txt_mrate_attendant.Text)
        txt_tot_mrate_rental.Text = Val(txt_qte_rental.Text) * Val(txt_mrate_rental.Text)
        txt_tot_mrate_bariatic.Text = Val(txt_qte_bariatic.Text) * Val(txt_mrate_bariatic.Text)
        txt_tot_mrate_stairs.Text = Val(txt_qte_stairs.Text) * Val(txt_mrate_stairs.Text)
        txt_tot_mrate_rush.Text = Val(txt_qte_rush.Text) * Val(txt_mrate_rush.Text)
        txt_tot_mrate_other.Text = Val(txt_qte_other.Text) * Val(txt_mrate_other.Text)
        txt_tot_mrate_afterhours.Text = Val(txt_qte_afterhours.Text) * Val(txt_mrate_afterhours.Text)

        'High Rate or Stretcher
        txt_tot_hrate_deadmiles.Text = Val(txt_qte_deadmiles.Text) * Val(txt_hrate_deadmiles.Text)
        txt_tot_hrate_loadedmiles.Text = Val(txt_qte_loadedmiles.Text) * Val(txt_hrate_loadedmiles.Text)
        txt_tot_hrate_leg.Text = Val(txt_qte_leg.Text) * Val(txt_hrate_leg.Text)
        txt_tot_hrate_waittime.Text = Val(txt_qte_waittime.Text) * Val(txt_hrate_waittime.Text)
        txt_tot_hrate_attendant.Text = Val(txt_qte_attendant.Text) * Val(txt_hrate_attendant.Text)
        txt_tot_hrate_rental.Text = Val(txt_qte_rental.Text) * Val(txt_hrate_rental.Text)
        txt_tot_hrate_bariatic.Text = Val(txt_qte_bariatic.Text) * Val(txt_hrate_bariatic.Text)
        txt_tot_hrate_stairs.Text = Val(txt_qte_stairs.Text) * Val(txt_hrate_stairs.Text)
        txt_tot_hrate_rush.Text = Val(txt_qte_rush.Text) * Val(txt_hrate_rush.Text)
        txt_tot_hrate_other.Text = Val(txt_qte_other.Text) * Val(txt_hrate_other.Text)
        txt_tot_hrate_afterhours.Text = Val(txt_qte_afterhours.Text) * Val(txt_hrate_afterhours.Text)
    End Sub

    Private Sub calculate_Rate_totals()

        lbl_transport_lrate.Text = ""
        lbl_transport_mrate.Text = ""
        lbl_transport_hrate.Text = ""

        txt_total_hrate.Text = ""
        txt_total_lrate.Text = ""
        txt_total_mrate.Text = ""

        lbl_service_fee_lrate.Text = ""
        lbl_service_fee_mrate.Text = ""
        lbl_service_fee_hrate.Text = ""

        lbl_transport_lrate.Text = FormatNumber(Val(txt_tot_lrate_deadmiles.Text) + Val(txt_tot_lrate_loadedmiles.Text) + Val(txt_tot_lrate_leg.Text), 2)
        lbl_transport_mrate.Text = FormatNumber(Val(txt_tot_mrate_deadmiles.Text) + Val(txt_tot_mrate_loadedmiles.Text) + Val(txt_tot_mrate_leg.Text), 2)
        lbl_transport_hrate.Text = FormatNumber(Val(txt_tot_hrate_deadmiles.Text) + Val(txt_tot_hrate_loadedmiles.Text) + Val(txt_tot_hrate_leg.Text), 2)


        lbl_service_fee_lrate.Text = FormatNumber(Val(txt_tot_lrate_waittime.Text) + Val(txt_tot_lrate_attendant.Text) + Val(txt_tot_lrate_rental.Text) + Val(txt_tot_lrate_bariatic.Text) + Val(txt_tot_lrate_stairs.Text) + Val(txt_tot_lrate_rush.Text) + Val(txt_tot_lrate_other.Text) + Val(txt_tot_lrate_afterhours.Text), 2)
        lbl_service_fee_mrate.Text = FormatNumber(Val(txt_tot_mrate_waittime.Text) + Val(txt_tot_mrate_attendant.Text) + Val(txt_tot_mrate_rental.Text) + Val(txt_tot_mrate_bariatic.Text) + Val(txt_tot_mrate_stairs.Text) + Val(txt_tot_mrate_rush.Text) + Val(txt_tot_mrate_other.Text) + Val(txt_tot_mrate_afterhours.Text), 2)
        lbl_service_fee_hrate.Text = FormatNumber(Val(txt_tot_hrate_waittime.Text) + Val(txt_tot_hrate_attendant.Text) + Val(txt_tot_hrate_rental.Text) + Val(txt_tot_hrate_bariatic.Text) + Val(txt_tot_hrate_stairs.Text) + Val(txt_tot_hrate_rush.Text) + Val(txt_tot_hrate_other.Text) + Val(txt_tot_hrate_afterhours.Text), 2)


        txt_total_lrate.Text = FormatNumber(Val(txt_tot_lrate_deadmiles.Text) + Val(txt_tot_lrate_loadedmiles.Text) + Val(txt_tot_lrate_leg.Text) + Val(txt_tot_lrate_waittime.Text) + Val(txt_tot_lrate_attendant.Text) + Val(txt_tot_lrate_rental.Text) + Val(txt_tot_lrate_bariatic.Text) + Val(txt_tot_lrate_stairs.Text) + Val(txt_tot_lrate_rush.Text) + Val(txt_tot_lrate_other.Text) + Val(txt_tot_lrate_afterhours.Text), 2)
        txt_total_mrate.Text = FormatNumber(Val(txt_tot_mrate_deadmiles.Text) + Val(txt_tot_mrate_loadedmiles.Text) + Val(txt_tot_mrate_leg.Text) + Val(txt_tot_mrate_waittime.Text) + Val(txt_tot_mrate_attendant.Text) + Val(txt_tot_mrate_rental.Text) + Val(txt_tot_mrate_bariatic.Text) + Val(txt_tot_mrate_stairs.Text) + Val(txt_tot_mrate_rush.Text) + Val(txt_tot_mrate_other.Text) + Val(txt_tot_mrate_afterhours.Text), 2)
        txt_total_hrate.Text = FormatNumber(Val(txt_tot_hrate_deadmiles.Text) + Val(txt_tot_hrate_loadedmiles.Text) + Val(txt_tot_hrate_leg.Text) + Val(txt_tot_hrate_waittime.Text) + Val(txt_tot_hrate_attendant.Text) + Val(txt_tot_hrate_rental.Text) + Val(txt_tot_hrate_bariatic.Text) + Val(txt_tot_hrate_stairs.Text) + Val(txt_tot_hrate_rush.Text) + Val(txt_tot_hrate_other.Text) + Val(txt_tot_hrate_afterhours.Text), 2)

        txt_cancel_lrate.Text = FormatNumber(Val(txt_total_lrate.Text) / 2, 2)
        txt_cancel_mrate.Text = FormatNumber(Val(txt_total_mrate.Text) / 2, 2)
        txt_cancel_hrate.Text = FormatNumber(Val(txt_total_hrate.Text) / 2, 2)



    End Sub

    Private Sub Clean_master()

        txt_afterhours.Text = ""
        txt_attendant.Text = ""
        txt_bariatric.Text = ""
        txt_cancel_hrate.Text = ""
        txt_cancel_lrate.Text = ""
        txt_cancel_mrate.Text = ""
        txt_date.Text = Today
        txt_dropoff.Text = ""
        txt_hrate_afterhours.Text = ""
        txt_hrate_attendant.Text = ""
        txt_hrate_bariatic.Text = ""
        txt_hrate_deadmiles.Text = ""
        txt_hrate_leg.Text = ""
        txt_hrate_loadedmiles.Text = ""
        txt_hrate_other.Text = ""
        txt_hrate_rental.Text = ""
        txt_hrate_rush.Text = ""
        txt_hrate_stairs.Text = ""
        txt_hrate_waittime.Text = ""
        txt_lrate_afterhours.Text = ""
        txt_lrate_attendant.Text = ""
        txt_lrate_bariatic.Text = ""
        txt_lrate_deadmiles.Text = ""
        txt_lrate_leg.Text = ""
        txt_lrate_loadedmiles.Text = ""
        txt_lrate_other.Text = ""
        txt_lrate_rental.Text = ""
        txt_lrate_rush.Text = ""
        txt_lrate_stairs.Text = ""
        txt_lrate_waittime.Text = ""
        txt_mrate_afterhours.Text = ""
        txt_mrate_attendant.Text = ""
        txt_mrate_bariatic.Text = ""
        txt_mrate_deadmiles.Text = ""
        txt_mrate_loadedmiles.Text = ""
        txt_mrate_leg.Text = ""
        txt_mrate_other.Text = ""
        txt_mrate_rental.Text = ""
        txt_mrate_rush.Text = ""
        txt_mrate_stairs.Text = ""
        txt_mrate_waittime.Text = ""
        txt_other.Text = ""
        txt_pickup.Text = ""
        txt_qte_afterhours.Text = ""
        txt_qte_attendant.Text = ""
        txt_qte_bariatic.Text = ""
        txt_qte_deadmiles.Text = ""
        txt_qte_leg.Text = ""
        txt_qte_loadedmiles.Text = ""
        txt_qte_other.Text = ""
        txt_qte_rental.Text = ""
        txt_qte_rush.Text = ""
        txt_qte_stairs.Text = ""
        txt_qte_waittime.Text = ""
        txt_rental.Text = ""
        txt_rush.Text = ""
        txt_stairs.Text = ""
        txt_total_hrate.Text = ""
        txt_total_lrate.Text = ""
        txt_total_mrate.Text = ""
        txt_tot_hrate_afterhours.Text = ""
        txt_tot_hrate_attendant.Text = ""
        txt_tot_hrate_bariatic.Text = ""
        txt_tot_hrate_deadmiles.Text = ""
        txt_tot_hrate_leg.Text = ""
        txt_tot_hrate_loadedmiles.Text = ""
        txt_tot_hrate_other.Text = ""
        txt_tot_hrate_rental.Text = ""
        txt_tot_hrate_rush.Text = ""
        txt_tot_hrate_stairs.Text = ""
        txt_tot_hrate_waittime.Text = ""
        txt_tot_lrate_afterhours.Text = ""
        txt_tot_lrate_attendant.Text = ""
        txt_tot_lrate_bariatic.Text = ""
        txt_tot_lrate_deadmiles.Text = ""
        txt_tot_lrate_leg.Text = ""
        txt_tot_lrate_loadedmiles.Text = ""
        txt_tot_lrate_other.Text = ""
        txt_tot_lrate_rental.Text = ""
        txt_tot_lrate_rush.Text = ""
        txt_tot_lrate_stairs.Text = ""
        txt_tot_lrate_waittime.Text = ""
        txt_tot_mrate_afterhours.Text = ""
        txt_tot_mrate_attendant.Text = ""
        txt_tot_mrate_bariatic.Text = ""
        txt_tot_mrate_deadmiles.Text = ""
        txt_tot_mrate_leg.Text = ""
        txt_tot_mrate_loadedmiles.Text = ""
        txt_tot_mrate_other.Text = ""
        txt_tot_mrate_rental.Text = ""
        txt_tot_mrate_rush.Text = ""
        txt_tot_mrate_stairs.Text = ""
        txt_tot_mrate_waittime.Text = ""
        txt_waittime.Text = ""
        lbl_company_name.Text = ""
        lbl_destination0.Text = ""
        lbl_destination1.Text = ""
        lbl_destination2.Text = ""
        lbl_destination3.Text = ""
        lbl_destination4.Text = ""
        lbl_distance0.Text = ""
        lbl_distance1.Text = ""
        lbl_distance2.Text = ""
        lbl_distance3.Text = ""
        lbl_distance4.Text = ""
        lbl_origin0.Text = ""
        lbl_origin1.Text = ""
        lbl_origin2.Text = ""
        lbl_origin3.Text = ""
        lbl_origin4.Text = ""

        lbl_selection1.Text = ""
        lbl_selection2.Text = ""
        lbl_selection3.Text = ""
        lbl_time0.Text = ""
        lbl_time1.Text = ""
        lbl_time2.Text = ""
        lbl_time3.Text = ""
        lbl_time4.Text = ""
        lbl_total_distance_deadmile.Text = ""
        lbl_total_distance_loaded_miles.Text = ""
        lbl_total_time_deadmile.Text = ""
        lbl_total_time_loadedmiles.Text = ""
        rbtn_selection1.Checked = False
        rbtn_selection2.Checked = False
        rbtn_selection3.Checked = False
        ddl_flat_rate_option.Text = "--Select--"
        ddl_home.Text = "--Select--"
        ddl_type.Text = "--Select--"
        ll_add_new.Enabled = True
        ll_ok_itinerary.Enabled = True
        btn_cancel.Visible = True
        btn_reservation.Visible = True
    End Sub

    Private Sub Clean_Rate()
        'Low Rate or Ambulatory Rate

        txt_lrate_deadmiles.Text = ""
        txt_lrate_loadedmiles.Text = ""
        txt_lrate_leg.Text = ""
        txt_lrate_waittime.Text = ""
        txt_lrate_attendant.Text = ""
        txt_lrate_rental.Text = ""
        txt_lrate_bariatic.Text = ""
        txt_lrate_stairs.Text = ""
        txt_lrate_rush.Text = ""
        txt_lrate_other.Text = ""
        txt_lrate_afterhours.Text = ""

        'Mid Rate or Wheelchair

        txt_mrate_deadmiles.Text = ""
        txt_mrate_loadedmiles.Text = ""
        txt_mrate_leg.Text = ""
        txt_mrate_waittime.Text = ""
        txt_mrate_attendant.Text = ""
        txt_mrate_rental.Text = ""
        txt_mrate_bariatic.Text = ""
        txt_mrate_stairs.Text = ""
        txt_mrate_rush.Text = ""
        txt_mrate_other.Text = ""
        txt_mrate_afterhours.Text = ""

        'High Rate or Stretcher

        txt_hrate_deadmiles.Text = ""
        txt_hrate_loadedmiles.Text = ""
        txt_hrate_leg.Text = ""
        txt_hrate_waittime.Text = ""
        txt_hrate_attendant.Text = ""
        txt_hrate_rental.Text = ""
        txt_hrate_bariatic.Text = ""
        txt_hrate_stairs.Text = ""
        txt_hrate_rush.Text = ""
        txt_hrate_other.Text = ""
        txt_hrate_afterhours.Text = ""
    End Sub

    Private Sub Clear_error()
        DSerror.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from Error_Message ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSerror, "Error_Message")
    End Sub

    Private Sub Clear_Proforma()
        ''To clean the datasource and the datatable
        DSproforma.Clear()
        Adapters = Nothing
        Command = New SqlCommand("select * from proforma ", Connection)
        Adapters = New SqlDataAdapter(Command)
        Adapters.Fill(DSproforma, "proforma")
    End Sub

    Private Sub Extract_Deadmiles()

        lbl_total_distance_deadmile.Text = Replace(lbl_total_distance_deadmile.Text, "km", "Miles")

        Dim total_time As String = Replace(lbl_total_time_deadmile.Text, "hours", ":")
        total_time = Replace(total_time, "mins", " ")

        Dim i As Integer
        Dim a As String
        Dim b As String
        For i = 1 To Len(total_time)
            a = Mid(total_time, i, 1)
            If a = ":" Then
                b = 1
            End If
        Next
        If b >= 1 Then
            lbl_total_time_deadmile.Text = Trim(total_time)
        Else
            lbl_total_time_deadmile.Text = "0:" & "" & Trim(total_time)
        End If

    End Sub

    Private Sub Filter_Proforma()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Proforma  where proforma_id like '%" & lbl_id_proforma.Text & "%'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_proforma.DataSource = reader
            grd_proforma.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Filter Proforma"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()

        Publish_Proforma()
    End Sub

    Private Sub filter_SubCompany()
        Open_Connection()
        Connection.Open()


        Try
            If lbl_company.Text = "Flat Rate" Then

                Command = New SqlCommand("SELECT * from SubCompany where company_id = '" & lbl_company_id.Text & "' and name like '%" & ddl_flat_rate_option.Text & "%'", Connection)
            Else
                Command = New SqlCommand("SELECT * from SubCompany where company_id = '" & lbl_company_id.Text & "'", Connection)
            End If

            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_rates.DataSource = reader
            grd_rates.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Filter Sub-Company"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        publish_Rate()
    End Sub

    Private Sub Generate_ProformaID()
        ''To generate new Employe ID

        Dim Reader As SqlDataReader

        If Connection.State = ConnectionState.Closed Then
            Open_Connection()
            Connection.Open()
        End If
        Try

            Dim cmd As SqlCommand = New SqlCommand("select Proforma_id from proforma where proforma_id=(select max(proforma_id) from proforma) ", Connection)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If Reader.Read Then
                lbl_id_proforma.Text = Reader("Proforma_id").ToString()
                lbl_id_proforma.Text = Val(lbl_id_proforma.Text) + 1
                Exit Sub
            Else
                lbl_id_proforma.Text = "1000"
            End If
        Catch ex As Exception
            error_message = ex.Message & " - " & "Generate Proforma ID"
            Unexpected_Error()
            Save_Error()
        End Try
        Reader.Close()
        Connection.Close()

    End Sub

    Private Sub Load_Company()
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

    Private Sub Load_Location()
        'To lod the location list into the gridview
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Location", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_location.DataSource = reader
            grd_location.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Location"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()
        Publish_location()
    End Sub

    Private Sub Load_Proforma()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Proforma ", Connection)
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

    Private Sub Load_SubCompany()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from SubCompany where company_id = '" & lbl_company_id.Text & "'", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_rates.DataSource = reader
            grd_rates.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Sub-Company"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()

        Publish_subcompany
    End Sub

    Private Sub Load_Time()
        Open_Connection()
        Connection.Open()


        Try
            Command = New SqlCommand("SELECT * from Time", Connection)
            Dim reader As SqlDataReader
            reader = Command.ExecuteReader
            grd_time.DataSource = reader
            grd_time.DataBind()
        Catch ex As Exception
            error_message = ex.Message & " - " & "Load Time"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
        End Try
        Connection.Close()
        Connection.Dispose()

        Publish_Time()
    End Sub

    Private Sub Open_Connection()
        ''To open a connection between de database and the application
        Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("con").ConnectionString)
    End Sub

    Private Sub pass_address()
        If th_row0.Visible = True And lbl_origin0.Text = "" Then
            lbl_origin0.Text = txt_pickup.Text
            lbl_destination0.Text = txt_dropoff.Text
            Calculate_distance_and_time_Deadmiles()
            Calculate_distance_and_time_0()
        ElseIf th_row0.Visible = True And lbl_origin0.Text <> "" Then
            If th_row1.Visible = True And lbl_origin1.Text = "" Then

                lbl_origin1.Text = txt_pickup.Text
                lbl_destination1.Text = txt_dropoff.Text
                Calculate_distance_and_time_1()
            ElseIf th_row1.Visible = True And lbl_origin1.Text <> "" Then
                If th_row2.Visible = True And lbl_origin2.Text = "" Then

                    lbl_origin2.Text = txt_pickup.Text
                    lbl_destination2.Text = txt_dropoff.Text
                    Calculate_distance_and_time_2()
                ElseIf th_row2.Visible = True And lbl_origin2.Text <> "" Then
                    If th_row3.Visible = True And lbl_origin3.Text = "" Then

                        lbl_origin3.Text = txt_pickup.Text
                        lbl_destination3.Text = txt_dropoff.Text
                        Calculate_distance_and_time_3()
                    ElseIf th_row3.Visible = True And lbl_origin3.Text <> "" Then
                        If th_row4.Visible = True And lbl_origin4.Text = "" Then

                            lbl_origin4.Text = txt_pickup.Text
                            lbl_destination4.Text = txt_dropoff.Text
                            Calculate_distance_and_time_4()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Pass_Distance_Data()
        Dim i As Integer = Val(lbl_total_distance_deadmile.Text)
        Dim ii As Integer = Val(lbl_total_distance_loaded_miles.Text)

        txt_qte_deadmiles.Text = i
        txt_qte_loadedmiles.Text = ii
        Dim a As Integer
        Dim b As Integer
        Dim c As Integer
        Dim d As Integer
        Dim f As Integer

        If th_row0.Visible = True Then
            a = 1
        Else
            a = 0
        End If

        If th_row1.Visible = True Then
            b = 1
        Else
            b = 0
        End If

        If th_row2.Visible = True Then
            c = 1
        Else
            c = 0
        End If

        If th_row3.Visible = True Then
            d = 1
        Else
            d = 0
        End If

        If th_row4.Visible = True Then
            f = 1
        Else
            f = 0
        End If

        lbl_rowcount.Text = a + b + c + d + f
        txt_qte_leg.Text = lbl_rowcount.Text
    End Sub

    Private Sub Publish_location()
        Dim i As Integer
        Dim a As String

        ddl_home.Items.Add("--Select--")
        For i = 0 To grd_location.Rows.Count - 1
            a = grd_location.Rows.Item(i).Cells(1).Text

            ddl_home.Items.Add(a)
        Next
    End Sub

    Private Sub Publish_Proforma()
        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.Red

        If grd_proforma.Rows.Count <= 0 Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Proforma number doesn't exist"

            Exit Sub
        End If

        txt_date.Text = grd_proforma.Rows.Item(0).Cells(1).Text
        ddl_time.Text = grd_proforma.Rows.Item(0).Cells(2).Text
        ddl_type.Text = grd_proforma.Rows.Item(0).Cells(3).Text
        ddl_home.Text = grd_proforma.Rows.Item(0).Cells(4).Text
        lbl_origin0.Text = grd_proforma.Rows.Item(0).Cells(5).Text
        lbl_destination0.Text = grd_proforma.Rows.Item(0).Cells(6).Text
        lbl_time0.Text = grd_proforma.Rows.Item(0).Cells(7).Text
        lbl_distance0.Text = grd_proforma.Rows.Item(0).Cells(8).Text
        lbl_origin1.Text = grd_proforma.Rows.Item(0).Cells(9).Text
        lbl_destination1.Text = grd_proforma.Rows.Item(0).Cells(10).Text
        lbl_time1.Text = grd_proforma.Rows.Item(0).Cells(11).Text
        lbl_distance1.Text = grd_proforma.Rows.Item(0).Cells(12).Text

        lbl_origin2.Text = grd_proforma.Rows.Item(0).Cells(13).Text
        lbl_destination2.Text = grd_proforma.Rows.Item(0).Cells(14).Text
        lbl_time2.Text = grd_proforma.Rows.Item(0).Cells(15).Text
        lbl_distance2.Text = grd_proforma.Rows.Item(0).Cells(16).Text
        lbl_origin3.Text = grd_proforma.Rows.Item(0).Cells(17).Text
        lbl_destination3.Text = grd_proforma.Rows.Item(0).Cells(18).Text
        lbl_time3.Text = grd_proforma.Rows.Item(0).Cells(19).Text
        lbl_distance3.Text = grd_proforma.Rows.Item(0).Cells(20).Text
        lbl_origin4.Text = grd_proforma.Rows.Item(0).Cells(21).Text
        lbl_destination4.Text = grd_proforma.Rows.Item(0).Cells(22).Text
        lbl_time4.Text = grd_proforma.Rows.Item(0).Cells(23).Text
        lbl_distance4.Text = grd_proforma.Rows.Item(0).Cells(24).Text
        lbl_total_time_deadmile.Text = grd_proforma.Rows.Item(0).Cells(25).Text
        lbl_total_distance_deadmile.Text = grd_proforma.Rows.Item(0).Cells(26).Text
        lbl_total_time_loadedmiles.Text = grd_proforma.Rows.Item(0).Cells(27).Text
        lbl_total_distance_loaded_miles.Text = grd_proforma.Rows.Item(0).Cells(28).Text
        txt_qte_deadmiles.Text = grd_proforma.Rows.Item(0).Cells(29).Text
        txt_qte_loadedmiles.Text = grd_proforma.Rows.Item(0).Cells(30).Text
        txt_qte_leg.Text = grd_proforma.Rows.Item(0).Cells(31).Text
        txt_waittime.Text = grd_proforma.Rows.Item(0).Cells(32).Text
        txt_attendant.Text = grd_proforma.Rows.Item(0).Cells(33).Text
        txt_rental.Text = grd_proforma.Rows.Item(0).Cells(34).Text
        txt_bariatric.Text = grd_proforma.Rows.Item(0).Cells(35).Text
        txt_stairs.Text = grd_proforma.Rows.Item(0).Cells(36).Text
        txt_rush.Text = grd_proforma.Rows.Item(0).Cells(37).Text
        txt_other.Text = grd_proforma.Rows.Item(0).Cells(38).Text
        txt_afterhours.Text = grd_proforma.Rows.Item(0).Cells(39).Text
        lbl_company_name.Text = grd_proforma.Rows.Item(0).Cells(40).Text
        Dim servicename As String = grd_proforma.Rows.Item(0).Cells(41).Text

        If servicename = "Ambulatory" Then
            rbtn_selection1.Checked = True
        ElseIf servicename = "Wheelchair" Then
            rbtn_selection2.Checked = True
        ElseIf servicename = "Stretcher" Then
            rbtn_selection3.Checked = True
        End If


        If lbl_origin1.Text = "-" Then

            th_row1.Visible = False
        Else
            th_row1.Visible = True
        End If


        If lbl_origin2.Text = "-" Then

            th_row2.Visible = False
        Else
            th_row2.Visible = True
        End If

        If lbl_origin3.Text = "-" Then

            th_row3.Visible = False
        Else
            th_row3.Visible = True
        End If

        If lbl_origin4.Text = "-" Then

            th_row4.Visible = False
        Else
            th_row4.Visible = True
        End If




    End Sub

    Private Sub publish_Rate()


        'Low Rate or Ambulatory Rate

        txt_lrate_deadmiles.Text = grd_rates.Rows.Item(0).Cells(3).Text
        txt_lrate_loadedmiles.Text = grd_rates.Rows.Item(0).Cells(4).Text
        txt_lrate_leg.Text = grd_rates.Rows.Item(0).Cells(5).Text
        txt_lrate_waittime.Text = grd_rates.Rows.Item(0).Cells(6).Text
        txt_lrate_attendant.Text = grd_rates.Rows.Item(0).Cells(7).Text
        txt_lrate_rental.Text = grd_rates.Rows.Item(0).Cells(8).Text
        txt_lrate_bariatic.Text = grd_rates.Rows.Item(0).Cells(9).Text
        txt_lrate_stairs.Text = grd_rates.Rows.Item(0).Cells(10).Text
        txt_lrate_rush.Text = grd_rates.Rows.Item(0).Cells(11).Text
        txt_lrate_other.Text = grd_rates.Rows.Item(0).Cells(12).Text
        txt_lrate_afterhours.Text = grd_rates.Rows.Item(0).Cells(13).Text

        'Mid Rate or Wheelchair

        txt_mrate_deadmiles.Text = grd_rates.Rows.Item(1).Cells(3).Text
        txt_mrate_loadedmiles.Text = grd_rates.Rows.Item(1).Cells(4).Text
        txt_mrate_leg.Text = grd_rates.Rows.Item(1).Cells(5).Text
        txt_mrate_waittime.Text = grd_rates.Rows.Item(1).Cells(6).Text
        txt_mrate_attendant.Text = grd_rates.Rows.Item(1).Cells(7).Text
        txt_mrate_rental.Text = grd_rates.Rows.Item(1).Cells(8).Text
        txt_mrate_bariatic.Text = grd_rates.Rows.Item(1).Cells(9).Text
        txt_mrate_stairs.Text = grd_rates.Rows.Item(1).Cells(10).Text
        txt_mrate_rush.Text = grd_rates.Rows.Item(1).Cells(11).Text
        txt_mrate_other.Text = grd_rates.Rows.Item(1).Cells(12).Text
        txt_mrate_afterhours.Text = grd_rates.Rows.Item(1).Cells(13).Text

        'High Rate or Stretcher

        txt_hrate_deadmiles.Text = grd_rates.Rows.Item(2).Cells(3).Text
        txt_hrate_loadedmiles.Text = grd_rates.Rows.Item(2).Cells(4).Text
        txt_hrate_leg.Text = grd_rates.Rows.Item(2).Cells(5).Text
        txt_hrate_waittime.Text = grd_rates.Rows.Item(2).Cells(6).Text
        txt_hrate_attendant.Text = grd_rates.Rows.Item(2).Cells(7).Text
        txt_hrate_rental.Text = grd_rates.Rows.Item(2).Cells(8).Text
        txt_hrate_bariatic.Text = grd_rates.Rows.Item(2).Cells(9).Text
        txt_hrate_stairs.Text = grd_rates.Rows.Item(2).Cells(10).Text
        txt_hrate_rush.Text = grd_rates.Rows.Item(2).Cells(11).Text
        txt_hrate_other.Text = grd_rates.Rows.Item(2).Cells(12).Text
        txt_hrate_afterhours.Text = grd_rates.Rows.Item(2).Cells(13).Text


    End Sub

    Private Sub Publish_SubCompany()
        Clean_Rate()

        If lbl_company.Text = "Flat Rate" Then
            lbl_selection1.Text = "LOW"
            lbl_selection2.Text = "MID"
            lbl_selection3.Text = "HIGH"
            ddl_flat_rate_option.Visible = True
        Else
            lbl_selection1.Text = "AMBULATORY"
            lbl_selection2.Text = "WHEELCHAIR"
            lbl_selection3.Text = "STRETCHER"
            ddl_flat_rate_option.Visible = False

        End If
    End Sub

    Private Sub Publish_Time()
        Dim i As Integer
        Dim a As String

        For i = 0 To grd_time.Rows.Count - 1
            a = grd_time.Rows.Item(i).Cells(1).Text

            ddl_time.Items.Add(a)
        Next
    End Sub

    Private Sub Remove_row0()
        lbl_destination0.Text = ""
        lbl_distance0.Text = ""
        lbl_origin0.Text = ""
        lbl_time0.Text = ""
        th_row0.Visible = False
        ll_add_new.Visible = True
        Dim a As String = Val(lbl_rowcount.Text)
        a = a - 1
        lbl_rowcount.Text = a
    End Sub

    Private Sub Remove_row1()
        lbl_destination1.Text = ""
        lbl_distance1.Text = ""
        lbl_origin1.Text = ""
        lbl_time1.Text = ""
        th_row1.Visible = False
        ll_add_new.Visible = True
        Dim a As String = Val(lbl_rowcount.Text)
        a = a - 1
        lbl_rowcount.Text = a
    End Sub

    Private Sub Remove_row2()
        lbl_destination2.Text = ""
        lbl_distance2.Text = ""
        lbl_origin2.Text = ""
        lbl_time2.Text = ""
        th_row2.Visible = False
        ll_add_new.Visible = True
        Dim a As String = Val(lbl_rowcount.Text)
        a = a - 1
        lbl_rowcount.Text = a
    End Sub

    Private Sub Remove_row3()
        lbl_destination3.Text = ""
        lbl_distance3.Text = ""
        lbl_origin3.Text = ""
        lbl_time3.Text = ""
        th_row3.Visible = False
        ll_add_new.Visible = True
        Dim a As String = Val(lbl_rowcount.Text)
        a = a - 1
        lbl_rowcount.Text = a
    End Sub

    Private Sub Remove_row4()
        lbl_destination4.Text = ""
        lbl_distance4.Text = ""
        lbl_origin4.Text = ""
        lbl_time4.Text = ""
        th_row4.Visible = False
        ll_add_new.Visible = True
        Dim a As String = Val(lbl_rowcount.Text)
        a = a - 1
        lbl_rowcount.Text = a
    End Sub

    Private Sub Save_Error()
        Open_Connection()
        Connection.Open()
        Dim edate As Date = FormatDateTime(Today, DateFormat.ShortDate)
        Dim etime As Date = FormatDateTime(Now, DateFormat.LongTime)
        Dim page As String = "Proforma"
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

    Private Sub Save_Proforma()
        Open_Connection()
        Connection.Open()
        Dim total_rate As Double
        Dim cancel_rate As Double
        Dim status As String = "Reserved"
        Dim transport As Double
        Dim services As Double
        Dim servicename As String

        If rbtn_selection1.Checked Then
            transport = lbl_transport_lrate.Text
            services = lbl_service_fee_lrate.Text
            total_rate = txt_total_lrate.Text
            cancel_rate = txt_cancel_lrate.Text
            servicename = "Ambulatory"
        ElseIf rbtn_selection2.Checked Then
            transport = lbl_transport_mrate.Text
            services = lbl_service_fee_mrate.Text
            total_rate = txt_total_mrate.Text
            cancel_rate = txt_cancel_mrate.Text
            servicename = "Wheelchair"
        ElseIf rbtn_selection3.Checked = True Then
            transport = lbl_transport_hrate.Text
            services = lbl_service_fee_hrate.Text
            total_rate = txt_total_hrate.Text
            cancel_rate = txt_cancel_hrate.Text
            servicename = "Stretcher"
        End If





        Try
            Command = New SqlCommand("Insert into Proforma values('" & lbl_id_proforma.Text & "','" & txt_date.Text & "', '" & ddl_time.Text & "', '" & ddl_type.Text & "', '" & ddl_home.Text & "', '" & lbl_origin0.Text & "', '" & lbl_destination0.Text & "', '" & lbl_time0.Text & "', '" & lbl_distance0.Text & "', '" & lbl_origin1.Text & "', '" & lbl_destination1.Text & "', '" & lbl_time1.Text & "', '" & lbl_distance1.Text & "', '" & lbl_origin2.Text & "', '" & lbl_destination2.Text & "', '" & lbl_time2.Text & "', '" & lbl_distance2.Text & "', '" & lbl_origin3.Text & "', '" & lbl_destination3.Text & "', '" & lbl_time3.Text & "', '" & lbl_distance3.Text & "', '" & lbl_origin4.Text & "', '" & lbl_destination4.Text & "', '" & lbl_time4.Text & "', '" & lbl_distance4.Text & "', '" & lbl_total_time_deadmile.Text & "', '" & lbl_total_distance_deadmile.Text & "', '" & lbl_total_time_loadedmiles.Text & "', '" & lbl_total_distance_loaded_miles.Text & "', '" & txt_qte_deadmiles.Text & "', '" & txt_qte_loadedmiles.Text & "', '" & txt_qte_leg.Text & "', '" & txt_waittime.Text & "', '" & txt_attendant.Text & "', '" & txt_rental.Text & "', '" & txt_bariatric.Text & "', '" & txt_stairs.Text & "', '" & txt_rush.Text & "', '" & txt_other.Text & "', '" & txt_afterhours.Text & "', '" & lbl_company.Text & "', '" & servicename & "', '" & transport & "', '" & services & "', '" & total_rate & "', '" & cancel_rate & "', '" & status & "')", Connection)
            Command.ExecuteNonQuery()  'Execute un insert ou un update mais ne retourne rien
            Clear_Proforma
        Catch ex As Exception
            error_message = ex.Message & " - " & "Save Proforma"
            Unexpected_Error()
            Save_Error()
            Connection.Close()
            Exit Sub
        End Try
        Connection.Close()
        Connection.Dispose()

        Load_Proforma()

        Session.Add("Proforma ID", lbl_id_proforma.Text)
        Response.Redirect("~/Content/Reservation/Reservation.aspx")
    End Sub

    Private Sub Send_intake()

        txt_qte_waittime.Text = txt_waittime.Text
        txt_qte_attendant.Text = txt_attendant.Text
        txt_qte_rental.Text = txt_rental.Text
        txt_qte_bariatic.Text = txt_bariatric.Text
        txt_qte_stairs.Text = txt_stairs.Text
        txt_qte_rush.Text = txt_rush.Text
        txt_qte_other.Text = txt_other.Text
        txt_qte_afterhours.Text = txt_afterhours.Text
    End Sub

    Private Sub Unexpected_Error()
        lbl_comment.Visible = True
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed
        lbl_comment.BackColor = System.Drawing.Color.LightPink
        lbl_comment.Text = "Unexpected error. Please try again later or contact your system administrator"
    End Sub

    Private Sub Validate_distance()
        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed

        If lbl_total_distance_deadmile.Text = "" Then
            lbl_comment.Visible = True
            lbl_comment.Text = "Please select home point ans pick up destination before saving"

            Exit Sub
        End If

        If lbl_total_distance_loaded_miles.Text = "" Then
            lbl_comment.Text = "Please input destination push the 'Check Button' before saving"
            lbl_comment.Visible = True
            Exit Sub
        End If
        Pass_Distance_Data()
    End Sub

    Private Sub Validate_intake()
        If txt_waittime.Text = "" Then
            txt_waittime.Text = 0
        End If

        If txt_attendant.Text = "" Then
            txt_attendant.Text = 0
        End If

        If txt_rental.Text = "" Then
            txt_rental.Text = 0
        End If

        If txt_stairs.Text = "" Then
            txt_stairs.Text = 0
        End If

        If txt_bariatric.Text = "" Then
            txt_bariatric.Text = 0
        End If

        If txt_rush.Text = "" Then
            txt_rush.Text = 0
        End If

        If txt_other.Text = "" Then
            txt_other.Text = 0
        End If

        If txt_afterhours.Text = "" Then
            txt_afterhours.Text = 0
        End If

        Send_intake()
    End Sub

    Private Sub validate_itinerary()
        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed

        If txt_pickup.Text = "" Then

            lbl_comment.Text = "Please inser the pick up address"
            lbl_comment.Visible = True
            Exit Sub
        End If
        If txt_dropoff.Text = "" Then

            lbl_comment.Text = "Please inser the dropoff address"
            lbl_comment.Visible = True
            Exit Sub
        End If
        pass_address()
    End Sub

    Private Sub validate_Time_ad_Distance_Loaded_miles()
        If lbl_time0.Text = "" Then
            lbl_time0.Text = "0:00"
        End If

        If lbl_time1.Text = "" Then
            lbl_time1.Text = "0:00"
        End If
        If lbl_time2.Text = "" Then
            lbl_time2.Text = "0:00"
        End If

        If lbl_time3.Text = "" Then
            lbl_time3.Text = "0:00"
        End If

        If lbl_time4.Text = "" Then
            lbl_time4.Text = "0:00"
        End If

        If lbl_distance1.Text = "" Then
            lbl_distance1.Text = "0"
        End If

        If lbl_distance2.Text = "" Then
            lbl_distance2.Text = "0"
        End If

        If lbl_distance3.Text = "" Then
            lbl_distance3.Text = "0"
        End If

        If lbl_distance4.Text = "" Then
            lbl_distance4.Text = "0"
        End If
        calculate_distance_and_time_loaded_miles()
    End Sub

    Private Sub validate_Proforma()
        lbl_comment.Text = ""
        lbl_comment.ForeColor = System.Drawing.Color.DarkRed

        If lbl_company_name.Text = "" Then

            lbl_comment.Text = "Please choose a company from the list "
            lbl_comment.Visible = True
            Exit Sub
        End If

        If rbtn_selection1.Checked = False And rbtn_selection2.Checked = False And rbtn_selection3.Checked = False Then

            lbl_comment.Text = "Please choose from a rate list the one that will be applicable "
            lbl_comment.Visible = True
            Exit Sub
        End If

        If lbl_origin1.Text = "" Then
            lbl_origin1.Text = "-"
        End If

        If lbl_origin2.Text = "" Then
            lbl_origin2.Text = "-"
        End If

        If lbl_origin3.Text = "" Then
            lbl_origin3.Text = "-"
        End If

        If lbl_origin4.Text = "" Then
            lbl_origin4.Text = "-"
        End If

        If lbl_destination1.Text = "" Then
            lbl_destination1.Text = "-"
        End If

        If lbl_destination2.Text = "" Then
            lbl_destination2.Text = "-"
        End If

        If lbl_destination3.Text = "" Then
            lbl_destination3.Text = "-"
        End If

        If lbl_destination4.Text = "" Then
            lbl_destination4.Text = "-"
        End If

        If lbl_time1.Text = "" Then
            lbl_time1.Text = "0"
        End If

        If lbl_time2.Text = "" Then
            lbl_time2.Text = "0"
        End If

        If lbl_time3.Text = "" Then
            lbl_time3.Text = "0"
        End If

        If lbl_time4.Text = "" Then
            lbl_time4.Text = "0"
        End If

        If lbl_distance1.Text = "" Then
            lbl_distance1.Text = "0"
        End If

        If lbl_distance2.Text = "" Then
            lbl_distance2.Text = "0"
        End If

        If lbl_distance2.Text = "" Then
            lbl_distance2.Text = "0"
        End If

        If lbl_distance3.Text = "" Then
            lbl_distance3.Text = "0"
        End If


        If lbl_distance4.Text = "" Then
            lbl_distance4.Text = "0"
        End If


        Save_Proforma()
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then

        Else
            Clean_master()
            Load_Proforma()
            Load_Location()
            Load_Company()
            Load_Time()
            lbl_id_proforma.Text = Session("Proforma ID")
            If lbl_id_proforma.Text = "" Then

                Generate_ProformaID()
                btn_reservation.Visible = True
                btn_cancel.Visible = True
            Else
                btn_reservation.Visible = False
                btn_cancel.Visible = False
                Filter_Proforma()
            End If

        End If
    End Sub

    Private Sub ll_erase0_Click(sender As Object, e As EventArgs) Handles ll_erase0.Click

        lbl_comment.Visible = False
        Remove_row0()
    End Sub

    Private Sub ll_erase1_Click(sender As Object, e As EventArgs) Handles ll_erase1.Click
        lbl_comment.Visible = False
        Remove_row1()
    End Sub

    Private Sub ll_erase2_Click(sender As Object, e As EventArgs) Handles ll_erase2.Click

        lbl_comment.Visible = False
        Remove_row2()
    End Sub

    Private Sub ll_erase3_Click(sender As Object, e As EventArgs) Handles ll_erase3.Click
        lbl_comment.Visible = False
        Remove_row3()
    End Sub

    Private Sub ll_erase4_Click(sender As Object, e As EventArgs) Handles ll_erase4.Click
        lbl_comment.Visible = False
        Remove_row4()
    End Sub

    Private Sub ll_add_new_Click(sender As Object, e As EventArgs) Handles ll_add_new.Click
        lbl_comment.Visible = False
        Dim a As Integer = Val(lbl_rowcount.Text)

        a = a + 1
        If a = 4 Then
            ll_add_new.Visible = False
        End If
        lbl_rowcount.Text = a
        Add_row()
    End Sub

    Protected Sub ll_select_Click(sender As Object, e As EventArgs)
        lbl_comment.Visible = False
        Dim ll As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(ll.Parent.Parent, GridViewRow)
        Dim idx As Integer = row.RowIndex




        lbl_company_id.Text = grd_company.Rows.Item(idx).Cells(1).Text
        lbl_company.Text = grd_company.Rows.Item(idx).Cells(2).Text

        lbl_company_name.Text = lbl_company.Text
        Load_SubCompany()
        If lbl_company.Text <> "Flat Rate" Then
            filter_SubCompany()
        End If
        calculate_Rate()
        calculate_Rate_totals()
    End Sub

    Private Sub ddl_flat_rate_option_TextChanged(sender As Object, e As EventArgs) Handles ddl_flat_rate_option.TextChanged
        lbl_comment.Visible = False
        lbl_company_name.Text = ""
        lbl_company_name.Text = lbl_company.Text & " " & ddl_flat_rate_option.Text
        filter_SubCompany()

        calculate_Rate()
        calculate_Rate_totals()


    End Sub

    Private Sub btn_save_intake_Click(sender As Object, e As EventArgs) Handles btn_save_intake.Click
        lbl_comment.Visible = False
        Validate_intake()
    End Sub

    Private Sub ll_ok_itinerary_Click(sender As Object, e As EventArgs) Handles ll_ok_itinerary.Click
        lbl_comment.Visible = False
        validate_itinerary()
        validate_Time_ad_Distance_Loaded_miles()
    End Sub

    Private Sub btn_save_distance_Click(sender As Object, e As EventArgs) Handles btn_save_distance.Click
        lbl_comment.Visible = False
        Validate_distance()
    End Sub

    Private Sub cbx_loadedmiles_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_loadedmiles.CheckedChanged
        lbl_comment.Visible = False
        If cbx_loadedmiles.Checked = True Then
            txt_qte_loadedmiles.Text = 0
            txt_qte_loadedmiles.Enabled = False
            txt_lrate_loadedmiles.Enabled = False
            txt_tot_lrate_loadedmiles.Enabled = False
            txt_mrate_loadedmiles.Enabled = False
            txt_tot_mrate_loadedmiles.Enabled = False
            txt_hrate_loadedmiles.Enabled = False
            txt_tot_hrate_loadedmiles.Enabled = False
            txt_total_hrate.ReadOnly = False
            txt_total_lrate.ReadOnly = False
            txt_total_mrate.ReadOnly = False
            txt_cancel_hrate.ReadOnly = False
            txt_cancel_lrate.ReadOnly = False
            txt_cancel_mrate.ReadOnly = False
        ElseIf cbx_loadedmiles.Checked = False Then
            txt_qte_loadedmiles.Enabled = True
            txt_lrate_loadedmiles.Enabled = True
            txt_tot_lrate_loadedmiles.Enabled = True
            txt_mrate_loadedmiles.Enabled = True
            txt_tot_mrate_loadedmiles.Enabled = True
            txt_hrate_loadedmiles.Enabled = True
            publish_Rate()
            calculate_Rate()
            calculate_Rate_totals()

        End If
    End Sub

    Private Sub cbx_deadmiles_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_deadmiles.CheckedChanged

        lbl_comment.Visible = False
        If cbx_deadmiles.Checked = True Then
            txt_qte_deadmiles.Text = 0
            txt_qte_deadmiles.Enabled = False
            txt_lrate_deadmiles.Enabled = False
            txt_tot_lrate_deadmiles.Enabled = False
            txt_mrate_deadmiles.Enabled = False
            txt_tot_mrate_deadmiles.Enabled = False
            txt_hrate_deadmiles.Enabled = False
            txt_tot_hrate_deadmiles.Enabled = False
            txt_total_hrate.ReadOnly = False
            txt_total_lrate.ReadOnly = False
            txt_total_mrate.ReadOnly = False
            txt_cancel_hrate.ReadOnly = False
            txt_cancel_lrate.ReadOnly = False
            txt_cancel_mrate.ReadOnly = False
        ElseIf cbx_deadmiles.Checked = False Then
            txt_qte_deadmiles.Enabled = True
            txt_lrate_deadmiles.Enabled = True
            txt_tot_lrate_deadmiles.Enabled = True
            txt_mrate_deadmiles.Enabled = True
            txt_tot_mrate_deadmiles.Enabled = True
            txt_hrate_deadmiles.Enabled = True
            txt_tot_hrate_deadmiles.Enabled = True
            publish_Rate()
            calculate_Rate()
            calculate_Rate_totals()
        End If
    End Sub

    Private Sub cbx_leg_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_leg.CheckedChanged
        lbl_comment.Visible = False
        If cbx_leg.Checked = True Then
            txt_qte_leg.Text = 0
            txt_qte_leg.Enabled = False
            txt_lrate_leg.Enabled = False
            txt_tot_lrate_leg.Enabled = False
            txt_mrate_leg.Enabled = False
            txt_tot_mrate_leg.Enabled = False
            txt_hrate_leg.Enabled = False
            txt_tot_hrate_leg.Enabled = False
            txt_total_hrate.ReadOnly = False
            txt_total_lrate.ReadOnly = False
            txt_total_mrate.ReadOnly = False
            txt_cancel_hrate.ReadOnly = False
            txt_cancel_lrate.ReadOnly = False
            txt_cancel_mrate.ReadOnly = False
        ElseIf cbx_leg.Checked = False Then
            txt_qte_leg.Enabled = True
            txt_lrate_leg.Enabled = True
            txt_tot_lrate_leg.Enabled = True
            txt_mrate_leg.Enabled = True
            txt_tot_mrate_leg.Enabled = True
            txt_hrate_leg.Enabled = True
            txt_tot_hrate_leg.Enabled = True
            publish_Rate()
            calculate_Rate()
            calculate_Rate_totals()
        End If
    End Sub

    Private Sub cbx_waittime_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_waittime.CheckedChanged
        lbl_comment.Visible = False
        If cbx_waittime.Checked = True Then
            txt_qte_waittime.Text = 0
            txt_qte_waittime.Enabled = False
            txt_lrate_waittime.Enabled = False
            txt_tot_lrate_waittime.Enabled = False
            txt_mrate_waittime.Enabled = False
            txt_tot_mrate_waittime.Enabled = False
            txt_hrate_waittime.Enabled = False
            txt_tot_hrate_waittime.Enabled = False
            txt_total_hrate.ReadOnly = False
            txt_total_lrate.ReadOnly = False
            txt_total_mrate.ReadOnly = False
            txt_cancel_hrate.ReadOnly = False
            txt_cancel_lrate.ReadOnly = False
            txt_cancel_mrate.ReadOnly = False
        ElseIf cbx_waittime.Checked = False Then
            txt_qte_waittime.Enabled = True
            txt_lrate_waittime.Enabled = True
            txt_tot_lrate_waittime.Enabled = True
            txt_mrate_waittime.Enabled = True
            txt_tot_mrate_waittime.Enabled = True
            txt_hrate_waittime.Enabled = True
            txt_tot_hrate_waittime.Enabled = True
            publish_Rate()
            calculate_Rate()
            calculate_Rate_totals()
        End If
    End Sub

    Private Sub cbx_attendant_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_attendant.CheckedChanged
        lbl_comment.Visible = False
        If cbx_attendant.Checked = True Then
            txt_qte_attendant.Text = 0
            txt_qte_attendant.Enabled = False
            txt_lrate_attendant.Enabled = False
            txt_tot_lrate_attendant.Enabled = False
            txt_mrate_attendant.Enabled = False
            txt_tot_mrate_attendant.Enabled = False
            txt_hrate_attendant.Enabled = False
            txt_tot_hrate_attendant.Enabled = False
            txt_total_hrate.ReadOnly = False
            txt_total_lrate.ReadOnly = False
            txt_total_mrate.ReadOnly = False
            txt_cancel_hrate.ReadOnly = False
            txt_cancel_lrate.ReadOnly = False
            txt_cancel_mrate.ReadOnly = False
        ElseIf cbx_attendant.Checked = False Then
            txt_qte_attendant.Enabled = True
            txt_lrate_attendant.Enabled = True
            txt_tot_lrate_attendant.Enabled = True
            txt_mrate_attendant.Enabled = True
            txt_tot_mrate_attendant.Enabled = True
            txt_hrate_attendant.Enabled = True
            txt_tot_hrate_attendant.Enabled = True
            publish_Rate()
            calculate_Rate()
            calculate_Rate_totals()
        End If
    End Sub

    Private Sub cbx_rental_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_rental.CheckedChanged
        lbl_comment.Visible = False
        If cbx_rental.Checked = True Then
            txt_qte_rental.Text = 0
            txt_qte_rental.Enabled = False
            txt_lrate_rental.Enabled = False
            txt_tot_lrate_rental.Enabled = False
            txt_mrate_rental.Enabled = False
            txt_tot_mrate_rental.Enabled = False
            txt_hrate_rental.Enabled = False
            txt_tot_hrate_rental.Enabled = False
            txt_total_hrate.ReadOnly = False
            txt_total_lrate.ReadOnly = False
            txt_total_mrate.ReadOnly = False
            txt_cancel_hrate.ReadOnly = False
            txt_cancel_lrate.ReadOnly = False
            txt_cancel_mrate.ReadOnly = False
        ElseIf cbx_rental.Checked = False Then
            txt_qte_rental.Enabled = True
            txt_lrate_rental.Enabled = True
            txt_tot_lrate_rental.Enabled = True
            txt_mrate_rental.Enabled = True
            txt_tot_mrate_rental.Enabled = True
            txt_hrate_rental.Enabled = True
            txt_tot_hrate_rental.Enabled = True
            publish_Rate()
            calculate_Rate()
            calculate_Rate_totals()
        End If
    End Sub

    Private Sub cbx_bariatic_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_bariatic.CheckedChanged
        lbl_comment.Visible = False
        If cbx_bariatic.Checked = True Then
            txt_qte_bariatic.Text = 0
            txt_qte_bariatic.Enabled = False
            txt_lrate_bariatic.Enabled = False
            txt_tot_lrate_bariatic.Enabled = False
            txt_mrate_bariatic.Enabled = False
            txt_tot_mrate_bariatic.Enabled = False
            txt_hrate_bariatic.Enabled = False
            txt_tot_hrate_bariatic.Enabled = False
            txt_total_hrate.ReadOnly = False
            txt_total_lrate.ReadOnly = False
            txt_total_mrate.ReadOnly = False
            txt_cancel_hrate.ReadOnly = False
            txt_cancel_lrate.ReadOnly = False
            txt_cancel_mrate.ReadOnly = False
        ElseIf cbx_bariatic.Checked = False Then
            txt_qte_bariatic.Enabled = True
            txt_lrate_bariatic.Enabled = True
            txt_tot_lrate_bariatic.Enabled = True
            txt_mrate_bariatic.Enabled = True
            txt_tot_mrate_bariatic.Enabled = True
            txt_hrate_bariatic.Enabled = True
            txt_tot_hrate_bariatic.Enabled = True
            publish_Rate()
            calculate_Rate()
            calculate_Rate_totals()
        End If
    End Sub

    Private Sub cbx_stairs_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_stairs.CheckedChanged
        lbl_comment.Visible = False
        If cbx_stairs.Checked = True Then
            txt_qte_stairs.Text = 0
            txt_qte_stairs.Enabled = False
            txt_lrate_stairs.Enabled = False
            txt_tot_lrate_stairs.Enabled = False
            txt_mrate_stairs.Enabled = False
            txt_tot_mrate_stairs.Enabled = False
            txt_hrate_stairs.Enabled = False
            txt_tot_hrate_stairs.Enabled = False
            txt_total_hrate.ReadOnly = False
            txt_total_lrate.ReadOnly = False
            txt_total_mrate.ReadOnly = False
            txt_cancel_hrate.ReadOnly = False
            txt_cancel_lrate.ReadOnly = False
            txt_cancel_mrate.ReadOnly = False
        ElseIf cbx_stairs.Checked = False Then
            txt_qte_stairs.Enabled = True
            txt_lrate_stairs.Enabled = True
            txt_tot_lrate_stairs.Enabled = True
            txt_mrate_stairs.Enabled = True
            txt_tot_mrate_stairs.Enabled = True
            txt_hrate_stairs.Enabled = True
            txt_tot_hrate_stairs.Enabled = True
            publish_Rate()
            calculate_Rate()
            calculate_Rate_totals()
        End If
    End Sub

    Private Sub cbx_rush_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_rush.CheckedChanged
        lbl_comment.Visible = False
        If cbx_rush.Checked = True Then
            txt_qte_rush.Text = 0
            txt_qte_rush.Enabled = False
            txt_lrate_rush.Enabled = False
            txt_tot_lrate_rush.Enabled = False
            txt_mrate_rush.Enabled = False
            txt_tot_mrate_rush.Enabled = False
            txt_hrate_rush.Enabled = False
            txt_tot_hrate_rush.Enabled = False
            txt_total_hrate.ReadOnly = False
            txt_total_lrate.ReadOnly = False
            txt_total_mrate.ReadOnly = False
            txt_cancel_hrate.ReadOnly = False
            txt_cancel_lrate.ReadOnly = False
            txt_cancel_mrate.ReadOnly = False
        ElseIf cbx_rush.Checked = False Then
            txt_qte_rush.Enabled = True
            txt_lrate_rush.Enabled = True
            txt_tot_lrate_rush.Enabled = True
            txt_mrate_rush.Enabled = True
            txt_tot_mrate_rush.Enabled = True
            txt_hrate_rush.Enabled = True
            txt_tot_hrate_rush.Enabled = True
            publish_Rate()
            calculate_Rate()
            calculate_Rate_totals()
        End If
    End Sub

    Private Sub cbx_other_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_other.CheckedChanged
        lbl_comment.Visible = False
        If cbx_other.Checked = True Then
            txt_qte_other.Text = 0
            txt_qte_other.Enabled = False
            txt_lrate_other.Enabled = False
            txt_tot_lrate_other.Enabled = False
            txt_mrate_other.Enabled = False
            txt_tot_mrate_other.Enabled = False
            txt_hrate_other.Enabled = False
            txt_tot_hrate_other.Enabled = False
            txt_total_hrate.ReadOnly = False
            txt_total_lrate.ReadOnly = False
            txt_total_mrate.ReadOnly = False
            txt_cancel_hrate.ReadOnly = False
            txt_cancel_lrate.ReadOnly = False
            txt_cancel_mrate.ReadOnly = False
        ElseIf cbx_other.Checked = False Then
            txt_qte_other.Enabled = True
            txt_lrate_other.Enabled = True
            txt_tot_lrate_other.Enabled = True
            txt_mrate_other.Enabled = True
            txt_tot_mrate_other.Enabled = True
            txt_hrate_other.Enabled = True
            txt_tot_hrate_other.Enabled = True
            publish_Rate()
            calculate_Rate()
            calculate_Rate_totals()
        End If
    End Sub

    Private Sub cbx_afterhours_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_afterhours.CheckedChanged
        lbl_comment.Visible = False
        If cbx_afterhours.Checked = True Then
            txt_qte_afterhours.Text = 0
            txt_qte_afterhours.Enabled = False
            txt_lrate_afterhours.Enabled = False
            txt_tot_lrate_afterhours.Enabled = False
            txt_mrate_afterhours.Enabled = False
            txt_tot_mrate_afterhours.Enabled = False
            txt_hrate_afterhours.Enabled = False
            txt_tot_hrate_afterhours.Enabled = False
            txt_total_hrate.ReadOnly = False
            txt_total_lrate.ReadOnly = False
            txt_total_mrate.ReadOnly = False
            txt_cancel_hrate.ReadOnly = False
            txt_cancel_lrate.ReadOnly = False
            txt_cancel_mrate.ReadOnly = False
        ElseIf cbx_afterhours.Checked = False Then
            txt_qte_afterhours.Enabled = True
            txt_lrate_afterhours.Enabled = True
            txt_tot_lrate_afterhours.Enabled = True
            txt_mrate_afterhours.Enabled = True
            txt_tot_mrate_afterhours.Enabled = True
            txt_hrate_afterhours.Enabled = True
            txt_tot_hrate_afterhours.Enabled = True
            publish_Rate()
            calculate_Rate()
            calculate_Rate_totals()
        End If
    End Sub

    Private Sub btn_calculate_Click(sender As Object, e As EventArgs) Handles btn_calculate.Click
        lbl_comment.Visible = False
        calculate_Rate()
        calculate_Rate_totals()
    End Sub

    Private Sub btn_reservation_Click(sender As Object, e As EventArgs) Handles btn_reservation.Click
        lbl_comment.Visible = False
        validate_Proforma()

    End Sub

    Private Sub ll_close_Click(sender As Object, e As EventArgs) Handles ll_close.Click
        Dim place As String = Session("Place")
        If place = "Database" Then
            Response.Redirect("~/Content/Proforma/Proforma_Database.aspx")
        ElseIf place = "Calendar Database" Then
            Response.Redirect("~/Content/Reservation/Database.aspx")
        ElseIf place = "Calendar" Then
            Response.Redirect("~/Content/Reservation/Calendar.aspx")
        End If

    End Sub

    Private Sub Proforma_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Clean_master()
    End Sub

End Class