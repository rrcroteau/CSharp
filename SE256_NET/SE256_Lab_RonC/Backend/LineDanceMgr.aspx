<%@ Page Title="Dance Manager" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LineDanceMgr.aspx.cs" Inherits="SE256_Lab_RonC.Backend.LineDanceMgr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NewContentHolder" runat="server">

    <a href="~/Backend/ControlPanel.aspx" runat="server" style="color:black">Return to Control Panel</a>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <%-- For later use --%>
        <tr>
            <td>Dance ID</td>
            <td>&nbsp; <asp:Label ID="lblDance_ID" runat="server" style="color:#fe7014"/></td>
        </tr>

        <tr>
            <td>&nbsp;</td> <%--This is just for readability--%>
        </tr>

        <%-- Dance Name --%>
        <tr>
            <td>Dance Name</td>
            <td>&nbsp; <asp:TextBox ID="txtDanceName" runat="server" MaxLength="255" style="color:black"/>*</td>
            <td><asp:RequiredFieldValidator ID="RequiredField1" runat="server" ControlToValidate="txtDanceName" ErrorMessage="You must enter a dance name" style="color:#fe7014" /></td>
        </tr>

        <%-- Choreographer Information --%>
        <tr>
            <td>Choreographer's First Name</td>
            <td>&nbsp; <asp:TextBox ID="txtChoreo1First" runat="server" MaxLength="30" style="color:black"/>*</td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtChoreo1First" ErrorMessage="You must enter a first name" style="color:#fe7014" /></td>
        </tr>

        <tr>
            <td>Choreographer's Last Name</td>
            <td>&nbsp; <asp:TextBox ID="txtChoreo1Last" runat="server" MaxLength="30" style="color:black"/>*</td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtChoreo1Last" ErrorMessage="You must enter a last name" style="color:#fe7014" /></td>
        </tr>

        <tr>
            <td>2nd Choreographer's First Name</td>
            <td>&nbsp; <asp:TextBox ID="txtChoreo2First" runat="server" MaxLength="30" style="color:black"/></td>
        </tr>

        <tr>
            <td>2nd Choreographer's Last Name</td>
            <td>&nbsp; <asp:TextBox ID="txtChoreo2Last" runat="server" MaxLength="30" style="color:black"/></td>
        </tr>

        <tr>
            <td>3rd Choreographer's First Name</td>
            <td>&nbsp; <asp:TextBox ID="txtChoreo3First" runat="server" MaxLength="30" style="color:black"/></td>
        </tr>

        <tr>
            <td>3rd Choreographer's Last Name</td>
            <td>&nbsp; <asp:TextBox ID="txtChoreo3Last" runat="server" MaxLength="30" style="color:black"/></td>
        </tr>

        <%-- Music --%>
        <tr>
            <td>Music</td>
            <td>&nbsp; <asp:TextBox ID="txtMusic" runat="server" MaxLength="50" style="color:black"/>*</td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMusic" ErrorMessage="You must enter the music for the dance" style="color:#fe7014" /></td>
        </tr>

        <%-- Artist --%>
        <tr>
            <td>Artist</td>
            <td>&nbsp; <asp:TextBox ID="txtArtist" runat="server" MaxLength="50" style="color:black"/>*</td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtArtist" ErrorMessage="You must the artist for the music" style="color:#fe7014" /></td>
        </tr>

        <tr>
            <td>&nbsp;</td> <%--This is just for readability--%>
        </tr>

        <%-- Line or Partner --%>
        <tr>
            <td>Line or Partner</td>
            <td> 
                <asp:RadioButtonList ID="rbLinePartner" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem value="Line" Selected="True" style="padding-left:5px">&nbsp;Line&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                <asp:ListItem value="Partner">&nbsp;Partner</asp:ListItem> 
                </asp:RadioButtonList>
            </td>
        </tr>

        <tr>
            <td>&nbsp;</td> <%--This is just for readability--%>
        </tr>

        <%-- Difficulty --%>
        <tr>
            <td>Difficulty</td>
            <td>&nbsp; <asp:DropDownList ID="drpDifficulty" runat="server" MaxLength="20" style="color:black" Width="178px" Height="26px" >
                            <asp:ListItem Value="0" Selected="True" Text="--Select a Difficulty--"></asp:ListItem>
                            <asp:ListItem Value="Beginner" Text="Beginner"></asp:ListItem>
                            <asp:ListItem Value="Intermediate" Text="Intermediate"></asp:ListItem>
                            <asp:ListItem Value="Advanced" Text="Advanced"></asp:ListItem>
                       </asp:DropDownList>*</td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="drpDifficulty" InitialValue="0" ErrorMessage="You must select a difficulty" style="color:#fe7014" /></td>

        </tr>

        <%-- Steps --%>
        <tr>
            <td>Steps</td>
            <td>&nbsp; <asp:TextBox ID="txtSteps" runat="server" MaxLength="3" style="color:black"/>*</td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtSteps" InitialValue="" ErrorMessage="Please enter a step count (min. 8)" style="color:#fe7014" /></td>
            <td><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtSteps" Type="Integer" Operator="GreaterThanEqual" ValueToCompare="8" ErrorMessage="Steps must be greater than or equal to 8." style="color:#fe7014" /></td>
        </tr>

        <%-- Walls --%>
        <tr>
            <td>Walls</td>
            <td>&nbsp; <asp:TextBox ID="txtWalls" runat="server" MaxLength="1" style="color:black"/>*</td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtWalls" InitialValue="" ErrorMessage="Please enter # of walls (1-4)" style="color:#fe7014" /></td>
            <td><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtWalls" Type="Integer" MinimumValue="1" MaximumValue="4" ErrorMessage="Walls must be between 1 and 4" style="color:#fe7014" /></td>
        </tr>

        <tr>
            <td>&nbsp;</td> <%--This is just for readability--%>
        </tr>

        <%-- Date Choreographed --%>

        <tr>
            <td>&nbsp;</td> <%--This is just for readability--%>
        </tr>

        <tr>
            <td>Date Choreographed</td>
            <td> <%--Testing out some drop downs to make the built-in ASP calendar less cumbersome--%>&nbsp;&nbsp;&nbsp;
                <asp:DropDownList id="drpCalMonth" Runat="Server" OnSelectedIndexChanged="Set_Calendar" AutoPostBack="true" style="color:black"></asp:DropDownList>
                <asp:DropDownList id="drpCalYear" Runat="Server" OnSelectedIndexChanged="Set_Calendar" AutoPostBack="true" style="color:black"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>&nbsp</td>
            <td>&nbsp; <asp:Calendar ID="calDateChoreographed" runat="server" Selected="Today" TitleStyle-BackColor="#fe7014" DayStyle-BackColor="White" SelectedDayStyle-BackColor="#fe7014" style="color:black"/></td>
        </tr>

        <tr>
            <td>&nbsp;</td> <%--This is just for readability--%>
        </tr>

        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="* Mandatory Fields" style="margin-left:50px;"/></td>
        <%--<td><asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please correct the following errors:" /></td>--%>
        </tr>

    </table>

    <%-- Button to add a book to a DB --%>
    <br />
    <asp:Button ID="BtnAdd" runat="server" Text="Add" style="color:black" OnClick="BtnAdd_Click" />

    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="BtnUpdate" runat="server" Text="Update" style="color:black" OnClick="BtnUpdate_Click" />

    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="BtnDelete" runat="server" Text="Delete" style="color:black" OnClick="BtnDelete_Click" CausesValidation="false" />
    
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" style="color:black" OnClick="BtnCancel_Click" CausesValidation="false" />

    <%-- Feedback Label to show errors, provide confirmation, etc. --%>
    <br />
    <asp:Label ID="lblFeedback" runat="server" />

</asp:Content>
