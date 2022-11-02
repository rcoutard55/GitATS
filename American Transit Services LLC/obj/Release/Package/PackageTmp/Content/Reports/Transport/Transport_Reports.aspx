<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/ats_reports.master" CodeBehind="Transport_Reports.aspx.vb" Inherits="American_Transit_Services_LLC.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-reports2" style="font-size:small">
        
            <div class="col-md-12 mx-auto">
           
            <div class="row ">
                <div class="col-md-5">
                    <label class="header-label-header container-fluid form-control">Transport Report</label>
                </div>

            </div>
            <br />
            <div class="row blue-line"></div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-header">
                            <label>Select Company</label>
                        </div>
                        <div class="card-body" style="height:110px; overflow-y:scroll">
                            <div class="row">
                                <div class="col">
                                    <asp:GridView ID="grd_company" CssClass="container-fluid grid" runat="server" AlternatingRowStyle-BackColor="#D7D7D7" AutoGenerateColumns="False" BackColor="White" HeaderStyle-BackColor="SteelBlue" HeaderStyle-ForeColor="White">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="ll_select" OnClick="ll_select_Click" ForeColor="SteelBlue" Font-Bold="true" runat="server"><i class="fas fa-check"></i></asp:LinkButton>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:BoundField DataField="company_id" HeaderText="#" SortExpression="company_id" ItemStyle-ForeColor="Black" />
                                            <asp:BoundField DataField="company" HeaderText="Company" SortExpression="company" ItemStyle-ForeColor="Black" />
                                        </Columns>

                                    </asp:GridView>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="card">
                       <div class="card-header">
                           <label>Select Service</label>
                       </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    <asp:RadioButton ID="rbtn_all" AutoPostBack="true" runat="server" text="All" GroupName="Service"/>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <asp:RadioButton ID="rbtn_ambulatory" AutoPostBack="true" runat="server" text="Ambulatory" GroupName="Service"/>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <asp:RadioButton ID="rbtn_wheelchair" AutoPostBack="true" runat="server" text="Wheelchair" GroupName="Service"/>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <asp:RadioButton ID="rbtn_strecher" AutoPostBack="true" runat="server" text="Strecher" GroupName="Service" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-header">
                            <label>Search Option</label>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-4" style="margin-top:10px" >
                                    <label>Initial Date</label>
                            </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txt_initial_date" AutoPostBack="true" CssClass="container-fluid form-control" TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                  <div class="col-md-4" style="margin-top:10px">
                                    <label>Final Date</label>
                            </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txt_final_date" AutoPostBack="true" CssClass="container-fluid form-control" TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col" style="margin-top: 20px;">
                    <asp:Label ID="lbl_comment" CssClass="comment container-fluid form-control" runat="server" Visible="false" Text=""></asp:Label>
                </div>
            </div>
            <br />
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-1">
                            <asp:LinkButton ID="ll_download" CssClass="card-header-control" runat="server"><i class="fas fa-download"></i></asp:LinkButton>
                        </div>
                        <div class="col" style="text-align:right">
                            <label class="card-header-control"><asp:Label ID="lbl_total_entry" runat="server" Text="Label"></asp:Label> Entries</label>
                        </div>
                        
                    </div>
                </div>
                <div class="card-body" style="overflow-x:scroll; height:600px; overflow-y:scroll">
                    <asp:GridView ID="grd_transport" CssClass="container-fluid table table-strip table-bordered" AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:BoundField DataField="transport_id" HeaderText="ID" ReadOnly="True" SortExpression="transport_id" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                            <asp:BoundField DataField="title" HeaderText="Title" SortExpression="title" ItemStyle-ForeColor="Black" />
                            <asp:BoundField DataField="legs" HeaderText="Legs" SortExpression="legs" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                            <asp:BoundField DataField="total_miles" HeaderText="Total Miles" SortExpression="total_miles" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                            <asp:BoundField DataField="company" HeaderText="Company" SortExpression="company" ItemStyle-ForeColor="Black" />
                            <asp:BoundField DataField="services" HeaderText="Service" SortExpression="services" ItemStyle-ForeColor="Black" />
                            <asp:BoundField DataField="pickup_date" HeaderText="Date" SortExpression="pickup_date" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" HtmlEncode="false" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="pickup_time" HeaderText="Time" SortExpression="pickup_time" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" HtmlEncode="false"  />
                            <asp:BoundField DataField="origin" HeaderText="Origin" SortExpression="origin" ItemStyle-ForeColor="Black"  />
                            <asp:BoundField DataField="destination" HeaderText="Destination" SortExpression="destination" ItemStyle-ForeColor="Black"  />
                            <asp:BoundField DataField="trip_type" HeaderText="Trip Type" SortExpression="trip_type" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                            <asp:BoundField DataField="wait_time" HeaderText="Wait Time" SortExpression="wait_time" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="center" />
                        </Columns>
                        <AlternatingRowStyle BackColor="lightgray" ForeColor="black" />
                        <HeaderStyle BackColor="steelblue" BorderColor="white" BorderStyle="Solid" BorderWidth="1px" CssClass="container-fluid" ForeColor="White" HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
       

</asp:Content>
