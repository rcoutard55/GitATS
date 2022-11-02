<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="Password.aspx.vb" Inherits="American_Transit_Services_LLC.Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" >
        <div class="col-md-11 mx-auto">
            <br /><br />
            <div class="row">
                <div class="col-md-4">
                    <label class="header-text">Change Password</label>
                </div>
                 <div class="col-md-7" style="text-align:right">
                   <asp:LinkButton ID="ll_close" ForeColor="DarkRed" CssClass="close-control" runat="server" ToolTip="Close"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
             <div class="row line"></div>
            <br />
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <div class="card">
                        <div class="card-body">
                             <br />
                           <div class="row">
                                <div class="col" style="margin-top: 20px;">
                                    <asp:Label ID="lbl_comment" CssClass="comment container-fluid form-control" runat="server" Visible="false" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                           
                            <div class="row">
                                <div class="col">
                                    <label style="color:black">Actual Password</label>
                                    <asp:TextBox id="txt_password" cssclass="container-fluid form-control" textmode="password" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col">
                                    <label style="color:black">New Password</label>
                                    <asp:TextBox id="txt_new_password" cssclass="container-fluid form-control" textmode="password" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col">
                                    <label style="color:black">Confirm Password</label>
                                    <asp:TextBox id="txt_confirm_password" cssclass="container-fluid form-control" textmode="password" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-10 mx-auto">
                                    <asp:Button id="btn_save" cssclass="btn-blue container-fluid form-control"  runat="server" Text="Save" />
                                    
                                </div>
                            </div>
                            
                        </div>
                        <br /><br />
                        </div>
                    <br /><br /><br /><br /><br /><br />
                    </div>
                <div class="row">
                    <asp:GridView ID="grd_user" Visible="false" runat="server"></asp:GridView>
                    <asp:GridView ID="grd_password_saver" Visible="false" runat="server"></asp:GridView>
                    <asp:Label ID="lbl_password" Visible="false" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="lbl_employe_ID" Visible="false" runat="server" Text="Label"></asp:Label>
                </div>
                </div>
            </div>
        </div>
</asp:Content>
