<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ats_settings.Master" CodeBehind="Location.aspx.vb" Inherits="American_Transit_Services_LLC.Location" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../../../../Css/rate.css" rel="stylesheet" />
</asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-md-12 mx-auto">
            <br /><br />
            <div class="row">
                <div class="col">
                    <label class="header-text">Home Point</label>
                </div>
            </div>
            <br />
            <div class="row line"></div>
             <br />
            <div class="row row-comment" id="row_comment" runat="server" visible="false">
                <div class="col-md-9" style="margin-top: 20px;">
                    <asp:Label ID="lbl_comment" ForeColor="Black" Font-Bold="true" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col" style="margin-top: 20px;">
                    <asp:LinkButton ID="ll_ok1" CssClass="link5" ForeColor="Green" runat="server" Visible="false"><i class="fas fa-check-circle"></i></asp:LinkButton>
                    <asp:LinkButton ID="ll_ok2" CssClass="link5" ForeColor="darkred" runat="server" Visible="false"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-10 mx-auto">
                    <div class="card">
                    <div class="card-header">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:TextBox id="txt_location" cssclass="container-fluid form-control" placeholder="Type your location" runat="server"></asp:TextBox>
                            </div>
                            <div class="col">
                                <asp:LinkButton id="lbl_search" cssclass="link6" runat="server" tooltip="Search"><i class="fas fa-search"></i></asp:LinkButton>
                                <asp:LinkButton id="lbl_save" cssclass="link6" runat="server" tooltip="Save"><i class="fas fa-save"></i></asp:LinkButton>
                                
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="grd_location" CssClass="container-fluid" AutoGenerateColumns="false" runat="server">
                               <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" SortExpression="id" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                    <asp:BoundField DataField="location" HeaderText="Home Point" SortExpression="location" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="left" />
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <label>Options</label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="ll_modify" OnClick="ll_modify_Click"  ForeColor="steelblue" runat="server" ToolTip="Modify"><i class="fas fa-pen"></i></asp:LinkButton>
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
                <div class="row">
                    <asp:Label ID="lbl_location_id" Visible="false" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="lbl_choice" Visible="false" runat="server" Text="Label"></asp:Label>
                </div>
                </div>
            </div>
         </div>
</asp:Content>
