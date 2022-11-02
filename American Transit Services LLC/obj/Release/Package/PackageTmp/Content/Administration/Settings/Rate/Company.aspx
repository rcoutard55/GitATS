<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ats_settings.Master" CodeBehind="Company.aspx.vb" Inherits="American_Transit_Services_LLC.rate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../../Css/rate.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
     <div class="row">
        <div class="col-md-11 mx-auto">
            <br /><br />
            <div class="row">
                <div class="col">
                    <label class="header-text">Companies </label>
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
                <div class="col-md-5 mx-auto">
                    <div class="card">
                    <div class="card-header">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:TextBox id="txt_company" cssclass="container-fluid form-control" placeholder="Type your company here" runat="server"></asp:TextBox>
                            </div>
                            <div class="col">
                                <asp:LinkButton id="lbl_search" cssclass="card-header-control" runat="server" tooltip="Search"><i class="fas fa-search"></i></asp:LinkButton>
                                <asp:LinkButton id="lbl_save" cssclass="card-header-control" runat="server" tooltip="Save"><i class="fas fa-save"></i></asp:LinkButton>
                                
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:GridView id="grd_company" cssclass="container-fluid" autogeneratecolumns="false" runat="server">
                            <columns>
                                 <asp:BoundField DataField="company_id" HeaderText="ID" ReadOnly="True" SortExpression="company_id" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                    <asp:BoundField DataField="company" HeaderText="Company" SortExpression="company" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="left" />
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <label>Options</label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="ll_view" OnClick="ll_view_Click" ForeColor="steelblue" runat="server" ToolTip="View"><i class="fas fa-eye"></i></asp:LinkButton>
                                            <asp:LinkButton ID="lbl_modify" OnClick="lbl_modify_Click" ForeColor="steelblue" runat="server" ToolTip="Modify"><i class="fas fa-pen"></i></asp:LinkButton>
                                            <asp:LinkButton ID="ll_delete" OnClick="ll_delete_Click" ForeColor="darkred" runat="server" ToolTip="delete"><i class="fas fa-trash-alt"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                            </columns>
                             <AlternatingRowStyle BackColor="lightgray" ForeColor="black" />
                                <HeaderStyle BackColor="steelblue" BorderColor="white" BorderStyle="Solid" BorderWidth="1px" CssClass="container-fluid" ForeColor="White" HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                </div>
                </div>
                <div class="row">
                    <asp:Label ID="lbl_company_id" Visible="false" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="lbl_choice" Visible="false" runat="server" Text="Label"></asp:Label>
                </div>
                
            </div>
            </div>
         </div>
    <br /><br />
</asp:Content>
