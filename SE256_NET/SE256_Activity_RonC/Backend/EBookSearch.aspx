<%@ Page Title="EBook Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EBookSearch.aspx.cs" Inherits="SE256_Activity_RonC.Backend.EBookSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>EBook Search</h1>

    <p>Optional Search Criteria to Narrow Search Results</p>
    <p>
        Book Title: <asp:TextBox ID="txtTitle" runat="server" Columns="30" />

        &nbsp;&nbsp;&nbsp;&nbsp;

        Author's Last Name: <asp:TextBox ID="txtAuthorLast" runat="server" Columns="30" />
    </p>

    <br />

    <asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" />

    <br />
    <br />

    <%-- First we will display the DataSet results, which show in a DataGrid -- This basically looks like an Excel spreadsheet
        The hyperlink will pass the EBook_ID to the EBook Manager page in order to to pull that specific book up in th manager to read/update/delete
        
        In VS2019, certain elements were renamed with Column instead of Field, such as BoundField to BoundColumn... along with other renamings, so be careful of how you write the code and use IntelliSense when possible        --%>

    <asp:DataGrid ID="dgResults" runat="server" AutoGenerateColumns="false" >
        <Columns>
            <asp:BoundColumn DataField="Title" HeaderText="Book Title" />
            <asp:BoundColumn DataField="AuthorFirst" HeaderText="Author's First Name" />
            <asp:BoundColumn DataField="AuthorLast" HeaderText="Author's Last Name" />
            <asp:BoundColumn DataField="DatePublished" HeaderText="Date Published" />
            <asp:HyperLinkColumn Text="Edit" DataNavigateUrlFormatString="~/Backend/EBookMgr.aspx?EBook_ID={0}" DataNavigateUrlField="EBook_ID" />
        </Columns>
    </asp:DataGrid>

    <br />
    <br />

    <h2>Another Output Option: Create our own output looping through the DataReader and filling an ItemTemplate</h2>
    <asp:Repeater ID="rptSearch" runat="server" >
        <HeaderTemplate>
            <asp:Label ID="lblHeader" runat="server" Text="Your Results..." />
        </HeaderTemplate>

        <ItemTemplate>
            <br />
            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>' />
            <asp:Label ID="lblAuthorFirst" runat="server" Text='<%# Eval("AuthorFirst") %>' />
            <asp:Label ID="lblAuthorLast" runat="server" Text='<%# Eval("AuthorLast") %>' />
            <asp:Label ID="lblDatePublished" runat="server" Text='<%# Eval("DatePublished") %>' />
            <asp:HyperLink ID="HyperLink1" runat="server" Text="Edit" NavigateUrl='<%# Eval("EBook_ID", "EBookMgr.aspx?EBook_ID={0}") %>' />
            <br />
        </ItemTemplate>

    </asp:Repeater>

    <br />
    <br />
    <h2>Another Output Option: Create our own output looping through the DataReader and developing all the HTML on the fly using Literal</h2>
    <asp:Literal ID="litResults" runat="server" Text="" />


</asp:Content>
