<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="Document.aspx.vb" Inherits="American_Transit_Services_LLC.Document" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-11 mx-auto">
            <div class="row">
                <div class="col-md-5">
                    <label class="header-text">Document</label>
                </div>
                <div class="col-md-7" style="text-align:right">
                    <asp:LinkButton id="ll_close" cssclass="close-control" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>
                </div>
            </div>
            <br />
            <div class="row blue-line"></div>
            <br />

            <div class="row">
                <div class="col">
                    <div class="card">
                        <div class="card-header">
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:LinkButton id="ll_download" cssclass="card-header-control" runat="server"><i class="fas fa-download"></i></asp:LinkButton>
                                </div>
                                <div class="col-md-1">
                                    <asp:LinkButton id="ll_save" cssclass="card-header-control" runat="server"><i class="fas fa-save"></i></asp:LinkButton>
                                </div>
                                <div class="col-md-1">
                                    <asp:LinkButton id="ll_left_align" cssclass="card-header-control" runat="server"><i class="fas fa-align-left"></i></asp:LinkButton>
                                </div>
                                <div class="col-md-1">
                                    <asp:LinkButton id="ll_right_align" cssclass="card-header-control" runat="server"><i class="fas fa-align-right"></i></asp:LinkButton>
                                </div>
                                <div class="col-md-1">
                                    <asp:LinkButton id="ll_justify_aligh" cssclass="card-header-control" runat="server"><i class="fas fa-align-justify"></i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    <asp:TextBox id="txt_document" cssclass="container-fluid form-control" textmode="multiline" height="700px" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />
                    </div>
                    <br /><br />
                </div>
            </div>
            
            
           
        </div>
    </div>
</asp:Content>
