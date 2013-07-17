<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ByManager.aspx.cs" Inherits="HNHUWO2.Reports.ByCoordinator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">Reports</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server"></asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">Reports - By Manager</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Filters" runat="server"></asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Main" runat="server">

    <div class="report-form">
        <div class="inline">
        <label class="inline">Start Date:</label> <asp:TextBox ID="txtStartDate" runat="server" CssClass="datepicker text-input"></asp:TextBox>
        </div>
        <div class="inline">
        <label class="inline">End Date:</label> <asp:TextBox ID="txtEndDate" runat="server" CssClass="datepicker text-input"></asp:TextBox>
        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Update" CssClass="button" onclick="btnSubmit_Click" />
    </div>

    <asp:Repeater ID="rptReport" runat="server" onitemdatabound="rptReport_ItemDataBound">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <th>Manager</th>
                        <th>Number of Work Orders</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:Literal ID="ltCoordinator" runat="server" Text='<%# Eval("CoordinatorName") %>' /></td>
                <td><asp:Literal ID="ltCount" runat="server" Text='<%# Eval("Count") %>' /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
        </tbody>
            <tfoot>
            <tr>
                <td>Total</td>
                <td><asp:Literal ID="ltTotal" runat="server"></asp:Literal></td>
                
            </tr>
            </tfoot>
                
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <div>
        <asp:Literal ID="ltEmpty" runat="server" Text="Oh no! It looks like there were no work orders submitted during this time span." Visible="false"></asp:Literal>
    </div>
    
</asp:Content>
