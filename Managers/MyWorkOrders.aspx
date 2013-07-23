<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyWorkOrders.aspx.cs" Inherits="HNHUWO2.Coordinators.MyWorkOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">
    My Staff's Work Orders
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Filters" runat="server">
    <label for="ddFilters">Show:</label>
    <asp:DropDownList ID="ddFilters" runat="server" 
        onselectedindexchanged="ddFilters_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Value="unapproved" Text="Waiting for Approval"></asp:ListItem>
        <asp:ListItem Value="inprogress" Text="In Progress"></asp:ListItem>
        <asp:ListItem Value="completed" Text="Completed"></asp:ListItem>
        <asp:ListItem Value="deleted" Text="Deleted"></asp:ListItem>
        <asp:ListItem Value="all" Text="All"></asp:ListItem>
    </asp:DropDownList>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Main" runat="server">
    <asp:Repeater ID="rptWorkOrders" runat="server">
        <HeaderTemplate>
            <table class="sortable">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Submitted By</th>
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
                <td><asp:Literal ID="Literal1" runat="server" Text='<%# GetUserName(Eval("submitted_by").ToString()) %>' /></td>
                <td><asp:Literal ID="ltDateSubmitted" runat="server" Text='<%# Eval("submitted_date", "{0:MMMM d, yyyy }") %>'/></td>
                <td><asp:Literal ID="ltWorkOrderType" runat="server" Text='<%# Eval("wotypeText") %>' /></td>
                <td><asp:Literal ID="ltStatus" runat="server" Text='<%# Eval("statusText") %>'/></td>
                <td>
                    <asp:HyperLink ID="lnkApprove" runat="server" NavigateUrl='<%# String.Format("~/View/Default.aspx?type={0}&ID={1}",Eval("wotype"),Eval("ID")) %>' Visible='<%# IsUnapproved(Eval("status")) %>' >Approve Work Order</asp:HyperLink>
                    <asp:HyperLink ID="lnkView" runat="server" NavigateUrl='<%# String.Format("~/View/Default.aspx?type={0}&ID={1}",Eval("wotype"),Eval("ID")) %>' Visible='<%# !IsUnapproved(Eval("status")) %>' >View Work Order</asp:HyperLink>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
