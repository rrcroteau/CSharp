<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SE256_Activity_RonC.Contact" %>

<%-- Placeholder for the breaking news content. If there is no breaking news, clear the content between the div tags--%>
<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">

    <div>

    </div>


</asp:Content>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <address>
        One New England Tech Boulevard<br />
        East Greenwich, Rhode Island 02818-1205<br />
        <abbr title="Phone">P:</abbr>
        401-739-5000
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:rrcroteau@mail.neit.edu">Email Me</a><br />
    </address>
</asp:Content>
