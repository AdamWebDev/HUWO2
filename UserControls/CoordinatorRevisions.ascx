<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CoordinatorRevisions.ascx.cs" Inherits="HNHUWO2.UserControls.CoordinatorRevisions" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<h3>Coordintor Revisions</h3>
<label>Coordinator Notes</label>
<asp:TextBox ID="txtCoordintorNotes" runat="server" TextMode="MultiLine" Rows="6"></asp:TextBox>
<label>Revised Files</label>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <telerik:radasyncupload ID="uploadFiles" runat="server" 
            MultipleFileSelection="Automatic" 
            Localization-Select="Add Files..." 
            onfileuploaded="uploadFiles_FileUploaded" TargetFolder="~/uploads"></telerik:radasyncupload>
    </ContentTemplate>
</asp:UpdatePanel>