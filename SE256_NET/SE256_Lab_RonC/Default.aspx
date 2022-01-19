<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SE256_Lab_RonC._Default" %>

<%-- Placeholder for the 2nd Content holder. If there is no breaking news, clear the content between the div tags--%>
<asp:Content ID="Content2" ContentPlaceHolderID="SecondContentHolder" runat="server">

    <div>
        <h1>New Dance Alert</h1>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;Here I will add the information about a new dance that has been choreographed/taught
            <br />
            <br />
        </p>
    </div>


</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <br />
        Random Content in the Main Content Area
    </div>

</asp:Content>
