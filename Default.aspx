<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HNHUWO2.Default" %>
<asp:Content ContentPlaceHolderID="MenuButtons" ID="Buttons" runat="server">
    <uc:NavButton ID="navCreateNew" runat="server" Icon="~/resources/images/icons/add.png" AltText="Add Icon" Text="Create New Work Order" NavURL="~/CreateWorkOrder.aspx" />
</asp:Content>

<asp:Content ID="MainTitle" ContentPlaceHolderID="MainTitle" runat="server">
My current work orders
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="Main" runat="server">
Work orders.
</asp:Content>