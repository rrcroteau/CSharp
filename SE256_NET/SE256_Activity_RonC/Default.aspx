<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SE256_Activity_RonC._Default" %>


<%-- Placeholder for the breaking news content. If there is no breaking news, clear the content between the div tags--%>
<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">

    <div>
        <h1>Breaking News:</h1>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;Microsoft has purchased Activision Blizzard for 89.7 billion dollars!
        </p>

    </div>


</asp:Content>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <br />
        Random Content in the Main Content Area
    </div>

</asp:Content>
