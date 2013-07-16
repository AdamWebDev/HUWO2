<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OpenWorkOrders.aspx.cs" Inherits="HNHUWO2.Designers.OpenWorkOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server"><asp:Literal ID="ltPageTitle" runat="server"></asp:Literal></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server"></asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server"><asp:Literal ID="ltContentTitle" runat="server"></asp:Literal></asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Filters" runat="server">
    <label for="ddFilters">Show:</label>
    <asp:DropDownList ID="ddFilters" runat="server" 
        onselectedindexchanged="ddFilters_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Value="open" Text="Open"></asp:ListItem>
        <asp:ListItem Value="unapproved" Text="Waiting for Approval"></asp:ListItem>
        <asp:ListItem Value="completed" Text="Completed"></asp:ListItem>
        <asp:ListItem Value="deleted" Text="Deleted"></asp:ListItem>
    </asp:DropDownList>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Main" runat="server">
    <asp:Repeater ID="rptWorkOrders" runat="server">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Submitted By</th>
                        <th>Date Submitted</th>
                        <th>Due Date</th>
                        <th>Details</th>
                        <th>Status</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Literal ID="ltWorkOrderNum" runat="server" Text='<%# Eval("ID") %>' /></td>
                <td><asp:Literal ID="ltSubmittedBy" runat="server" Text='<%# GetUserName(Eval("submitted_by").ToString()) %>' /></td>
                <td><asp:Literal ID="ltDateSubmitted" runat="server" Text='<%# Eval("submitted_date", "{0:MMMM d, yyyy }") %>'/></td>
                <td><asp:Literal ID="ltDueDate" runat="server" Text='<%# Eval("duedate", "{0:MMMM d, yyyy }") %>'/></td>
                <td><asp:Literal ID="ltWorkOrderType" runat="server" Text='<%# String.Format("{0} - {1}", Eval("wotypeText"), Eval("title")) %>' /></td>
                <td><asp:Literal ID="ltStatus" runat="server" Text='<%# Eval("statusText") %>'/></td>
                <td><asp:HyperLink ID="lnkView" runat="server" NavigateUrl='<%# String.Format("~/View/Default.aspx?type={0}&ID={1}",Eval("wotype"),Eval("ID")) %>'>View Work Order</asp:HyperLink></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
