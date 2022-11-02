<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ats_settings.Master" CodeBehind="Department.aspx.vb" Inherits="American_Transit_Services_LLC.Department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../../Css/rate.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-11 mx-auto">
            <br />
            <br />
            <div class="row">
                <div class="col">
                    <label class="header-text">Department</label>
                </div>
            </div>
            <br />
            <div class="row line"></div>
            <br />
            <div class="row">
                <div class="col" style="margin-top: 20px;">
                    <asp:Label ID="lbl_comment" CssClass="comment container-fluid form-control" runat="server" Visible="false" Text=""></asp:Label>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <div class="card">
                        <div class="card-header">
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:TextBox ID="txt_department" CssClass="container-fluid form-control" placeholder="Type your department" runat="server"></asp:TextBox>
                                </div>
                                <div class="col">
                                    <asp:LinkButton ID="lbl_search" CssClass="link6" runat="server" ToolTip="Search"><i class="fas fa-search"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lbl_save" CssClass="link6" runat="server" ToolTip="Save"><i class="fas fa-save"></i></asp:LinkButton>

                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <asp:GridView ID="grd_department" CssClass="container-fluid table table-strip table-bordered" AutoGenerateColumns="false" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" SortExpression="id" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                    <asp:BoundField DataField="department" HeaderText="Department" SortExpression="department" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="left" />
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <label>Options</label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbl_modify" OnClick="lbl_modify_Click" ForeColor="steelblue" runat="server" ToolTip="Modify"><i class="fas fa-pen"></i></asp:LinkButton>
                                            <asp:LinkButton ID="ll_delete" OnClick="ll_delete_Click" ForeColor="darkred" runat="server" ToolTip="delete"><i class="fas fa-trash-alt"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <AlternatingRowStyle BackColor="lightgray" ForeColor="black" />
                                <HeaderStyle BackColor="steelblue" BorderColor="white" BorderStyle="Solid" BorderWidth="1px" CssClass="container-fluid" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <asp:Label ID="lbl_choice" Visible="false" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="ll_department_id" Visible="false" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
