<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ats_rrhh.Master" CodeBehind="User_Database.aspx.vb" Inherits="American_Transit_Services_LLC.User_Database" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12 mx-auto">
            <br />
            <br />
            <div class="row">
                <div class="col">
                    <label class="header-text">User Database</label>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col">
                    <asp:LinkButton ID="ll_add_new" CssClass="add-link" runat="server"><i class="fas fa-plus-circle"></i></asp:LinkButton>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col" style="margin-top: 20px;">
                    <asp:Label ID="lbl_comment" CssClass="comment container-fluid form-control" runat="server" Visible="false" Text=""></asp:Label>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col">
                    <div class="card" style="height: 100vh;">
                        <div class="card-header">
                            <div class="row">
                                <div class="col-md-5">
                                    <asp:TextBox ID="txt_search" CssClass="container-fluid form-control" placeholder="Search" AutoPostBack="true" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="card-body" style="overflow-y: scroll">
                            <asp:GridView ID="grd_user" CssClass="container-fluid table table-strip table-bordered" AutoGenerateColumns="False" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="employe_id" HeaderText="ID" ReadOnly="True" SortExpression="employe_id" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                    <asp:BoundField DataField="username" HeaderText="Username" SortExpression="username" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                    <asp:BoundField DataField="role" HeaderText="Role" SortExpression="role" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                    <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                    <asp:TemplateField ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="ll_modify" ForeColor="SteelBlue" Font-Bold="true" runat="server"><i class="fas fa-pen"></i></asp:LinkButton>
                                            <asp:LinkButton ID="ll_reset" OnClick="ll_reset_Click" ForeColor="SteelBlue" Font-Bold="true" runat="server" ToolTip="Reset Password"><i class="fas fa-undo"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <AlternatingRowStyle BackColor="lightgray" ForeColor="black" />
                                <HeaderStyle BackColor="steelblue" BorderColor="white" BorderStyle="Solid" BorderWidth="1px" CssClass="container-fluid" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:atsConnectionString %>" SelectCommand="SELECT [employe_ID], [username], [role], [status] FROM [User]"></asp:SqlDataSource>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <asp:Label ID="lbl_employe_ID" Visible="false" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
