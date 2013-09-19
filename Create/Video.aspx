<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Video.aspx.cs" Inherits="HNHUWO2.Create.Video" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">Create Video Work Order</asp:Content>
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
<asp:Content ID="Content4" ContentPlaceHolderID="MainTitle" runat="server">Create Video Work Order</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Main" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:ValidationSummary ID="ValidationSummary" HeaderText="Your work order has not been saved. Please note the following fields that are missing information:" runat="server" CssClass="error-summary"  />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc:Notification ID="notMain" runat="server" Visible="false"/>

            <label>Title of Video</label>
            <asp:TextBox ID="txtTitleVideo" runat="server" CssClass="text-input medium-input" MaxLength="255"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqTitleVideo" runat="server" ControlToValidate="txtTitleVideo" ErrorMessage="Tile of Video is Required" CssClass="input-notification error png_bg" />

            <label>Program Manager</label>
            <asp:DropDownList ID="ddCoordinators" runat="server" AppendDataBoundItems="True" CssClass="medium-input"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="reqCoordinators" runat="server" ControlToValidate="ddCoordinators" ErrorMessage="Program Manager is Required" CssClass="input-notification error png_bg" />

            <label>Source of Video</label>
            <asp:DropDownList ID="ddVideoSource" runat="server" AppendDataBoundItems="true"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="reqVideoSource" runat="server" ControlToValidate="ddVideoSource" ErrorMessage="Video Source is Required" CssClass="input-notification error png_bg" />

            <label>What is Video Being Viewed On? (check all that apply)</label>
            <asp:CheckBoxList ID="chkVideoDestination" runat="server" CssClass="checkboxtable" RepeatLayout="UnorderedList" AutoPostBack="true" OnSelectedIndexChanged="chkVideoDestination_SelectedIndexChanged"></asp:CheckBoxList>
            <asp:CustomValidator ID="reqVideoDestination" runat="server" ErrorMessage="Video Destination is Required" ClientValidationFunction="ValidateCheckBoxList"  CssClass="input-notification error png_bg" />

            <asp:PlaceHolder ID="phOtherWebsite" runat="server" Visible="false">
                <label>Specify Other Website URL</label>
                <asp:TextBox ID="txtDestinationURL" runat="server" CssClass="text-input medium-input" MaxLength="255"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqDestinationURL" runat="server" ControlToValidate="txtDestinationURL" Enabled="false" ErrorMessage="Destination URL is Required" CssClass="input-notification error png_bg" />
            </asp:PlaceHolder>

            <asp:PlaceHolder ID="phNumberDVDs" runat="server" Visible="false">
                <label>Specify the Number of DVD Copies</label>
                <asp:TextBox ID="txtNumberDVDs" runat="server" CssClass="text-input medium-input" MaxLength="255"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqNumberDVDs" runat="server" ControlToValidate="txtNumberDVDs" Enabled="false" ErrorMessage="Number of DVDs is Required" CssClass="input-notification error png_bg" />
            </asp:PlaceHolder>

            <label>Approximate Length of Video</label>
            <asp:TextBox ID="txtVideoLength" runat="server" CssClass="text-input medium-input" MaxLength="255"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqVideoLength" runat="server" ControlToValidate="txtVideoLength" ErrorMessage="Length of Video is Required" CssClass="input-notification error png_bg" />

            <label>Due Date</label>
            <asp:TextBox ID="txtDueDate" runat="server" CssClass="text-input small-input datepicker" ontextchanged="txtDueDate_TextChanged" AutoPostBack="true" />
            <asp:RequiredFieldValidator ID="reqDueDate" runat="server" ControlToValidate="txtDueDate" ErrorMessage="Due Date is Required" CssClass="input-notification error png_bg" Display="Dynamic" />
            <asp:CompareValidator ID="cmpDueDate" runat="server" ErrorMessage="Due Date cannot be in the past." ControlToValidate="txtDueDate" Operator="GreaterThanEqual" Type="Date" Display="Dynamic" CssClass="input-notification error png_bg"></asp:CompareValidator>
            
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <uc:Notification ID="notDueDate" runat="server" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtDueDate" />
                </Triggers>
            </asp:UpdatePanel>

            <label>Background Music</label>
            <uc:TrueFalseDropDown ID="ddBackgroundMusic" runat="server" OnSelectedIndexChanged="ddBackgroundMusic_SelectedIndexChanged" AutoPostBack="true" />
            <asp:RequiredFieldValidator ID="reqBackgroundMusic" runat="server" ControlToValidate="ddBackgroundMusic:dd" ErrorMessage="Background Music is Required" CssClass="input-notification error png_bg" />

            <asp:PlaceHolder ID="phBackgroundMusic" runat="server" Visible="false">
                <label>Please Provide Song Choices from <a href="http://freeplaymusic.com/" target="_blank">freeplaymusic.com</a> or <a href="http://www.istockphoto.com/audio" target="_blank">istockphoto.com</a></label>
                <asp:TextBox ID="txtSongChoices" runat="server" CssClass="text-input" TextMode="MultiLine" Rows="5"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqSongChoices" runat="server" ControlToValidate="txtSongChoices" ErrorMessage="Song Choices are Required" CssClass="input-notification error png_bg" Enabled="false" />
            </asp:PlaceHolder>

            <label>Narration Required</label>
            <uc:TrueFalseDropDown ID="ddNarrationRequired" runat="server" OnSelectedIndexChanged="ddNarrationRequired_SelectedIndexChanged" AutoPostBack="true" />
            <asp:RequiredFieldValidator ID="reqNarrationRequired" runat="server" ControlToValidate="ddNarrationRequired:dd" ErrorMessage="Narration Required is Required" CssClass="input-notification error png_bg" />

            <asp:PlaceHolder ID="phNarration" runat="server" Visible="false">
                <label>Who Will Be Recording Narration</label>
                <asp:DropDownList ID="ddNarrator" runat="server" AppendDataBoundItems="true"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqNarrator" runat="server" ControlToValidate="ddNarrator" ErrorMessage="Narration Option is Required" CssClass="input-notification error png_bg" Enabled="false" />
            </asp:PlaceHolder>

            <label>Please Describe What Video Will Be Used For</label>
            <asp:TextBox ID="txtVideoDescription" runat="server" TextMode="MultiLine" CssClass="text-input" Rows="5"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqVideoDescription" runat="server" ControlToValidate="txtVideoDescription" ErrorMessage="Video Use is Required" CssClass="input-notification error png_bg" />

            <label>Are Credits Required At End of Video?</label>
            <uc:TrueFalseDropDown ID="ddCreditsRequired" runat="server" OnSelectedIndexChanged="ddCreditsRequired_SelectedIndexChanged" AutoPostBack="true" />
            <asp:RequiredFieldValidator ID="reqCreditsRequired" runat="server" ControlToValidate="ddCreditsRequired:dd" ErrorMessage="Credit Requirements are Required" CssClass="input-notification error png_bg" />
            <uc:Notification ID="notDisclaimer" runat="server" Visible="false" />

            <label>Attach files:</label>
            <telerik:radasyncupload ID="AttachedFiles" runat="server" MultipleFileSelection="Automatic" Skin="" Localization-Select="Add a File to Attach" ></telerik:radasyncupload>
            <div class="sub-text">Please note that multiple files can be uploaded.</div>

            <label>Additional Notes:</label>
            <asp:TextBox ID="txtNotes" runat="server" CssClass="text-input textarea" Rows="5" TextMode="MultiLine"></asp:TextBox>

            <p><asp:Button ID="btnSubmit" runat="server" Text="Save Work Order" CssClass="button" onclick="btnSubmit_Click" /></p>
    
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
