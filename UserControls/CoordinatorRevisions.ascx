<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CoordinatorRevisions.ascx.cs" Inherits="HNHUWO2.UserControls.CoordinatorRevisions" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<div id="ApproveWithChangesModal" class="mfp-hide white-popup">
    <h2>Program Manager Revisions</h2>
    <label>Notes</label>
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
    
</div>