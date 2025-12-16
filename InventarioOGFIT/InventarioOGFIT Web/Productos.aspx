<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="InventarioOGFITWeb.Productos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
     <h2>Productos</h2>

    <asp:GridView 
    ID="gvProductos" 
    runat="server" 
    AutoGenerateColumns="false" 
    GridLines="Horizontal"
    CssClass="table">

    <Columns>
        <asp:BoundField DataField="Nombre" HeaderText="Producto" />
        <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
        <asp:BoundField DataField="Precio" HeaderText="Precio ($)" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="Stock" HeaderText="Stock" />
    </Columns>

</asp:GridView>
    <br />
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
