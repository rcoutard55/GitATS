<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="Client_add.aspx.vb" Inherits="American_Transit_Services_LLC.Client_add" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
        <div class="col-md-12 mx-auto">
            <br />
            <div class="row">
                <div class="col-md-4">
                     <label class="header-text">New Client</label>
                </div>
                <div class="col-md-7" style="text-align:right">
                    <asp:LinkButton ID="ll_close"  CssClass="close-control" runat="server" ToolTip="Close"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
            <div class="row blue-line"></div>
           <br />
            <div class="row">
                <div class="col">
                    <asp:LinkButton ID="ll_save"  CssClass="control-link-blue" runat="server" ToolTip="Save"><i class="fas fa-save"></i></asp:LinkButton>
                    <asp:LinkButton ID="ll_cancel"  CssClass="control-link-red" runat="server" ToolTip="Cancel"><i class="fas fa-trash-alt"></i></asp:LinkButton>
                </div>
            </div>
            <br />
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
                                    <asp:TextBox ID="txt_email" CssClass="container-fluid form-control" TextMode="Email" placeholder="E-mail Address" runat="server"></asp:TextBox>
                                    
                                </div>

                            </div>
                            <br />
                            <div class="row line"></div>
                            <br />
                            <div class="row">
                               <div class="col-md-3">
                                   <label style="color:black">Blood Type</label>
                                   <asp:DropDownList ID="ddl_bloodtype" CssClass="container-fluid form-control" runat="server">
                                       <asp:ListItem Text="--Select--" Value="--Select--" />
                                       <asp:ListItem Text="A+" Value="A+" />
                                       <asp:ListItem Text="A-" Value="A-" />
                                       <asp:ListItem Text="B+" Value="B+" />
                                       <asp:ListItem Text="B-" Value="B-" />
                                       <asp:ListItem Text="O+" Value="O+" />
                                       <asp:ListItem Text="O-" Value="O-" />
                                       <asp:ListItem Text="AB+" Value="AB+" />
                                       <asp:ListItem Text="AB-" Value="AB-" />
                                       
                                   </asp:DropDownList>
                               </div>
                                <div class="col-md-3">
                                     <label style="color:black">Date Of Birth</label>
                                    <asp:TextBox ID="txt_dob" CssClass="container-fluid form-control" Autopostback="true" TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-3" style="text-align:center">
                                     <label style="color:black">Age</label>
                                    <asp:TextBox ID="txt_age" ReadOnly="true" CssClass="container-fluid form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-3" style="text-align:center">
                                     <label style="color:black">Gender</label>
                                    <asp:DropDownList ID="ddl_gender" CssClass="container-fluid form-control" runat="server">
                                        <asp:ListItem Text="--Select--" Value="--Select--" />
                                        <asp:ListItem Text="Female" Value="Female" />
                                        <asp:ListItem Text="Male" Value="Male" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-8">
                                    <label style="color:black">Prescribe Medication List</label>
                                    <asp:TextBox ID="txt_medication" CssClass="container-fluid form-control" TextMode="MultiLine" Height="150" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col">
                                    <label style="color:black">Emergency Contact Information</label>
                                    <div class="row">
                                        <div class="col-md-8">
                                             <label style="color:black">Name</label>
                                            <asp:TextBox ID="txt_name" CssClass="container-fluid form-control" placeholder="Contact name" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4">
                                            <label style="color:black">Telephone Number</label>
                                            <asp:TextBox ID="txt_telephone2" CssClass="container-fluid form-control" placeholder="Telephone" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br /><br />
                        </div>
                        
                    </div>
                    <br /><br />
                </div>
                <div class="row">
                    <div class="col">
                        
                        <asp:GridView ID="grd_client" Visible="False" runat="server" ></asp:GridView>
                       
                        <asp:GridView ID="grd_state" Visible="False" runat="server" ></asp:GridView>
                        <asp:Label ID="lbl_client_id" Visible="false" runat="server" Text="Label"></asp:Label>
                        
                    </div>
                </div>
            </div>
        </div>

    </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ll_save" />
            <asp:PostBackTrigger ControlID="ll_cancel" />
            <asp:PostBackTrigger ControlID="ll_close" />
            
            
        </Triggers>
    </asp:UpdatePanel>
    
</asp:Content>
