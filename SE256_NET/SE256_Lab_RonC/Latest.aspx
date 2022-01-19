<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Latest.aspx.cs" Inherits="SE256_Lab_RonC.Latest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SecondContentHolder" runat="server">
     <div>
        <h1>Latest Video:</h1>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;This will have the name and information about the latest video made
        </p>

    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>This Barn</h2>
        <iframe width="800" height="600" src="https://www.youtube.com/embed/gEewG2-O-40" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"></iframe>
</video>
    </div>

</asp:Content>
