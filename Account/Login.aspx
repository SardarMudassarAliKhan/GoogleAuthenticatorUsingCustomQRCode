<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Account.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    <br />

    <asp:Button ID="btnLogin"
        Text="Login"
        runat="server"
        CssClass="btn btn-primary"
        OnClick="btnLogin_Click" />

</asp:Content>
