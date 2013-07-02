<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="HNHUWO2.View.News" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">View News Release Work Order</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server">
    <uc:statusbuttons ID="statusButtons" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">View News Release Work Order</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Main" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc:StatusMessages ID="statusMessages" runat="server" />
    <ul class="view-wo">
        <li>
            <label>Coordinator</label>
            <asp:Label ID="lblCoordinator" runat="server"></asp:Label>
        </li>
        <li>
            <label>Title/Topic</label>
            <asp:Label ID="lblTitleTopic" runat="server"></asp:Label>
        </li>
        <li>
            <label>Date to Issue</label>
            <asp:Label ID="lblDateToIssue" runat="server"></asp:Label>
        </li>
        <li>
            <label>Distribution Outlets</label>
            <asp:Label ID="lblDistributionOutlets" runat="server"></asp:Label>
        </li>
        <li>
            <label>Other Outlets</label>
            <asp:Label ID="lblDistributionOutletsOther" runat="server"></asp:Label>
        </li>
        <li>
            <label>Health Unit Contact</label>
            <asp:Label ID="lblContact" runat="server"></asp:Label>
        </li>
        <li>
            <label>Additional Notes</label>
            <asp:Label ID="lblNotes" runat="server"></asp:Label>
        </li>
        <li>
            <label>Attached Files</label>
            <uc:FileList ID="attachedFiles" runat="server" />
        </li>
        <li>
            <label>Coordinator Notes</label>
            <asp:Label ID="lblCoordinatorNotes" runat="server" ></asp:Label>
        </li>
        <li>
            <label>Activity Log</label>
            <uc:ActivityLog ID="activityLog" runat="server" />
        </li>
        <uc:coordinatorrevisions ID="CoordinatorRevisions" runat="server" />
    </ul>
</asp:Content>
