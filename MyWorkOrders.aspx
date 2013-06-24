﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyWorkOrders.aspx.cs" Inherits="HNHUWO2.MyWorkOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">My Work Orders</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server"></asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">My Work Orders</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Filters" runat="server">
    <label for="ddItemsPerPage">Show:</label>
    <asp:DropDownList ID="ddItemsPerPage" runat="server" 
        onselectedindexchanged="ddItemsPerPage_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Value="10" Text="10 Items"></asp:ListItem>
        <asp:ListItem Value="25" Text="25 Items"></asp:ListItem>
        <asp:ListItem Value="50" Text="50 Items"></asp:ListItem>
        <asp:ListItem Value="100" Text="100 Items"></asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddFilters" runat="server" onselectedindexchanged="ddFilters_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Value="open" Text="Open"></asp:ListItem>
        <asp:ListItem Value="unapproved" Text="Waiting for Approval"></asp:ListItem>
        <asp:ListItem Value="completed" Text="Completed"></asp:ListItem>
        <asp:ListItem Value="deleted" Text="Deleted"></asp:ListItem>
    </asp:DropDownList>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Main" runat="server">
    <uc:Notification ID="notSuccess" runat="server" Type="Success" Message="Your work order has been successfully submitted!" Visible="false" />
    <asp:HiddenField ID="hdnCurrentPage" runat="server" Value="0" />
    <asp:LinkButton ID="lnkNextPage" runat="server" onclick="lnkNextPage_Click">Next Page</asp:LinkButton>
    <asp:Repeater ID="rptWorkOrders" runat="server">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <th>Work Order #</th>
                        <th>Date Submitted</th>
                        <th>Work Order Type</th>
                        <th>Status</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Literal ID="ltWorkOrderNum" runat="server" Text='<%# Eval("ID") %>' /></td>
                <td><asp:Literal ID="ltDateSubmitted" runat="server" Text='<%# Eval("submitted_date", "{0:MMMM d, yyyy }") %>'/></td>
                <td><asp:Literal ID="ltWorkOrderType" runat="server" Text='<%# Eval("wotypeText") %>' /></td>
                <td><asp:Literal ID="ltStatus" runat="server" Text='<%# Eval("statusText") %>'/></td>
                <td><asp:HyperLink ID="lnkView" runat="server" NavigateUrl='<%# String.Format("~/View/Default.aspx?type={0}&ID={1}",Eval("wotype"),Eval("ID")) %>' >View Work Order</asp:HyperLink></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>