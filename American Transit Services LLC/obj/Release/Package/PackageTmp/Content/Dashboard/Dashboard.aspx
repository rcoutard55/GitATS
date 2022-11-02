<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="Dashboard.aspx.vb" Inherits="American_Transit_Services_LLC.Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="Dashboard">
        <div class="row back-image">
        <div class="col-md-11 mx-auto ">
            <div class="row" >
                <div class="col-md-9">
                    <div class="row">
                        <div class="col-md-3"></div>
                        <div class="col-md-9">
                            <br />
                            <div class="row">
                                <div class="col">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col" style="text-align:center">
                                                    <label class="header-text">DASHBOARD</label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col">
                                                    <label class="header-label-header container-fluid form-control">Contract Chart</label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col">
                                                    <label style="font-weight: bold; color: #418CF0">Total Reservation</label>
                                                    <br />
                                                    <label style="font-weight: bold; color: #BD8730">Reservation Close</label>
                                                    <br />
                                                    <label style="font-weight: bold; color: #E0400A">Reservation Cancel</label>
                                                    <asp:Panel ID="Panel1" CssClass="container-fluid chart-panel" runat="server">
                                                        <asp:Chart ID="chart_contract" CssClass="chart-contract" runat="server" >
                                                        <series>
                                                            <asp:Series Name="Series1"></asp:Series>
                                                            <asp:Series Name="Series2"></asp:Series>
                                                            <asp:Series Name="Series3"></asp:Series>
                                                        </series>
                                                        
                                                        <chartareas>
                                                            <asp:ChartArea Name="ChartArea1">
                                                                <AxisX TitleFont="Bookman Old Style, 8pt"/>
                                                                <Area3DStyle Enable3D="true" Rotation="20" WallWidth="20" />
                                                            </asp:ChartArea>
                                                        </chartareas>
                                                    </asp:Chart>
                                                    </asp:Panel>
                                                    
                                                </div>
                                            </div>
                                            <br /><br /><br /><br />
                                            <div class="row">
                                                <div class="col">
                                                    <label class="header-label-header container-fluid form-control">Client Chart</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    
                    <div class="row notification">
                        <div class="card password-change" id="card_password" runat="server" visible="false">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-10">
                                        <label class="password-change"><i class="fas fa-exclamation-triangle"></i>Your password will expire in: <asp:Label ID="lbl_days" ForeColor="White" runat="server" Text="Label1"></asp:Label><asp:LinkButton ID="ll_password" CssClass="password-change" runat="server"> Click Here to change</asp:LinkButton></label>
                                    </div>
                                    <div class="col-md-2" style="text-align: right">
                                        <asp:LinkButton ID="ll_close" CssClass="password-change" runat="server"><i class="fas fa-times"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card contract-info" id="card_contract" runat="server" visible="false">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-10">
                                        <label class="contract-info" ><i class="fas fa-info-circle"></i> Remaining for your next contract: <asp:Label ID="lbl_info" runat="server" Text="">. </asp:Label> <asp:LinkButton ID="ll_reservation1" CssClass="contract-info" runat="server"> Click Here to View</asp:LinkButton></label>
                                    </div>
                                    <div class="col-md-2" style="text-align: right">
                                        <asp:LinkButton ID="ll_close2" CssClass="contract-info" runat="server"><i class="fas fa-times"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card contract-info2" id="card_contract2" runat="server" visible="false" >
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-10">
                                        <label class="contract-info2" ><i class="fas fa-question-circle"></i> You have over due Contract<asp:LinkButton ID="ll_reservation2" CssClass="contract-info2" runat="server"> Click Here to change</asp:LinkButton></label>
                                    </div>
                                    <div class="col-md-2" style="text-align: right">
                                        <asp:LinkButton ID="ll_close3" CssClass="contract-info2" runat="server"><i class="fas fa-times"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                
            </div>
           
        </div>
        <div class="row">
            <asp:Label ID="lbl_employe_ID" Visible="false" runat="server" Text="Label"></asp:Label>
            <asp:GridView ID="grd_user" Visible="false" runat="server"></asp:GridView>
            <asp:GridView ID="grd_reservation" Visible="false" runat="server"></asp:GridView>
            <asp:GridView ID="grd_reservation_point" Visible="false" runat="server"></asp:GridView>
        </div>
    </div>
    </div>
    
</asp:Content>
