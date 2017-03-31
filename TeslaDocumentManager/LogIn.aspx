<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TeslaDocumentManager.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
     <form id="form1" runat="server">
        <div class="page-container">
            <div class="window">
                <div class="header">
                    <h3>Unesite svoje podatke:</h3>
                </div>
                <asp:Label ID="error_message" runat="server" Visible="false" Text=""></asp:Label>
                <div class="username">
                    <asp:textbox id="tbx_username" runat="server"></asp:textbox>
                </div>
                <div class="pass">
                    <asp:TextBox ID="tbx_pass" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <div class="login">
                    <asp:Button ID="btn_login" runat="server" Text="Uloguj se" OnClick="btn_login_Click" />
                </div>
                <div class="passrecovery">
                    <a href="PassRecovery.aspx">Zaboravljena lozinka?</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
