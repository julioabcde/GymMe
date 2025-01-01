<%@ Page Title="History" Language="C#" MasterPageFile="~/Layout/NavBar.Master" AutoEventWireup="true" CodeBehind="HistoryPage.aspx.cs" Inherits="GymMe.View.HistoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/HistoryStyle.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>History</h2>
    <div class="center">
        <asp:Label ID="Lbl_Status" runat="server" Text="Only order that have been handled by admin can be viewed in the history!"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="GV_TransactionListAdmin" class="gridview" runat="server" OnSelectedIndexChanged="GV_TransactionLisAdmin_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="Btn_View" class="view_button" runat="server" Text="   View   " CommandName="Select" UseSubmitBehavior="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <asp:GridView ID="GV_TransactionListCustomer" class="gridview" runat="server" OnSelectedIndexChanged="GV_TransactionListCustomer_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="Btn_View" class="view_button" runat="server" Text="   View   " CommandName="Select" UseSubmitBehavior="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
