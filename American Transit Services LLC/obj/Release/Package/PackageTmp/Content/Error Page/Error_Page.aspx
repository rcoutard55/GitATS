<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="Error_Page.aspx.vb" Inherits="American_Transit_Services_LLC.Error_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="height:90vh; font-family:'Bookman Old Style'">
        <div class="col-md-12">
            <br />
            <br />
            <br />


            <div class="row">
                <div class="col" style="text-align:center">
                    <i style="color:darkgoldenrod; font-size:xx-large; font-weight:bold" class="fas fa-exclamation-triangle"></i>
                </div>
            </div>
            <p style="text-align:center; font-size:large; font-weight:bold; color:darkred">
                Your system is currently blocked. You have not changed your password in time. 
                
            </p>
            <p style="text-align:center; font-size:large; font-weight:bold; color:darkred">
                Please contact your system Administrator.
            </p>
        </div>
    </div>
</asp:Content>
