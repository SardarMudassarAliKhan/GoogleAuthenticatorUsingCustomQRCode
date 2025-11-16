<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Account.Register" %>

<asp:content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
<br />
<asp:Button ID="btnRegister" Text="Register" runat="server" OnClick="btnRegister_Click" CssClass="btn btn-primary"/>

<br /><br />
<div>
    <asp:Image ID="imgQrCode" runat="server" Visible="false" />
</div>

<label>Manual Secret:</label>
<asp:Label ID="lblSecret" runat="server" Visible="false" />
</asp:content>