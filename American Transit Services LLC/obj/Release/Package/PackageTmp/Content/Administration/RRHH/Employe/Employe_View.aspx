<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="Employe_View.aspx.vb" Inherits="American_Transit_Services_LLC.Employe_View" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
        <div class="col-md-10 mx-auto">
            <br />
            <div class="row">
                <div class="col-md-8">
                    <label class="header-text">Employe ID : <asp:Label ID="lbl_employe_id" runat="server" Text="Label"></asp:Label></label>
                </div>
                <div class="col-md-3" style="text-align:right">
                    <asp:LinkButton ID="ll_close" CssClass="close-control" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
            <br />
            <div class="row blue-line"></div>
            <div class="row">
                <div class="col-md-1">
                    <asp:LinkButton ID="ll_download" CssClass="control-link-blue" runat="server"><i class="fas fa-download"></i></asp:LinkButton>
                </div>
            </div>
            <div class="row blue-line"></div>
            <br />
            <div class="row">
                <div class="col">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col" style="margin-top: 20px;">
                                    <asp:Label ID="lbl_comment" CssClass="comment container-fluid form-control" runat="server" Visible="false" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="header-label-header container-fluid form-control">Employe Information</label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-2">
                                    <label>Employe ID</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lbl_employe_id2" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-2">
                                    <label>First Name</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lbl_firstname" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_firstname" CssClass="container-fluid form-control" placeholder="First Name" Visible="false" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txt_firstname" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ .-" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-2">
                                    <label>Middle Name</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lbl_middlename" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_middlename" CssClass="container-fluid form-control" placeholder="Middle Name" Visible="false" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txt_middlename" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ .-" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-2">
                                    <label>Last Name</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lbl_lastname" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_lastname" CssClass="container-fluid form-control" placeholder="Last Name" Visible="false" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txt_lastname" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ .-" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <br />
                            
                            <div class="row">
                                <div class="col-md-2">
                                    <label>Address (line1)</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lbl_address1" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_address1" CssClass="container-fluid form-control" placeholder="Address line 1" Visible="false" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txt_address1" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ .-#0123456789," runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-2">
                                    <label>Address (line2)</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lbl_address2" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_address2" CssClass="container-fluid form-control" placeholder="Address line 2" Visible="false" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txt_address2" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ .-#0123456789," runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <br />
                            
                            <div class="row">
                                <div class="col-md-2">
                                    <label>City</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lbl_city" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_city" CssClass="container-fluid form-control" placeholder="City" Visible="false" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txt_city" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ- " runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-2">
                                    <label>State</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lbl_state" runat="server" Text="Label"></asp:Label>
                                    <asp:DropDownList ID="ddl_state" CssClass="container-fluid form-control" Visible="false" runat="server">
                                        <asp:ListItem Text="--Select--" Value="--Select--" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                 <div class="col-md-2">
                                    <label>Zip Code</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lbl_zipcode" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_zipcode" CssClass="container-fluid form-control" placeholder="Zip Code" Visible="false" MaxLength="5" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txt_zipcode" ValidChars="0123456789" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-2">
                                    <label>Telephone</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lbl_telephone" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_telephone" CssClass="container-fluid form-control" placeholder="Telephone" Visible="false" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txt_telephone" ValidChars="0123456789-() " runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                             <br />
                            <div class="row">
                                 <div class="col-md-2">
                                    <label>E-Mail</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lbl_email" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_email" CssClass="container-fluid form-control" placeholder="E-Mail" Visible="false" TextMode="Email" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txt_email" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ- ._@#$%^*=+" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-2">
                                    <label>Status</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lbl_status" runat="server" Text="Label"></asp:Label>
                                    <asp:DropDownList ID="ddl_status" CssClass="container-fluid form-control" Visible="false" runat="server">
                                        <asp:ListItem Text="--Select--" Value="--Select--" />
                                        <asp:ListItem Text="Activate" Value="Activate" />
                                        <asp:ListItem Text="Desactivate" Value="Desactivate" />
                                    </asp:DropDownList>
                                </div>
                                
                            </div>
                            <br />
                            <div class="row">
                                <div class="col" style="text-align:right">
                                    <asp:LinkButton ID="ll_modify_employe" CssClass="control-link-blue" Font-Size="small" runat="server">Modify <i class="fas fa-pen"></i></asp:LinkButton>
                                    <asp:LinkButton ID="ll_save_employe" CssClass="control-link-blue" Font-Size="small" Visible="false" runat="server">Save <i class="fas fa-save"></i></asp:LinkButton>
                                    <asp:LinkButton ID="ll_cancel_employe" CssClass="control-link-red" Font-Size="small" Visible="false" runat="server">Cancel <i class="fas fa-ban"></i></asp:LinkButton>
                                </div>
                            </div>
                            <br />
                            <div class="row blue-line"></div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="header-label-header container-fluid form-control">Employement Information</label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-2">
                                    <label>Employement Date</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lbl_employement_date" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_employement_date" Visible="false" CssClass="container-fluid form-control" TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label>Department</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lbl_department" runat="server" Text="Label"></asp:Label>
                                    <asp:DropDownList ID="ddl_department" AutoPostBack="true" CssClass="container-fluid form-control" Visible="false" runat="server">
                                        <asp:ListItem Text="--Select--" Value="--Select--" />
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txt_department" Visible="false" CssClass="container-fluid form-control" placeholder="Department"  runat="server"></asp:TextBox>
                                    <asp:LinkButton ID="ll_save_department" Style="text-align:right"  CssClass="control-link-blue" Visible="false" runat="server"><i class="fas fa-save"></i></asp:LinkButton>
                                    <asp:LinkButton ID="ll_cancel_department" Style="text-align:right"  CssClass="control-link-red" Visible="false" runat="server"><i class="fas fa-ban"></i></asp:LinkButton>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-2">
                                    <label>Position</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lbl_position" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_position" Visible="false" CssClass="container-fluid form-control" PlaceHolder="Position" runat="server"></asp:TextBox>
                               <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" TargetControlID="txt_position" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ- ." runat="server"></cc1:FilteredTextBoxExtender>
                                    </div>
                                <div class="col-md-2">
                                    <label>Salary</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lbl_salary" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_salary" CssClass="container-fluid form-control" Visible="false" Style="text-align: right" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" TargetControlID="txt_salary" ValidChars="0123456789,." runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <br />
                            <div class="row" id="row_comment" runat="server" visible="false">
                                <div class="col-md-2">
                                    <label>Comment</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txt_comments" CssClass="container-fluid form-control" placeholder="Comments" TextMode="MultiLine" Height="100" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btn_save" CssClass="btn-blue container-fluid form-control"  runat="server" Text="Save" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col" style="text-align:right">
                                    <asp:LinkButton ID="ll_modify_employement" CssClass="control-link-blue" Font-Size="small" runat="server">Modify <i class="fas fa-pen"></i></asp:LinkButton>
                                    <asp:LinkButton ID="ll_save_employement" CssClass="control-link-blue" Font-Size="small" Visible="false" runat="server">Save <i class="fas fa-save"></i></asp:LinkButton>
                                    <asp:LinkButton ID="ll_cancel_employement" CssClass="control-link-red" Font-Size="small" Visible="false" runat="server">Cancel <i class="fas fa-ban"></i></asp:LinkButton>
                                </div>
                            </div>
                            <br />
                            <div class="row blue-line"></div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="header-label-header container-fluid form-control">Commentaries</label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col">
                                    <asp:GridView ID="grd_employe_comment" CssClass="container-fluid table table-strip table-bordered" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" ItemStyle-ForeColor="Black" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="center" HtmlEncode="false" DataFormatString="{0:d}" />
                                            <asp:BoundField DataField="Comment" HeaderText="Commentaries" SortExpression="comment" ItemStyle-ForeColor="Black" />
                                            <asp:BoundField DataField="e_user" HeaderText="User" SortExpression="e_user" ItemStyle-ForeColor="Black" ItemStyle-Width="200px" />
                                            
                                        </Columns>
                                        <AlternatingRowStyle BackColor="lightgray" ForeColor="black" />
                                        <HeaderStyle BackColor="steelblue" BorderColor="white" BorderStyle="Solid" BorderWidth="1px" CssClass="container-fluid" ForeColor="White" HorizontalAlign="Center" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br /><br />
                </div>
            </div>
            <div class="row">
                <asp:GridView ID="grd_employe" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_employement" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_state" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_department" Visible="false" runat="server"></asp:GridView>
                
            </div>
        </div>
    </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ll_modify_employe" />
            <asp:PostBackTrigger ControlID="ll_save_employe" />
            <asp:PostBackTrigger ControlID="ll_cancel_employe" />
            <asp:PostBackTrigger ControlID="ll_modify_employement" />
            <asp:PostBackTrigger ControlID="ll_save_employement" />
            <asp:PostBackTrigger ControlID="ll_cancel_employement" />
            <asp:PostBackTrigger ControlID="ll_save_department" />
            <asp:PostBackTrigger ControlID="ll_cancel_department" />
            <asp:PostBackTrigger ControlID="btn_save" />

        </Triggers>
    </asp:UpdatePanel>
    
</asp:Content>
