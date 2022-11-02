<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ats_settings.Master" CodeBehind="Authorization.aspx.vb" Inherits="American_Transit_Services_LLC.Authorization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../../Css/role.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-11 mx-auto ">
            <br />
            <div class="row">
                <div class="col-md-7">
                    <label class="header-text">Role & Authorization</label>
                </div>
                <div class="col-md-4" style="text-align: right">
                    <asp:LinkButton ID="ll_close" CssClass="close-control" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
            <div class="row line"></div>
            <br />
            <br />
            <div class="row">
                <div class="col" style="margin-top: 20px;">
                    <asp:Label ID="lbl_comment" CssClass="comment container-fluid form-control" runat="server" Visible="false" Text=""></asp:Label>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header">
                            <div class="row">
                                <div class="col-md-7">
                                    <asp:TextBox ID="txt_role" CssClass="container-fluid form-control" placeholder="Your Text here" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-5">
                                    <asp:LinkButton ID="ll_search" CssClass="card-header-control" runat="server"><i class="fas fa-search"></i></asp:LinkButton>
                                    <asp:LinkButton ID="ll_save" CssClass="card-header-control" runat="server"><i class="fas fa-save"></i></asp:LinkButton>

                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <asp:GridView ID="grd_role" CssClass="container-fluid table table-strip table-bordered" AutoGenerateColumns="False" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="role_id" HeaderText="#" SortExpression="role_id" />
                                    <asp:BoundField DataField="role" HeaderText="Role" SortExpression="role" />

                                    <asp:TemplateField ItemStyle-HorizontalAlign="center">
                                        <HeaderTemplate>
                                            <label>Options</label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="ll_edit" OnClick="ll_edit_Click" ForeColor="SteelBlue" Font-Bold="true" runat="server"><i class="fas fa-pen"></i></asp:LinkButton>
                                            <asp:LinkButton ID="ll_delete" ForeColor="darkred" Font-Bold="true" runat="server"><i class="fas fa-trash"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <AlternatingRowStyle BackColor="lightgray" ForeColor="black" />
                                <HeaderStyle BackColor="steelblue" BorderColor="white" BorderStyle="Solid" BorderWidth="1px" CssClass="container-fluid" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:atsConnectionString %>" SelectCommand="SELECT [role_id], [role] FROM [Role] ORDER BY [role]"></asp:SqlDataSource>
                            <br />

                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header">
                            <div class="row">
                                <div class="col-md-4">
                                    <label>Authorisation</label>
                                </div>
                                <div class="col-md-1" style="text-align:right">
                                    <asp:LinkButton ID="ll_save_authorization" CssClass="card-header-control" runat="server"><i class="fas fa-save"></i></asp:LinkButton>
                                </div>
                            </div>

                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:CheckBox ID="cbx_administration" AutoPostBack="true" runat="server" />
                                </div>
                                <div class="col">
                                    <label style="color: black">Administration</label>
                                </div>
                            </div>
                            <br />
                             <div class="row">
                        <div class="col-md-2" style="text-align:right">
                            <asp:CheckBox ID="cbx_rrhh" AutoPostBack="true" runat="server" />
                        </div>
                        <div class="col">
                            <label style="color: black">Human Ressources</label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2" style="text-align:right">
                            <asp:CheckBox ID="cbx_finances" AutoPostBack="true" runat="server" />
                        </div>
                        <div class="col">
                            <label style="color: black">Finances</label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2" style="text-align:right">
                            <asp:CheckBox ID="cbx_settings" AutoPostBack="true" runat="server" />
                        </div>
                        <div class="col">
                            <label style="color: black">Settings</label>
                        </div>
                    </div>
                    <br />
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:CheckBox ID="cbx_client" runat="server" />
                                </div>
                                <div class="col">
                                    <label style="color: black">Client</label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:CheckBox ID="cbx_proforma" runat="server" />
                                </div>
                                <div class="col">
                                    <label style="color: black">Proforma</label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:CheckBox ID="cbx_reservation" runat="server" />
                                </div>
                                <div class="col">
                                    <label style="color: black">Reservation</label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:CheckBox ID="cbx_invoice" runat="server" />
                                </div>
                                <div class="col">
                                    <label style="color: black">Invoice</label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <asp:GridView ID="grd_authorization" Visible="False" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="autorisation_id" HeaderText="autorisation_id" InsertVisible="False" ReadOnly="True" SortExpression="autorisation_id" />
                        <asp:BoundField DataField="role" HeaderText="role" SortExpression="role" />
                        <asp:BoundField DataField="administration" HeaderText="adminiatration" SortExpression="administration" />
                        <asp:BoundField DataField="client" HeaderText="client" SortExpression="client" />
                        <asp:BoundField DataField="proforma" HeaderText="proforma" SortExpression="proforma" />
                        <asp:BoundField DataField="reservation" HeaderText="reservation" SortExpression="reservation" />
                        <asp:BoundField DataField="invoice" HeaderText="invoice" SortExpression="invoice" />
                        <asp:BoundField DataField="rrhh" HeaderText="rrhh" SortExpression="rrhh" />
                        <asp:BoundField DataField="finance" HeaderText="finance" SortExpression="finance" />
                        <asp:BoundField DataField="settings" HeaderText="settings" SortExpression="settings" />
                    </Columns>
                </asp:GridView>

                <asp:Label ID="lbl_place" Visible="false" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lbl_rolse_id" Visible="false" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lbl_option" Visible="false" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
