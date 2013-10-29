<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Web.aspx.cs" Inherits="HNHUWO2.View.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">View Web Work Order</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server">
    <uc:statusbuttons ID="statusButtons" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">View Web Work Order</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Main" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc:StatusMessages ID="statusMessages" runat="server" />
    <asp:Panel ID="pnNotification" runat="server" CssClass="notification attention png_bg" Visible="false">
        <div>
            This web work order has a related print work order. <asp:HyperLink ID="lnkRelatedWO" runat="server">View it now</asp:HyperLink>.
        </div>
    </asp:Panel>

    <ul class="view-wo">
        <li>
            <label>Work Order #</label>
            <asp:Label ID="lblID" runat="server"></asp:Label>
        </li>
        <li>
            <label>Submitted By</label>
            <asp:Label ID="lblSubmittedBy" runat="server"></asp:Label>
        </li>
        <li>
            <label>Status</label>
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
        </li>
        <li>
            <label>Type of Web Work</label>
            <asp:Label ID="lblTypeWebWork" runat="server"></asp:Label>
        </li>
        <li>
            <label>Program Manager</label>
            <asp:Label ID="lblProgramManager" runat="server"></asp:Label>
        </li>
        <li>
            <label>Website</label>
            <asp:Label ID="lblWebsite" runat="server"></asp:Label>
        </li>
        <li>
            <label>Location</label>
            <asp:Label ID="lblLocation" runat="server"></asp:Label>
        </li>
        <li>
            <label>Specify Location</label>
            <asp:Label ID="lblAtoZLocation" runat="server"></asp:Label>
        </li>
        <li>
            <label>Posting Date</label>
            <asp:Label ID="lblAtoZPostingDate" runat="server"></asp:Label>
        </li>
        <li>
            <label>Removal Date</label>
            <asp:Label ID="lblAtoZRemovalDate" runat="server"></asp:Label>
        </li>
        <li>
            <label>Heading for New Page</label>
            <asp:Label ID="lblAtoZHeading" runat="server"></asp:Label>
        </li>
        <li>
            <label>Content</label>
            <asp:Label ID="lblAtoZContent" runat="server"></asp:Label>
        </li>
        <li>
            <label>Event Name</label>
            <asp:Label ID="lblCalEventName" runat="server"></asp:Label>
        </li>
        <li>
            <label>Event Location</label>
            <asp:Label ID="lblCalEventLocation" runat="server"></asp:Label>
        </li>
        <li>
            <label>Event Start Date</label>
            <asp:Label ID="lblCalStartDate" runat="server"></asp:Label>
        </li>
        <li>
            <label>Event Start Time</label>
            <asp:Label ID="lblCalStartTime" runat="server"></asp:Label>
        </li>
        <li>
            <label>Event End Date</label>
            <asp:Label ID="lblCalEndDate" runat="server"></asp:Label>
        </li>
        <li>
            <label>Event End Time</label>
            <asp:Label ID="lblCalEndTime" runat="server"></asp:Label>
        </li>
        <li>
            <label>Contact Name</label>
            <asp:Label ID="lblContactName" runat="server"></asp:Label>
        </li>
        <li>
            <label>Contact Email</label>
            <asp:Label ID="lblContactEmail" runat="server"></asp:Label>
        </li>
        <li>
            <label>Event Description</label>
            <asp:Label ID="lblEventDesc" runat="server"></asp:Label>
        </li>
        <li>
            <label>Date to be Posted</label>
            <asp:Label ID="lblDatePosted" runat="server"></asp:Label>
        </li>
        <li>
            <label>Type of Update</label>
            <asp:Label ID="lblTypeOfUpdate" runat="server"></asp:Label>
        </li>
        <li>
            <label>Date to be Changed</label>
            <asp:Label ID="lblDateToBeChanged" runat="server"></asp:Label>
        </li>
        <li>
            <label>Location (URL)</label>
            <asp:Label ID="lblURL" runat="server"></asp:Label>
        </li>
        <li>
            <label>Description</label>
            <asp:Label ID="lblUpdateDescription" runat="server"></asp:Label>
        </li>
        <li>
            <label>Budget</label>
            <asp:Label ID="lblBudget" runat="server"></asp:Label>
        </li>
        <li>
            <label>Time Frame</label>
            <asp:Label ID="lblTimeFrame" runat="server"></asp:Label>
        </li>
        <li>
            <label>Goals</label>
            <asp:Label ID="lblGoals" runat="server"></asp:Label>
        </li>
        <li>
            <label>Brief Explanation</label>
            <asp:Label ID="lblExplanation" runat="server"></asp:Label>
        </li>
        <li>
            <label>Target Audience</label>
            <asp:Label ID="lblAudience" runat="server"></asp:Label>
        </li>
        <li>
            <label>Number of Pages</label>
            <asp:Label ID="lblNumberOfPages" runat="server"></asp:Label>
        </li>
        <li>
            <label>Post Date</label>
            <asp:Label ID="lblWebAdPostDate" runat="server"></asp:Label>
        </li>
        <li>
            <label>Removal Date</label>
            <asp:Label ID="lblWebAdRemovalDate" runat="server"></asp:Label>
        </li>
        <li>
            <label>URL To Link To</label>
            <asp:Label ID="lblWebAdURL" runat="server"></asp:Label>
        </li>
        <li>
            <label>Content</label>
            <asp:Label ID="lblWebAdContent" runat="server"></asp:Label>
        </li>
        <li>
            <label>Post Date</label>
            <asp:Label ID="lblFacebookPostDate" runat="server"></asp:Label>
        </li>
        <li>
            <label>Content</label>
            <asp:Label ID="lblFacebookContent" runat="server"></asp:Label>
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
            <label class="pm-notes">Program Manager Notes</label>
            <asp:Label ID="lblCoordinatorNotes" runat="server" ></asp:Label>
        </li>
        <li>
            <label>Activity Log</label>
            <uc:ActivityLog ID="activityLog" runat="server" />
        </li>
    </ul>
    <uc:coordinatorrevisions ID="CoordinatorRevisions" runat="server" />
</asp:Content>
