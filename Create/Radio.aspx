<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Radio.aspx.cs" Inherits="HNHUWO2.Create.Radio" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">Create a Radio Ad Work Order</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server">
    <uc:NavButton ID="navCancel" runat="server" Icon="icon-remove" AltText="Cancel Icon" Text="Cancel" NavURL="~/Default.aspx" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">Create a Radio Ad Work Order</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Main" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:ValidationSummary ID="ValidationSummary" HeaderText="Your work order has not been saved. Please note the following fields that are missing information:" runat="server" CssClass="error-summary"  />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc:Notification ID="notMain" runat="server" Visible="false"/>
            
            <label>Ad Type</label>
            <asp:DropDownList ID="ddAdType" runat="server" AppendDataBoundItems="true" CssClass="small-input" AutoPostBack="true" onselectedindexchanged="ddAdType_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="reqAdType" runat="server" ControlToValidate="ddAdType" ErrorMessage="Ad Type is Required" CssClass="input-notification error png_bg" />
    
            <label>Program Coordinator</label>
            <asp:DropDownList ID="ddCoordinators" runat="server" AppendDataBoundItems="True" CssClass="small-input"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="reqCoordinators" runat="server" ControlToValidate="ddCoordinators" ErrorMessage="Program Coordinator is Required" CssClass="input-notification error png_bg" />

            <asp:PlaceHolder ID="phMonthly" runat="server" Visible="false">
                <label>Airing Month</label>
                <asp:DropDownList ID="ddAiringMonth" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqAiringMonth" runat="server" ControlToValidate="ddAiringMonth" ErrorMessage="Airing Month is Required" CssClass="input-notification error png_bg" Enabled="false" />
            </asp:PlaceHolder>

            <asp:PlaceHolder ID="phIndividual" runat="server" Visible="false">
                <label>Desired Radio Station</label>
                <asp:DropDownList ID="ddRadioStation" runat="server" AppendDataBoundItems="True" CssClass="small-input"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqRadioStation" runat="server" ControlToValidate="ddRadioStation" ErrorMessage="Desired Radio Station is Required" CssClass="input-notification error png_bg" Enabled="false"  />

                <label>Length of Ad</label>
                <asp:DropDownList ID="ddLengthOfAd" runat="server" AppendDataBoundItems="True" CssClass="small-input"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqLengthOfAd" runat="server" ControlToValidate="ddLengthOfAd" ErrorMessage="Length of Ad is Required" CssClass="input-notification error png_bg" Enabled="false"  />

                <label>Start Airing Date</label>
                <asp:TextBox ID="txtStartAiringDate" runat="server" CssClass="text-input small-input datepicker" />
                <asp:RequiredFieldValidator ID="reqStartAiringDate" runat="server" ControlToValidate="txtStartAiringDate" ErrorMessage="Start Airing Date is Required" CssClass="input-notification error png_bg" Enabled="false"  />

                <label>End Airing Date</label>
                <asp:TextBox ID="txtEndAiringDate" runat="server" CssClass="text-input small-input datepicker" />
                <asp:RequiredFieldValidator ID="reqEndAiringDate" runat="server" ControlToValidate="txtEndAiringDate" ErrorMessage="End Airing Date is Required" CssClass="input-notification error png_bg" Enabled="false" Display="Dynamic"  />
                <asp:CompareValidator ID="compEndAiringDate" runat="server" ControlToValidate="txtEndAiringDate" ControlToCompare="txtStartAiringDate" Operator="GreaterThanEqual" Type="Date" ErrorMessage="End Date must come after Starting Date" CssClass="input-notification error png_bg" Display="Dynamic"></asp:CompareValidator>

                <label>Budget</label>
                <asp:TextBox ID="txtBudget" runat="server" CssClass="text-input small-input" MaxLength="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqBudget" runat="server" ControlToValidate="txtBudget" ErrorMessage="Budget is Required" CssClass="input-notification error png_bg" Enabled="false" />

                <label>G/L Code</label>
                <asp:TextBox ID="txtGLCode" runat="server" CssClass="text-input small-input" MaxLength="25"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqGLCode" runat="server" ControlToValidate="txtGLCode" ErrorMessage="GL Code is Required" CssClass="input-notification error png_bg" Enabled="false" />
            
            </asp:PlaceHolder>

            <asp:PlaceHolder ID="phAdditionalInfo" runat="server" Visible="false">

                <label>Recording Options</label>
                <asp:DropDownList ID="ddRecordingOptions" runat="server" AppendDataBoundItems="true" CssClass="small-input"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqRecordingOptions" runat="server" ControlToValidate="ddRecordingOptions" ErrorMessage="Recording Options is Required" CssClass="input-notification error png_bg" Enabled="false"/>
                
                <label>Attach Files</label>
                <telerik:radasyncupload ID="AttachedFiles" runat="server" MultipleFileSelection="Automatic" TargetFolder="~/uploads"></telerik:radasyncupload>
                
                <label>Additional Notes</label>
                <asp:TextBox ID="txtNotes" runat="server" CssClass="text-input textarea" Rows="5" TextMode="MultiLine"></asp:TextBox>

            </asp:PlaceHolder>

            <p><asp:Button ID="btnSubmit" runat="server" Text="Submit Work Order" CssClass="button" Visible="false" onclick="btnSubmit_Click" /></p>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
