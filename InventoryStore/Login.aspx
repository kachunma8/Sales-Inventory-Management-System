﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InventoryStore.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet" />
</head>
<body class="bg-gradient-primary">
    <div class="container">
        <!-- Outer Row -->
        <div class="row justify-content-center">
            <div class="col-xl-6 col-lg-6 col-md-6">
                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row" style="text-align: center; padding-top: 30px;">
                            <div class="col-lg-12">
                                <h1 class="h3 mb-2 text-gray-800">Welcome to Inventory Store!</h1>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="p-5">
                                    <form class="user" runat="server" id="loginForm">
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control form-control-user" TextMode="Email" runat="server" ID="txtEmail" required placeholder="Enter Email Address..."></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox runat="server" CssClass="form-control form-control-user" TextMode="Password" ID="txtPassword" required placeholder="Enter Password..."></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <div class="custom-control custom-checkbox small">
                                                <input type="checkbox" class="custom-control-input" id="customCheck">
                                                <label class="custom-control-label" for="customCheck">Remember Me</label>
                                            </div>
                                        </div>
                                        <asp:Button runat="server" Text="Login" ID="btnLogin" CssClass="btn btn-primary btn-user btn-block" OnClick="btnLogin_Click" />
                                    </form>
                                    <hr>
                                    <%--<div class="text-center">
                                        <a class="small" href="forgot-password.html">Forgot Password?</a>
                                    </div>--%>
                                    <div class="text-center">
                                        <a class="small" href="Register.aspx">Create an Account!</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Bootstrap core JavaScript-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
    <!-- Custom scripts for all pages-->
    <script src="js/sb-admin-2.min.js"></script>
</body>
</html>
