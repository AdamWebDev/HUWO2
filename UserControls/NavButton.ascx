<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavButton.ascx.cs" Inherits="HNHUWO2.NavButton" %>
<li>
<asp:HyperLink ID="lnkLink" runat="server" CssClass="shortcut-button">
    <span><i id="icon" runat="server" class=""></i>
		<br />
		<asp:Literal ID="ltText" runat="server"></asp:Literal>
</span></asp:HyperLink>
</li>