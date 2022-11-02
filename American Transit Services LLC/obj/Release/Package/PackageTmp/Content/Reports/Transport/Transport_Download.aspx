<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ats_reports.master" CodeBehind="Transport_Download.aspx.vb" Inherits="American_Transit_Services_LLC.Transport_Download" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-md-11 mx-auto">
            <div class="row">
                <div class="col-md-5">
                    <label class="header-text">Transport Report</label>
                </div>
                <div class="col-md-6" style="text-align: right">
                    <asp:LinkButton ID="lbl_close" CssClass="close-control" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
            <br />
            <div class="row blue-line"></div>
            <br />
            <div class="row">
                <div class="col">
                     <rsweb:ReportViewer ID="ReportViewer1" runat="server" CssClass="container-fluid " Width="850px" Height="1100px" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" >
                <LocalReport ReportPath="Content\Reports\Transport\Transport_Report.rdlc">
                    <DataSources>
                        
                        <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DS_Transport" />
                        
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:atsConnectionString %>" SelectCommand="SELECT * FROM [Report_Transport]"></asp:SqlDataSource>
                </div>
            </div>
        </div>

    </div>
    
</asp:Content>
