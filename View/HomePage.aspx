<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Layout/NavBar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="GymMe.View.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/HomeStyle.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Role: <asp:Label ID="Lbl_Role" runat="server" Text=""></asp:Label></h3>
    <div>
        <asp:GridView ID="GV_CustomerList" class="gridview" runat="server">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="ID" SortExpression="UserID" />
                <asp:BoundField DataField="UserName" HeaderText="Username" SortExpression="UserName" />
                <asp:BoundField DataField="UserEmail" HeaderText="Email" SortExpression="UserEmail" />
                <asp:BoundField DataField="UserDoB" HeaderText="Date of Birth" SortExpression="UserDoB" />
                <asp:BoundField DataField="UserGender" HeaderText="Gender" SortExpression="UserGender" />
                <asp:BoundField DataField="UserRole" HeaderText="Role" SortExpression="UserRole" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
