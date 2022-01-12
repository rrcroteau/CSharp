<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebCalc_RC._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%-- Author: Ron Croteau --%>
    <%-- SE256 Week 1 Activity/Lab - Web Calculator --%>

    <%-- Determine visual needs of a calculator --%>

    <div style="margin-top:20px;">

        <%-- Create a table to hold the calculator elements --%>
        <table>
            <%-- Setup the LCD Display to show the numbers/operands input by the user --%>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtLCD" runat="server" Columns="20" />
                </td>
                <td>
                    <asp:Label ID="lblMemory" Text="" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblOperand" Text="" runat="server" />
                </td>
            </tr>

            <%-- Add Buttons to simulate a calculator--%>

            <tr>
                <td><asp:Button ID="btnClear" Text="AC" runat="server" OnClick="Clear_Click" Width="40" /></td>
                <td><asp:Button ID="btnNegPos" Text="+/-" runat="server" OnClick="NegPos_Click" Width="40" /></td>
                <td><asp:Button ID="btnPercent" Text="%" runat="server" OnClick="Percent_Click" Width="40" /></td>
                <td><asp:Button ID="btnDivide" Text="/" runat="server" OnClick="Operand_Click" Width="40" Height="30" BackColor="#FF9900" /></td>
            </tr>

            <tr>
                <td><asp:Button ID="btn7" Text="7" runat="server" OnClick="NumButtons_Click" Width="40" BackColor="#666666" ForeColor="White" /></td>
                <td><asp:Button ID="btn8" Text="8" runat="server" OnClick="NumButtons_Click" Width="40" BackColor="#666666" ForeColor="White" /></td>
                <td><asp:Button ID="btn9" Text="9" runat="server" OnClick="NumButtons_Click" Width="40" BackColor="#666666" ForeColor="White" /></td>
                <td><asp:Button ID="btnMultiply" Text="x" runat="server" OnClick="Operand_Click" Width="40" Height="30" BackColor="#FF9900" /></td>
            </tr>

            <tr>
                <td><asp:Button ID="btn4" Text="4" runat="server" OnClick="NumButtons_Click" Width="40" BackColor="#666666" ForeColor="White" /></td>
                <td><asp:Button ID="btn5" Text="5" runat="server" OnClick="NumButtons_Click" Width="40" BackColor="#666666" ForeColor="White" /></td>
                <td><asp:Button ID="btn6" Text="6" runat="server" OnClick="NumButtons_Click" Width="40" BackColor="#666666" ForeColor="White" /></td>
                <td><asp:Button ID="btnSubtract" Text="-" runat="server" OnClick="Operand_Click" Width="40" Height="30" BackColor="#FF9900" /></td>
            </tr>

            <tr>
                <td><asp:Button ID="btn1" Text="1" runat="server" OnClick="NumButtons_Click" Width="40" BackColor="#666666" ForeColor="White" /></td>
                <td><asp:Button ID="btn2" Text="2" runat="server" OnClick="NumButtons_Click" Width="40" BackColor="#666666" ForeColor="White" /></td>
                <td><asp:Button ID="btn3" Text="3" runat="server" OnClick="NumButtons_Click" Width="40" BackColor="#666666" ForeColor="White" /></td>
                <td><asp:Button ID="btnAdd" Text="+" runat="server" OnClick="Operand_Click" Width="40" Height="30" BackColor="#FF9900" /></td>
            </tr>

            <tr>
                <td colspan="2"><asp:Button ID="btn0" Text="0" runat="server" OnClick="NumButtons_Click" Width="86" BackColor="#666666" ForeColor="White"/></td>
                <td><asp:Button ID="btnDecimal" Text="." runat="server" OnClick="NumButtons_Click" Width="40" BackColor="#666666" ForeColor="White" /></td>
                <td rowspan="2"><asp:Button ID="btnEquals" Text="=" runat="server" OnClick="Equals_Click" Width="40" Height="60" BackColor="#FF9900" /></td>

            </tr>

            <%-- Add some Memory functions to the calculator --%>
            <tr>
                <td><asp:Button ID="btnMemoryStore" Text="MS" runat="server" OnClick="MemoryStore_Click" Width="40"  BackColor="Silver" /></td>
                <td><asp:Button ID="btnMemoryRestore" Text="MR" runat="server" OnClick="MemoryRestore_Click" Width="40"  BackColor="Silver" /></td>
                <td><asp:Button ID="btnMemoryClear" Text="MC" runat="server" OnClick="MemoryClear_Click" Width="40"  BackColor="Silver" /></td>
            </tr>

        </table>


    </div>

</asp:Content>
