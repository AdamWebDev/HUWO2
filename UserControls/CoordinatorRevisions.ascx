<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CoordinatorRevisions.ascx.cs" Inherits="HNHUWO2.UserControls.CoordinatorRevisions" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<fieldset>
    <legend>Coordintor Revisions</legend>
    <label>Coordinator Notes</label>
    <asp:TextBox ID="txtCoordintorNotes" runat="server" TextMode="MultiLine" Rows="6"></asp:TextBox>
    <label>Revised Files</label>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <telerik:radasyncupload ID="uploadFiles" runat="server" 
                MultipleFileSelection="Automatic" 
                Localization-Select="Add Files to Attach" Skin=""
                onfileuploaded="uploadFiles_FileUploaded"></telerik:radasyncupload>
        </ContentTemplate>
    </asp:UpdatePanel>
</fieldset>