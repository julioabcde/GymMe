<%@ Page Title="Transaction Report" Language="C#" MasterPageFile="~/Layout/NavBar.Master" AutoEventWireup="true" CodeBehind="TransactionReportPage.aspx.cs" Inherits="GymMe.View.TransactionReportPage" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/TransactionReportStyle.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Transaction Report</h2>
    <CR:CrystalReportViewer ID="CRV_Transaction" class="crv" runat="server" AutoDataBind="true" />
</asp:Content>
