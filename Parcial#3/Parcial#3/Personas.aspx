<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="Parcial_3.Personas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                <h2>Registro de Personas</h2>

        <asp:SqlDataSource ID="SqlDataSourcePersonas" runat="server"
            ConnectionString="<%$ ConnectionStrings:dbPasaportes %>"
            SelectCommand="SELECT * FROM Persona"
            InsertCommand="INSERT INTO Persona (Nombre, Apellido, Cedula, FechaNacimiento, Telefono, Correo)
                           VALUES (@Nombre, @Apellido, @Cedula, @FechaNacimiento, @Telefono, @Correo)"
            UpdateCommand="UPDATE Persona SET Nombre=@Nombre, Apellido=@Apellido, Cedula=@Cedula,
                           FechaNacimiento=@FechaNacimiento, Telefono=@Telefono, Correo=@Correo
                           WHERE PersonaId=@PersonaId"
            DeleteCommand="DELETE FROM Persona WHERE PersonaId=@PersonaId">
        </asp:SqlDataSource>

        <asp:GridView ID="GridView1" runat="server"
            AutoGenerateColumns="False" DataKeyNames="PersonaId"
            DataSourceID="SqlDataSourcePersonas"
            AllowPaging="true" AllowSorting="true">

            <Columns>
                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />

                <asp:BoundField DataField="PersonaId" HeaderText="ID" ReadOnly="true" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Cedula" HeaderText="Cédula" />
                <asp:BoundField DataField="FechaNacimiento" HeaderText="Nacimiento" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="Correo" HeaderText="Correo" />
            </Columns>

        </asp:GridView>

    </form>
</body>
</html>
