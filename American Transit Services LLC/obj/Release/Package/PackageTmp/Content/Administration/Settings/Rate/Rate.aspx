<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ats_settings.Master" CodeBehind="Rate.aspx.vb" Inherits="American_Transit_Services_LLC.Rate1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../../Css/Rate2.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-md-12 mx-auto">
            <br />
            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="lbl_company" CssClass="header-text" runat="server" Text="label1"></asp:Label>
                </div>
                <div class="col-md-5" style="text-align: right">
                    <asp:LinkButton ID="ll_close" CssClass="close-control" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
            <br />
            <div class="row line"></div>
            <br />
           <div class="row">
                <div class="col" style="margin-top: 20px;">
                    <asp:Label ID="lbl_comment" CssClass="comment container-fluid form-control" runat="server" Visible="false" Text=""></asp:Label>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-7 mx-auto">
                    <div class="card">
                        <div class="card-header">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:LinkButton ID="ll_add" CssClass="card-header-control" runat="server"><i class="fas fa-plus-circle"></i></asp:LinkButton>
                                    <asp:LinkButton ID="ll_save" CssClass="card-header-control" runat="server" Visible="false"><i class="fas fa-save"></i></asp:LinkButton>
                            <asp:LinkButton ID="ll_modify" CssClass="card-header-control" runat="server"><i class="fas fa-pen"></i></asp:LinkButton>
                            <asp:LinkButton ID="ll_delete" CssClass="card-header-control" runat="server"><i class="fas fa-trash-alt"></i></asp:LinkButton>
                                </div>
                                <div class="col-md-4" style="text-align:right">
                                    <asp:Label ID="lbl_number" ForeColor="White" Font-Bold="true" runat="server" Text="Label"></asp:Label>
                                    <label style="color:white">|</label>
                                    <asp:Label ID="lbl_total" ForeColor="White" Font-Bold="true" runat="server" Text="Label"></asp:Label>

                                </div>
                                <div class="col-md-2">
                                    <asp:LinkButton ID="ll_back" CssClass="card-header-control" runat="server"><i class="fas fa-step-backward"></i></asp:LinkButton>
                                    <asp:LinkButton ID="ll_fwd" CssClass="card-header-control" runat="server"><i class="fas fa-step-forward"></i></asp:LinkButton>
                                </div>
                            </div>
                            
                        </div>
                        <div class="card-body">
                            <br />
                            <div class="row">
                                <div class="col-md-4" style="text-align:right">
                                    <label style="color:black">Sub Company name</label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txt_name" CssClass="container-fluid form-control" placeholder="Sub Company name" runat="server"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txt_name" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ." runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-8" style="text-align: right">
                                    <label style="color: black">Dead Miles</label>

                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_deadmiles" CssClass="container-fluid form-control" Style="text-align:right" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txt_deadmiles" ValidChars="0123456789." runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                             <br />
                            <div class="row">
                                <div class="col-md-8" style="text-align: right">
                                    <label style="color: black">Loaded Miles</label>

                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_loadedmiles" CssClass="container-fluid form-control" Style="text-align:right" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txt_loadedmiles" ValidChars="0123456789." runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                             <br />
                            <div class="row">
                                <div class="col-md-8" style="text-align: right">
                                    <label style="color: black">Legs/Load Fees (Each Leg)</label>

                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_leg" CssClass="container-fluid form-control" Style="text-align:right" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txt_leg" ValidChars="0123456789." runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                             <br />
                            <div class="row">
                                <div class="col-md-8" style="text-align: right">
                                    <label style="color: black">Wait Time</label>

                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_waittime" CssClass="container-fluid form-control" Style="text-align:right" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txt_waittime" ValidChars="0123456789." runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                             <br />
                            <div class="row">
                                <div class="col-md-8" style="text-align: right">
                                    <label style="color: black">Attendant</label>

                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_attendant" CssClass="container-fluid form-control" Style="text-align:right" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txt_attendant" ValidChars="0123456789." runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                             <br />
                            <div class="row">
                                <div class="col-md-8" style="text-align: right">
                                    <label style="color: black">Equipment Rental</label>

                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_rental" CssClass="container-fluid form-control" Style="text-align:right" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txt_rental" ValidChars="0123456789." runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                             <br />
                            <div class="row">
                                <div class="col-md-8" style="text-align: right">
                                    <label style="color: black">Bariatric</label>

                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_bariatric" CssClass="container-fluid form-control" Style="text-align:right" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txt_bariatric" ValidChars="0123456789." runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                             <br />
                            <div class="row">
                                <div class="col-md-8" style="text-align: right">
                                    <label style="color: black">Stairs</label>

                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_stairs" CssClass="container-fluid form-control" Style="text-align:right" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txt_stairs" ValidChars="0123456789." runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                             <br />
                            <div class="row">
                                <div class="col-md-8" style="text-align: right">
                                    <label style="color: black">Rush</label>

                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_rush" CssClass="container-fluid form-control" Style="text-align:right" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" TargetControlID="txt_rush" ValidChars="0123456789." runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                             <br />
                            <div class="row">
                                <div class="col-md-8" style="text-align: right">
                                    <label style="color: black">Other Assistance</label>

                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_other" CssClass="container-fluid form-control" Style="text-align:right" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" TargetControlID="txt_other" ValidChars="0123456789." runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                             <br />
                            <div class="row">
                                <div class="col-md-8" style="text-align: right">
                                    <label style="color: black">After hours / Holiday / Weekend</label>

                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txt_afterhours" CssClass="container-fluid form-control" Style="text-align:right" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" TargetControlID="txt_afterhours" ValidChars="0123456789." runat="server"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <asp:Label ID="lbl_choice" Visible="false" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="lbl_company_ID" Visible="false" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="lbl_subcompany_ID" Visible="false" runat="server" Text="Label"></asp:Label>
                    <asp:GridView ID="grd_company" Visible="false" runat="server"></asp:GridView>
                    <asp:GridView ID="grd_subcompany" Visible="false" runat="server"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
