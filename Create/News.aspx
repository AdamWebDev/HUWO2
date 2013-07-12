<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="HNHUWO2.Create.News" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">Create News Release Work Order</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server">
    <uc:NavButton ID="navCancel" runat="server" Icon="icon-remove" AltText="Cancel Icon" Text="Cancel" NavURL="~/Default.aspx" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">Create a News Release Work Order</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Main" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:ValidationSummary ID="ValidationSummary" HeaderText="Your work order has not been saved. Please note the following fields that are missing information:" runat="server" CssClass="error-summary"  />
    
        <uc:Notification ID="notMain" runat="server" Visible="false"/>
        
        <label>Program Coordinator</label>
        <asp:DropDownList ID="ddCoordinators" runat="server" AppendDataBoundItems="True" CssClass="small-input" />
        <asp:RequiredFieldValidator ID="reqCoordinators" runat="server" ControlToValidate="ddCoordinators" ErrorMessage="Program Coordinator Required" CssClass="input-notification error png_bg" />

        <label>Title/Topic</label>
        <asp:TextBox ID="txtTitleTopic" runat="server" CssClass="text-input small-input"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqTitleTopic" runat="server" ControlToValidate="txtTitleTopic" ErrorMessage="Title/Topic is Required" CssClass="input-notification error png_bg" />

        <label>Date to Issue</label>
        <asp:TextBox ID="txtDateToIssue" runat="server" CssClass="text-input small-input datepicker" />
        <asp:RequiredFieldValidator ID="reqDateToIssue" runat="server" ControlToValidate="txtDateToIssue" ErrorMessage="Date To Issue is Required" CssClass="input-notification error png_bg" />

        
        
        <label>Distribution Outlets</label>
        <asp:DropDownList ID="ddDistributionOutlets" runat="server" CssClass="small-input" AppendDataBoundItems="true" AutoPostBack="true" onselectedindexchanged="ddDistributionOutlets_SelectedIndexChanged"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="reqDistributionOutlets" runat="server" ControlToValidate="ddDistributionOutlets" ErrorMessage="Distribution Outlet is Required" CssClass="input-notification error png_bg"/>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="phDistroOther" runat="server" Visible="false">
                    <label>Please Specify</label>
                    <asp:TextBox ID="txtDistributionOutletsOther" runat="server" CssClass="text-input small-input" MaxLength="255"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqDistributionOutletsOther" runat="server" ControlToValidate="txtDistributionOutletsOther" ErrorMessage="Distribution Details are Required" CssClass="input-notification error png_bg" />
                </asp:PlaceHolder>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddDistributionOutlets" />
            </Triggers>
        </asp:UpdatePanel>

        <label>Health Unit Contact for News Release</label>
        <asp:TextBox ID="txtContact" runat="server" CssClass="text-input small-input" MaxLength="255"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqContact" runat="server" ControlToValidate="txtContact" ErrorMessage="Health Unit Contact Required" CssClass="input-notification error png_bg" />

        <label>Attach files</label>
        <telerik:radasyncupload ID="AttachedFiles" runat="server" MultipleFileSelection="Automatic"></telerik:radasyncupload>

        <label>Additional Notes</label>
        <asp:TextBox ID="txtNotes" runat="server" CssClass="text-input textarea" Rows="5" TextMode="MultiLine"></asp:TextBox>

        <asp:Button ID="btnSubmit" runat="server" Text="Submit Workorder" CausesValidation="true" CssClass="button" onclick="btnSubmit_Click" />

</asp:Content>
