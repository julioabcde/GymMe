<%@ Page Title="Order Supplement" Language="C#" MasterPageFile="~/Layout/NavBar.Master" AutoEventWireup="true" CodeBehind="OrderSupplementPage.aspx.cs" Inherits="GymMe.View.OrderSupplementPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/OrderSupplementStyle.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Order Supplement</h2>
    <div>
        <asp:GridView ID="GV_SupplementDetailList" class="gridview" runat="server" OnRowCommand="GV_SupplementDetailList_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="Btn_Order" class="order_button" runat="server" Text="  Order  " CommandName="Order" UseSubmitBehavior="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SupplementName" HeaderText="Supplement Name" SortExpression="SupplementName" />
                <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" />
                <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                <asp:BoundField DataField="SupplementTypeName" HeaderText="Type" SortExpression="SupplementTypeName" />
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="TBox_Quantity" class="textbox" runat="server" Text="0"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div class="center">
        <asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label>
    </div>
    <br />
    <div>
        <asp:GridView ID="GV_CartList" class="gridview" runat="server">
            <Columns>
                <asp:BoundField DataField="SupplementName" HeaderText="Supplement Name" SortExpression="SupplementName" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                <asp:BoundField DataField="SubTotal" HeaderText="Subtotal" SortExpression="SubTotal" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="center">
        <asp:Button ID="Btn_Clear" class="action_button" runat="server" Text="  Clear  " OnClick="Btn_Clear_Click"/>
        <asp:Button ID="Btn_Checkout" class="action_button" runat="server" Text="  Checkout  " OnClick="Btn_Checkout_Click"/>
    </div>
</asp:Content>
