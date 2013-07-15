<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="HNHUWO2.Admin.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">Manage Users - Admin</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server">
    <uc:NavButton ID="addNewUser" Icon="icon-plus" runat="server" NavURL="~/Admin/AddUser.aspx" Text="Add User" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">Manage Users</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Filters" runat="server"></asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Main" runat="server">

    <asp:Repeater ID="rptUsers" runat="server" 
        onitemdatabound="rptUsers_ItemDataBound">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <th scope="col">User</th>
                        <th scope="col">Full Name</th>
                        <th scope="col">Email</th>
                        <th scope="col">Role</th>
                        <th scope="col">Actions</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
        <ItemTemplate>
            <tr>
                <th colspan="row"><%# Eval("Username") %><asp:HiddenField ID="hdnID" Value='<%# Eval("ID") %>' runat="server" /><asp:HiddenField ID="hdnActive" Value='<%# Eval("Active") %>' runat="server" /></td>
                <td><%# Eval("Fullname") %></td>
                <td><%# Eval("Email") %></td>
                <td><%# Eval("Role") %></td>
                <td><asp:Button ID="btnActive" runat="server" CssClass="button" OnClick="btnActive_Click" CommandArgument='<%# Eval("ID") %>' />
                    <asp:HyperLink ID="lnkEditUser" runat="server" NavigateUrl='<%# String.Format("~/Admin/EditUser.asxp?ID={0}",Eval("ID")) %>' CssClass="button">Edit Details</asp:HyperLink>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>


</asp:Content>
