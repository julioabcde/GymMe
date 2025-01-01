<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Layout/NavBar.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="GymMe.View.ProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/ProfileStyle.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Profile</h2>
    <table class="UpdateProfileTable">
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
                <asp:ImageButton ID="IB_DoB" class="image-button" runat="server" OnClick="IB_DoB_Click" ImageUrl="~/Image/CalendarLogo.png" Height="20px" Width="20px"/>
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
                <asp:Button ID="Btn_Choose" class="choose_button" runat="server" Text="  Choose  " OnClick="Btn_Choose_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr class="center">
            <td colspan="2">
                <asp:Button ID="Btn_UpdateProfile" class="action_button" runat="server" Text="  Update Profile  " OnClick="Btn_UpdateProfile_Click" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <h2>Update Password</h2>
    <table class="UpdatePasswordTable">
        <tr>
            <td>
                <asp:Label ID="Lbl_OldPassword" runat="server" Text="Old Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TBox_OldPassword" class="textbox" runat="server" Type="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Lbl_NewPassword" runat="server" Text="New Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Tbox_NewPassword" class="textbox" runat="server" Type="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Lbl_PassStatus" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr class="center">
            <td colspan="2">
                <asp:Button ID="Btn_UpdatePass" class="action_button" runat="server" Text="  Update Password  " OnClick="Btn_UpdatePass_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
