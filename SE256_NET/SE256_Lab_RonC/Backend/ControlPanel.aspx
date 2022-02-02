<%@ Page Title="Control Panel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="SE256_Lab_RonC.Backend.ControlPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NewContentHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Control Panel</h2>

        <table>

            <tr>
                <td><a href="LineDanceMgr.aspx" runat="server" style="color:#fe7014">Add a Line Dance</a></td>
            </tr>

            <tr>
                <td><a href="DanceSearch.aspx" runat="server" style="color:#fe7014">Search Line Dances</a></td>
            </tr>
            <tr><td>&nbsp;</td></tr> <%--This is just to add some space between the rows and the log out button--%>
            <tr>
                <td><asp:Button ID="BtnLogout" runat="server" Text="Log Out" OnClick="BtnLogout_Click" style="color: #393e46;" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
