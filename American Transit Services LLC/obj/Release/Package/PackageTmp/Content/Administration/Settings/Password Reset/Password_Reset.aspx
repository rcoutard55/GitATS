<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ats_settings.Master" CodeBehind="Password_Reset.aspx.vb" Inherits="American_Transit_Services_LLC.Password_Reset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../../Css/Employe_Database.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12 mx-auto">
            <br />
            <br />
            <div class="row">
                <div class="col">
                    <label class="header-text">User Password Reset</label>
                </div>
            </div>
            <br />
            <div class="row row-comment" id="row_comment" runat="server" visible="false">
                <div class="col-md-9" style="margin-top: 20px;">
                    <asp:Label ID="lbl_comment" ForeColor="Black" Font-Bold="true" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col">
                    <asp:LinkButton ID="ll_ok1" CssClass="fas fa-check link5" Style="margin-top: 20px" ForeColor="Green" runat="server"></asp:LinkButton>
                    <asp:LinkButton ID="ll_ok2" CssClass="fas fa-times-circle link5" ForeColor="darkred" runat="server"></asp:LinkButton>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col">
                    <div class="card" style="height: 100vh;">
                        <div class="card-body" style="overflow-y: scroll">
                            <asp:GridView ID="grd_user" CssClass="container-fluid" AutoGenerateColumns="false" runat="server">
                                <Columns>
                                </Columns>
                                <HeaderStyle />
                                <AlternatingRowStyle />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
