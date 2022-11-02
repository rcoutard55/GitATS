<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="Administration.aspx.vb" Inherits="American_Transit_Services_LLC.Administration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row row-administration">
        <div class="col-md-12 mx-auto">
              <br />  <br />
            <div class="row">
                <div class="col" style="text-align:center">
            <label class="header-text2">Administracion</label>
        </div>

        </div>
        <br /><br />
    <div class="row">
        <div class="col-md-5 mx-auto">
            <div class="card card-administration">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="container-administration">
                                <div class="row">
                                    <div class="col">
                                        <asp:LinkButton ID="ll_rrhh" CssClass="admin-link container-fluid" runat="server"><i class="fas fa-users"></i> RR.HH</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="container">
                                <div class="row">
                                    <div class="col">
                                        <asp:LinkButton ID="ll_finance" CssClass="admin-link container-fluid" runat="server"><i class="fas fa-money-bill-wave"></i> Finance</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-6">
                            <div class="container">
                                <div class="row">
                                    <div class="col">
                                        <asp:LinkButton ID="ll_settings" CssClass="admin-link container-fluid" runat="server"><i class="fas fa-cogs"></i> Settings</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    </div>
</asp:Content>
