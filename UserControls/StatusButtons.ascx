<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatusButtons.ascx.cs" Inherits="HNHUWO2.UserControls.StatusButtons" %>
<%@ Register Src="~/UserControls/NavButton.ascx" TagPrefix="uc" TagName="NavButtons" %>
<uc:NavButtons ID="btnUnapprove" runat="server" Text="Unapprove" OnClick="btnUnapprove_OnClick" Visible="false" Icon="icon-thumbs-down" />
<uc:NavButtons ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_OnClick" Visible="false" Icon="icon-thumbs-up" />
<asp:PlaceHolder ID="phApproveWithChanges" runat="server" Visible="false">
<li>
<a href="#ApproveWithChangesModal" id="popup" class="shortcut-button">
    <span><i class="icon-edit icon-4x"></i>
		<br />
		<span><asp:Literal ID="ltText" runat="server" Text="Approve With Changes"></asp:Literal></span>
</span></a>
</li>
</asp:PlaceHolder>
<uc:NavButtons ID="btnMarkInProgress" runat="server" Text="Mark in Progress" OnClick="btnMarkInProgress_OnClick" Visible="false" Icon="icon-cogs" />
<uc:NavButtons ID="btnProofSent" runat="server" Text="Proof Sent" OnClick="btnProofSent_OnClick" Visible="false" Icon="icon-envelope" />
<uc:NavButtons ID="btnMarkComplete" runat="server" Text="Mark Complete" OnClick="btnMarkComplete_OnClick" Visible="false" Icon="icon-check" />
<uc:NavButtons ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_OnClick" Visible="false" Icon="icon-trash" />