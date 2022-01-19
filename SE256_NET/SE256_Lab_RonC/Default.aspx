<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SE256_Lab_RonC._Default" %>

<%-- Placeholder for the 2nd Content holder. If there is no breaking news, clear the content between the div tags--%>
<asp:Content ID="NewContent" ContentPlaceHolderID="NewContentHolder" runat="server">

    <div>
        <h1 style="margin:0; padding-top:1rem; color:#393e46;">New Dance Alert!</h1>
            <br />
            <p style="color:#eee; font-size:2rem;">&nbsp;&nbsp;&nbsp;&nbsp;A new favorite, "This Barn", is featured on our <a runat="server" href="~/Latest" style="color:#393e46">Latest Video</a> page!</p>
            <br />
            <br />
        
    </div>


</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" style="background-color:#393e46; color:#eee">

    <div >
        <br />
        Random Content in the Main Content Area
    </div>

</asp:Content>
