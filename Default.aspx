<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forms Authentication - Default Page</title>
</head>
<%--<script runat="server">
    void Page_Load(object sender, EventArgs e)
    {
        Welcome.Text = "Hello, " + Context.User.Identity.Name;
    }

    void Signout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();

        // clear and abandon session
        Session.Clear();
        Session.Abandon();

        Response.Redirect("Logon.aspx");
    }
</script>--%>

<body>
    <h3>Using Forms Authentication</h3>
    <asp:Label ID="Welcome" runat="server"></asp:Label>
    <form id="form1" runat="server">
        <asp:Button ID="Submit1" OnClick="Signout_Click" runat="server" Text="Sign Out" />

    </form>
</body>
</html>
