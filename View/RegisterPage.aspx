<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="GymMe.View.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="../Style/RegisterStyle.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <h1>Register</h1>
    <form id="RegisterForm" runat="server">
        <table class="RegisterTable">
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
                    <asp:Label ID="Lbl_Email" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TBox_Email" class="textbox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Lbl_Gender" runat="server" Text="Gender"></asp:Label>
                </td>
                <td>
                    <asp:RadioButton ID="Rbt_Male" GroupName="Genders" runat="server" Text="Male"/>
                    <asp:RadioButton ID="Rbt_Female" GroupName="Genders" runat="server" Text="Female"/>
                </td>
            </tr>
            <tr>
                <td rowspan="2">
                    <asp:Label ID="Lbl_DoB" runat="server" Text="Date of Birth"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TBox_DoB" class="textbox" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="IB_DoB" runat="server" OnClick="IB_DoB_Click" ImageUrl="~/Image/CalendarLogo.png" Height="20px" Width="20px"/>
                    <asp:Calendar ID="Cld_DoB" runat="server" Visible="False" BackColor="White" BorderColor="#F13737" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                        <DayHeaderStyle BackColor="#F4C857" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#F367EE" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#F4C857" />
                        <TitleStyle BackColor="#86F583" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#a7e1fa" ForeColor="Black" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Btn_Choose" runat="server" Text=" Choose " OnClick="Btn_Choose_Click" />
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
                    <asp:Label ID="Lbl_ConfPass" runat="server" Text="Confirmation Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Tbox_ConfPass" class="textbox" runat="server" Type="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="center">
                <td colspan="2">
                    <p>Already have an account? <a href="LoginPage.aspx">Login here!</a></p>
                </td>
            </tr>
            <tr class="center">
                <td colspan="2">
                    <asp:Button ID="Btn_Register" runat="server" Text=" Register " OnClick="Btn_Register_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
