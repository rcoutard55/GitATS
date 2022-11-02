<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ats_rrhh.Master" CodeBehind="Employe_Add.aspx.vb" Inherits="American_Transit_Services_LLC.Employe_Add" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
        <div class="col-md-12 mx-auto">
            <br />
            <div class="row">
                <div class="col-md-4">
                     <label class="header-text">New Employe</label>
                </div>
                <div class="col" style="text-align:right">
                    <asp:LinkButton ID="ll_save" ForeColor="SteelBlue" CssClass="link5" runat="server" ToolTip="Save"><i class="fas fa-save"></i></asp:LinkButton>
                    <asp:LinkButton ID="ll_cancel" ForeColor="DarkRed" CssClass="link5" runat="server" ToolTip="Cancel"><i class="fas fa-trash-alt"></i></asp:LinkButton>
                    <label class="link5" style="font-size: x-large; font-weight: bold; color: #000000">|</label>
                    <asp:LinkButton ID="ll_close" ForeColor="DarkRed" CssClass="link5" runat="server" ToolTip="Close"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
            <div class="row line"></div>
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
                                <div class="col-md-4">
                                    <label style="color: #000000">First Name</label>
                                    <asp:TextBox ID="txt_firstname" CssClass="container-fluid form-control" placeholder="First Name" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txt_firstname" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ -" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-4">
                                    <label style="color: #000000">Middle Name</label>
                                    <asp:TextBox ID="txt_middlename" CssClass="container-fluid form-control" placeholder="Middle Name" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txt_middlename" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ -" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-4">
                                    <label style="color: #000000">Last Name</label>
                                    <asp:TextBox ID="txt_lastname" CssClass="container-fluid form-control" placeholder="Last Name" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txt_lastname" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ -" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <label style="color: #000000">Address Line 1</label>
                                    <asp:TextBox ID="txt_address1" CssClass="container-fluid form-control" placeholder="House, apartment, condo #1" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txt_address1" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ# -0123456789" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-6">
                                    <label style="color: #000000">Address Line 2</label>
                                    <asp:TextBox ID="txt_address2" CssClass="container-fluid form-control" placeholder="Street name, area" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txt_address2" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ -0123456789" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-4">
                                    <label style="color: #000000">City</label>
                                    <asp:TextBox ID="txt_city" CssClass="container-fluid form-control" placeholder="City" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txt_city" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ -" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-4">
                                    <label style="color: #000000">State</label>
                                    <asp:DropDownList ID="ddl_state" CssClass="container-fluid form-control" runat="server">
                                        <asp:ListItem Text="--Select--" Value="--Select--" />
                                    </asp:DropDownList>
                                    
                                </div>
                                <div class="col-md-4">
                                    <label style="color: #000000">Zip Code</label>
                                    <asp:TextBox ID="txt_zipcode" CssClass="container-fluid form-control" placeholder="Zip Code" runat="server" MaxLength="5"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txt_zipcode" ValidChars="0123456789" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-4">
                                    <label style="color: #000000">Telephone</label>
                                    <asp:TextBox ID="txt_telephone" CssClass="container-fluid form-control" placeholder="Telephone" runat="server" MaxLength="14"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txt_telephone" ValidChars="0123456789" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-8">
                                    <label style="color: #000000">E-Mail</label>
                                    <asp:TextBox ID="txt_email" CssClass="container-fluid form-control" placeholder="E-mail Address" runat="server"></asp:TextBox>
                                    
                                </div>

                            </div>
                            <br />
                            <div class="row line"></div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <label style="color: #000000">Employement Date</label>
                                    <asp:TextBox ID="txt_employementdate" CssClass="container-fluid form-control" textmode="Date" runat="server" ></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label style="color: #000000">Department</label>
                                    <asp:DropDownList ID="ddl_department" AutoPostBack="true" CssClass="container-fluid form-control" runat="server"/>
                                    <asp:TextBox ID="txt_department" CssClass="form-control" Visible="false" runat="server"></asp:TextBox>
                                    <asp:LinkButton ID="ll_save_department" ForeColor="SteelBlue" Font-Size="Small" Font-Bold="true" runat="server" Visible="false"><i class="fas fa-save"></i></asp:LinkButton>
                                    <asp:LinkButton ID="ll_cancel_department" ForeColor="darkred" Font-Size="Small" Font-Bold="true" runat="server" Visible="false"><i class="fas fa-ban"></i></asp:LinkButton>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <label style="color: #000000">Position</label>
                                    <asp:TextBox ID="txt_position" CssClass="container-fluid form-control" placeholder="Position" runat="server" ></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" TargetControlID="txt_position" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ -" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-6">
                                    <label style="color: #000000">Department</label>
                                    <asp:TextBox ID="txt_salary" CssClass="container-fluid form-control" Style="text-align:right" runat="server" placeholder="Salary"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" TargetControlID="txt_salary" ValidChars="0123456789." runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                           
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        
                        <asp:GridView ID="grd_employe" Visible="False" runat="server" ></asp:GridView>
                        <asp:GridView ID="grd_department" Visible="False" runat="server" ></asp:GridView>
                        <asp:GridView ID="grd_state" Visible="False" runat="server" ></asp:GridView>
                        <asp:Label ID="lbl_employe_id" Visible="false" runat="server" Text="Label"></asp:Label>
                        <asp:GridView ID="grd_proforma" Visible="False" runat="server" ></asp:GridView>
                    </div>
                </div>
            </div>
        </div>

    </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ll_save" />
            <asp:PostBackTrigger ControlID="ll_cancel" />
        </Triggers>
    </asp:UpdatePanel>
    
    
</asp:Content>
