<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllPendingWorkOrders.aspx.cs" Inherits="HNHUWO2.Coordinators.AllPendingWorkOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">
    All Pending Work Orders
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Filters" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Main" runat="server">
<asp:Repeater ID="rptWorkOrders" runat="server">
        <HeaderTemplate>
            <table class="sortable">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Submitted By</th>
                        <th>Date Submitted</th>
                        <th>Work Order Type</th>
                        <th>Program Manager</th>
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
                <td><asp:Literal ID="ltStatus" runat="server" Text='<%# Eval("coordinatorName") %>'/></td>
                <td><asp:HyperLink ID="lnkApprove" runat="server" CssClass="button" NavigateUrl='<%# String.Format("~/View/Default.aspx?type={0}&ID={1}",Eval("wotype"),Eval("ID")) %>'>Approve Work Order</asp:HyperLink></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
