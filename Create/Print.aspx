<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="HNHUWO2.Create.Print" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server"><asp:Literal ID="ltPageTitle" runat="server"></asp:Literal></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server">
    <uc:NavButton ID="navCancel" runat="server" Icon="icon-remove" AltText="Cancel Icon" Text="Cancel" NavURL="~/Default.aspx" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">
    <asp:Literal ID="ltContentTitle" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Main" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:ValidationSummary ID="ValidationSummary" HeaderText="Your work order has not been saved. Please note the following fields that are missing information:" runat="server" CssClass="error-summary"  />
    
    <label for="txtPubTitle">Publication Title</label>
    <asp:TextBox ID="txtPubTitle" runat="server" CssClass="text-input small-input" MaxLength="75"></asp:TextBox>
    <asp:RequiredFieldValidator ID="reqPubTitle" runat="server" ControlToValidate="txtPubTitle" ErrorMessage="Publication Title is Required" CssClass="input-notification error png_bg" />

    <label>Program Manager</label>
    <asp:DropDownList ID="ddCoordinators" runat="server" AppendDataBoundItems="True" CssClass="small-input"></asp:DropDownList>
    <asp:RequiredFieldValidator ID="reqCoordinators" runat="server" ControlToValidate="ddCoordinators" ErrorMessage="Program Manager is Required" CssClass="input-notification error png_bg" />

    
        <label>Type of Project</label>
        <asp:DropDownList ID="ddTypeProject" runat="server" onselectedindexchanged="ddTypeProject_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="True" CssClass="small-input"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="reqTypeProject" runat="server" ControlToValidate="ddTypeProject" ErrorMessage="Type of Project is Required" CssClass="input-notification error png_bg" />

        <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
        <asp:PlaceHolder ID="phProjectOther" runat="server" Visible="false">
            <label>Describe the Project</label>
            <asp:TextBox ID="txtProjectOther" runat="server" CssClass="text-input small-input" MaxLength="255"></asp:TextBox><asp:Label ID="lblProjectOther" runat="server"></asp:Label>
            <asp:RequiredFieldValidator ID="reqProjectOther" ControlToValidate="txtProjectOther" runat="server" ErrorMessage="Project Description is Required" CssClass="input-notification error png_bg"  Enabled="false"></asp:RequiredFieldValidator>
            </asp:PlaceHolder>
        
            <asp:PlaceHolder ID="phDisplay" runat="server" Visible="false">
                <label>Type of Display</label>
                <asp:DropDownList ID="ddTypeOfDisplay" runat="server" AppendDataBoundItems="True" CssClass="small-input" onselectedindexchanged="ddTypeOfDisplay_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><asp:Label ID="lblTypeOfDisplay" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="reqTypeOfDisplay" runat="server" ControlToValidate="ddTypeOfDisplay" ErrorMessage="Type of Display is Required" CssClass="input-notification error png_bg" Enabled="false" ></asp:RequiredFieldValidator>
            </asp:PlaceHolder>

            <asp:PlaceHolder ID="phDisplayOther" runat="server" Visible="false">
                <label>Describe Display</label>
                <asp:TextBox ID="txtDisplayOther" runat="server" CssClass="text-input small-input" MaxLength="255"></asp:TextBox><asp:Label ID="lblDisplayOther" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="reqDisplayOther" runat="server" ControlToValidate="txtDisplayOther" ErrorMessage="Type of Display is Required" CssClass="input-notification error png_bg" Enabled="false" ></asp:RequiredFieldValidator>
            </asp:PlaceHolder>

            <asp:PlaceHolder ID="phPromoItem" runat="server" Visible="false">
                <label>Please Describe</label>
                <asp:TextBox ID="txtPromoItem" runat="server" CssClass="text-input small-input" MaxLength="255"></asp:TextBox><asp:Label ID="lblPromoItem" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="reqPromoItem" runat="server" ControlToValidate="txtPromoItem" ErrorMessage="Type of Promotional Item is Required" CssClass="input-notification error png_bg" Enabled="false" ></asp:RequiredFieldValidator>
            </asp:PlaceHolder>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddTypeProject" />
            </Triggers>
        </asp:UpdatePanel>

        <label>Due Date of Finished Project</label>
        <asp:TextBox ID="txtDueDate" runat="server" CssClass="text-input small-input datepicker" AutoPostBack="true" OnTextChanged="txtDueDate_TextChanged" />
        <asp:RequiredFieldValidator ID="reqDueDate" runat="server" ControlToValidate="txtDueDate" ErrorMessage="Due Date is Required" CssClass="input-notification error png_bg" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cmpDueDate" runat="server" ErrorMessage="Due date cannot be in the past." ControlToValidate="txtDueDate" Operator="GreaterThanEqual" Type="Date" Display="Dynamic" CssClass="input-notification error png_bg"></asp:CompareValidator>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <uc:Notification ID="notDueDate" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtDueDate" />
            </Triggers>
        </asp:UpdatePanel>
        
        
        <label>Printing Method</label>
        <asp:DropDownList ID="ddPrintingMethod" runat="server" AppendDataBoundItems="true" onselectedindexchanged="ddPrintingMethod_SelectedIndexChanged" AutoPostBack="true" CssClass="small-input"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="reqPrintingMethod" runat="server" ControlToValidate="ddPrintingMethod" ErrorMessage="Printing Method is Required" CssClass="input-notification error png_bg" ></asp:RequiredFieldValidator>

        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <asp:PlaceHolder ID="phBudget" runat="server" Visible="false">
                <label>Budget ($)</label>
                <asp:TextBox ID="txtBudget" runat="server" CssClass="text-input small-input" MaxLength="10"></asp:TextBox><asp:Label ID="lblBudget" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="reqBudget" runat="server" ErrorMessage="Budget is Required" ControlToValidate="txtBudget" CssClass="input-notification error png_bg"  Enabled="false" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="chkBudget" runat="server" ControlToValidate="txtBudget" ErrorMessage="Not a valid number. Please enter the amount only (e.g. 583.24)" CssClass="input-notification error png_bg" Operator="DataTypeCheck" Type="Double" Display="Dynamic" Enabled="true"></asp:CompareValidator>
            </asp:PlaceHolder>

            <uc:Notification ID="notCommercialInfo" runat="server" Visible="false" Type="information" Message="If you are unsure how long delivery time is from a commercial printer please speak to communications staff and they will find an estimate for your project. Please give communications staff more than the minimum timeline in order for your product to arrive in time for your event/due date." />

            <asp:PlaceHolder ID="phCommercialPrint" runat="server" Visible="false">
            <label>Number of Copies/Pieces</label>
            <asp:TextBox ID="txtNumberCopies" runat="server" CssClass="text-input small-input" MaxLength="50"></asp:TextBox><asp:Label ID="lblNumberCopies" runat="server"></asp:Label>
            <asp:RequiredFieldValidator ID="reqNumberCopies" runat="server" ControlToValidate="txtNumberCopies" ErrorMessage="Number of Copies is Required" CssClass="input-notification error png_bg" Enabled="false" />

            <label>Full Bleed</label>
            <uc:TrueFalseDropDown ID="ddFullBleed" runat="server" CssClass="small-input" /><asp:Label ID="lblFullBleed" runat="server"></asp:Label>
            <asp:RequiredFieldValidator ID="reqFullBleed" runat="server" ErrorMessage="Full Bleed is Required" ControlToValidate="ddFullBleed:dd"  CssClass="input-notification error png_bg" Enabled="false"></asp:RequiredFieldValidator>
        </asp:PlaceHolder>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddPrintingMethod" />
        </Triggers>
        </asp:UpdatePanel>

        <label>Paper or Product Size</label>
        <asp:DropDownList ID="ddPaperSize" runat="server" AppendDataBoundItems="true" AutoPostBack="true" onselectedindexchanged="ddPaperSize_SelectedIndexChanged" CssClass="small-input"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="reqPaperSize" runat="server" ErrorMessage="Paper/Product Size is Required" ControlToValidate="ddPaperSize" CssClass="input-notification error png_bg" ></asp:RequiredFieldValidator>
    
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <asp:PlaceHolder ID="phCustomPaperSize" runat="server" Visible="false">
            <label>Custom Paper Size</label>
            <asp:TextBox ID="txtCustomPaperSize" runat="server"  CssClass="text-input small-input" MaxLength="50"></asp:TextBox><asp:Label ID="lblCustomPaperSize" runat="server"></asp:Label>
            <asp:RequiredFieldValidator ID="reqCustomPaperSize" runat="server" ErrorMessage="Custom Paper Size is Required" ControlToValidate="txtCustomPaperSize" CssClass="input-notification error png_bg"  Enabled="false" Display="Dynamic"></asp:RequiredFieldValidator>
            </asp:PlaceHolder>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddPaperSize" />
        </Triggers>
        </asp:UpdatePanel>
        

        <label>Paper Type</label>
        <asp:DropDownList ID="ddPaperType" runat="server" AppendDataBoundItems="true" CssClass="small-input"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="reqPaperType" runat="server" ErrorMessage="Paper Type is Required" CssClass="input-notification error png_bg" ControlToValidate="ddPaperType" ></asp:RequiredFieldValidator>

        <label>Colour Information</label>
        <asp:DropDownList ID="ddColourInfo" runat="server" AppendDataBoundItems="true" CssClass="small-input"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="reqColourInfo" runat="server" ErrorMessage="Colour Information is Required" ControlToValidate="ddColourInfo" CssClass="input-notification error png_bg" ></asp:RequiredFieldValidator>
        
        <label>Credits</label>
        <asp:DropDownList ID="ddCredits" runat="server" AppendDataBoundItems="true" AutoPostBack="true" onselectedindexchanged="ddCredits_SelectedIndexChanged" CssClass="small-input"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="reqCredits" runat="server" ErrorMessage="Credits are Required" ControlToValidate="ddCredits"  CssClass="input-notification error png_bg"></asp:RequiredFieldValidator>

        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="phCredits" runat="server" Visible="false">
                <label>Name/Company</label>
                <asp:TextBox ID="txtCreditName" runat="server" CssClass="text-input medium-input" MaxLength="100"></asp:TextBox><asp:Label ID="lblCreditName" runat="server"></asp:Label>
                <asp:RequiredFieldValidator ID="reqCreditName" runat="server" ControlToValidate="txtCreditName" ErrorMessage="Credit Information Required" CssClass="input-notification error png_bg"  Enabled="false" Display="Dynamic"/>
            </asp:PlaceHolder>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddCredits" />
            </Triggers>
        </asp:UpdatePanel>

        <label>Add To Website?</label>
        <uc:TrueFalseDropDown ID="ddAddToWebsite" runat="server" />
        
        <label>Attach files</label>
        <telerik:radasyncupload ID="AttachedFiles" runat="server" MultipleFileSelection="Automatic" Skin="" Localization-Select="Add a File to Attach" InputSize="30"></telerik:radasyncupload>
        
        <label>Additional Notes</label>
        <asp:TextBox ID="txtNotes" runat="server" CssClass="text-input textarea" Rows="5" TextMode="MultiLine"></asp:TextBox>

        <p><asp:Button ID="btnSubmit" runat="server" Text="Submit Work Order" CssClass="button"  onclick="btnSubmit_Click" /></p>

</asp:Content>
