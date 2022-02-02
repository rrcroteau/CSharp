<%@ Page Title="EBook Manager" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EBookMgr.aspx.cs" Inherits="SE256_Activity_RonC.Backend.EBookMgr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="BreakingNewsContent" runat="server">

    <a href="~/Backend/ControlPanel.aspx" runat="server" style="color:black">Return to Control Panel</a>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <%-- For later use --%>
        <tr>
            <td>Book ID</td>
            <td>&nbsp; <asp:Label ID="lblEbook_ID" runat="server" /></td>
        </tr>

        <tr>
            <td>&nbsp;</td> <%--This is just for readability--%>
        </tr>

        <%-- Book Title --%>
        <tr>
            <td>Book Title</td>
            <td>&nbsp; <asp:TextBox ID="txtTitle" runat="server" MaxLength="255" /></td>
        </tr>

        <%-- Author Information --%>
        <tr>
            <td>Author's First Name</td>
            <td>&nbsp; <asp:TextBox ID="txtAuthorFirst" runat="server" MaxLength="20" /></td>
        </tr>

        <tr>
            <td>Author's Last Name</td>
            <td>&nbsp; <asp:TextBox ID="txtAuthorLast" runat="server" MaxLength="40" /></td>
        </tr>

        <tr>
            <td>Author's Email</td>
            <td>&nbsp; <asp:TextBox ID="txtAuthorEmail" runat="server" MaxLenght="30" /></td>
        </tr>

        <%-- Date Published --%>
        <tr>
            <td>Date Published</td>
            <td>&nbsp; <asp:Calendar ID="calDatePublished" runat="server"><SelectedDayStyle Font-Size="Large" /></asp:Calendar></td>
        </tr>

        <tr>
            <td>&nbsp;</td> <%--This is just for readability--%>
        </tr>

        <%-- # of pages --%>
        <tr>
            <td>Number of Pages</td>
            <td>&nbsp; <asp:TextBox ID="txtPages" runat="server" MaxLength="5" /></td>
        </tr>

        <%-- Price --%>
        <tr>
            <td>Price Per Copy</td>
            <td>$<asp:TextBox ID="txtPrice" runat="server" MaxLength="10"  /></td>
        </tr>

        <%-- Bookmark Page --%>
        <tr>
            <td>Bookmark Page</td>
            <td>&nbsp; <asp:TextBox ID="txtBookmarkPage" runat="server" MaxLength="5" /></td>
        </tr>

        <tr>
            <td>&nbsp;</td> <%--This is just for readability--%>
        </tr>

        <%-- Date Rental Expires --%>
        <tr>
            <td>Date Rental Expires</td>
            <td><asp:Calendar ID="calRentalExpires" runat="server"><SelectedDayStyle Font-Size="Large" /></asp:Calendar></td>
        </tr>

    </table>

    <%-- Button to add a book to a DB --%>
    <br />
    <asp:Button ID="BtnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="BtnDelete" runat="server" Text="Delete" OnClick="BtnDelete_Click" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />

    <%-- Feedback Label to show errors, provide confirmation, etc. --%>
    <br />
    <asp:Label ID="lblFeedback" runat="server" />

</asp:Content>
