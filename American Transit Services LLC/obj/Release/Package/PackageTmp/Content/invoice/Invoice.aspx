<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="Invoice.aspx.vb" Inherits="American_Transit_Services_LLC.Invoice" EnableEventValidation="False" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-md-11 mx-auto">
            <br />
            <br />
            <div class="row blue-line"></div>
            
            <div class="row" style="margin-top:10px; margin-bottom:10px;">
                <div class="col-md-1">
                    <asp:LinkButton ID="ll_download" CssClass="control-link-blue" runat="server"><i class="fas fa-download"></i></asp:LinkButton>
                </div>
                
                <div class="col-md-1">
                    <asp:LinkButton ID="ll_delete"  CssClass="control-link-red" runat="server"><i class="fas fa-trash-alt"></i></asp:LinkButton>
                </div>
                 
                <div class="col-md-1">
                    <asp:LinkButton ID="ll_mail"  CssClass="control-link-blue" runat="server"><i class="fas fa-envelope-open"></i></asp:LinkButton>
                </div>
                <div class="col-md-4" style="margin-top:10px;">
                    <asp:CheckBox ID="cbx_additionnal" CssClass="label-text" AutoPostBack="true" Text=" Show/Hide Additionnal Services" runat="server" />
                </div>
                <div class="col-md-3" style="text-align:right">
                    <asp:LinkButton ID="lbl_close" CssClass="close-control" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
           
            
            <br />
            <div class="row">
                <div class="col-md-5">
                    <asp:TextBox ID="txt_email" Visible="false" CssClass="container-fluid form-control" TextMode="Email" placeholder="Enter E-Mail address" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btn_send" Visible="false" cssclass="container-fluid form-control" forecolor="white" backcolor="steelblue" font-bold="true" font-size="large" runat="server" Text="SEND" />
                </div>
            </div>
            <div class="row blue-line"></div>
                <br />
            <div class="row">
                <div class="col">
                    <div class="card" id="card_invoice" runat="server">
                        <div class="card-body">
                            <div class="container" style="height:650px">
                            <div class="row">
                                <div class="col-md-2">
                                    <img src="../../Images/1_PNG.png" id="img_logo5" height="75" width="100" cssclass="img-logo5" />
                                </div>
                                <div class="col-md-10">
                                    <div class="row">
                                        <div class="col" style="text-align:center">
                                            <label style="font-size: large; color: #000000; text-decoration: underline; font-weight: bold; margin-left:-100px">AMERICAN TRANSIT SERVICES</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col" style="text-align:center">
                                            <label style="color: #000000; font-size:small; margin-left:-100px; font-weight: bold;">820 Morrow Rd Forest park GA 30297</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col" style="text-align:center">
                                            <label style="color: #000000; font-size:small; margin-left:-100px; font-weight: bold;">(000) 000-0000</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row black-line"></div>
                            <br />
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-5">
                                                    <label class="label-text">First Name</label>
                                                </div>
                                                <div class="col">
                                                    <asp:Label ID="lbl_firstname" cssclass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-5">
                                                    <label class="label-text">Middle Name</label>
                                                </div>
                                                <div class="col">
                                                    <asp:Label ID="lbl_middlename" cssclass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-5">
                                                    <label class="label-text">Last Name</label>
                                                </div>
                                                <div class="col">
                                                    <asp:Label ID="lbl_lastname" cssclass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-5">
                                                    <label class="label-text">Telephone</label>
                                                </div>
                                                <div class="col">
                                                    <asp:Label ID="lbl_telephone" cssclass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>
                                           
                                        </div>
                                    </div>
                                    
                                </div>
                                <div class="col-md-4">
                                   
                                </div>
                                <div class="col-md-4">
                                    <div class="card" >
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-5" style="text-align:right">
                                                    <label class="label-text">Invoice #</label>
                                                </div>
                                                <div class="col" style="text-align:right">
                                                    <asp:Label ID="lbl_invoice_id2" CssClass="label-text" runat="server" Text="2022ATS1000"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-5" style="text-align:right">
                                                    <label class="label-text">Date</label>
                                                </div>
                                                <div class="col" style="text-align:right">
                                                    <asp:Label ID="lbl_date" CssClass="label-text" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-4">

                                </div>
                                <div class="col-md-8">
                                    <div class="row line2"></div>
                                    <div class="row" style="background-color: gray">
                                        <div class="col-md-8" style="text-align: center">
                                            <label  class="label-text" style="font-weight: bold" >Description</label>
                                        </div>
                                        <div class="col-md-4" style="text-align: center">
                                            <label  class="label-text" style="font-weight: bold" >Price</label>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-8" style="text-align:right">
                                            <label class="label-text">Transport</label>
                                        </div>
                                        <div class="col-md-4" style="text-align:right">
                                            <asp:Label ID="lbl_transport" cssclass="label-text" runat="server" Text="Label"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row" style="background-color:lightgray">
                                        <div class="col-md-8" style="text-align:right">
                                            <label class="label-text">Additional Services</label>
                                        </div>
                                        <div class="col-md-4" style="text-align:right">
                                            <asp:Label ID="lbl_service_fee" cssclass="label-text" runat="server" Text="Label"></asp:Label>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-6"></div>
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-4"style="text-align:right; font-weight: bold; text-decoration: underline;">
                                                     <label class="label-text">Total</label>
                                                </div>
                                                <div class="col-md-8" style="text-align:right">
                                            <asp:Label ID="lbl_total" cssclass="label-text" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                        </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="row_fee" runat="server" visible="false" >
                                <div class="col-md-6" >
                                    <div class="row" style="background-color:gray; margin-left:50px; border-style:solid; border-width:1px; border-color:black" >
                                        <div class="col" style="text-align:center">
                                            <label  class="label-text" style="font-weight: bold">Additionnal Services</label>
                                        </div>

                                    </div>
                                    <div class="row" style="background-color:gray; margin-left:50px; border-style:solid; border-width:1px; border-color:black">
                                        <div class="col-md-8" style="text-align:center; border-style:solid; border-width:1px; border-color:black">
                                            <label class="label-text" style="font-weight: bold;" >Description</label>
                                        </div>
                                        <div class="col-md-4" style="text-align:center; border-style:solid; border-width:1px; border-color:black">
                                            <label class="label-text" style="font-weight: bold;">Prices</label>
                                        </div>
                                    </div>
                                    <div class="row" style="background-color:white; margin-left:50px; border-style:solid; border-width:1px; border-color:black">
                                        <div class="col-md-8" style="text-align:right; border-style:solid; border-width:1px; border-color:black">
                                            <label class="label-text">Wait Time</label>
                                        </div>
                                        <div class="col-md-4" style="text-align:right; border-style:solid; border-width:1px; border-color:black">
                                            <asp:Label ID="lbl_waittime" cssclass="label-text" runat="server" Text="Label"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row" style="background-color:lightgray; margin-left:50px; border-style:solid; border-width:1px; border-color:black">
                                        <div class="col-md-8" style="text-align:right; border-style:solid; border-width:1px; border-color:black">
                                            <label class="label-text">Additionnal Passenger</label>
                                        </div>
                                        <div class="col-md-4" style="text-align:right; border-style:solid; border-width:1px; border-color:black">
                                            <asp:Label ID="lbl_attendant" cssclass="label-text" runat="server" Text="Label"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row" style="background-color:white; margin-left:50px; border-style:solid; border-width:1px; border-color:black">
                                        <div class="col-md-8" style="text-align:right; border-style:solid; border-width:1px; border-color:black">
                                            <label class="label-text">Equipment</label>
                                        </div>
                                        <div class="col-md-4" style="text-align:right; border-style:solid; border-width:1px; border-color:black">
                                            <asp:Label ID="lbl_rental" cssclass="label-text" runat="server" Text="Label"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row" style="background-color:lightgray; margin-left:50px; border-style:solid; border-width:1px; border-color:black">
                                        <div class="col-md-8" style="text-align:right; border-style:solid; border-width:1px; border-color:black">
                                            <label class="label-text">Additionnal Help (stairs, weight, rush)</label>
                                        </div>
                                        <div class="col-md-4" style="text-align:right; border-style:solid; border-width:1px; border-color:black">
                                            <asp:Label ID="lbl_additionnal_help" cssclass="label-text" runat="server" Text="Label"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row" style="background-color:white; margin-left:50px; border-style:solid; border-width:1px; border-color:black">
                                        <div class="col-md-8" style="text-align:right; border-style:solid; border-width:1px; border-color:black">
                                            <label class="label-text">After Hours</label>
                                        </div>
                                        <div class="col-md-4" style="text-align:right; border-style:solid; border-width:1px; border-color:black">
                                            <asp:Label ID="lbl_afterhours" cssclass="label-text" runat="server" Text="Label"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                                </div>
                            <br />
                            <div class="row black-line"></div>
                            <br />
                            <div class="row">
                                <div class="col">
                                    <p class="label-text" style="text-align: justify">
                                        Thank youf for choosing American transit Services. We hope the experience has lived up to your expectation. 
                                        Don't hesitate to contact us at: should the need be as we are here for you. Please visit our webpage: <asp:LinkButton ID="ll_ats_webpagge" forecolor="steelblue" runat="server"> www.atsment.com</asp:LinkButton>  and rate our 
                                        service. Please place your comments and help us become better.
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br /><br /><br />
                </div>
            </div>
            <div class="row">
                <asp:GridView ID="grd_reservation" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_invoice" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_invoice_detail" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_proforma" Visible="false" runat="server"></asp:GridView>
                <asp:GridView ID="grd_client" Visible="false" runat="server"></asp:GridView>
                <asp:Label ID="lbl_client_id" Visible="false" runat="server" Text="Label"></asp:Label>
            </div>
            </div>
        </div>
    
</asp:Content>
