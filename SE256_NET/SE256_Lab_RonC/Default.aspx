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

    <style>
        table {
            border-collapse: collapse;
            text-align: center;
            vertical-align: middle;
            color:black;
        }


        thead {
            background-color: #333;
            color: white;
        }

        th, td {
            border: 1px solid black;
            width: 11%;
            padding: 5px;
            text-align: center;
        }

        caption {
            font-weight: bold;
            font-size: 24px;
            margin-bottom: 5px;
            color:#fe7014;
        }

        tbody tr:nth-child(odd) {
            background-color: #fff;

        }

        tbody tr:nth-child(even) {
            background-color: #eee;
        }

    </style>

    <h1>Find Your Favorite Dances Here!</h1>

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
