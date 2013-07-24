<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatusButtons.ascx.cs" Inherits="HNHUWO2.UserControls.StatusButtons" %>
<%@ Register Src="~/UserControls/NavButton.ascx" TagPrefix="uc" TagName="NavButtons" %>
<uc:NavButtons ID="btnGoBack" runat="server" Text="Go Back" NavURL="javascript:history.go(-1);" Icon="icon-arrow-left"  />
<uc:NavButtons ID="btnUnapprove" runat="server" Text="Unapprove" OnClick="btnUnapprove_OnClick" Visible="false" Icon="icon-thumbs-down" />
<uc:NavButtons ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_OnClick" Visible="false" Icon="icon-thumbs-up" />
<a href="#ApproveWithChangesModal" class="button open-popup-link" >Test</a>
<uc:NavButtons ID="btnApproveWithChanges" runat="server" Text="Approve With Changes" NavURL="#ApproveWithChangesModal" Visible="false" Icon="icon-edit" data-reveal-id="ApproveWithChangesModal"  />
<uc:NavButtons ID="btnMarkInProgress" runat="server" Text="Mark in Progress" OnClick="btnMarkInProgress_OnClick" Visible="false" Icon="icon-cogs" />
<uc:NavButtons ID="btnProofSent" runat="server" Text="Proof Sent" OnClick="btnProofSent_OnClick" Visible="false" Icon="icon-envelope" />
<uc:NavButtons ID="btnMarkComplete" runat="server" Text="Mark Complete" OnClick="btnMarkComplete_OnClick" Visible="false" Icon="icon-check" />
<uc:NavButtons ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_OnClick" Visible="false" Icon="icon-trash" />