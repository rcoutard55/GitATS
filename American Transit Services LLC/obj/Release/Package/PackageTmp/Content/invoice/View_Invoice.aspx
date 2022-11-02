<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="View_Invoice.aspx.vb" Inherits="American_Transit_Services_LLC.View_Invoice" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-md-11 mx-auto">
             <div class="row" style="margin-top:10px; margin-bottom:10px;">
               
                <div class="col-md-11" style="text-align:right">
                    <asp:LinkButton ID="lbl_close" CssClass="close-control" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
            <div class="row blue-line"></div>
            <br />
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" CssClass="container-fluid " Width="850px" Height="1100px" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" >
                <LocalReport ReportPath="Content\invoice\Invoice.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="DS_Report_Invoice" Name="DS_report_Invoice" />
                        
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            
            
            
            <asp:SqlDataSource ID="DS_Report_Invoice" runat="server" ConnectionString="<%$ ConnectionStrings:atsConnectionString %>" SelectCommand="SELECT * FROM [Report_Invoice]"></asp:SqlDataSource>
            
            
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:atsConnectionString %>" SelectCommand="SELECT * FROM [Report_Invoice]"></asp:SqlDataSource>
            
        </div>
        <div class="row">
            <div class="col">
                <asp:GridView ID="grd_reservation" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_invoice" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_invoice_detail" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_proforma" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_client" Visible="false" runat="server"></asp:GridView>
                <asp:Label ID="lbl_client_id" Visible="false" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
    
</asp:Content>
