<%@ Page Title="Update Supplement" Language="C#" MasterPageFile="~/Layout/NavBar.Master" AutoEventWireup="true" CodeBehind="UpdateSupplementPage.aspx.cs" Inherits="GymMe.View.UpdatePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/UpdateSupplementStyle.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Supplement</h2>
    <table class="UpdateTable">
        <tr>
            <td>
                <asp:Label ID="Lbl_Id" runat="server" Text="Supplement ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TBox_Id" class="textbox" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Lbl_Name" runat="server" Text="Supplement Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TBox_Name" class="textbox" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td rowspan="2">
                <asp:Label ID="Lbl_ExpiryDate" runat="server" Text="Expiry Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TBox_ExpiryDate" class="textbox" runat="server" ></asp:TextBox>
                <asp:ImageButton ID="IB_ExpiryDate" class="image-button" runat="server" OnClick="IB_ExpiryDate_Click" ImageUrl="~/Image/CalendarLogo.png" Height="20px" Width="20px"/>
                <asp:Calendar ID="Cld_ExpiryDate" runat="server" Visible="False" BackColor="White" BorderColor="#F13737" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
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
                <asp:Button ID="Btn_Choose" class="choose_button" runat="server" Text="  Choose  " OnClick="Btn_Choose_Click"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Lbl_Price" runat="server" Text="Price"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TBox_Price" class="textbox" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td rowspan="2">
                <asp:Label ID="Lbl_TypeId" runat="server" Text="Supplement Type Id"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TBox_TypeId" class="textbox" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Btn_Load" class="load_button" runat="server" Text="    Load    " OnClick="Btn_Load_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Lbl_TypeName" runat="server" Text="Supplement Type Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TBox_TypeName" class="textbox" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr class="center">
            <td colspan="2">
                <asp:Button ID="Btn_Update" class="action_button" runat="server" Text="  Update  " OnClick="Btn_Update_Click" />
                <asp:Button ID="Btn_Back" class="action_button" runat="server" Text="  Back  " OnClick="Btn_Back_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
