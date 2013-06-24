﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileList.ascx.cs" Inherits="HNHUWO2.UserControls.FileList" %>
<span>
    <asp:Repeater ID="rptFiles" runat="server" 
    onitemdatabound="rptFiles_ItemDataBound">
        <HeaderTemplate>
            <ul class="filelist">
        </HeaderTemplate>
        <ItemTemplate>
            <li><asp:HyperLink ID="lnkFile" runat="server" Text='<%# Eval("Filename") %>' NavigateUrl='<%# Eval("URL") %>' ></asp:HyperLink>
                <asp:LinkButton ID="lnkDelete" CssClass="button warning" runat="server" CommandName="DeleteFile" CommandArgument='<%# Eval("ID") %>' Text="Delete" OnCommand="lnkDelete_Command" Visible="false"></asp:LinkButton></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
            
        </FooterTemplate>
    </asp:Repeater>
    <asp:Literal ID="ltEmpty" runat="server" Text="No files attached." Visible="false"></asp:Literal>
</span>
