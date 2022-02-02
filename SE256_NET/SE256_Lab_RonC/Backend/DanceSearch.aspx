<%@ Page Title="Dance Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanceSearch.aspx.cs" Inherits="SE256_Lab_RonC.Backend.DanceSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NewContentHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Line Dance Search</h1>

    <p>Optional Search Criteria</p>
    <p>
        Dance Name: <asp:TextBox ID="txtDanceName" runat="server" Columns="30" Style="color:black"/>
        &nbsp;&nbsp;&nbsp;&nbsp;
        Music: <asp:TextBox ID="txtMusic" runat="server" Columns="30" Style="color:black" />
    </p>
    <br />
    <asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" Style="color:black" />

    <br />
    <br />
    <br />
    <asp:Literal ID="litResults" runat="server" Text="" />

</asp:Content>
