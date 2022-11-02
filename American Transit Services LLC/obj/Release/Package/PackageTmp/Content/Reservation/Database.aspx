<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="Database.aspx.vb" Inherits="American_Transit_Services_LLC.Database" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12 mx-auto">
            <br />
            <div class="row">
                <div class="col-md-5">
                    <label class="header-text">Reservation Database</label>
                </div>
            </div>
            <div class="row line"></div>
            <div class="row">
                <div class="col-md-1">
                    <asp:LinkButton ID="ll_calendar" CssClass="container-fluid add-link"  runat="server"><i class="far fa-calendar-alt"></i></asp:LinkButton>
                </div>
                <div class="col-md-1">
                    <asp:LinkButton ID="ll_add_new" CssClass="container-fluid add-link" runat="server"><i class="fas fa-plus-circle"></i></asp:LinkButton>
                </div>
                </div>
           
            <br />
            <div class="row">
                <div class="col">
                    <div class="card" style="height:75vh;">
                        <div class="card-header">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_search" AutoPostBack="true" CssClass="container-fluid form-control" placeholder="Search" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="card-body" style="overflow-y:scroll">
                            <asp:GridView ID="grd_reservation" Class="container-fluid table table-strip table-bordered" AutoGenerateColumns="False" runat="server" FooterStyle-BackColor="SteelBlue" ShowFooter="True" >
                                <Columns>
                                    <asp:BoundField DataField="reservation_id" HeaderText="ID" ReadOnly="True" SortExpression="reservation_id" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                    <asp:BoundField DataField="firstname" HeaderText="First Name" SortExpression="firstname" ItemStyle-ForeColor="Black"/>
                                    <asp:BoundField DataField="lastname" HeaderText="Last Name" SortExpression="lastname" ItemStyle-ForeColor="Black"/>
                                    <asp:BoundField DataField="pickup_date" HeaderText="Date" SortExpression="pickup_date" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" HtmlEncode="false" DataFormatString="{0:d}"/>
                                    <asp:BoundField DataField="pickup_time" HeaderText="Time" SortExpression="pickup_time" ItemStyle-ForeColor="Black"/>
                                    <asp:BoundField DataField="reason" HeaderText="Reason" SortExpression="reason" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center"/>
                                    <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center"/>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbl_select" OnClick="lbl_select_Click" ForeColor="SteelBlue" Font-Bold="true" Font-Size="Small"  runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                 <alternatingRowStyle backcolor="lightgray" ForeColor="black" />
                            <HeaderStyle BackColor="steelblue"  BorderColor="white" BorderStyle="Solid" BorderWidth="1px" CssClass="container-fluid" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            <div class="row">
                <div class="col">
                    <asp:Label ID="lbl_reservation_id" Visible="false" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            </div>
        </div>

</asp:Content>
