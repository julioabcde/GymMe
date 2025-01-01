<%@ Page Title="Transaction Detail" Language="C#" MasterPageFile="~/Layout/NavBar.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="GymMe.View.TransactionDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/TransactionDetailStyle.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Transaction Detail</h2>
    <table class="ViewTable">
        <tr>
            <td>
                <asp:Label ID="Lbl_TransactionId" runat="server" Text="Transaction ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TBox_TransactionId" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Lbl_UserId" runat="server" Text="User ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TBox_UserId" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Lbl_TransactionDate" runat="server" Text="Transaction Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TBox_TransactionDate" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Lbl_Status" runat="server" Text="Status"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TBox_Status" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <div>
        <asp:GridView ID="GV_TransactionList" class="gridview" runat="server">
            <Columns>
                <asp:BoundField DataField="SupplementName" HeaderText="Supplement Name" SortExpression="SupplementName" />
                <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="SubTotal" HeaderText="Sub Total" SortExpression="SubTotal" />
            </Columns>
        </asp:GridView>
        <h3>Total Price: <asp:Label ID="Lbl_Total" runat="server" Text=""></asp:Label></h3>
    </div>
    <div class="center">
        <asp:Button ID="Btn_Back" class="back_button" runat="server" Text="  Back  " OnClick="Btn_Back_Click" />
    </div>
</asp:Content>
