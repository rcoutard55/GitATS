<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="Client.aspx.vb" Inherits="American_Transit_Services_LLC.Client" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-md-12 mx-auto">
            <br /><br />
            <div class="row">
                <div class="col">
                    <label class="header-text">Client Database</label>
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
                            <asp:GridView ID="grd_Client" Class="container-fluid table table-strip table-bordered" FooterStyle-BackColor="SteelBlue" ShowFooter="True" AutoGenerateColumns="False" runat="server" >
                                <Columns>
                                    <asp:BoundField DataField="client_id" HeaderText="ID" ReadOnly="True" SortExpression="client_id" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                    <asp:BoundField DataField="first_name" HeaderText="First Name" SortExpression="first_name" ItemStyle-ForeColor="Black"/>
                                    <asp:BoundField DataField="last_name" HeaderText="Last Name" SortExpression="last_name" ItemStyle-ForeColor="Black"/>
                                    <asp:BoundField DataField="telephone" HeaderText="Telephone" SortExpression="telephone" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center"/>
                                    <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" ItemStyle-ForeColor="Black"/>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate >
                                            <asp:LinkButton ID="ll_view" OnClick="ll_view_Click" ForeColor="SteelBlue" Font-Size="small" Font-Bold="true" runat="server"><i class="fas fa-eye"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                 <alternatingRowStyle backcolor="lightgray" ForeColor="black" />
                            <HeaderStyle BackColor="steelblue"  BorderColor="white" BorderStyle="Solid" BorderWidth="1px" CssClass="container-fluid" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>
                            
                           
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label ID="lbl_client_id" Visible="false" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
