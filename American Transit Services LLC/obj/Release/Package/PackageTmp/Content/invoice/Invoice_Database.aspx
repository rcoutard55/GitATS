<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="Invoice_Database.aspx.vb" Inherits="American_Transit_Services_LLC.Invoice_Database" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12 mx-auto">
            <br /><br />
            <div class="row">
                <div class="col">
                    <label class="header-text">Invoices</label>
                </div>
            </div>
            <br />
            
            <br />
            <div class="row">
                <div class="col">
                    <div class="card" style="height:75vh;">
                        <div class="card-body" style="overflow-y:scroll">
                            <asp:GridView ID="grd_invoice" FooterStyle-BackColor="SteelBlue" ShowFooter="True" CssClass="container-fluid" AutoGenerateColumns="false" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="invoice_id" HeaderText="ID" ReadOnly="True" SortExpression="invoice_id" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                    <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" ItemStyle-ForeColor="Black" HtmlEncode="false" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="center"/>
                                    <asp:BoundField DataField="firstname" HeaderText="First Name" SortExpression="firstname" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center"/>
                                    <asp:BoundField DataField="lastname" HeaderText="Last Name" SortExpression="lastname" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center"/>
                                    <asp:BoundField DataField="amount" HeaderText="Amount" SortExpression="amount" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="right"/>
                                    <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center"/>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate >
                                            <asp:LinkButton ID="ll_view" OnClick="ll_view_Click"  ForeColor="SteelBlue" Font-Size="small" Font-Bold="true" runat="server"><i class="fas fa-eye"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <alternatingRowStyle backcolor="lightgray" ForeColor="black" />
                            <HeaderStyle BackColor="steelblue"  BorderColor="white" BorderStyle="Solid" BorderWidth="1px" CssClass="container-fluid" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label ID="lbl_invoice_id" Visible="false" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
