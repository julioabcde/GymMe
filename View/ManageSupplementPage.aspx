<%@ Page Title="Manage Supplement" Language="C#" MasterPageFile="~/Layout/NavBar.Master" AutoEventWireup="true" CodeBehind="ManageSupplementPage.aspx.cs" Inherits="GymMe.View.ManageSupplementPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/ManageSupplementStyle.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Manage Supplement</h2>
    <div>
        <asp:GridView ID="GV_SupplementList" class="gridview" runat="server" OnSelectedIndexChanged="GV_SupplementList_SelectedIndexChanged" OnRowDeleting="GV_SupplementList_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="Btn_Update" class="action_button" runat="server" Text="  Update  " CommandName="Select" UseSubmitBehavior="false" />
                        <asp:Button ID="Btn_Delete" class="action_button" runat="server" Text="  Delete  " CommandName="Delete" UseSubmitBehavior="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SupplementID" HeaderText="ID" SortExpression="SupplementID" />
                <asp:BoundField DataField="SupplementName" HeaderText="Supplement Name" SortExpression="SupplementName" />
                <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" />
                <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                <asp:BoundField DataField="SupplementTypeID" HeaderText="Type" SortExpression="SupplementTypeID" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div class="center">
        <asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="Btn_Insert" class="insert_button" runat="server" Text="  Insert New Supplement  " OnClick="Btn_Insert_Click"/>
    </div>
</asp:Content>
