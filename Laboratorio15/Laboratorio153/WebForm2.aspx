<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Laboratorio153.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Texto1" Text="Numero1"  runat="server" />
        <br />
        <asp:TextBox ID="Numero1" runat="server" />
        <br />
        <asp:Label ID="Texto2" Text="Numero2" runat="server" />
        <br />
        <asp:TextBox ID="Numero2" runat="server" />
        <asp:Button ID="BotonSumar" runat="server" Text="Sumar" OnClick="BotonSumar_Click" />
        <asp:Label ID="SumaTotal" runat="server" Text="" /> 
        <div>
        </div>
    </form>
</body>
</html>
