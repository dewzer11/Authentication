<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenerateConnectionString.aspx.cs" Inherits="GenerateConnectionString" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Please enter your connection string:
        <asp:TextBox ID="ConnectionString" runat="server"></asp:TextBox>
        <asp:Button ID="EncryptButton" runat="server" Text="Encrypt"  OnClick="EncryptButton_Click"/>

        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Your encrypted connection string is:"></asp:Label>
        <asp:Label ID="EncryptedString" runat="server" Text=""></asp:Label>
        <br />
        
        <asp:Label ID="Label2" runat="server" Text="Your decrypted connections string is:"></asp:Label>
        <asp:Label ID="DecryptedString" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
