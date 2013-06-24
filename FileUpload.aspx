<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="HNHUWO2.FileUpload" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <label>Attach files<asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            </label>
        &nbsp;<telerik:radasyncupload ID="AttachedFiles" runat="server" 
                MultipleFileSelection="Automatic" TargetFolder="~/uploads"></telerik:radasyncupload>
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />

    </div>
    </form>
</body>
</html>
