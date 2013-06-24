<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Video.aspx.cs" Inherits="HNHUWO2.View.Video" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">View Video Work Order</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server">
    <uc:statusbuttons ID="statusButtons" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">View Video Work Order</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Main" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc:StatusMessages ID="statusMessages" runat="server" />
    <ul class="view-wo">
        <li>
            <label>Title of Video</label>
            <asp:Label ID="lblTitleVideo" runat="server"></asp:Label>
        </li>
        <li>
            <label>Coordinator</label>
            <asp:Label ID="lblCoordinator" runat="server"></asp:Label>
        </li>
        <li>
            <label>Source of Video</label>
            <asp:Label ID="lblVideoSource" runat="server"></asp:Label>
        </li>
        <li>
            <label>Video Destination</label>
            <asp:Label ID="lblVideoDestination" runat="server"></asp:Label>
        </li>
        <li>
            <label>Specify Other Website URL</label>
            <asp:Label ID="lblVideoDestinationOther" runat="server"></asp:Label>
        </li>
        <li>
            <label>Number of DVD Copies</label>
            <asp:Label ID="lblNumberDVDs" runat="server"></asp:Label>
        </li>
        <li>
            <label>Length of Video</label>
            <asp:Label ID="lblVideoLength" runat="server"></asp:Label>
        </li>
        <li>
            <label>Due Date</label>
            <asp:Label ID="lblDueDate" runat="server"></asp:Label>
        </li>
        <li>
            <label>Background Music</label>
            <asp:Label ID="lblBackgroundMusic" runat="server"></asp:Label>
        </li>
        <li>
            <label>Song Choices</label>
            <asp:Label ID="lblSongChoices" runat="server"></asp:Label>
        </li>
        <li>
            <label>Narration Required</label>
            <asp:Label ID="lblNarrationRequired" runat="server"></asp:Label>
        </li>
        <li>
            <label>Narrator</label>
            <asp:Label ID="lblNarrator" runat="server"></asp:Label>
        </li>
        <li>
            <label>This Video Will Be Used For</label>
            <asp:Label ID="lblVideoDescription" runat="server"></asp:Label>
        </li>
        <li>
            <label>Credits Required?</label>
            <asp:Label ID="lblCreditsRequired" runat="server"></asp:Label>
        </li>
        <li>
            <label>Attached Files</label>
            <uc:FileList ID="attachedFiles" runat="server" />
        </li>
        <li>
            <label>Additional Notes</label>
            <asp:Label ID="lblNotes" runat="server"></asp:Label>
        </li>
        <li>
            <label>Activity Log</label>
            <uc:ActivityLog ID="activityLog" runat="server" />
        </li>
        
        <uc:coordinatorrevisions ID="CoordinatorRevisions" runat="server" />
    </ul>
</asp:Content>
