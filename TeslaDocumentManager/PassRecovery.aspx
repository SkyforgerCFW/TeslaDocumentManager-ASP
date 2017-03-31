<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassRecovery.aspx.cs" Inherits="TeslaDocumentManager.PassRecovery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Zaboravljena Lozinka</title>
    <link rel="stylesheet" type="text/css" href="style.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-container">
            <div class="window">
                <div class="header">
                    <h3>Zaboravljena lozinka?</h3>
                </div>
                <div class="info">
                    Unesite svoju e-mail adresu <br />
                    da bismo Vam poslali lozinku.
                </div>
                <div class="emailrec">
                    <asp:TextBox ID="tbx_emailrecovery" runat="server"></asp:TextBox>
                </div>
                <div class="posalji">
                    <asp:Button ID="btn_posalji" runat="server" Text="Pošalji" />
                </div>
                <div class="back">
                    <a href="Login.aspx">Početna</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
