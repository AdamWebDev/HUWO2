<%@ Page Title="User Name Change" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NameChange.aspx.cs" Inherits="HNHUWO2.Admin.NameChange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
User Name Change
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">User Name Change</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Filters" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Main" runat="server">
    <p>Has a user changed their name? Let's help them get all of their work orders associated with their new account.</p>

    <asp:Label ID="lblOldUserName" runat="server" AssociatedControlID="txtOldUserName">Old User Name:</asp:Label>
    <asp:TextBox ID="txtOldUserName" runat="server" CssClass="text-input small-input"></asp:TextBox>
    <asp:Button ID="btnLookupUsername" runat="server" CssClass="button" 
        Text="Lookup User" onclick="btnLookupUsername_Click" />

    <asp:PlaceHolder ID="phResults" runat="server" Visible="false">
        <p><asp:Literal ID="ltResultCount" runat="server" Text="0" /> work orders found. <asp:Literal ID="ltActivityCount" runat="server" Text="0" /> action(s) logged.</p>
    </asp:PlaceHolder>

    <asp:PlaceHolder ID="phNewUserName" runat="server" Visible="false">
        <asp:Label ID="lblNewUserName" runat="server" AssociatedControlID="txtNewUserName">New User Name:</asp:Label>
        <asp:TextBox ID="txtNewUserName" runat="server" CssClass="text-input small-input"></asp:TextBox><asp:Button ID="btnChangeName" runat="server" CssClass="button" Text="Change Name" OnClick="btnChangeName_Click" />
    </asp:PlaceHolder>

    
    <uc:Notification ID="notSuccess" runat="server" Type="Success" Message="Username change successful!" Visible="false" />
    
</asp:Content>
