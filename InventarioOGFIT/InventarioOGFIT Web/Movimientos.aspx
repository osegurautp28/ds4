<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Movimientos.aspx.cs" Inherits="InventarioOGFITWeb.PaginaMovimientos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Movimientos de Stock</h2>

<asp:Label runat="server" Text="Producto:" />
<asp:DropDownList ID="ddlProductos" runat="server" />
<br /><br />

<asp:Label runat="server" Text="Tipo:" />
<asp:RadioButtonList ID="rblTipo" runat="server" RepeatDirection="Horizontal">
    <asp:ListItem Text="Entrada" Value="ENTRADA" Selected="True"></asp:ListItem>
    <asp:ListItem Text="Salida" Value="SALIDA"></asp:ListItem>
</asp:RadioButtonList>
<br />

<asp:Label runat="server" Text="Cantidad:" />
<asp:TextBox ID="txtCantidad" runat="server" />
<br /><br />

<asp:Label runat="server" Text="Nota:" />
<asp:TextBox ID="txtNota" runat="server" Width="350" />
<br /><br />

<asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
<br /><br />

<asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
<hr />
<h3>Stock actual</h3>
<asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="true" />

        </div>
    </form>
</body>
</html>
