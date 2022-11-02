<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="Reservation.aspx.vb" Inherits="American_Transit_Services_LLC.Reservation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
    
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false&libraries=places&key=AIzaSyBDJoTcSeGRvKUADN5kcNGIEyiVEvFAHrI"></script>
    <script type="text/javascript">
        google.maps.event.addDomListener(window, 'load', function () {
            var places = new google.maps.places.Autocomplete(document.getElementById('<%=txt_pick_up_1.ClientID %>'));
            var places = new google.maps.places.Autocomplete(document.getElementById('<%=txt_dropoff_1.ClientID %>'));
            var places = new google.maps.places.Autocomplete(document.getElementById('<%=txt_pick_up_2.ClientID %>'));
            var places = new google.maps.places.Autocomplete(document.getElementById('<%=txt_dropoff_2.ClientID %>'));
            var places = new google.maps.places.Autocomplete(document.getElementById('<%=txt_pick_up_3.ClientID %>'));
            var places = new google.maps.places.Autocomplete(document.getElementById('<%=txt_dropoff_3.ClientID %>'));
            google.maps.event.addListener(places, 'place_changed', function () {
            var place = places.getPlace();
                document.getElementById('<%=txt_pick_up_1.ClientID %>').value = place.formatted_address;
                document.getElementById('<%=txt_dropoff_1.ClientID %>').value = place.formatted_address;
                document.getElementById('<%=txt_pick_up_2.ClientID %>').value = place.formatted_address;
                document.getElementById('<%=txt_dropoff_2.ClientID %>').value = place.formatted_address;
                document.getElementById('<%=txt_pick_up_3.ClientID %>').value = place.formatted_address;
                document.getElementById('<%=txt_dropoff_3.ClientID %>').value = place.formatted_address;
             });
           });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="row">
        <div class="col-md-12 mx-auto">
            <br /><br />
            <div class="row">
                <div class="col-md-7">
                    <label class="header-text">Reservation <label class="header-text">#: <asp:Label ID="lbl_reservation_id" runat="server" Text=""></asp:Label></label></label>
                </div>
              
                <div class="col-md-4" style="text-align:right; margin-top:4px;">
                    <asp:LinkButton ID="ll_close" CssClass="close-control" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
            <br />
            <div class="row blue-line"></div>
            
            <div class="row" style="margin-top:10px; margin-bottom:10px;">
                <div class="col-md-1">
                    <asp:LinkButton ID="lbl_save" CssClass="control-link-blue" runat="server"><i class="fas fa-save"></i></asp:LinkButton>
                </div>
                
                <div class="col-md-1">
                    <asp:LinkButton ID="ll_delete" CssClass="control-link-red" runat="server"><i class="fas fa-trash-alt"></i></asp:LinkButton>
                </div>
                 <div class="col-md-1">
                    <asp:LinkButton ID="ll_download" CssClass="control-link-blue" runat="server"><i class="fas fa-download"></i></asp:LinkButton>
                </div>
                <div class="col-md-1">
                    <asp:LinkButton ID="ll_mail" CssClass="control-link-blue" runat="server"><i class="fas fa-envelope-open"></i></asp:LinkButton>
                </div>
            </div>
            <div class="row line"></div>
            <br />
            
            <div class="row">
                <div class="col">
                    <div class="card" >
                        <div class="card-body" >
                            <br />
                            <div class="col" style="margin-top: 20px;">
                                    <asp:Label ID="lbl_comment" CssClass="comment container-fluid form-control" runat="server" Visible="false" Text=""></asp:Label>
                                </div>
                            <br />
                            <div class="row">
                                <div class="col-md-4">
                                    <label class="label-head">First Name</label>
                                    <asp:TextBox ID="txt_firstname" CssClass="container-fluid form-control" placeholder="First Name" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label class="label-head">Middle Name</label>
                                    <asp:TextBox ID="txt_middlename" CssClass="container-fluid form-control" placeholder="Middle Name" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label class="label-head">Last Name</label>
                                    <asp:TextBox ID="txt_lastname" CssClass="container-fluid form-control" placeholder="Last Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                            <div class="col-md-4">
                                <label class="label-head">Telephone</label>
                                <asp:TextBox ID="txt_telephone" CssClass="container-fluid form-control" runat="server" MaxLength="14"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txt_telephone" ValidChars="0123456789() -" runat="server"></cc1:FilteredTextBoxExtender>
                            </div>
                                <div class="col-md-8">
                                    <label class="label-head">E-mail</label>
                                    <asp:TextBox ID="txt_email" CssClass="container-fluid form-control" runat="server"></asp:TextBox>
                                </div>
                                </div>
                            <div class="row">
                                <div class="col-md-8">
                                    <asp:CheckBox ID="cbx_save_client" CssClass="container-fluid form-control" Text="Click to save client information in Database" runat="server" BorderStyle="None" />
                                </div>
                                <div class="col-md-3" style="text-align:right; margin-top:10px;">
                                    <asp:LinkButton ID="ll_import" cssclass="link27" runat="server"><i class="fas fa-upload"></i> Import From Database</asp:LinkButton>
                                </div>
                            </div>
                            <div class="row" id="row_client" runat="server" visible="false">
                                <div class="col">
                                    <div class="card">
                                        <div class="card-header">
                                            <div class="row">
                                                <div class="col-md-5">
                                                    <asp:TextBox ID="txt_search" cssclass="container-fluid form-control" placeholder="Search" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-6" style="text-align:right">
                                                    <asp:LinkButton ID="ll_close2" CssClass="close-control" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card-body">
                                            <asp:GridView ID="grd_client" CssClass="container-fluid"  AutoGenerateColumns="false" runat="server">
                                                <Columns>
                                                   
                                                    <asp:BoundField DataField="Client_id" HeaderText="ID" ReadOnly="True" SortExpression="employe_id" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                                    <asp:BoundField DataField="first_name" HeaderText="First Name" SortExpression="first_name" ItemStyle-ForeColor="Black" />
                                                    <asp:BoundField DataField="middle_name" HeaderText="Middle Name" SortExpression="middle_name" ItemStyle-ForeColor="Black" />
                                                    <asp:BoundField DataField="last_name" HeaderText="Last Name" SortExpression="last_name" ItemStyle-ForeColor="Black" />
                                                    <asp:BoundField DataField="telephone" HeaderText="Telephone" SortExpression="telephone" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                                    <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="ll_choice" ForeColor="SteelBlue" OnClick="ll_choice_Click" Font-Bold="true" Font-Size="Small" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                </Columns>
                                                <AlternatingRowStyle BackColor="lightgray" ForeColor="black" />
                                                <HeaderStyle BackColor="steelblue" BorderColor="white" BorderStyle="Solid" BorderWidth="1px" CssClass="container-fluid" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                            <br />
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row line"></div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="card">
                                        <div class="card-header">
                                            <label>Date, Time & Transport</label>
                                        </div>
                                        <div class="card-body">
                                            <div class=row>
                                                <div class="col-md-5" style="text-align:right">
                                                    <label class="label-head">Pick up Date</label>
                                                </div>
                                                <div class="col-md-5">
                                                    <asp:TextBox ID="txt_pickup_date2" CssClass="container-fluid form-control" runat="server"></asp:TextBox>
                                                    <asp:TextBox ID="txt_pickup_date" CssClass="container-fluid form-control" TextMode="Date" Visible="false" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2">
                                                    <asp:LinkButton ID="ll_modify_date" ForeColor="SteelBlue" font-size="X-Small" Font-Bold="true" runat="server"><i class="fas fa-pen"></i> Modify</asp:LinkButton>
                                                    <asp:LinkButton ID="ll_save_date" ForeColor="SteelBlue" font-size="X-Small" Font-Bold="true" Visible="false" runat="server"><i class="fas fa-save"></i> Save</asp:LinkButton>
                                                    <asp:LinkButton ID="ll_cancel_date" ForeColor="Darkred" font-size="X-Small" Font-Bold="true" runat="server"><i class="fas fa-ban"></i> Cancel</asp:LinkButton>
                                                </div>
                                            </div>
                                            <br />
                                            <div class=row>
                                                <div class="col-md-5" style="text-align:right">
                                                    <label class="label-head">Pick up Time</label>
                                                </div>
                                                <div class="col-md-5">
                                                    
                                                    <asp:DropDownList ID="ddl_pickup_time" CssClass="container-fluid form-control" runat="server">
                                                        <asp:ListItem Text="--Select--" Value="--Select--" />
                                                        
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <br />
                                            <div class=row>
                                                <div class="col-md-5" style="text-align:right">
                                                    <label class="label-head">Transport Type</label>
                                                </div>
                                                <div class="col-md-5">
                                                    <asp:TextBox ID="txt_transport_type" CssClass="container-fluid form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="card">
                                        <div class="card-header">
                                            <div class="row">
                                                <div class="col-md-6" style="text-align:center">
                                                    <label>Pick Up</label>
                                                </div>
                                                <div class="col-md-6" style="text-align:center">
                                                    <label>Drop Off</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card-body">
                                           
                                            <div class="row">
                                                
                                                <div class="col-md-6">
                                                    <asp:TextBox ID="txt_pick_up_1" CssClass="container-fluid form-control" placeholder="Origin" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-6">
                                                    <asp:TextBox ID="txt_dropoff_1" CssClass="container-fluid form-control" placeholder="Destination" runat="server"></asp:TextBox>
                                                </div>
                                                
                                            </div>
                                            <br />
                                            <div class="row">
                                                
                                                <div class="col-md-6">
                                                    <asp:TextBox ID="txt_pick_up_2" CssClass="container-fluid form-control" placeholder="Origin" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-6">
                                                    <asp:TextBox ID="txt_dropoff_2" CssClass="container-fluid form-control" placeholder="Destination" runat="server"></asp:TextBox>
                                                </div>
                                                
                                            </div>
                                            <br />
                                            <div class="row">
                                                
                                                <div class="col-md-6">
                                                    <asp:TextBox ID="txt_pick_up_3" CssClass="container-fluid form-control" placeholder="Origin" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-6">
                                                    <asp:TextBox ID="txt_dropoff_3" CssClass="container-fluid form-control" placeholder="Destination" runat="server"></asp:TextBox>
                                                </div>
                                                
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                             <div class="row line"></div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="label-head">Transport Reason</label>
                                    <asp:TextBox ID="txt_reason" CssClass="container-fluid form-control" TextMode="MultiLine" Height="150" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br /><br />
        </div>
         <div class="row">
             <asp:Label ID="lbl_client_id" Visible="false" runat="server" Text="Label"></asp:Label>
             <asp:GridView ID="grd_time" Visible="false" runat="server"></asp:GridView>
             <asp:GridView ID="grd_reservation" Visible="false" runat="server"></asp:GridView>
             <asp:GridView ID="grd_proforma" Visible="false" runat="server"></asp:GridView>
             <asp:Label ID="lbl_proforma_id" Visible="false" runat="server" Text="Label"></asp:Label>
         </div>
         <br />
         <br />
    </div>
   
    
</asp:Content>
