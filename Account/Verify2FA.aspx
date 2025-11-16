<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Verify2FA.aspx.cs" Inherits="WebApplication1.Account.Verify2FA" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Enter Google Authenticator Code</h3>

<asp:TextBox ID="txtCode" runat="server" CssClass="form-control"></asp:TextBox>
<br />
<asp:Button ID="btnVerify" Text="Verify" runat="server" OnClick="btnVerify_Click" CssClass="btn btn-success"/>
<br /><br />
<asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
 </asp:Content>

