<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="HNHUWO2.Admin.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">Add User</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server">
    <uc:NavButton runat="server" ID="btnBack" Icon="icon-arrow-left" NavURL="~/Admin/Users.aspx" Text="Back to Users" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">Add User</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Filters" runat="server"></asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Main" runat="server">

<uc:Notification ID="notSuccess" Type="Success" Visible="false" Message="User has been created! Hooray!" runat="server" />

    <asp:Label ID="lblUsername" runat="server" Text="Username" AssociatedControlID="txtUsername"></asp:Label> 
    <asp:TextBox ID="txtUsername" runat="server" CssClass="text-input small-input" /> <i class="icon-question-sign tooltip" data-help="This <strong>must</strong> be the user's login name (e.g. lastname-f)"></i>
    <asp:RequiredFieldValidator ID="reqUsername" runat="server" ErrorMessage="Username is Required" ControlToValidate="txtUsername" CssClass="input-notification error png_bg" />

    <asp:Label ID="lblFullName" runat="server" Text="Full Name" AssociatedControlID="txtFullName" />
    <asp:TextBox ID="txtFullName" runat="server" CssClass="text-input small-input"  />
    <asp:RequiredFieldValidator ID="reqFullName" runat="server" ErrorMessage="Full Name is Required" ControlToValidate="txtFullName" CssClass="input-notification error png_bg" />

    <asp:Label ID="lblEmail" runat="server" Text="Email" AssociatedControlID="txtEmail" />
    <asp:TextBox ID="txtEmail" runat="server" CssClass="text-input small-input"  />
    <asp:RequiredFieldValidator ID="reqEmail" runat="server" ErrorMessage="Email is Required" ControlToValidate="txtEmail" CssClass="input-notification error png_bg" />

    <asp:Label ID="lblRole" runat="server" Text="Role" AssociatedControlID="ddRole" />
    <asp:DropDownList ID="ddRole" runat="server"></asp:DropDownList>

    <br /><br />
    <p><asp:Button ID="btnSubmit" runat="server" Text="Create user!" CssClass="button" onclick="btnSubmit_Click" CausesValidation="true" /></p>
</asp:Content>
