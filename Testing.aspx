<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Testing.aspx.cs" Inherits="HNHUWO2.Testing" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <uc:CoordinatorRevisions ID="CoordinatorRevisions1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </ContentTemplate>
</asp:UpdatePanel>
    
    </div>
    </form>
</body>
</html>
