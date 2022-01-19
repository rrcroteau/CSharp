<%@ Page Title="Backend Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SE256_Lab_RonC.Backend.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NewContentHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br />
        <br />
        Username: <asp:TextBox ID="txtUName" runat="server" style="color:#393e46"/>
        <br />
        <br />
        Password: <asp:TextBox ID="txtPW" runat="server" TextMode="Password"  style="color:#393e46; margin-left:3px;"/>
        <br />
        <br />
        <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="Login" style="color:#393e46; width:100px; margin-left:100px;"/>
        <br />
        <br />
        <asp:Label ID="lblFeedback" runat="server" Text="" />
    </div>
</asp:Content>
