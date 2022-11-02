<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="Proforma_Database.aspx.vb" Inherits="American_Transit_Services_LLC.Proforma_Database" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12 mx-auto">
            <br /><br />
            <div class="row">
                <div class="col">
                    <label class="header-text">Proforma Database</label>
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
                            <asp:GridView ID="grd_proforma" PageSize="5" Class="container-fluid table table-strip table-bordered" AutoGenerateColumns="False" runat="server" FooterStyle-BackColor="SteelBlue" ShowFooter="True">
                                <Columns>
                                    <asp:BoundField DataField="proforma_id" HeaderText="ID" ReadOnly="True" SortExpression="Proforma_id" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" >
<ItemStyle HorizontalAlign="Center" ForeColor="Black"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="reservation_date" HeaderText="Date" SortExpression="reservation_date" ItemStyle-ForeColor="Black" HtmlEncode="false" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="center">
<ItemStyle HorizontalAlign="Center" ForeColor="Black"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="reservation_time" HeaderText="Appointment Time" SortExpression="reservation_time" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center">
<ItemStyle HorizontalAlign="Center" ForeColor="Black"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="total_rate" HeaderText="Payable Amount" SortExpression="total_rate" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="right">
<ItemStyle HorizontalAlign="Right" ForeColor="Black"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="total_cancel" HeaderText="Cancel Amount" SortExpression="total_cancel" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="right">
<ItemStyle HorizontalAlign="Right" ForeColor="Black"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center">
<ItemStyle HorizontalAlign="Center" ForeColor="Black"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="center">
                                        <ItemTemplate >
                                            <asp:LinkButton ID="ll_view" OnClick="ll_view_Click"  ForeColor="SteelBlue" Font-Size="small" Font-Bold="true" runat="server"><i class="fas fa-eye"></i></asp:LinkButton>
                                        </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                </Columns>
                                 <alternatingRowStyle backcolor="lightgray" ForeColor="black" />

<FooterStyle BackColor="SteelBlue"></FooterStyle>

                            <HeaderStyle BackColor="steelblue"  BorderColor="white" BorderStyle="Solid" BorderWidth="1px" CssClass="container-fluid" ForeColor="White" HorizontalAlign="Center" />
                           
                                <PagerSettings NextPageText="Next &gt;&gt;" PageButtonCount="5" PreviousPageText="&lt;&lt; Previous" />
                           
                            </asp:GridView>
                            
                           
                        </div>
                    </div>
                    <br /><br />
                    <div class="row">
                        <asp:Label ID="lbl_proforma_id" Visible="false" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
