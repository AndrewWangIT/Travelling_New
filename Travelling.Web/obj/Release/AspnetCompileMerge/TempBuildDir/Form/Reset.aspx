<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reset.aspx.cs" Inherits="Travelling.Web.Form.Reset" %>

<!DOCTYPE html>
<html lang="en" class="no-js">

    <head>

        <meta charset="utf-8">
        <title>Fullscreen Reset</title>
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

        <div>
            <h1>Reset Password</h1>
            <br />
            <br />
            <form runat ="server">
                <asp:TextBox ID="txtUserName" runat="server" class="username" placeholder="Username"></asp:TextBox>
                <asp:TextBox ID="txtPassword" runat="server" class="password" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9]/g,'')" TextMode="Password" placeholder="New Password"></asp:TextBox>
                <asp:TextBox ID="txtReset" runat="server" class="password" onkeyup="value=value.replace(/[^\a-\z\A-\Z0-9]/g,'')" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
                <asp:Button ID="btnReset" runat="server" class="button" Text ="Reset" OnClick="btnReset_Click" OnClientClick="ResetFunc();" />
                <asp:Button ID="btnCancel" runat ="server" class="button" Text ="Cancel" OnClick="btnCancel_Click" />
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
        <script type="text/javascript">
            function ResetFunc() {
                var firstPassword = txtPassword.value;
                var secondPassword = txtReset.value;
                if (firstPassword != secondPassword)
                {
                    alert("请确保两个密码一致！");
                    txtPassword.value = '';
                    txtReset.value = '';
                    return false;
                }    
            }
        </script> 
    </body>

</html>