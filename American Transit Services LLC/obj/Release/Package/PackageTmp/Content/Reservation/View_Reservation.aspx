<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="View_Reservation.aspx.vb" Inherits="American_Transit_Services_LLC.View_Reservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12 mx-auto">
            <br />
            <div class="row">
                <div class="col-md-7">
                    <label class="header-text">Reservation #: <asp:Label ID="lbl_reservation_id" runat="server" Text=""></asp:Label></label>
                    
                </div>
                <div class="col-md-4" style="text-align:right">
                    <asp:LinkButton ID="lbl_close" CssClass="close-control" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
            <br />
            <div class="row line"></div>
            <br />
            <div class="row">
                <div class="col-md-8 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            
                             <div class="row">
                                <div class="col" style="margin-top: 20px;">
                                    <asp:Label ID="lbl_comment" CssClass="comment container-fluid form-control" runat="server" Visible="false" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col col-header" style="text-align:left">
                                    <label class="header-label-header container-fluid form-control">Client Information</label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-4" style="text-align:center">
                                    <label class="label-text">First Name</label>
                                    <br />
                                    <asp:Label ID="lbl_firstname" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>

                                </div>
                                <div class="col-md-4" style="text-align:center">
                                    <label class="label-text">Middle Name</label>
                                    <br />
                                    <asp:Label ID="lbl_middlename" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>

                                </div>
                                <div class="col-md-4" style="text-align:center">
                                    <label class="label-text">Last Name</label>
                                    <br />
                                    <asp:Label ID="lbl_lastname" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>

                                </div>
                            </div>
                            <br />
                            <div class="row">
                            <div class="col-md-8" style="text-align:center">
                                    <label class="label-text">E-mail</label>
                                    <br />
                                    <asp:Label ID="lbl_email" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>

                                </div>
                            <div class="col-md-4" style="text-align:center">
                                    <label class="label-text">Telephone</label>
                                    <br />
                                    <asp:Label ID="lbl_telephone" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>

                                </div>
                                </div>
                           
                            <br />
                            <div class="row line"></div>
                            <br />
                            <div class="row">
                                <div class="col col-header" style="text-align:left">
                                    <label class="header-label-header container-fluid form-control">Reservation</label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-3">
                                    <label class="label-text">PickUp Date</label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lbl_pickup_date" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                     <div class="col-md-3">
                                    <label class="label-text">PickUp Time</label>
                                         </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lbl_pickup_time" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    </div>
                                 </div>
                               <br />
                            <div class="row">
                                <div class="col-md-6" style="text-align:center">
                                    <label class="label-text">Origin</label>
                                </div>
                                <div class="col-md-6" style="text-align:center">
                                    <label class="label-text">Destination</label>
                                </div>
                            </div>
                                <br />
                            <div class="row" id="th_row0" runat="server">
                                <div class="col-md-6" style="text-align:left">
                                    <asp:Label ID="lbl_origin0" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="col-md-6" style="text-align:left">
                                    <asp:Label ID="lbl_destination0" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                            
                            <br />
                            <div class="row" id="th_row1" runat="server" visible="false">
                                <div class="col-md-6" style="text-align:left">
                                    <asp:Label ID="lbl_origin1" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="col-md-6" style="text-align:left">
                                    <asp:Label ID="lbl_destination1" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                            
                            <br />
                            <div class="row" id="th_row2" runat="server" visible="false">
                                <div class="col-md-6" style="text-align:left">
                                    <asp:Label ID="lbl_origin2" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="col-md-6" style="text-align:left">
                                    <asp:Label ID="lbl_destination2" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                            
                            <br />
                            <div class="row" id="th_row3" runat="server" visible="false">
                                <div class="col-md-6" style="text-align:left">
                                    <asp:Label ID="lbl_origin3" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="col-md-6" style="text-align:left">
                                    <asp:Label ID="lbl_destination3" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                            
                            <br />
                            <div class="row" id="th_row4" runat="server" visible="false">
                                <div class="col-md-6" style="text-align:left">
                                    <asp:Label ID="lbl_origin4" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="col-md-6" style="text-align:left">
                                    <asp:Label ID="lbl_destination4" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                            
                            <br />
                            <div class="row">
                                <div class="col-md-3">
                                    <label class="label-text">Total Distance :</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="lbl_total_distance" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                             <br />
                            <div class="row">
                                <div class="col-md-3">
                                    <label class="label-text">Total Time :</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="lbl_total_time" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col col-header" style="text-align:left">
                                    <label class="header-label-header container-fluid form-control">Status</label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-3">
                                    <label class="label-text">Status</label>
                                        <asp:DropDownList ID="ddl_status" CssClass="container-fluid form-control" runat="server">
                                            <asp:ListItem Text="--Select--" Value="--Select--" />
                                            <asp:ListItem Text="Open" Value="Open" />
                                            <asp:ListItem Text="In Progress" Value="In Progress" />
                                            <asp:ListItem Text="Canceled" Value="Canceled" />
                                            <asp:ListItem Text="Closed" Value="Close" />
                                        </asp:DropDownList>
                                    </div>
                                <div class="col-md-7">
                                    <label class="label-text">Comments</label>
                                    <asp:TextBox ID="txt_status" CssClass="container-fluid form-control" TextMode="MultiLine"  runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btn_save" Style="margin-top:25px"  CssClass="btn2 container-fluid form-control" runat="server" Text="Save" />
                                </div>
                                </div>
                            <br />
                            <div class="row">
                                    <div class="col">
                                        <asp:GridView ID="grd_reservation_comment" CssClass="container-fluid" AutoGenerateColumns="false" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" HtmlEncode="false" DataFormatString="{0:d}" />
                                                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" ItemStyle-ForeColor="Black" />
                                                <asp:BoundField DataField="comment" HeaderText="Comments" SortExpression="comment" ItemStyle-ForeColor="Black" />
                                                <asp:BoundField DataField="user" HeaderText="User" SortExpression="user" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                            </Columns>
                                            <AlternatingRowStyle BackColor="lightgray" ForeColor="black" />
                                            <HeaderStyle BackColor="steelblue" BorderColor="white" BorderStyle="Solid" BorderWidth="1px" CssClass="container-fluid" ForeColor="White" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <br />
                               
                            </div>
                        </div>
                    <br /><br /><br />
                    </div>
                <div class="row">
                    <div class="col">
                        <asp:GridView ID="grd_reservation" Visible="false" runat="server"></asp:GridView>
                        <asp:GridView ID="grd_proforma" Visible="false" runat="server"></asp:GridView>
                        <asp:GridView ID="grd_client" Visible="false" runat="server"></asp:GridView>
                        <asp:Label ID="lbl_client_ID" Visible="false" runat="server" Text="Label"></asp:Label>
                        <asp:Label ID="lbl_place" Visible="false" runat="server" Text="Label"></asp:Label>
                        <asp:Label ID="lbl_proforma_ID" Visible="false" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                </div>
            </div>
        </div>
    
</asp:Content>
