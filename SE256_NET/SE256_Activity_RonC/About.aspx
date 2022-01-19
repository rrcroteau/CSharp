<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SE256_Activity_RonC.About" %>

<%-- Placeholder for the breaking news content. If there is no breaking news, clear the content between the div tags--%>
<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">

    <div>

    </div>


</asp:Content>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>EBook Manager</h3>
    <p>This application allows the user to create, read, update, and delete EBook records from a database.</p>
</asp:Content>
