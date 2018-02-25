<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Travelling.Web.Form.Login" %>

<!DOCTYPE html>
<html lang="en" class="no-js">

    <head>

        <meta charset="utf-8">
        <title>旅游报客系统登陆界面</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta name="description" content="">
        <meta name="author" content="">

        <!-- CSS -->
        <link rel='stylesheet' href='http://fonts.googleapis.com/css?family=PT+Sans:400,700'>
        <link rel="stylesheet" href="../assets/css/reset.css">
        <link rel="stylesheet" href="../assets/css/supersized.css">
        <link rel="stylesheet" href="../assets/css/style.css">

        <!-- HTML5 shim, for IE6-8 support of HTML5 elements -->
        <!--[if lt IE 9]>
            <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
        <![endif]-->

    </head>

    <body>
        <div class="page-container">
            <h1>登陆</h1>
            <form runat ="server">
                <asp:TextBox ID="txtUserName" runat="server" class="username" placeholder="用户名"></asp:TextBox>
                <asp:TextBox ID="txtPassword" runat="server" class="password" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9]/g,'')" TextMode="Password" placeholder="密码"></asp:TextBox>
                <asp:Button ID="btnLogin" runat ="server" class="button" Text ="登陆" OnClick="btnLogin_Click" />
                <asp:Button ID="btnReset" runat="server" class="button" Text ="重置密码" OnClick="btnReset_Click" />
                <div class="error"><span>+</span></div>
                <%--<input type="text" name="username" class="username" placeholder="Username">
                <input type="password" name="password" class="password" placeholder="Password">
                <button type="submit">Sign in</button>
                <div class="error"><span>+</span></div>--%>
            </form>
        </div>

        <!-- Javascript -->
        <script src="../assets/js/jquery-1.8.2.min.js"></script>
        <script src="../assets/js/supersized.3.2.7.min.js"></script>
        <script src="../assets/js/supersized-init.js"></script>
        <script src="../assets/js/scripts.js"></script>

    </body>

</html>