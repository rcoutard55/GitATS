<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="Client_View.aspx.vb" Inherits="American_Transit_Services_LLC.Client_View" %>
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
                    <label class="header-text">Client Information</label>
                </div>
                <div class="col-md-7" style="text-align:right">
                    <asp:LinkButton ID="ll_close" CssClass="close-control" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
            <br />
            <div class="row blue-line"></div>
            <br />
           
            <br />
            <div class="row">
                <div class="col-md-10 mx-auto">
                    <div class="card">
                        <div class="card-header">
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:LinkButton ID="ll_download" CssClass="card-header-control" runat="server"><i class="fas fa-download"></i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col" style="margin-top: 20px;">
                                    <asp:Label ID="lbl_comment" CssClass="comment container-fluid form-control" runat="server" Visible="false" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="header-label-header container-fluid form-control">Client Information</label>
                                </div>
                            </div>
                            <br />
                            <div class="row row-client">
                                <div class="col-md-4">
                                    <label class="label-text">First Name</label>
                                    <br />
                                    <asp:Label ID="lbl_firstname" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_firstname" CssClass="container-fluid form-control" placeholder="First name" Visible="false" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txt_firstname" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ -" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-4">
                                    <label class="label-text">Middle Name</label>
                                    <br />
                                    <asp:Label ID="lbl_middlename" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_middlename" CssClass="container-fluid form-control" placeholder="Middle name" Visible="false" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txt_middlename" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ -" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-4">
                                    <label class="label-text">Last Name</label>
                                    <br />
                                    <asp:Label ID="lbl_lastname" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_lastname" CssClass="container-fluid form-control" placeholder="First name" Visible="false" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txt_lastname" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ -" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <br />
                            <div class="row row-client">
                                <div class="col-md-4">
                                    <label class="label-text">Address (Line1) :</label>
                                    <br />
                                    <asp:Label ID="lbl_address1" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_address1" CssClass="container-fluid form-control" placeholder="House, apartment, condo number" Visible="false" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txt_address1" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ -#.,0123456789" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-4">
                                    <label class="label-text">Address (Line2) :</label>
                                    <br />
                                    <asp:Label ID="lbl_address2" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_address2" CssClass="container-fluid form-control" placeholder="Street, area" Visible="false" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txt_address2" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ -#.,0123456789" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-4">
                                    <label class="label-text">City :</label>
                                    <br />
                                    <asp:Label ID="lbl_city" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_city" CssClass="container-fluid form-control" placeholder="City" Visible="false" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txt_City" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ -#." runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <br />
                            <div class="row row-client">
                                <div class="col-md-4">
                                    <label class="label-text">State :</label>
                                    <br />
                                    <asp:Label ID="lbl_state" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    <asp:DropDownList ID="dll_state" CssClass="container-fluid form-control" Visible="false" runat="server">
                                        <asp:ListItem Text="--Select--" Value="--Select--" />
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label class="label-text">Zip Code :</label>
                                    <br />
                                    <asp:Label ID="lbl_zipcode" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_zipcode" CssClass="container-fluid form-control" placeholder="Zip Code" MaxLength="5" Visible="false" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txt_zipcode" ValidChars="0123456789" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-4">
                                    <label class="label-text">Telephone :</label>
                                    <br />
                                    <asp:Label ID="lbl_telephone" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_telephone" CssClass="container-fluid form-control" placeholder="Telephone" MaxLength="14" Visible="false" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txt_telephone" ValidChars="0123456789()- " runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <br />
                            <div class="row row-client">
                                <div class="col-md-4">
                                    <label class="label-text">E-Mail :</label>
                                    <br />
                                    <asp:Label ID="lbl_email" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_email" CssClass="container-fluid form-control" TextMode="Email" placeholder="E-Mail" MaxLength="14" Visible="false" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-11" style="text-align: right">
                                    <asp:LinkButton ID="ll_modify_client" ForeColor="SteelBlue" Font-Bold="true" Font-Size="X-Small" runat="server">Modify <i class="fas fa-pen"></i></asp:LinkButton>
                                    <asp:LinkButton ID="ll_save_client" ForeColor="SteelBlue" Font-Bold="true" Font-Size="X-Small" Visible="false" runat="server">Save <i class="fas fa-save"></i></asp:LinkButton>
                                    <asp:LinkButton ID="ll_cancel_client" ForeColor="Darkred" Font-Bold="true" Font-Size="X-Small" Visible="false" runat="server">Cancel <i class="fas fa-ban"></i></asp:LinkButton>
                                </div>

                            </div>
                            <br />
                            <div class="row blue-line"></div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="header-label-header container-fluid form-control">Additionnal Information</label>
                                </div>
                            </div>
                            <br />
                            <div class="row row-client">
                                <div class="col-md-3">
                                    <label class="label-text">Gender</label>
                                    <br />
                                    <asp:Label ID="lbl_gender" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    <asp:DropDownList ID="ddl_gender" CssClass="container-fluid form-control" Visible="false" runat="server">
                                        <asp:ListItem Text="--Select--" Value="--Select--" />
                                        <asp:ListItem Text="Female" Value="Female" />
                                        <asp:ListItem Text="Male" Value="Male" />
                                    </asp:DropDownList>

                                </div>
                                <div class="col-md-3">
                                    <label class="label-text">Date of Birth</label>
                                    <br />
                                    <asp:Label ID="lbl_dob" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_dob" CssClass="container-fluid form-control" TextMode="Date" Visible="false" runat="server"></asp:TextBox>

                                </div>
                                <div class="col-md-3">
                                    <label class="label-text">Age</label>
                                    <br />
                                    <asp:Label ID="lbl_age" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_age" Style="text-align: center" ReadOnly="true" CssClass="container-fluid form-control" Visible="false" runat="server"></asp:TextBox>

                                </div>
                                <div class="col-md-3">
                                    <label class="label-text">Blood Type</label>
                                    <br />
                                    <asp:Label ID="lbl_bloodtype" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    <asp:DropDownList ID="ddl_bloodtype" CssClass="container-fluid form-control" Visible="false" runat="server">
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
                            </div>
                            <br />
                            <div class="row row-client">
                                <div class="col-md-4" style="text-align: center">
                                    <label class="label-text">Medication List</label>
                                    <br />
                                    <asp:TextBox ID="txt_medication" CssClass="container-fluid form-control" ReadOnly="true" TextMode="MultiLine" Height="100" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label class="label-text">Emergency Contact</label>
                                    <br />
                                    <asp:Label ID="lbl_name" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_name" CssClass="container-fluid form-control" placeholder="Contact name" Visible="false" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txt_name" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ -" runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                                <div class="col-md-4">
                                    <label class="label-text">Telephone</label>
                                    <br />
                                    <asp:Label ID="lbl_telephone2" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txt_telephone2" CssClass="container-fluid form-control" placeholder="Telephone" Visible="false" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" TargetControlID="txt_telephone2" ValidChars="0123456789()- " runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <br />
                            <div class="row row-client">
                                <div class="col-md-10" style="text-align: right">
                                    <asp:LinkButton ID="ll_modify_additionnal" ForeColor="SteelBlue" Font-Bold="true" Font-Size="X-Small" runat="server">Modify <i class="fas fa-pen"></i></asp:LinkButton>
                                    <asp:LinkButton ID="ll_save_additionnal" ForeColor="SteelBlue" Font-Bold="true" Font-Size="X-Small" Visible="false" runat="server">Save <i class="fas fa-save"></i></asp:LinkButton>
                                    <asp:LinkButton ID="ll_cancel_additionnal" ForeColor="Darkred" Font-Bold="true" Font-Size="X-Small" Visible="false" runat="server">Cancel <i class="fas fa-ban"></i></asp:LinkButton>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="header-label-header container-fluid form-control">Invoices</label>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col">
                                    <asp:GridView ID="grd_invoice" Height="350" CssClass="container-fluid form-control" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="Invoice_id" HeaderText="#" ReadOnly="True" SortExpression="invoice_id" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                            <asp:BoundField DataField="invoice_date" HeaderText="Date" SortExpression="invoice_date" ItemStyle-ForeColor="Black" />
                                            <asp:BoundField DataField="amount" HeaderText="Amount" SortExpression="amount" ItemStyle-ForeColor="Black" />
                                            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                                            <asp:TemplateField ItemStyle-HorizontalAlign="center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="ll_view" ForeColor="SteelBlue" Font-Bold="true" Font-Size="small" runat="server"><i class="fas fa-eye"></i></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <AlternatingRowStyle BackColor="lightgray" ForeColor="black" />
                                        <HeaderStyle BackColor="steelblue" BorderColor="white" BorderStyle="Solid" BorderWidth="1px" CssClass="container-fluid" ForeColor="White" HorizontalAlign="Center" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <label class="label-text">PickUp Date</label>
                                                    <br />
                                                    <asp:Label ID="lbl_pickup_date" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="label-text">PickUp time</label>
                                                    <br />
                                                    <asp:Label ID="lbl_pick_time" CssClass="container-fluid label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-6" style="text-align: center">
                                                    <label class="label-text">Origin</label>
                                                </div>
                                                <div class="col-md-6" style="text-align: center">
                                                    <label class="label-text">Destination</label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-6" style="text-align: center">
                                                    <asp:Label ID="lbl_origin1" CssClass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                                <div class="col-md-6" style="text-align: center">
                                                    <asp:Label ID="lbl_destination1" CssClass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row" id="row_travel2" runat="server" visible="false">
                                                <div class="col-md-6" style="text-align: center">
                                                    <asp:Label ID="lbl_origin2" CssClass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                                <div class="col-md-6" style="text-align: center">
                                                    <asp:Label ID="lbl_destination2" CssClass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row" id="row_travel3" runat="server" visible="false">
                                                <div class="col-md-6" style="text-align: center">
                                                    <asp:Label ID="lbl_origin3" CssClass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                                <div class="col-md-6" style="text-align: center">
                                                    <asp:Label ID="lbl_destination3" CssClass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row" id="row_travel4" runat="server" visible="false">
                                                <div class="col-md-6" style="text-align: center">
                                                    <asp:Label ID="lbl_origin4" CssClass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                                <div class="col-md-6" style="text-align: center">
                                                    <asp:Label ID="lbl_destination4" CssClass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row" id="row_travel5" runat="server" visible="false">
                                                <div class="col-md-6" style="text-align: center">
                                                    <asp:Label ID="lbl_origin5" CssClass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                                <div class="col-md-6" style="text-align: center">
                                                    <asp:Label ID="lbl_destination5" CssClass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <label class="label-text">Distance :</label>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:Label ID="lbl_distance" CssClass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <label class="label-text">Time :</label>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:Label ID="lbl_time" CssClass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <label class="label-text">Reason :</label>
                                                </div>
                                                <div class="col-md-10">
                                                    <asp:Label ID="lbl_reason" CssClass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <br />
                    <br />
                    <br />
                </div>
            </div>
            <div class="row">
                <asp:Label ID="lbl_client_id" Visible="false" runat="server" Text="Label"></asp:Label>
                <asp:GridView ID="grd_client" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_client_additionnal" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_reservation" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_state" Visible="false" runat="server"></asp:GridView>
            </div>
        </div>
    </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ll_close" />
            
            <asp:PostBackTrigger ControlID="ll_modify_client" />
            <asp:PostBackTrigger ControlID="ll_save_client" />
            <asp:PostBackTrigger ControlID="ll_cancel_client" />
            <asp:PostBackTrigger ControlID="ll_modify_additionnal" />
            <asp:PostBackTrigger ControlID="ll_save_additionnal" />
            <asp:PostBackTrigger ControlID="ll_cancel_additionnal" />
           
        </Triggers>
    </asp:UpdatePanel>
    
</asp:Content>
