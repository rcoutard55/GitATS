<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ATS.Master" CodeBehind="Calendar.aspx.vb" Inherits="American_Transit_Services_LLC.Calendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
        <div class="col-md-11 ">
            <br />
            <div class="row">
                <div class="col-md-5">
                    <label class="header-text">Calendar</label>
                </div>
            </div>
            <div class="row line"></div>
            <div class="row">
                <div class="col-md-1">
                    <asp:LinkButton ID="ll_list"  CssClass="container-fluid add-link" runat="server"><i class="fas fa-list"></i></asp:LinkButton>
                </div>
                <div class="col-md-1">
                    <asp:LinkButton ID="ll_add_new" CssClass="container-fluid add-link"  runat="server"><i class="fas fa-plus-circle"></i></asp:LinkButton>
                </div>
            </div>
            <br />

            <div class="row">
                <div class="col-md-6">
                    <asp:Calendar ID="Calendar1" CssClass="cal-calendar" OnDayRender="Calendar1_DayRender" runat="server" Height="185px" >
                        <DayHeaderStyle BackColor="SteelBlue" BorderColor="White" BorderStyle="Solid" BorderWidth="1px"  />
                        <SelectedDayStyle BackColor="SteelBlue" />
                        
                    </asp:Calendar>
                </div>
                
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lbl_date" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:LinkButton ID="ll_previous" CssClass="card-header-control" runat="server"><i class="fas fa-arrow-circle-left"></i></asp:LinkButton>
                                    <asp:LinkButton ID="ll_next" CssClass="card-header-control" runat="server"><i class="fas fa-arrow-circle-right"></i></asp:LinkButton>
                                </div>


                            </div>
                        </div>
                        <div class="card-body" style="height: 65vh; overflow-y: scroll">
                            <asp:GridView ID="grd_reservation" CssClass="container-fluid" AutoGenerateColumns="false"  runat="server" ShowHeader="False">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div class="card">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <asp:LinkButton ID="ll_time" CssClass="to-do"  runat="server" Text='<%#Eval("pickup_time") %>'></asp:LinkButton>
                                                    </div>
                                                    <div class="col-md-9">
                                                        <asp:LinkButton ID="ll_title" OnClick="ll_title_Click" CssClass="to-do" runat="server" Text='<%#Eval("title") %>'></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                </Columns>
                                <alternatingRowStyle backcolor="lightgray" ForeColor="black" />
                            <HeaderStyle BackColor="steelblue"  BorderColor="white" BorderStyle="Solid" BorderWidth="1px" CssClass="container-fluid" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>


                    </div>
                    </div>
                    </div>
                    <div class="row">
                        <asp:GridView ID="grd_reservation2" Visible="false" CssClass="container-fluid" runat="server" ></asp:GridView>
                        <asp:Label ID="lbl_new_date" Visible="false" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
