<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SE256_Lab_RonC.About" %>

<%-- Placeholder for the 2nd Content holder. If there is no breaking news, clear the content between the div tags--%>
<asp:Content ID="NewContent" ContentPlaceHolderID="NewContentHolder" runat="server">

    <div>
        
    </div>


</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Line Dance Manager</h3>
    <p>This application allows an unverified user to search/view line dances from a database and view the latest videos. A verified user can create, read, update, and delete line dance records from the database using the <a href="~/Backend/" runat="server" style="color:#fe7014" >Backend</a>.</p>
</asp:Content>
