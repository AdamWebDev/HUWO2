<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Web.aspx.cs" Inherits="HNHUWO2.Create.Web" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">Create Web Work Order</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
<script type="text/javascript">
    function ValidateCheckBoxList(sender, args) {
        args.IsValid = false;
        var n = $("input:checked").length;
        if (n > 0) {
            args.IsValid = true;
            return;
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuButtons" runat="server">
    <uc:NavButton ID="navCancel" runat="server" Icon="icon-remove" AltText="Cancel Icon" Text="Cancel" NavURL="~/Default.aspx" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">
    Create a Web Work Order
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Main" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Your work order has not been saved. Please note the following fields that are missing information:" runat="server" CssClass="error-summary"   />
            
            <uc:Notification ID="notMain" runat="server" Visible="false"/>
    
            <label>Type of Web Work</label>
            <asp:DropDownList ID="ddTypeWebWork" runat="server" CssClass="small-input" AppendDataBoundItems="true" AutoPostBack="True" onselectedindexchanged="ddTypeWebWork_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="reqTypeWebWork" runat="server" ControlToValidate="ddTypeWebWork" ErrorMessage="Type of Web Work is Required" CssClass="input-notification error png_bg" />

            <label>Program Coordinator</label>
            <asp:DropDownList ID="ddCoordinators" runat="server" AppendDataBoundItems="True" CssClass="small-input"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="reqCoordinators" runat="server" ControlToValidate="ddCoordinators" ErrorMessage="Program Coordinator is Required" CssClass="input-notification error png_bg" />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            
            <asp:PlaceHolder ID="phWebsite" runat="server" Visible="false">
                <label>Website</label>
                <asp:DropDownList ID="ddWebsite" runat="server" AppendDataBoundItems="true" CssClass="small-input" AutoPostBack="true" OnSelectedIndexChanged="ddWebsite_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqWebsite" runat="server" ControlToValidate="ddWebsite" ErrorMessage="Website is Required" CssClass="input-notification error png_bg" Enabled="false" />

                <asp:PlaceHolder ID="phWebsiteOther" runat="server" Visible="false">
                    <label>Please specify URL</label>
                    <asp:TextBox ID="txtWebsiteOther" runat="server" CssClass="small-input text-input" MaxLength="255"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqWebsiteOther" runat="server" ControlToValidate="txtWebsiteOther" ErrorMessage="URL is Required" CssClass="input-notification error png_bg" Enabled="false" />
                </asp:PlaceHolder>
            </asp:PlaceHolder>

            <asp:PlaceHolder ID="phNewContent" runat="server" Visible="false">
                <label>Location(s)</label>
                <asp:CheckBoxList ID="chkLocation" runat="server" CssClass="checkboxtable" OnSelectedIndexChanged="chkLocation_SelectedIndexChanged" AutoPostBack="true"></asp:CheckBoxList>
                <asp:CustomValidator ID="reqchkLocation" runat="server" ErrorMessage="Location is Required" ClientValidationFunction="ValidateCheckBoxList"  CssClass="input-notification error png_bg" Enabled="false" />

                <asp:PlaceHolder ID="phOtherLocation" runat="server" Visible="false">
                    <fieldset>
                    <legend>Where is this content supposed to go?</legend>
                    <label>Specify Location (URL)</label>
                    <asp:TextBox ID="txtAtoZLocation" runat="server" CssClass="text-input small-input" MaxLength="255"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqAtoZLocation" runat="server" ControlToValidate="txtAtoZLocation" ErrorMessage="Location (URL) is Required" CssClass="input-notification error png_bg" Enabled="false" />
                    </fieldset>
                </asp:PlaceHolder>

                <asp:PlaceHolder ID="phAtoZ" runat="server" Visible="false">
                    <fieldset>
                        <legend>Additional Information</legend>
                        <label>Posting Date</label>
                        <asp:TextBox ID="txtAtoZPostingDate" runat="server" CssClass="text-input small-input datepicker" />
                        <asp:RequiredFieldValidator ID="reqAtoZPostingDate" runat="server" ControlToValidate="txtAtoZPostingDate" ErrorMessage="Posting Date is Required" CssClass="input-notification error png_bg" Enabled="false" />

                        <label>Removal Date (if needed)</label>
                        <asp:TextBox ID="txtAtoZRemovalDate" runat="server" CssClass="text-input small-input datepicker" />
                        <asp:CompareValidator ID="cmpAtoZDates" runat="server" ErrorMessage="Removal date must be AFTER posting date" ControlToValidate="txtAtoZRemovalDate" ControlToCompare="txtAtoZPostingDate" CssClass="input-notification error png_bg" Enabled="False" Type="Date" Operator="GreaterThan"></asp:CompareValidator>

                        <label>Heading for New Page</label>
                        <asp:TextBox ID="txtAtoZHeading" runat="server" CssClass="text-input small-input" MaxLength="255"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqAtoZHeading" runat="server" ControlToValidate="txtAtoZHeading" ErrorMessage="Heading for New Page is Required" CssClass="input-notification error png_bg" Enabled="false" />

                        <label>Content</label>
                        <asp:TextBox ID="txtAtoZContent" runat="server" TextMode="MultiLine" CssClass="text-input medium-input" Rows="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqAtoZContent" runat="server" ControlToValidate="txtAtoZContent" ErrorMessage="Content is Required" CssClass="input-notification error png_bg" Enabled="false" />
                    </fieldset>
                </asp:PlaceHolder>

                <asp:PlaceHolder ID="phCalendar" runat="server" Visible="false">
                    <fieldset>
                        <legend>Calendar Details</legend>
                    

                        <label>Event Name</label>
                        <asp:TextBox ID="txtCalEventName" runat="server" CssClass="text-input small-input" MaxLength="255"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqCalEventName" runat="server" ControlToValidate="txtCalEventName" ErrorMessage="Event Name is Required" CssClass="input-notification error png_bg" Enabled="false" />

                        <label>Event Location</label>
                        <asp:TextBox ID="txtCalEventLocation" runat="server" CssClass=  "text-input small-input" MaxLength="255"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqCalEventLocation" runat="server" ControlToValidate="txtCalEventLocation" ErrorMessage="Event Location is Required" CssClass="input-notification error png_bg" Enabled="false" />

                        <label>Event Start Date</label>
                        <asp:TextBox ID="txtCalStartDate" runat="server" CssClass="text-input small-input datepicker" />
                        <asp:RequiredFieldValidator ID="reqCalStartDate" runat="server" ControlToValidate="txtCalStartDate" ErrorMessage="Event Start Date is Required" CssClass="input-notification error png_bg" Enabled="false" />

                        <label>Event Start Time</label>
                        <asp:TextBox ID="txtCalStartTime" runat="server" CssClass="text-input small-input timepicker" />
                        <asp:RequiredFieldValidator ID="reqCalStartTime" runat="server" ControlToValidate="txtCalStartTime" ErrorMessage="Event Start Time is Required" CssClass="input-notification error png_bg" Enabled="false" />

                        <label>Event End Date</label>
                        <asp:TextBox ID="txtCalEndDate" runat="server" CssClass="text-input small-input datepicker" />
                        <asp:RequiredFieldValidator ID="reqCalEndDate" runat="server" ControlToValidate="txtCalEndDate" ErrorMessage="Event End Date is Required" CssClass="input-notification error png_bg" Enabled="false" />

                        <label>Event End Time</label>
                        <asp:TextBox ID="txtCalEndTime" runat="server" CssClass="text-input small-input timepicker" />
                        <asp:RequiredFieldValidator ID="reqCalEndTime" runat="server" ControlToValidate="txtCalEndTime" ErrorMessage="Event End Time is Required" CssClass="input-notification error png_bg" Enabled="false" />

                        <label>Contact Name</label>
                        <asp:TextBox ID="txtContactName" runat="server" CssClass="text-input small-input" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqContactName" runat="server" ControlToValidate="txtContactName" ErrorMessage="Contact Name is Required" CssClass="input-notification error png_bg" Enabled="false" />

                        <label>Contact Email</label>
                        <asp:TextBox ID="txtContactEmail" runat="server" CssClass="text-input small-input" MaxLength="255"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqContactEmail" runat="server" ControlToValidate="txtContactEmail" ErrorMessage="Contact Email is Required" CssClass="input-notification error png_bg" Enabled="false" />

                        <label>Event Description</label>
                        <asp:TextBox ID="txtEventDesc" runat="server" CssClass="text-input small-input" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqEventDesc" runat="server" ControlToValidate="txtEventDesc" ErrorMessage="Event Description is Required" CssClass="input-notification error png_bg" Enabled="false" />

                        <label>Date to be Posted</label>
                        <asp:TextBox ID="txtDatePosted" runat="server" CssClass="text-input small-input datepicker" />
                        <asp:RequiredFieldValidator ID="reqDatePosted" runat="server" ControlToValidate="txtDatePosted" ErrorMessage="Date to be Posted is Required" CssClass="input-notification error png_bg" Enabled="false" />
                    </fieldset>
                </asp:PlaceHolder>
            </asp:PlaceHolder> <!-- End of NewContent -->
    
        <asp:PlaceHolder ID="phUpdateContent" runat="server" Visible="false">
            <label>Type of Update</label>
            <asp:DropDownList ID="ddTypeOfUpdate" runat="server" AppendDataBoundItems="true" />
            <asp:RequiredFieldValidator ID="reqTypeOfUpdate" runat="server" ControlToValidate="ddTypeOfUpdate" ErrorMessage="Type of Update is Required" CssClass="input-notification error png_bg" Enabled="false" />
        
            <label>Date to be Changed</label>
            <asp:TextBox ID="txtDateToBeChanged" runat="server" CssClass="text-input small-input datepicker" />
            <asp:RequiredFieldValidator ID="reqDateToBeChanged" runat="server" ControlToValidate="txtDateToBeChanged" ErrorMessage="Date to be Changed is Required" CssClass="input-notification error png_bg" Enabled="false" />

            <label>Location (URL)</label>
            <asp:TextBox ID="txtURL" runat="server" CssClass="text-input medium-input" MaxLength="255"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqURL" runat="server" ControlToValidate="txtURL" ErrorMessage="URL is Required" CssClass="input-notification error png_bg" Enabled="false" />

            <label>Description</label>
            <asp:TextBox ID="txtUpdateDesc" runat="server" CssClass="text-input" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqUpdateDesc" runat="server" ControlToValidate="txtUpdateDesc" ErrorMessage="Description is Required" CssClass="input-notification error png_bg" Enabled="false" />
        </asp:PlaceHolder>

        <asp:PlaceHolder ID="phNewWebsite" runat="server" Visible="false">
            <label>URL requesting</label>
            http://www.<asp:TextBox ID="txtRequestedURL" runat="server"  CssClass="text-input small-input" MaxLength="50"></asp:TextBox>
            <asp:DropDownList ID="ddDomain" runat="server">
                <asp:ListItem Value="" Text="--Select--" />
                <asp:ListItem Value=".com" Text=".com"/>
                <asp:ListItem Value=".ca" Text=".ca" />
            </asp:DropDownList>
            <asp:Button ID="btnCheckAvailable" runat="server" Text="Check Availability" CssClass="button" OnClick="btnCheckAvailable_OnClick" CausesValidation="false" />
            <uc:Notification ID="notURLAvailable" runat="server" />
            <p>This action requires the FO-79 form - New Technology Request.</p>
        </asp:PlaceHolder>

        <asp:PlaceHolder ID="phCD989WebAd" runat="server" Visible="false">
            <label>Post Date</label>
            <asp:TextBox ID="txtWebAdPostDate" runat="server" CssClass="text-input small-input datepicker" />
            <asp:RequiredFieldValidator ID="reqWebAdPostDate" runat="server" ControlToValidate="txtWebAdPostDate" ErrorMessage="Posting Date is Required" CssClass="input-notification error png_bg" Enabled="false" />    

            <label>Removal Date</label>
            <asp:TextBox ID="txtWebAdEndDate" runat="server" CssClass="text-input small-input datepicker" />
            <asp:RequiredFieldValidator ID="reqWebAdEndDate" runat="server" ControlToValidate="txtWebAdEndDate" ErrorMessage="Removal Date is Required" CssClass="input-notification error png_bg" Enabled="false" />    

            <label>URL To Link To</label>
            <asp:TextBox ID="txtWebAdURL" runat="server" CssClass="text-input small-input" MaxLength="255"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqWebAdURL" runat="server" ControlToValidate="txtWebAdURL" ErrorMessage="URL is Required" CssClass="input-notification error png_bg" Enabled="false" />

            <label>Content</label>
            <asp:TextBox ID="txtWebAdContent" runat="server" CssClass="text-input" TextMode="MultiLine" Rows="6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqWebAdContent" runat="server" ControlToValidate="txtWebAdContent" ErrorMessage="Content is Required" CssClass="input-notification error png_bg" Enabled="false" />
        </asp:PlaceHolder>

        <asp:PlaceHolder ID="phFacebookStatus" runat="server" Visible="false">
            <label>Post Date</label>
            <asp:TextBox ID="txtFacebookPostDate" runat="server" CssClass="text-input small-input datepicker" />
            <asp:RequiredFieldValidator ID="reqFacebookPostDate" runat="server" ControlToValidate="txtFacebookPostDate" ErrorMessage="Post Date is Required" CssClass="input-notification error png_bg" Enabled="false" />    

            <label>Content</label>
            <asp:TextBox ID="txtFacebookContent" runat="server" CssClass="text-input" TextMode="MultiLine" Rows="6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqFacebookContent" runat="server" ControlToValidate="txtFacebookContent" ErrorMessage="Content is Required" CssClass="input-notification error png_bg" Enabled="false" />
        </asp:PlaceHolder>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddTypeWebWork" />
        </Triggers>
    </asp:UpdatePanel>
            

            <label>Attach files:</label>
            <telerik:radasyncupload ID="AttachedFiles" runat="server" MultipleFileSelection="Automatic"></telerik:radasyncupload>

            <label>Additional Notes:</label>
            <asp:TextBox ID="txtNotes" runat="server" CssClass="text-input textarea" Rows="5" TextMode="MultiLine"></asp:TextBox>

        <p><asp:Button ID="btnSubmit" runat="server" Text="Submit Work Order" CssClass="button" onclick="btnSubmit_Click" /></p>

</asp:Content>
