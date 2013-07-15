<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="HNHUWO2.Admin.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">Edit User</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server">
    <uc:NavButton runat="server" ID="btnBack" Icon="icon-arrow-left" NavURL="~/Admin/Users.aspx" Text="Back to Users" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">Edit User Details</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Filters" runat="server"></asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Main" runat="server">

    <uc:Notification ID="notSuccess" Type="Success" Visible="false" Message="Changes to the user have been made!" runat="server" />

    <asp:Label ID="lblUsername" runat="server" Text="Username" AssociatedControlID="txtUsername" />
    <asp:TextBox ID="txtUsername" runat="server" CssClass="text-input small-input" />

    <asp:Label ID="lblFullName" runat="server" Text="Full Name" AssociatedControlID="txtFullName" />
    <asp:TextBox ID="txtFullName" runat="server" CssClass="text-input small-input"  />

    <asp:Label ID="lblEmail" runat="server" Text="Email" AssociatedControlID="txtEmail" />
    <asp:TextBox ID="txtEmail" runat="server" CssClass="text-input small-input"  />

    <asp:Label ID="lblRole" runat="server" Text="Role" AssociatedControlID="ddRole" />
    <asp:DropDownList ID="ddRole" runat="server"></asp:DropDownList>

    <br /><br />
    <p><asp:Button ID="btnSubmit" runat="server" Text="Save!" CssClass="button" onclick="btnSubmit_Click" /></p>
</asp:Content>
