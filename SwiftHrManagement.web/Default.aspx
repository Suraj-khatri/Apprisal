<%@ Page Title="Swift HR Management System 1.0" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SwiftHrManagement.web.Default" %>

<%@ Import Namespace="System.Data"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Swifttech">
    <link rel="shortcut icon" href="#" type="image/png">

    <title>Login</title>
    <link href="ui/css/bootstrap.min.css" rel="stylesheet" />
    <link href="ui/css/style-responsive.css" rel="stylesheet" />
    <link href="ui/css/style.css" rel="stylesheet" />
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
    <script src="js/respond.min.js"></script>
    <![endif]-->
</head>

<body class="login-body">
    <form id="form1" runat="server" class="form-signin" method="post" action="" role="form">
        <div class="wrap">
            <div class="form-signin-heading text-center">
                <h1 class="sign-title">Sign In</h1>
                <img src="images/logo.png" alt="" />
            </div>
            <div class="login-wrap">
                <asp:TextBox ID="txtUserName" runat="server" Class="form-control" placeholder="Username" required></asp:TextBox>
                <asp:TextBox ID="txtPassword" runat="server" Class="form-control" placeholder="Password" TextMode="Password" required></asp:TextBox>
                 <asp:Label ID="LblMsg" runat="server"></asp:Label>
                <asp:Button runat="server" ID="ImgLogin" CssClass="btn btn-lg btn-login btn-block" onclick="ImgLogin_Click" Text="LOGIN"/>
                
      
               <%-- <div class="registration">
                    Not a member yet?
                <a class="" href="registration.html">Signup
                </a>
                </div>
                <label class="checkbox">
                    <input type="checkbox" value="remember-me">
                    Remember me
                <span class="pull-right">
                    <a data-toggle="modal" href="#myModal">Forgot Password?</a>

                </span>
                </label>--%>

            </div>

            <!-- Modal -->
           <%-- <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">Forgot Password ?</h4>
                        </div>
                        <div class="modal-body">
                            <p>Enter your e-mail address below to reset your password.</p>
                            <input type="text" name="email" placeholder="Email" autocomplete="off" class="form-control placeholder-no-fix">
                        </div>
                        <div class="modal-footer">
                            <button data-dismiss="modal" class="btn btn-default" type="button">Cancel</button>
                            <button class="btn btn-primary" type="button">Submit</button>
                        </div>
                    </div>
                </div>
            </div>--%>
            <!-- modal -->
         </div>
    </form>
    <!-- Placed js at the end of the document so the pages load faster -->

    <!-- Placed js at the end of the document so the pages load faster -->
    <script src="ui/js/jquery-1.10.2.min.js"></script>
    <script src="ui/js/bootstrap.min.js"></script>
    <script src="ui/js/modernizr.min.js"></script>

</body>
</html>

