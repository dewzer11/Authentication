<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logon.aspx.cs" Inherits="Logon" %>
<%@ Import Namespace="System.Web.Security" %>

<%--<script runat="server">
    void Logon_Click(object sender, EventArgs e)
    {
        if ((UserEmail.Text == "jchen@contoso.com") &&
            (UserPass.Text == "37Yj*99Ps"))
        {
            FormsAuthentication.RedirectFromLoginPage
                (UserEmail.Text, Persist.Checked);
        }
        else
        {
            Msg.Text = "Invalid credentials. Please try again";
        }
    }
</script>--%>

<!DOCTYPE html>

<html  xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Forms Authentication - Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <h3>Logon Page</h3>
        <p>Not a member? <a href="Register.aspx">Register Here</a></p>
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
            <tr>
                <td>Remember me?</td>
                <td>
                    <asp:CheckBox ID="Persist" runat="server" />
                </td>
            </tr>
        </table>
        <asp:Button ID="Submit1" OnClick="Logon_Click" runat="server" Text="Log On" />
        <p>
            <asp:Label ID="Msg" ForeColor="Red" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
