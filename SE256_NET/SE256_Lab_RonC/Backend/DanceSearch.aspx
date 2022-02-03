<%@ Page Title="Dance Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanceSearch.aspx.cs" Inherits="SE256_Lab_RonC.Backend.DanceSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NewContentHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

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
            width: 20%;
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
