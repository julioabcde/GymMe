<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="GymMe.View.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../Style/LoginStyle.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <h1>Log In</h1>
    <form id="LoginForm" runat="server">
        <table class="LoginTable">
            <tr>
                <td>
                    <asp:Label ID="Lbl_Username" runat="server" Text="Username"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TBox_Username" class="textbox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Lbl_Password" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TBox_Password" class="textbox" runat="server" Type="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <asp:CheckBox ID="CBox_RememberMe" runat="server" />
                        <asp:Label ID="Lbl_RememberMe" runat="server" Text="Remember Me?"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr class="center">
                <td colspan="2">
                    <p>Don't have an account? <a href="RegisterPage.aspx">Register here!</a></p>
                </td>
            </tr>
            <tr class="center">
                <td colspan="2">
                    <asp:Button ID="Btn_Login" runat="server" Text=" Login " OnClick="Btn_Login_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
