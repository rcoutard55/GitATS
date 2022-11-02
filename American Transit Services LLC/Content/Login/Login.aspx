<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="American_Transit_Services_LLC.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>American Transit Services</title>

     <link rel="shortcut icon" type="image/ico" href="../Images/1_PNG.ico" />
    <link rel="icon" type="image/ico" href="../Images/1_PNG.ico" />
    <link rel="apple-touch-icon" type="image/ico" href="../Images/1_PNG.ico" />

    <!--Bootstrap-->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous"/>

    <!--FontAwsome-->
    <link href="../../Plugin/fontawesom/css/all.css" rel="stylesheet" />

    <link href="../../Css/Login.css" rel="stylesheet" />
</head>
<body >
    <form id="form1" runat="server">
       <div class="row">
           <div class="col-md-8 mx-auto">
               <br /><br /><br />
               <div class="row">
                   <div class="col-md-6">
                       <div class="card">
                           <div class="card-body">
                               <div class="row">
                                   <div class="col" style=" text-align:center">
                                       <img src="../../Images/images.jpg" id="img_logo" runat="server" />
                                   </div>
                               </div>
                               <br /><br />
                               <div class="row">
                                <div class="col" style="margin-top: 20px;">
                                    <asp:Label ID="lbl_comment" CssClass="comment container-fluid form-control" runat="server" Visible="false" Text=""></asp:Label>
                                </div>
                            </div>
                            <br />
                               <div class="row">
                                   <div class="col">
                                       <asp:TextBox ID="txt_username" cssclass="container-fluid form-control" placeholder="Username" runat="server"></asp:TextBox>
                                   </div>
                               </div>
                               <br />
                               <div class="row">
                                   <div class="col">
                                       <asp:TextBox ID="txt_password" cssclass="container-fluid form-control" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                                   </div>
                               </div>
                               <br />
                               <div class="row">
                                   <div class="col">
                                       <asp:Button ID="btn_enter" cssclass="btn container-fluid form-control" runat="server" Text="ENTER" />
                                   </div>
                               </div>
                               <br />
                               <div class="row">
                                   <div class="col" style="text-align:right">
                                       <asp:LinkButton ID="ll_password" CssClass="link-pass"  runat="server">Forgot Password ?</asp:LinkButton>
                                   </div>
                               </div>
                           </div>
                       </div>
                   </div>
                   <div class="col-md-6 col-back" >

                   </div>
               </div>
           </div>
           <div class="row">
               <asp:GridView ID="grd_user" visible="false" runat="server"></asp:GridView>
               <asp:GridView ID="grd_employe" visible="false" runat="server"></asp:GridView>
               <asp:Label ID="lbl_employe_id" visible="false" runat="server" Text="Label"></asp:Label>
           <asp:Label ID="lbl_days" visible="false" runat="server" Text="Label"></asp:Label>
           </div>
       </div>
        

        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/js/bootstrap.min.js" integrity="sha384-7VPbUDkoPSGFnVtYi0QogXtr74QeVeeIs99Qfg5YCF+TidwNdjvaKZX19NZ/e6oz" crossorigin="anonymous"></script>
        <script src="../Plugin/fontawesom/js/all.js"></script>
    </form>
</body>
</html>
