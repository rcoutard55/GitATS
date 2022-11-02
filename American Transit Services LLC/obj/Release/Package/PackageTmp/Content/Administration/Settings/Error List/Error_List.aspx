<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ats_settings.Master" CodeBehind="Error_List.aspx.vb" Inherits="American_Transit_Services_LLC.Error_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-11 mx-auto">
            <br /><br />
            <div class="row">
                <div class="col">
                    <label class="header-text">System Error list</label>
                </div>
            </div>
            <br />
            <div class="row line"></div>
            <br />
            <div class="row">
                <div class="col">
                    <div class="card">
                    <div class="card-header">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:TextBox id="txt_search" cssclass="container-fluid form-control" placeholder="Search" runat="server"></asp:TextBox>
                            </div>
                            <div class="col">
                                <asp:LinkButton id="lbl_search" cssclass="card-header-control" runat="server" tooltip="Search"><i class="fas fa-search"></i></asp:LinkButton>
                                
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="grd_error_list" CssClass="container-fluid" AutoGenerateColumns="false" runat="server">
                            <Columns>
                                 <asp:BoundField DataField="id" HeaderText="#" ReadOnly="True" SortExpression="id" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" ItemStyle-Width="100" />
                                    <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" ItemStyle-ForeColor="Black" HtmlEncode="false" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="center" ItemStyle-Width="150"/>
                                    <asp:BoundField DataField="time" HeaderText="Time" SortExpression="time" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" ItemStyle-Width="150"/>
                                    <asp:BoundField DataField="message" HeaderText="Error Message" SortExpression="message" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="left"/>
                                    
                                   
                                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" ItemStyle-Width="150"/>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="center" ItemStyle-Width="75">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="ll_view" ForeColor="SteelBlue" Font-Bold="true" runat="server"><i class="fas fa-eye"></i></asp:LinkButton>
                                            
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
            </div>
         </div>
</asp:Content>
