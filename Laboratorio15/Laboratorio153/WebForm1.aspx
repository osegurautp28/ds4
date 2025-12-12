<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio153.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label Text="Introduzca un Texto " runat="server" />
        <br />
        <asp:TextBox ID="txtTexto" runat="server"></asp:TextBox>
        <asp:Button ID="BotonSaludo" runat="server"  Text="Enviar Saludo!" OnClick="BotonSaludo_Click" />
        <div>
        </div>
    </form>
</body>
</html>
