<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="TeslaDocumentManager.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
                    Operater:
                    <asp:Label ID="lblOperater" runat="server" Text=""></asp:Label>
                    <asp:LinkButton ID="lnkOdjava" runat="server" OnClick="lnkOdjava_Click">Odjavi se</asp:LinkButton>
                </div>

                <hr class="my_hr" />

                <asp:Label ID="error_message" runat="server" Visible="false" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
