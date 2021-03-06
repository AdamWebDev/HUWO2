﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyWorkOrders.aspx.cs" Inherits="HNHUWO2.MyWorkOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">My Work Orders</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server">
    <uc:NavButton ID="navCreateNew" runat="server" Icon="icon-plus" AltText="Add Icon" Text="Create New Work Order" NavURL="~/CreateWorkOrder.aspx" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">My Work Orders</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Filters" runat="server">
    <label for="ddItemsPerPage">Show:</label>
    <asp:DropDownList ID="ddFilters" runat="server" onselectedindexchanged="ddFilters_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Value="open" Text="Open"></asp:ListItem>
        <asp:ListItem Value="unapproved" Text="Waiting for Approval"></asp:ListItem>
        <asp:ListItem Value="completed" Text="Completed"></asp:ListItem>
        <asp:ListItem Value="deleted" Text="Deleted"></asp:ListItem>
        <asp:ListItem Value="all" Text="All"></asp:ListItem>
    </asp:DropDownList>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Main" runat="server">
    <asp:Panel ID="pnSuccess" runat="server" Visible="false" CssClass="notification success png_bg">
        <div>
            <asp:Literal ID="ltMessage" runat="server" Text="Your work order has been successfully submitted!"></asp:Literal> 
            <asp:HyperLink ID="lnkWorkOrder" runat="server" Text="View your work order now!"></asp:HyperLink>
        </div>
    </asp:Panel>
    <asp:HiddenField ID="hdnCurrentPage" runat="server" Value="0" />

    
    <asp:Repeater ID="rptWorkOrders" runat="server">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <th>#</th>
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
                <td><asp:HyperLink ID="lnkView" runat="server" CssClass="button" NavigateUrl='<%# String.Format("~/View/Default.aspx?type={0}&ID={1}",Eval("wotype"),Eval("ID")) %>' >View Work Order</asp:HyperLink></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Label ID="lblEmpty" runat="server" Visible="false"></asp:Label>
</asp:Content>
