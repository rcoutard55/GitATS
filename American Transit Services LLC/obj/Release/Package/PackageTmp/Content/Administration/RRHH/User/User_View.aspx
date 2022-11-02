<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ats_rrhh.Master" CodeBehind="User_View.aspx.vb" Inherits="American_Transit_Services_LLC.User_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-11 mx-auto">
            <br />
            <div class="row">
                <div class="col-md-5">
                    <label class="header-text">User: <asp:Label ID="lbl_employe" runat="server" Text="Label"></asp:Label></label>
                </div>
                <div class="col-md-6" style="text-align:right">
                    <asp:LinkButton ID="ll_close" CssClass="close-control" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
            <br />
            <div class="row blue-line"></div>
            <br />
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-3">
                            <label>First Name</label>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lbl_firstname" CssClass="container-fluid" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <label>Last Name</label>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lbl_lastname" CssClass="container-fluid" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <label>Username</label>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lbl_username" CssClass="container-fluid" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <label>Password</label>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lbl_password" CssClass="container-fluid" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="col-md-1">
                            <asp:LinkButton ID="ll_reset" CssClass="control-link-blue" runat="server" ToolTip="Reset"><i class="fas fa-sync-alt"></i></asp:LinkButton>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <label>Role</label>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lbl_role" CssClass="container-fluid" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="ll_modify_role" ForeColor="SteelBlue" Font-Size="small" runat="server" ToolTip="Modify">Modify <i class="fas fa-pen"></i></asp:LinkButton>
                            <asp:LinkButton ID="ll_save_role" ForeColor="SteelBlue" Font-Size="small" runat="server" Visible="false" ToolTip="Save">Save <i class="fas fa-save"></i></asp:LinkButton>
                            <asp:LinkButton ID="ll_cancel_role" ForeColor="Darkred" Font-Size="small" runat="server" Visible="false" ToolTip="Cancel">Cancel <i class="fas fa-ban"></i></asp:LinkButton>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <label>Status</label>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lbl_status" CssClass="container-fluid form-control" runat="server" Text="Label"></asp:Label>
                            <asp:DropDownList ID="ddl_status" CssClass="container-fluid form-control" Visible="false" runat="server">
                                <asp:ListItem Text="--Select--" Value="--Select--" />
                                <asp:ListItem Text="Activate" Value="Activate" />
                                <asp:ListItem Text="Desacetivate" Value="Desactivate" />

                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="ll_modify_status" ForeColor="SteelBlue" Font-Size="small" runat="server" ToolTip="Modify">Modify <i class="fas fa-pen"></i></asp:LinkButton>
                            <asp:LinkButton ID="ll_save_status" ForeColor="SteelBlue" Font-Size="small" runat="server" Visible="false" ToolTip="Save">Save <i class="fas fa-save"></i></asp:LinkButton>
                            <asp:LinkButton ID="ll_cancel_status" ForeColor="Darkred" Font-Size="small" runat="server" Visible="false" ToolTip="Cancel">Cancel <i class="fas fa-ban"></i></asp:LinkButton>
                        </div>
                    </div>
                    <br />
                    <div class="row " id="row_comments" runat="server" visible="false">
                        <div class="col-md-3">
                            <label>Comments</label>
                        </div>
                        <div class="col-md-5">
                            <asp:TextBox ID="txt_comments" CssClass="container-fluid form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btn_save_comments" CssClass="container-fluid form-control btn-blue" runat="server" Text="Save" />
                        </div>
                    </div>
                    <br />
                    <div class="row blue-line"></div>
                    <br/>
                    <div class="row">
                        <div class="col-md-6">
                            <label class="header-label-header2 container-fluid form-control">Autorisation & Restriction</label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1">
                            <asp:CheckBox ID="cbx_administration" runat="server" />
                        </div>
                        <div class="col">
                            <label style="color: black">Administration</label>
                        </div>
                    </div>
                            <br />
                    <div class="row">
                        <div class="col-md-2" style="text-align:right">
                            <asp:CheckBox ID="cbx_rrhh" runat="server" />
                        </div>
                        <div class="col">
                            <label style="color: black">Human Ressources</label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2" style="text-align:right">
                            <asp:CheckBox ID="cbx_finances" runat="server" />
                        </div>
                        <div class="col">
                            <label style="color: black">Finances</label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2" style="text-align:right">
                            <asp:CheckBox ID="cbx_settings" runat="server" />
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
                    <br />
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:CheckBox ID="cbx_report" runat="server" />
                                </div>
                                <div class="col">
                                    <label style="color: black">Report</label>
                                </div>
                            </div>
                    <div class="row " id="row_comment2" runat="server" visible="false">
                        <div class="col-md-3">
                            <label>Comments</label>
                        </div>
                        <div class="col-md-5">
                            <asp:TextBox ID="TextBox1" CssClass="container-fluid form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="Button1" CssClass="container-fluid form-control btn-blue" runat="server" Text="Save" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col">
                            <asp:GridView ID="grd_employe_comments" CssClass="container-fluid" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                    <asp:BoundField DataField="comment" HeaderText="Comments" SortExpression="comment" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                    <asp:BoundField DataField="user" HeaderText="User" SortExpression="user" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                    
                                </Columns>
                                <AlternatingRowStyle BackColor="lightgray" ForeColor="black" />
                                <HeaderStyle BackColor="steelblue" BorderColor="white" BorderStyle="Solid" BorderWidth="1px" CssClass="container-fluid" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label ID="lbl_employe_id" Visible="false" runat="server" Text="Label"></asp:Label>
                        <asp:GridView ID="grd_user" Visible="false" runat="server"></asp:GridView>
                        <asp:GridView ID="grd_autjorization" Visible="false" runat="server"></asp:GridView>
                        <asp:GridView ID="grd_role" Visible="false" runat="server"></asp:GridView>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>
