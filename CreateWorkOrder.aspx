<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateWorkOrder.aspx.cs" Inherits="HNHUWO2.CreateWorkOrder" %>
<asp:Content ID="Title" ContentPlaceHolderID="PageTitle" runat="server">Create a Work Order</asp:Content>
<asp:Content ID="MainTitle" ContentPlaceHolderID="MainTitle" runat="server">Choose a Work Order Type</asp:Content>
<asp:Content ID="MenuButtons" ContentPlaceHolderID="MenuButtons" runat="server">
    <uc:NavButton ID="navCancel" runat="server" AltText="Cancel Icon" Text="Cancel" NavURL="~/Default.aspx" Icon="icon-arrow-left" />
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="Main" runat="server">
    <uc:Notification ID="notError" runat="server" />
    <asp:Panel ID="pnlStep1" runat="server">
        <p>Select the type of work order you would like to create.</p>
        <p><asp:DropDownList ID="ddWoTypes" runat="server" DataTextField="type" DataValueField="ID" CssClass="ddWoTypes" AppendDataBoundItems="True"/> 
        <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="button" /></p>
        <asp:RequiredFieldValidator ID="reqWoTypes" ControlToValidate="ddWoTypes" CssClass="input-notification error png_bg" runat="server" ErrorMessage="Please select a work order type." Display="Dynamic"></asp:RequiredFieldValidator>
    </asp:Panel>
</asp:Content>