<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="HNHUWO2.View.Print" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server"><asp:Literal ID="ltPageTitle" runat="server" Text="View Print Work Order"></asp:Literal></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server">
    <uc:statusbuttons ID="statusButtons" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server"><asp:Literal ID="ltContentTitle" runat="server" Text="View Print Work Order"></asp:Literal>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc:StatusMessages ID="statusMessages" runat="server" />
    <uc:Notification ID="notMessage" runat="server" Visible="false" />
    <uc:Notification ID="notQuote" runat="server" Type="Attention" Message="Please note that this a Quote for Commercial Print" Visible="false" />
    <ul class="view-wo">
        <li>
            <label>Status</label>
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
        </li>
        <li>
            <label>Title</label>
            <asp:Label ID="lblPubTitle" runat="server"></asp:Label>
        </li>
        <li>
            <label>Due Date</label>
            <asp:Label ID="lblDueDate" runat="server"></asp:Label>
        </li>
        <li>
            <label>Coordinator</label>
            <asp:Label ID="lblCoordinator" runat="server"></asp:Label>
        </li>
        <li>
            <label>Type of Project</label>
            <asp:Label ID="lblTypeOfProject" runat="server"></asp:Label>
        </li>
        <li>
            <label>Describe the Project</label>
            <asp:Label ID="lblProjectOther" runat="server"></asp:Label>
        </li>
        <li>
            <label>Type of Display</label>
            <asp:Label ID="lblTypeOfDisplay" runat="server"></asp:Label>
        </li>
        <li>
            <label>Describe Display</label>
            <asp:Label ID="lblDisplayOther" runat="server"></asp:Label>
        </li>
        <li>
            <label>Promo Item Details</label>
            <asp:Label ID="lblPromoItem" runat="server"></asp:Label>
        </li>
        
        <li>
            <label>Printing Method</label>
            <asp:Label ID="lblPrintingMethod" runat="server"></asp:Label>
        </li>
        <li>
            <label>Budget</label>
            <asp:Label ID="lblBudget" runat="server"></asp:Label>
        </li>
        <li>
            <label>Paper or Product Size</label>
            <asp:Label ID="lblPaperSize" runat="server"></asp:Label>
        </li>
        <li>
            <label>Custom Paper Size</label>
            <asp:Label ID="lblCustomPaperSize" runat="server"></asp:Label>
        </li>
        <li>
            <label>Paper Type</label>
            <asp:Label ID="lblPaperType" runat="server"></asp:Label>
        </li>
        <li>
            <label>Colour Information</label>
            <asp:Label ID="lblColourInfo" runat="server"></asp:Label>
        </li>
        <li>
            <label>Number of Copies/Pieces</label>
            <asp:Label ID="lblNumberCopies" runat="server"></asp:Label>
        </li>
        <li>
            <label>Full Bleed</label>
            <asp:Label ID="lblFullBleed" runat="server"></asp:Label>
        </li>
        <li>
            <label>Credits</label>
            <asp:Label ID="lblCredits" runat="server"></asp:Label>
        </li>
        <li>
            <label>Credit Name</label>
            <asp:Label ID="lblCreditName" runat="server"></asp:Label>
        </li>
        <li>
            <label>Add to Website</label>
            <asp:Label ID="lblAddToWebsite" runat="server"></asp:Label>
        </li>
        <li>
            <label>Additional Notes</label>
            <asp:Label ID="lblNotes" runat="server"></asp:Label>
        </li>
        <li>
            <label>Attached files</label>
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
