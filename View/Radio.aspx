<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Radio.aspx.cs" Inherits="HNHUWO2.View.Radio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">View Radio Work Order</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server">
    <uc:statusbuttons ID="statusButtons" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">View Radio Work Order</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Main" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc:StatusMessages ID="statusMessages" runat="server" />
    <ul class="view-wo">
        <li>
            <label>Work Order #</label>
            <asp:Label ID="lblID" runat="server"></asp:Label>
        </li>
        <li>
            <label>Status</label>
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
        </li>
        <li>
            <label>Ad Type</label>
            <asp:Label ID="lblAdType" runat="server"></asp:Label>
        </li>
        <li>
            <label>Program Manager</label>
            <asp:Label ID="lblProgramManager" runat="server"></asp:Label>
        </li>
        <li>
            <label>Airing Month</label>
            <asp:Label ID="lblAiringMonth" runat="server"></asp:Label>
        </li>
        <li>
            <label>Desired Radio Station</label>
            <asp:Label ID="lblRadioStation" runat="server"></asp:Label>
        </li>
        <li>
            <label>Length of Ad</label>
            <asp:Label ID="lblLengthOfAd" runat="server"></asp:Label>
        </li>
        <li>
            <label>Start Airing Date</label>
            <asp:Label ID="lblStartAiringDate" runat="server"></asp:Label>
        </li>
        <li>
            <label>End Airing Date</label>
            <asp:Label ID="lblEndAiringDate" runat="server"></asp:Label>
        </li>
        <li>
            <label>Budget</label>
            <asp:Label ID="lblBudget" runat="server"></asp:Label>
        </li>
        <li>
            <label>Recording Options</label>
            <asp:Label ID="lblRecordingOptions" runat="server"></asp:Label>
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
            <label>Program Manager Notes</label>
            <asp:Label ID="lblCoordinatorNotes" runat="server" ></asp:Label>
        </li>
        <li>
            <label>Activity Log</label>
            <uc:ActivityLog ID="activityLog" runat="server" />
        </li>
    </ul>
    <uc:coordinatorrevisions ID="CoordinatorRevisions" runat="server" />
</asp:Content>
