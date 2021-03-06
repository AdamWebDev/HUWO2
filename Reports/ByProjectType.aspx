﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ByProjectType.aspx.cs" Inherits="HNHUWO2.Reports.ByProjectType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">Reports</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">Reports - By Project Type</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Main" runat="server">

    <div class="report-form">
        <div class="inline">
            <label class="inline">Start Date:</label><asp:TextBox ID="txtStartDate" runat="server" CssClass="datepicker text-input"></asp:TextBox>
        </div>
        <div class="inline">
            <label class="inline">End Date: </label><asp:TextBox ID="txtEndDate" runat="server" CssClass="datepicker text-input"></asp:TextBox>
        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Update" CssClass="button" onclick="btnSubmit_Click" />
    </div>
    <asp:Repeater ID="rptReport" runat="server" onitemdatabound="rptReport_ItemDataBound">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <th scope="col">Type of Work Order</th>
                        <th scope="col">Number of Work Orders</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <th scope="row"><asp:Literal ID="ltProjectType" runat="server" Text='<%# Eval("ProjectType") %>' /></th>
                <td><asp:Literal ID="ltCount" runat="server" Text='<%# Eval("Count") %>' /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
        </tbody>
            <tfoot>
            <tr>
                <th scope="row">Total</th>
                <td><asp:Literal ID="ltTotal" runat="server"></asp:Literal></td>
                
            </tr>
            </tfoot>
                
            </table>
        </FooterTemplate>
    </asp:Repeater>

    <asp:Repeater ID="rptPrintReport" runat="server" onitemdatabound="rptPrintReport_ItemDataBound">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <th scope="col">Type of Print Work Order</th>
                        <th scope="col">Number of Work Orders</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <th scope="row"><asp:Literal ID="ltProjectType" runat="server" Text='<%# Eval("PrintType") %>' /></th>
                <td><asp:Literal ID="ltCount" runat="server" Text='<%# Eval("Count") %>' /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
        </tbody>
            <tfoot>
            <tr>
                <th scope="row">Total</th>
                <td><asp:Literal ID="ltTotal" runat="server"></asp:Literal></td>
                
            </tr>
            </tfoot>
                
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
