<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SetUp2FA.aspx.cs" Inherits="WebApplication1.Account.SetUp2FA" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <h3>Setup Google Authenticator</h3>

<asp:Image ID="imgQr" runat="server" style="height:150px; width:150px" />
<br />

<label>Or enter this secret manually:</label>
<asp:Label ID="lblSecret" runat="server" />

<br /><br />

Enter code from Google Authenticator:
<asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
<br />
<asp:Button ID="btnVerify" runat="server" Text="Activate" OnClick="btnVerify_Click" />

</asp:Content>
