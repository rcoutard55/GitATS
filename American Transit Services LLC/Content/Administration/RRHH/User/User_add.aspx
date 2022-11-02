<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ats_rrhh.Master" CodeBehind="User_add.aspx.vb" Inherits="American_Transit_Services_LLC.User_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-md-11 ">
            <br />
            <div class="row">
                <div class="col-md-4">
                     <label class="header-text">New User</label>
                </div>
                <div class="col-md-7" style="text-align:right">
                    <asp:LinkButton ID="ll_close" CssClass="close-control" runat="server" ToolTip="Close"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
            <br />
            <div class="row blue-line"></div>
            <div class="row">
                <div class="col-md-1">
                    <asp:LinkButton ID="ll_save" CssClass="control-link-blue" runat="server" ToolTip="Save"><i class="fas fa-save"></i></asp:LinkButton>
                </div>
                <div class="col-md-1">
                    <asp:LinkButton ID="ll_cancel" CssClass="control-link-red" runat="server" ToolTip="Cancel"><i class="fas fa-ban"></i></asp:LinkButton>
                </div>
            </div>
            <div class="row blue-line"></div>
           <br />
             <div class="row">
                <div class="col-md-8 mx-auto">
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
                                <div class="col-md-6">
                                    <label style="color:black">Select Employe</label>
                                    <asp:DropDownList ID="ddl_employe" AutoPostBack="true" CssClass="container-fluid form-control" runat="server">
                                        <asp:ListItem Text="--Select--" Value="--Select--" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <label style="color:black">First Name</label>
                                    <asp:TextBox ID="txt_first_name" cssclass="container-fluid form-control" readonly="true" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label style="color:black">Last Name</label>
                                    <asp:TextBox ID="txt_lastname" cssclass="container-fluid form-control" readonly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6 mx-auto">
                                    <asp:Button ID="btn_create" CssClass="btn2 container-fluid form-control" runat="server" Text="CREATE" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                     <label style="color:black">Username</label>
                                    <asp:TextBox ID="txt_username" cssclass="container-fluid form-control" enable="false" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                     <label style="color:black">Default Password</label>
                                    <asp:TextBox ID="txt_password" cssclass="container-fluid form-control" enable="false" text="ChangeIt" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <label style="color:black">Role</label>
                                    <asp:DropDownList ID="ddl_role" AutoPostBack="true" CssClass="container-fluid form-control" runat="server">
                                        <asp:ListItem Text="--Select--" Value="--Select--" />
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-6">
                                    <label style="color:black">Status</label>
                                    <asp:DropDownList ID="ddl_status" CssClass="container-fluid form-control" runat="server">
                                        <asp:ListItem Text="--Select--" Value="--Select--" />
                                        <asp:ListItem Text="Activate" Value="Activate" />
                                        <asp:ListItem Text="Desactivate" Value="Desactivate" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            </div>
                        </div>
                    </div>
                 <div class="row">
                     <asp:GridView ID="grd_employe" Visible="False" runat="server" AutoGenerateColumns="False" >
                         <Columns>
                             <asp:BoundField DataField="employe_id" HeaderText="employe_id" ReadOnly="True" SortExpression="employe_id" />
                             <asp:BoundField DataField="first_name" HeaderText="first_name" SortExpression="first_name" />
                             <asp:BoundField DataField="last_name" HeaderText="last_name" SortExpression="last_name" />
                             <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                         </Columns>
                     </asp:GridView>
                     
                     <asp:GridView ID="grd_role" Visible="False" runat="server" AutoGenerateColumns="False" >
                         <Columns>
                             <asp:BoundField DataField="role" HeaderText="role" SortExpression="role" />
                         </Columns>
                     </asp:GridView>
                     
                     <asp:Label ID="lbl_employe_ID" visible="false" runat="server" Text="Label"></asp:Label>
                 </div>
            </div>
         </div>
     </div>
</asp:Content>
