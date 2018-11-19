<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Windows Authentication - Registration</title>
</head>
<body>
    <form id="form1" runat="server">

    <h3>Registration Page</h3>
        <table>
            <tr>
                <td>E-mail address:</td>
                <td>
                    <asp:TextBox ID="UserEmail" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator" 
                        runat="server" 
                        ErrorMessage="Cannot leave empty"
                        ControlToValidate="UserEmail"
                        Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="UserPass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator2" 
                        runat="server" 
                        ErrorMessage="Cannot be empty"
                        ControlToValidate="UserPass"></asp:RequiredFieldValidator>
                </td>
            </tr>


            <p>Back to Login Page <a href="Logon.aspx">Logon</a></p>
        </table>
        <asp:Button ID="Submit1" OnClick="Register_Click" runat="server" Text="Register" />
        <p>
            <asp:Label ID="Msg" ForeColor="Red" runat="server"></asp:Label>
        </p>

    </form>
</body>
</html>
