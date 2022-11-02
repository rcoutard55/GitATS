<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="MyAccount.aspx.vb" Inherits="American_Transit_Services_LLC.MyAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="row" style="height:100vh">
        <div class="col-md-12 mx-auto">
            <br /><br />
            <div class="row">
                <div class="col">
                    <label class="header-text">My Account</label>
                </div>
            </div>
            <br /><br />
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <label style="color:black">First Name</label>
                                    <asp:TextBox ID="txt_firstname" CssClass="container-fluid form-control" ReadOnly="true" runat="server" />
                                </div>
                                <div class="col-md-6">
                                    <label style="color:black">Last Name</label>
                                    <asp:TextBox ID="txt_lastname" CssClass="container-fluid form-control" ReadOnly="true" runat="server" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col" style="text-align:right">
                                    <asp:LinkButton ID="ll_name_modify" ForeColor="SteelBlue" Font-Size="X-Small" runat="server"><i class="fas fa-pen"></i> Modify</asp:LinkButton>
                                    <asp:LinkButton ID="ll_save" ForeColor="SteelBlue" Font-Size="X-Small" runat="server" Visible="false"><i class="fas fa-save"></i> Save</asp:LinkButton>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <label style="color:black">Username</label>
                                    <asp:TextBox ID="txt_username" CssClass="container-fluid form-control" ReadOnly="true" runat="server" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:LinkButton ID="ll_password" ForeColor="SteelBlue" Font-Size="Small" runat="server">Change Password <i class="fas fa-key-skeleton"></i></asp:LinkButton>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col">
                                    <asp:CheckBox ID="cbx_notification" runat="server" CssClass="notification" />
                                    <label class="notification">Check if you wish to receive change password notification. <i class="fas fa-bell"></i></label>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <asp:GridView ID="grd_employe" Visible="false" runat="server"></asp:GridView>
                    <asp:GridView ID="grd_user" Visible="false" runat="server"></asp:GridView>
                    <asp:Label ID="lbl_employe_id" Visible="false" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            </div>
          </div>

</asp:Content>
