<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ats_rrhh.Master" CodeBehind="Employe_Download.aspx.vb" Inherits="American_Transit_Services_LLC.Employe_Download" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</<div class="row">
        <div class="col-md-11 mx-auto">
            <div class="row">
                <div class="col-md-6">
                    <label class="header-text">Download</label>
                </div>
                <div class="col-md-5" style="text-align:right">
                    <asp:LinkButton ID="ll_close" CssClass="close-control" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
            <br />
            <div class="row blue-line"></div>
            <br />
            <div class="row">
                <div class="col">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" CssClass="container-fluid " Width="850px" Height="1100px" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" >
                <LocalReport ReportPath="Content\Administration\RRHH\Employe\Employe.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="Employe_Dataset" />
                        <rsweb:ReportDataSource DataSourceId="SqlDataSource2" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:atsConnectionString %>" SelectCommand="SELECT [c_date], [comment], [user] FROM [Report_Employe_Comment] ORDER BY [c_date] DESC"></asp:SqlDataSource>
                </div>
            </div>
            
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:atsConnectionString %>" SelectCommand="SELECT * FROM [Report_Employe]"></asp:SqlDataSource>
            
        </div>
        <div class="row">
            <div class="col">
                <asp:GridView ID="grd_reservation" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_invoice" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_invoice_detail" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_proforma" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_client" Visible="false" runat="server"></asp:GridView>
                <asp:Label ID="lbl_employe_id" Visible="false" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
    </asp:Content>
