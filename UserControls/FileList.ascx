<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileList.ascx.cs" Inherits="HNHUWO2.UserControls.FileList" %>
<span id="FileList">
    <asp:Repeater ID="rptFiles" runat="server" onitemdatabound="rptFiles_ItemDataBound">
        <HeaderTemplate>
            <ul class="filelist">
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink ID="lnkFile" runat="server" Text='<%# Eval("Filename") %>' NavigateUrl='<%# String.Format("/uploads/{0}/{1}",Eval("wID"),Eval("Filename")) %>' ></asp:HyperLink> 
                <asp:Label ID="lblRevision" runat="server" Text="(Revised)" Visible='<%# Eval("Revision") %>'></asp:Label>
                <asp:LinkButton ID="lnkDelete" CssClass="button warning" runat="server" CommandName="DeleteFile" CommandArgument='<%# Eval("ID") %>' Text="Delete" OnCommand="lnkDelete_Command" Visible="false"></asp:LinkButton>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
            
        </FooterTemplate>
    </asp:Repeater>
</span>

