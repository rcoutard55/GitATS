<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ats_settings.Master" CodeBehind="Log History.aspx.vb" Inherits="American_Transit_Services_LLC.Log_History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../../Css/rate.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="row">
        <div class="col-md-12 mx-auto">
            <br /><br />
            <div class="row">
                <div class="col">
                    <label class="header-text">Log History</label>
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
                                <asp:LinkButton id="lbl_search" cssclass="fas fa-search link6" runat="server" tooltip="Search"></asp:LinkButton>
                                
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="grd_log_history" CssClass="container-fluid" AutoGenerateColumns="false" runat="server">
                            <Columns>

                            </Columns>
                            
                        </asp:GridView>
                    </div>
                        </div>
                    </div>
                </div>
            </div>
         </div>
</asp:Content>
