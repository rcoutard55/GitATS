<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="Proforma.aspx.vb" Inherits="American_Transit_Services_LLC.Proforma" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs.jquery/3/4.1/jquery.min.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBDJoTcSeGRvKUADN5kcNGIEyiVEvFAHrI&libraries=places&callback=initMap&solution_channel=GMP_QB_addressselection_v1_cABC" async defer></script>

    <script lang="javascript" type="text/javascript">
        function SelecRadiobutton(radio) {
            var rdBtn = document.getElementById(radio.id);
            var rdBtnList = document.getElementsByTagName("input");
            for (i = 0, i < rdBtnList.length; i++) {
                if (rdBtnList[i].type == "radio" && rdBtnList[i].id != rdBtn.id) {
                    rdBtnList[i].checked = false;
                }
            }
        }
    </script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false&libraries=places&key=AIzaSyBDJoTcSeGRvKUADN5kcNGIEyiVEvFAHrI"></script>
    <script type="text/javascript">
        google.maps.event.addDomListener(window, 'load', function () {
            var places = new google.maps.places.Autocomplete(document.getElementById('<%=txt_pickup.ClientID %>'));
                                                        var places = new google.maps.places.Autocomplete(document.getElementById('<%=txt_dropoff.ClientID %>'));
                                                        google.maps.event.addListener(places, 'place_changed', function () {
                                                            var place = places.getPlace();
                                                            document.getElementById('<%=lbl_origin0.ClientID %>').value = place.formatted_address;
                                                            document.getElementById('<%=lbl_destination0.ClientID %>').value = place.formatted_address;
                                                        });
                                                    });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row" style="background-color: white">
        <div class="col-md-12">
            <br />
            <div class="row">
                <div class="col-md-5">
                    <label class="header-text">Proforma #<asp:Label ID="lbl_id_proforma" runat="server" Text=""></asp:Label></label>
                </div>
                <div class="col-md-6" style="text-align:right">
                    <asp:LinkButton ID="ll_close" CssClass="close-control" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
            
            <br />
            <div class="row line"></div>
            <br />

            <div class="row">
                <div class="col">
                    <div class="card">
                        <div class="card-header">
                            <label>Pick up & Drop Off information</label>
                        </div>
                        <div class="card-body">
                            <br />
                            <div class="row">
                                <div class="col">
                                    <br />
                                    <div class="row">
                                <div class="col" style="margin-top: 20px;">
                                    <asp:Label ID="lbl_comment" CssClass="comment container-fluid form-control" runat="server" Visible="false" Text=""></asp:Label>
                                </div>
                            </div>
                                    <div class="card">
                                        <div class="card-header">
                                            <label><i class="fas fa-clock"></i> Date, Time & transport Type</label>
                                        </div>
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <label style="color:black"><i class="far fa-calendar-alt"></i> Date</label>
                                                    <asp:TextBox ID="txt_date" CssClass="container-fluid form-control" TextMode="Date" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-4">
                                                    <label style="color:black"><i class="fas fa-hourglass-half"></i> Appointment Time</label>
                                                    
                                                    <asp:DropDownList ID="ddl_time" CssClass="container-fluid form-control" runat="server">
                                                        <asp:ListItem Text="--Select--" Value="--Select--" />
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-4">
                                                    <label style="color:black"><i class="fas fa-ambulance"></i> Transport Type</label>
                                                    <asp:DropDownList ID="ddl_type" CssClass="container-fluid form-control" runat="server">
                                                        <asp:ListItem Text="--Select--" Value="--Select--" />
                                                        <asp:ListItem Text="One Way Trip" Value="One Way Trip" />
                                                        <asp:ListItem Text="Round Trip" Value="Round Trip" />
                                                        <asp:ListItem Text="Multiple" Value="Multiple" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="card-header">
                                            <label><i class="fas fa-directions"></i> Itinerary</label>
                                        </div>
                                        <div class="card-body">
                                           
                                            <div class="row">
                                                <div class="col-md-8">
                                                    <label style="color:black"><i class="fas fa-home"></i> Select Home Point</label>
                                                    <asp:DropDownList ID="ddl_home" CssClass="container-fluid form-control" runat="server">
                                                        <asp:ListItem Text="--Select--" Value="--Select"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                </div>
                                            <hr />
                                                <div class="row">
                                                <div class="col-md-5">
                                                    <label style="color:black"><i class="far fa-dot-circle"></i> Pick Up</label>
                                                    <asp:TextBox ID="txt_pickup" CssClass="container-fluid form-control" Placeholder="Origin" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-5">
                                                    <label style="color:black"><i class="fas fa-map-marker-alt"></i> Drop Off</label>
                                                    <asp:TextBox ID="txt_dropoff" CssClass="container-fluid form-control" Placeholder="Destination" runat="server"></asp:TextBox>
                                                </div>
                                                     
                                                <div class="col-md-1" style="margin-top:25px">
                                                    <asp:LinkButton ID="ll_ok_itinerary" ForeColor="Green" Font-Size="x-large" CssClass="link10" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="ll_add_new" ForeColor="SteelBlue" Font-Size="x-large" CssClass="link10" runat="server"><i class="fas fa-plus-circle"></i></asp:LinkButton>
                                                    
                                                </div>
                                                
                                            </div>
                                                     
                                            
                                            <br />
                                            <div class="row">
                                                <div class="col">
                                                    <asp:Table ID="table1" CssClass="table container-fluid" runat="server">
                                                        <asp:TableHeaderRow CssClass="th-row" BackColor="steelblue" >
                                                            <asp:TableHeaderCell CssClass="th-text" Width="320">
                                                                <label style="text-align:center" class="header-label-header2 container-fluid form-control" >Origin</label>
                                                            </asp:TableHeaderCell>
                                                            <asp:TableHeaderCell CssClass="th-text" Width="320">
                                                                <label style="text-align:center"  class="header-label-header2 container-fluid form-control">Destination</label>
                                                            </asp:TableHeaderCell>
                                                            <asp:TableHeaderCell CssClass="th-number" Width="120" >
                                                                <label style="text-align:center;"  class="header-label-header2 container-fluid form-control">Time</label>
                                                            </asp:TableHeaderCell>
                                                            <asp:TableHeaderCell CssClass="th-number" Width="120">
                                                                <label style="text-align:center;" class="header-label-header2 container-fluid form-control">Distance</label>
                                                            </asp:TableHeaderCell>
                                                            <asp:TableHeaderCell CssClass="th-link">
                                                                
                                                            </asp:TableHeaderCell>
                                                        </asp:TableHeaderRow>
                                                        <asp:TableRow CssClass="th-row" ID="th_row0" runat="server">
                                                            <asp:TableCell>
                                                                <asp:Label ForeColor="Black" ID="lbl_origin0" CssClass="row-text container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell>
                                                                <asp:Label ForeColor="black" ID="lbl_destination0" CssClass="row-text container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell Style="text-align: right">
                                                                <asp:Label forecolor="black" ID="lbl_time0" CssClass="row-number container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell Style="text-align: right">
                                                                <asp:Label forecolor="black" ID="lbl_distance0" CssClass="row-number container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell Style="text-align: center">
                                                                <asp:LinkButton ID="ll_erase0" CssClass="control-close2" runat="server"><i class="fas fa-minus-circle"></i></asp:LinkButton>
                                                            </asp:TableCell>
                                                        </asp:TableRow>
                                                        <asp:TableRow CssClass="th-row" ID="th_row1" runat="server" Visible="false">
                                                            <asp:TableCell>
                                                                <asp:Label forecolor="black" ID="lbl_origin1" CssClass="row-text container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell>
                                                                <asp:Label forecolor="black"  ID="lbl_destination1" CssClass="row-text container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell Style="text-align: right">
                                                                <asp:Label forecolor="black" ID="lbl_time1" CssClass="row-number container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell Style="text-align: right">
                                                                <asp:Label forecolor="black" ID="lbl_distance1" CssClass="row-number container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell Style="text-align: center">
                                                                <asp:LinkButton ID="ll_erase1" CssClass="control-close2" runat="server"><i class="fas fa-minus-circle"></i></asp:LinkButton>
                                                            </asp:TableCell>
                                                        </asp:TableRow>
                                                        <asp:TableRow CssClass="th-row" ID="th_row2" runat="server" Visible="false">
                                                            <asp:TableCell>
                                                                <asp:Label forecolor="black" ID="lbl_origin2" CssClass="row-text container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell>
                                                                <asp:Label forecolor="black" ID="lbl_destination2" CssClass="row-text container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell Style="text-align: right">
                                                                <asp:Label forecolor="black" ID="lbl_time2" CssClass="row-number container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell Style="text-align: right">
                                                                <asp:Label forecolor="black" ID="lbl_distance2" CssClass="row-number container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell Style="text-align: center">
                                                                <asp:LinkButton ID="ll_erase2" CssClass="control-close2" runat="server"><i class="fas fa-minus-circle"></i></asp:LinkButton>
                                                            </asp:TableCell>
                                                        </asp:TableRow>
                                                        <asp:TableRow CssClass="th-row" ID="th_row3" runat="server" Visible="false">
                                                            <asp:TableCell>
                                                                <asp:Label forecolor="black" ID="lbl_origin3" CssClass="row-text container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell>
                                                                <asp:Label forecolor="black" ID="lbl_destination3" CssClass="row-text container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell  Style="text-align: right">
                                                                <asp:Label forecolor="black" ID="lbl_time3" CssClass="row-number container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell Style="text-align: right">
                                                                <asp:Label forecolor="black" ID="lbl_distance3" CssClass="row-number container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell Style="text-align: center">
                                                                <asp:LinkButton ID="ll_erase3" CssClass="control-close2" runat="server"><i class="fas fa-minus-circle"></i></asp:LinkButton>
                                                            </asp:TableCell>
                                                        </asp:TableRow>
                                                        <asp:TableRow CssClass="th-row" ID="th_row4" runat="server" Visible="false">
                                                            <asp:TableCell>
                                                                <asp:Label forecolor="black" ID="lbl_origin4" CssClass="row-text container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell>
                                                                <asp:Label forecolor="black" ID="lbl_destination4" CssClass="row-text container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell Style="text-align: right">
                                                                <asp:Label forecolor="black" ID="lbl_time4" CssClass="row-number container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell Style="text-align: right">
                                                                <asp:Label ID="lbl_distance4" CssClass="row-number container-fluid form-control" runat="server" Text=""></asp:Label>
                                                            </asp:TableCell>
                                                            <asp:TableCell Style="text-align: center">
                                                                <asp:LinkButton ID="ll_erase4" CssClass="control-close2" runat="server"><i class="fas fa-minus-circle"></i></asp:LinkButton>
                                                            </asp:TableCell>
                                                        </asp:TableRow>
                                                    </asp:Table>
                                                    <asp:Label ID="lbl_rowcount" Visible="false" runat="server" Text="0"></asp:Label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5">
                                                    <div class="card">
                                                        <div class="card-header">
                                                            <label>Dead Miles</label>
                                                        </div>
                                                        <div class="card-body">

                                                            <div class="row">
                                                                <div class="col-md-2" style="text-align: right">
                                                                    <label style="margin-top: 30px; font-weight: bold; font-size: medium; color:black"">Total</label>
                                                                </div>
                                                                <div class="col-md-5" style="text-align: center">
                                                                    <label style="font-weight: bold; font-size: medium; color:black"">Time</label>
                                                                    <asp:TextBox ID="lbl_total_time_deadmile" CssClass="container-fluid form-control" Style="text-align: right" Enabled="false" runat="server"></asp:TextBox>
                                                                </div>
                                                                <div class="col-md-5" style="text-align: center">
                                                                    <label  style="font-weight: bold; font-size: medium; color:black"">Distance</label>
                                                                    <asp:TextBox ID="lbl_total_distance_deadmile" CssClass="container-fluid form-control" Style="text-align: right" Enabled="false" runat="server"></asp:TextBox>
                                                                </div>
                                                             
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-5">
                                                    <div class="card">
                                                        <div class="card-header">
                                                            <label>Loaded Miles</label>
                                                        </div>
                                                        <div class="card-body">

                                                            <div class="row">
                                                                <div class="col-md-2" style="text-align: right">
                                                                    <label style="margin-top: 30px; font-weight: bold; font-size: medium; color:black"">Total</label>
                                                                </div>
                                                                <div class="col-md-5" style="text-align: center">
                                                                    <label style="font-weight: bold; font-size: medium; color:black"">Time</label>
                                                                    <asp:TextBox ID="lbl_total_time_loadedmiles" CssClass="container-fluid form-control" Style="text-align: right" Enabled="false" runat="server"></asp:TextBox>
                                                                </div>
                                                                <div class="col-md-5" style="text-align: center">
                                                                    <label  style="font-weight: bold; font-size: medium; color:black"">Distance</label>
                                                                    <asp:TextBox ID="lbl_total_distance_loaded_miles" CssClass="container-fluid form-control" Style="text-align: right" Enabled="false" runat="server"></asp:TextBox>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="row">
                                                        <div class="col">
                                                            <asp:Button ID="btn_save_distance" CssClass="btn1 container-fluid form-control" runat="server" Text="GO" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="card-header">
                                            <label><i class="fas fa-edit"></i> Intake</label>
                                        </div>
                                        <div class="card-body">
                                            <br />
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <label style="color:black; font-size:small"><i class="fas fa-hourglass-half"></i> Wait Time</label>
                                                    <asp:TextBox ID="txt_waittime" Style="text-align:center"  CssClass="container-fluid form-control" TextMode="number" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2">
                                                    <label style="color:black; font-size:small"><i class="fas fa-user-friends"></i> Attendant</label>
                                                    <asp:TextBox ID="txt_attendant" Style="text-align:center" CssClass="container-fluid form-control" TextMode="number" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2">
                                                    <label style="color:black; font-size:small"><i class="fas fa-wheelchair"></i> Equipment Rental</label>
                                                    <asp:TextBox ID="txt_rental" Style="text-align:center" CssClass="container-fluid form-control" TextMode="number" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2">
                                                    <label style="color:black; font-size:x-small"><i class="fas fa-balance-scale-right"></i> Bariatric
                                                        <label style="color: #BF0000; font-size: xx-small">(above 300 lbs)</label></label>
                                                    <asp:TextBox ID="txt_bariatric"  Style="margin-top: -5px; text-align:center" CssClass="container-fluid form-control" TextMode="number" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2">
                                                    <label style="color:black; font-size:small"><i class="fas fa-sort-amount-up-alt"></i> Stairs
                                                        <label style="color: #BF0000; font-size: xx-small">(if "YES" put 1)</label></label>
                                                    <asp:TextBox ID="txt_stairs"  Style="margin-top: -5px; text-align:center" CssClass="container-fluid form-control" TextMode="number" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2">
                                                    <label style="color:black; font-size:small"><i class="fas fa-running"></i> Rush
                                                        <label style="color: #BF0000; font-size: xx-small">(if "YES" put 1)</label></label>
                                                    <asp:TextBox ID="txt_rush" Style="margin-top: -5px; text-align:center" CssClass="container-fluid form-control" TextMode="number" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <label style="color:black; font-size:small"><i class="far fa-meh-blank"></i> Other
                                                        <label style="color: #BF0000; font-size: xx-small">(if "YES" put 1)</label></label>
                                                    <asp:TextBox ID="txt_other" Style="margin-top: -5px; text-align:center" CssClass="container-fluid form-control" TextMode="number" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2">
                                                    <label style="color:black; font-size:x-small"><i class="fas fa-wreath"></i> After Hours
                                                        <label style="color: #BF0000; font-size: xx-small">(if "YES" put 1)</label></label>
                                                    <asp:TextBox ID="txt_afterhours" Style="margin-top: -5px; text-align:center" CssClass="container-fluid form-control" TextMode="number" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2" style="margin-top:25px;">
                                                    <asp:Button ID="btn_save_intake" CssClass="btn2 container-fluid form-control" runat="server" Text="GO" />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="card-header">
                                            <label><i class="fas fa-star-half-alt"></i> Rate Selection</label>
                                        </div>
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="card">
                                                        <div class="card-header">
                                                            <label>Company</label>
                                                        </div>
                                                        <div class="card-body">
                                                            <asp:GridView ID="grd_company" CssClass="container-fluid grid" runat="server" AlternatingRowStyle-BackColor="#D7D7D7" AutoGenerateColumns="False" BackColor="White" HeaderStyle-BackColor="SteelBlue" HeaderStyle-ForeColor="White">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="ll_select" ForeColor="SteelBlue" OnClick="ll_select_Click" Font-Bold="true" runat="server"><i class="fas fa-check"></i></asp:LinkButton>
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="company_id" HeaderText="#" SortExpression="company_id" ItemStyle-ForeColor="Black"/>
                                                                    <asp:BoundField DataField="company" HeaderText="Company" SortExpression="company" ItemStyle-ForeColor="Black"/>
                                                                </Columns>

                                                            </asp:GridView>
                                                            
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col">
                                                    <div class="card">
                                                        <div class="card-header" style="text-align: center">
                                                            <asp:Label  ID="lbl_company_name" runat="server" Text=""></asp:Label>
                                                            <asp:DropDownList ID="ddl_flat_rate_option" AutoPostBack="true" Width="22" runat="server" Visible="false">
                                                                <asp:ListItem Text="--Select--" Value="--Select--" />
                                                                <asp:ListItem Text="AMBULATORY" Value="AMBULATORY" />
                                                                <asp:ListItem Text="WHEELCHAIR" Value="WHEELCHAIR" />
                                                                <asp:ListItem Text="STRETCHER" Value="STRETCHER" />
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="card-body" style="font-size: small">
                                                            <div class="row">
                                                                <div class="col-md-3">
                                                                    <div class="card">
                                                                        <div class="card-header">
                                                                            <asp:Label ID="lbl_selection0" Font-Size="small" runat="server" Text="."></asp:Label>
                                                                        </div>
                                                                        <div class="card-header">
                                                                            <div class="row">
                                                                                <div class="col-md-1">
                                                                                    <label>.</label>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: center; font-size: small">
                                                                                    <label>Description</label>
                                                                                </div>
                                                                                <div class="col-md-4" style="text-align: center; font-size: small">
                                                                                    <label>QTE</label>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="card-body">
                                                                            <div class="row"style="margin-top: 1px">
                                                                                <div class="col-md-1" style="margin-top: 1px">
                                                                                    <asp:CheckBox ID="cbx_deadmiles" AutoPostBack="true" runat="server" />
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right; margin-top: 5px">
                                                                                    <label style="color:black">Dead Miles</label>
                                                                                </div>

                                                                                <div class="col-md-4">
                                                                                    <asp:TextBox ID="txt_qte_deadmiles" CssClass="container-fluid form-control" Font-Size="x-small" Style="text-align: center" runat="server"></asp:TextBox>
                                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txt_qte_deadmiles" ValidChars="0123456789." runat="server"></cc1:FilteredTextBoxExtender>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-1" style="margin-top: 5px">
                                                                                    <asp:CheckBox ID="cbx_loadedmiles" AutoPostBack="true" runat="server" />
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right; margin-top: 5px">
                                                                                    <label style="color:black">Load Mile</label>
                                                                                </div>
                                                                                <div class="col-md-4">
                                                                                    <asp:TextBox ID="txt_qte_loadedmiles" CssClass="container-fluid form-control" Font-Size="x-small" Style="text-align: center" runat="server"></asp:TextBox>
                                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txt_qte_loadedmiles" ValidChars="0123456789." runat="server"></cc1:FilteredTextBoxExtender>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-1" style="margin-top: 5px">
                                                                                    <asp:CheckBox ID="cbx_leg" AutoPostBack="true" runat="server" />
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right; margin-top: 5px">
                                                                                    <label style="color:black">Load Fee</label>
                                                                                </div>
                                                                                <div class="col-md-4">
                                                                                    <asp:TextBox ID="txt_qte_leg" CssClass="container-fluid form-control" Font-Size="x-small" Style="text-align: center" runat="server"></asp:TextBox>
                                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txt_qte_leg" ValidChars="0123456789" runat="server"></cc1:FilteredTextBoxExtender>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-1" style="margin-top: 5px">
                                                                                    <asp:CheckBox ID="cbx_waittime" AutoPostBack="true" runat="server" />
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right; margin-top: 5px">
                                                                                    <label style="color:black">Wait Time</label>
                                                                                </div>
                                                                                <div class="col-md-4">
                                                                                    <asp:TextBox ID="txt_qte_waittime" CssClass="container-fluid form-control" Font-Size="x-small" Style="text-align: center" runat="server"></asp:TextBox>
                                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txt_qte_waittime" ValidChars="0123456789" runat="server"></cc1:FilteredTextBoxExtender>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-1" style="margin-top: 5px">
                                                                                    <asp:CheckBox ID="cbx_attendant" AutoPostBack="true" runat="server" />
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right; margin-top: 5px">
                                                                                    <label style="color:black">Attendant</label>
                                                                                </div>
                                                                                <div class="col-md-4">
                                                                                    <asp:TextBox ID="txt_qte_attendant" CssClass="container-fluid form-control" Font-Size="x-small" Style="text-align: center" runat="server"></asp:TextBox>
                                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txt_qte_attendant" ValidChars="0123456789" runat="server"></cc1:FilteredTextBoxExtender>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-1" style="margin-top: 5px">
                                                                                    <asp:CheckBox ID="cbx_rental" AutoPostBack="true" runat="server" />
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right; margin-top: 5px">
                                                                                    <label style="color:black">Equipment</label>
                                                                                </div>
                                                                                <div class="col-md-4">
                                                                                    <asp:TextBox ID="txt_qte_rental" CssClass="container-fluid form-control" Font-Size="x-small" Style="text-align: center" runat="server"></asp:TextBox>
                                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txt_qte_rental" ValidChars="0123456789" runat="server"></cc1:FilteredTextBoxExtender>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-1" style="margin-top: 5px">
                                                                                    <asp:CheckBox ID="cbx_bariatic" AutoPostBack="true" runat="server" />
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right; margin-top: 5px">
                                                                                    <label style="color:black">Bariatic</label>
                                                                                </div>
                                                                                <div class="col-md-4">
                                                                                    <asp:TextBox ID="txt_qte_bariatic" CssClass="container-fluid form-control" Font-Size="x-small" Style="text-align: center" runat="server"></asp:TextBox>
                                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txt_qte_bariatic" ValidChars="0123456789" runat="server"></cc1:FilteredTextBoxExtender>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-1" style="margin-top: 5px">
                                                                                    <asp:CheckBox ID="cbx_stairs" AutoPostBack="true" runat="server" />
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right; margin-top: 5px">
                                                                                    <label style="color:black">Stairs</label>
                                                                                </div>
                                                                                <div class="col-md-4">
                                                                                    <asp:TextBox ID="txt_qte_stairs" CssClass="container-fluid form-control" Font-Size="x-small" Style="text-align: center" runat="server"></asp:TextBox>
                                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txt_qte_stairs" ValidChars="0123456789" runat="server"></cc1:FilteredTextBoxExtender>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-1" style="margin-top: 5px">
                                                                                    <asp:CheckBox ID="cbx_rush" AutoPostBack="true" runat="server" />
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right; margin-top: 5px">
                                                                                    <label style="color:black">Rush</label>
                                                                                </div>
                                                                                <div class="col-md-4">
                                                                                    <asp:TextBox ID="txt_qte_rush" CssClass="container-fluid form-control" Font-Size="x-small" Style="text-align: center" runat="server"></asp:TextBox>
                                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txt_qte_rush" ValidChars="0123456789" runat="server"></cc1:FilteredTextBoxExtender>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-1" style="margin-top: 5px">
                                                                                    <asp:CheckBox ID="cbx_other" AutoPostBack="true" runat="server" />
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right; margin-top: 5px">
                                                                                    <label style="color:black">Other</label>
                                                                                </div>
                                                                                <div class="col-md-4">
                                                                                    <asp:TextBox ID="txt_qte_other" CssClass="container-fluid form-control" Font-Size="x-small" Style="text-align: center" runat="server"></asp:TextBox>
                                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" TargetControlID="txt_qte_other" ValidChars="0123456789" runat="server"></cc1:FilteredTextBoxExtender>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-1" style="margin-top: 5px">
                                                                                    <asp:CheckBox ID="cbx_afterhours" AutoPostBack="true" runat="server" />
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right; margin-top: 5px">
                                                                                    <label style="color:black">After Hours</label>
                                                                                </div>
                                                                                <div class="col-md-4">
                                                                                    <asp:TextBox ID="txt_qte_afterhours" CssClass="container-fluid form-control" Font-Size="x-small" Style="text-align: center" runat="server"></asp:TextBox>
                                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" TargetControlID="txt_qte_afterhours" ValidChars="0123456789" runat="server"></cc1:FilteredTextBoxExtender>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <div class="card">
                                                                        <div class="card-header" style="text-align: center">
                                                                            <asp:RadioButton ID="rbtn_selection1"  runat="server"  GroupName="rate_selection" />
                                                                            <asp:Label ID="lbl_selection1" Font-Size="small" runat="server" Text=""></asp:Label>
                                                                        </div>
                                                                        <div class="card-header">
                                                                            <div class="row">
                                                                                <div class="col-md-6" style="text-align: center; font-size: small">
                                                                                    <label>RATE</label>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: center; font-size: small">
                                                                                    <label>TOTAL</label>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="card-body">
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_lrate_deadmiles"  CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server" ></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_lrate_deadmiles" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_lrate_loadedmiles" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_lrate_loadedmiles" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_lrate_leg" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_lrate_leg" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_lrate_waittime" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_lrate_waittime" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_lrate_attendant" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_lrate_attendant" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_lrate_rental" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_lrate_rental" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_lrate_bariatic" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_lrate_bariatic" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_lrate_stairs" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_lrate_stairs" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_lrate_rush" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_lrate_rush" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_lrate_other" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_lrate_other" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_lrate_afterhours" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_lrate_afterhours" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <div class="card">
                                                                        <div class="card-header" style="text-align: center">
                                                                            <asp:RadioButton ID="rbtn_selection2" GroupName="rate_selection" runat="server" />
                                                                            <asp:Label ID="lbl_selection2" runat="server" Font-Size="small" Text=""></asp:Label>
                                                                        </div>
                                                                        <div class="card-header">
                                                                            <div class="row">
                                                                                <div class="col-md-6" style="text-align: center; font-size: small">
                                                                                    <label>RATE</label>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: center; font-size: small">
                                                                                    <label>TOTAL</label>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="card-body">
                                                                            <div class="row">
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_mrate_deadmiles" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_mrate_deadmiles" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_mrate_loadedmiles" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_mrate_loadedmiles" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_mrate_leg" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_mrate_leg" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_mrate_waittime" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_mrate_waittime" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_mrate_attendant" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_mrate_attendant" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_mrate_rental" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_mrate_rental" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_mrate_bariatic" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_mrate_bariatic" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_mrate_stairs" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_mrate_stairs" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_mrate_rush" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_mrate_rush" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_mrate_other" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_mrate_other" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_mrate_afterhours" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_mrate_afterhours" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <div class="card">
                                                                        <div class="card-header" style="text-align: center">
                                                                            <asp:RadioButton ID="rbtn_selection3" GroupName="rate_selection" runat="server" />
                                                                            <asp:Label ID="lbl_selection3" runat="server" Font-Size="small" Text=""></asp:Label>
                                                                        </div>
                                                                        <div class="card-header">
                                                                            <div class="row">
                                                                                <div class="col-md-6" style="text-align: center; font-size: small">
                                                                                    <label>RATE</label>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: center; font-size: small">
                                                                                    <label>TOTAL</label>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="card-body">
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_hrate_deadmiles" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_hrate_deadmiles" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_hrate_loadedmiles" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_hrate_loadedmiles" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_hrate_leg" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_hrate_leg" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_hrate_waittime" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_hrate_waittime" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_hrate_attendant" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_hrate_attendant" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_hrate_rental" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_hrate_rental" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_hrate_bariatic" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_hrate_bariatic" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_hrate_stairs" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_hrate_stairs" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_hrate_rush" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_hrate_rush" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_hrate_other" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_hrate_other" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row" >
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_hrate_afterhours" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-md-6" style="text-align: right">
                                                                                    <asp:TextBox ID="txt_tot_hrate_afterhours" CssClass="container-fluid form-control" Font-Size="x-Small" Style="text-align: right" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-md-4 mx-auto">
                                                                    <asp:Button ID="btn_calculate" CssClass="btn2 container-fluid form-control" runat="server" Text="Calculate" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="card-body">
                                                            <div class="row">
                                                               <div class="col-md-6">
                                                                    <div class="row">
                                                                        <div class="col-md-6"style="text-align:right">
                                                                            <label style="color:black">TOTAL</label>
                                                                        </div>
                                                                        <div class="col-md-6">
                                                                            <asp:TextBox ID="txt_total_lrate" Style="text-align:right" CssClass="container-fluid form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <br />
                                                                    <div class="row">
                                                                        <div class="col-md-6" style="text-align:right">
                                                                            <label style="color:black">NO SHOW / LATE CANCEL</label>
                                                                        </div>
                                                                        <div class="col-md-6">
                                                                            <asp:TextBox ID="txt_cancel_lrate" Style="text-align:right" CssClass="container-fluid form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <div class="row">
                                                                        <div class="col" style="text-align:right">
                                                                            <asp:TextBox ID="txt_total_mrate" Style="text-align:right" CssClass="container-fluid form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        </div>
                                                                    <br />
                                                                        <div class="row">
                                                                        <div class="col">
                                                                            <asp:TextBox ID="txt_cancel_mrate" Style="text-align:right" CssClass="container-fluid form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <div class="row">
                                                                        <div class="col" style="text-align:right">
                                                                            <asp:TextBox ID="txt_total_hrate" Style="text-align:right" CssClass="container-fluid form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        </div>
                                                                    <br />
                                                                        <div class="row">
                                                                        <div class="col">
                                                                            <asp:TextBox ID="txt_cancel_hrate" Style="text-align:right" CssClass="container-fluid form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <asp:Button ID="btn_reservation" cssclass="container-fluid form-control btn-blue"  runat="server" Text="Create Reservation" />
                                                </div>
                                                <div class="col-md-6">
                                                    <asp:Button ID="btn_cancel" cssclass="container-fluid form-control btn-red" backColor="Darkred" runat="server" Text="Cancel" />
                                                </div>
                                            </div>

                                            <br />


                                        </div>
                                    </div>
                                    <div class="row">
                                        <asp:GridView ID="grd_location" Visible="false" runat="server"></asp:GridView>
                                        <asp:GridView ID="grd_rates" Visible="false" runat="server"></asp:GridView>
                                        <asp:GridView ID="grd_proforma" Visible="false" runat="server"></asp:GridView>
                                        <asp:GridView ID="grd_time" Visible="false" runat="server"></asp:GridView>
                                        <asp:Label ID="lbl_company_id" Visible="false" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="lbl_company" Visible="false" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="lbl_status" Visible="false" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="lbl_transport_lrate" Visible="false" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="lbl_transport_mrate" Visible="false" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="lbl_transport_hrate" Visible="false" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="lbl_service_fee_lrate" Visible="false" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="lbl_service_fee_mrate" Visible="false" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="lbl_service_fee_hrate" Visible="false" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            
        </div>
    </div>
        </ContentTemplate>
        <Triggers>
                     
            
            <asp:PostBackTrigger ControlID="btn_reservation" />
            <asp:PostBackTrigger ControlID="btn_cancel" />

            <asp:AsyncPostBackTrigger ControlID="ll_ok_itinerary" />
            <asp:AsyncPostBackTrigger ControlID="ll_add_new" />
            <asp:AsyncPostBackTrigger ControlID="btn_save_distance" />
            <asp:AsyncPostBackTrigger ControlID="btn_save_intake" />
            <asp:AsyncPostBackTrigger ControlID="btn_calculate" />

        </Triggers>
        
    </asp:UpdatePanel>
            
      
    
</asp:Content>
