<%@ Page Title="Transaction Queue" Language="C#" MasterPageFile="~/Layout/NavBar.Master" AutoEventWireup="true" CodeBehind="TransactionQueuePage.aspx.cs" Inherits="GymMe.View.TransactionQueuePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/TransactionQueueStyle.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Transaction Queue</h2>
    <div>
        <asp:GridView ID="GV_TransactionList" class="gridview" runat="server" OnRowDataBound="GV_TransactionList_RowDataBound" OnSelectedIndexChanged="GV_TransactionList_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="Btn_Handle" CssClass="handle_button" visible="false" runat="server" Text="  Handle  " CommandName="Select" UseSubmitBehavior="false"/>
                        <asp:Button ID="Btn_Handled" CssClass="handled_button" visible="false" runat="server" Text="  Handled  " UseSubmitBehavior="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
