<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Solicitudes.aspx.cs" Inherits="Parcial_3.Solicitudes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                <h2>Registrar Solicitud de Pasaporte</h2>

        <!-- DataSources -->
        <asp:SqlDataSource ID="SqlPersonas" runat="server"
            ConnectionString="<%$ ConnectionStrings:dbPasaportes %>"
            SelectCommand="SELECT PersonaId, (Nombre + ' ' + Apellido) AS NombreCompleto FROM Persona">
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlTipos" runat="server"
            ConnectionString="<%$ ConnectionStrings:dbPasaportes %>"
            SelectCommand="SELECT TipoPasaporteId, Nombre FROM TipoPasaporte">
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlEstados" runat="server"
            ConnectionString="<%$ ConnectionStrings:dbPasaportes %>"
            SelectCommand="SELECT EstadoSolicitudId, Nombre FROM EstadoSolicitud">
        </asp:SqlDataSource>

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


        <!-- FORM -->
        <label>Persona:</label>
        <asp:DropDownList ID="ddlPersona" runat="server" DataSourceID="SqlPersonas"
            DataTextField="NombreCompleto" DataValueField="PersonaId">
        </asp:DropDownList>
        <br /><br />

        <label>Tipo de Pasaporte:</label>
        <asp:DropDownList ID="ddlTipo" runat="server" DataSourceID="SqlTipos"
            DataTextField="Nombre" DataValueField="TipoPasaporteId">
        </asp:DropDownList>
        <br /><br />

        <label>Estado:</label>
        <asp:DropDownList ID="ddlEstado" runat="server" DataSourceID="SqlEstados"
            DataTextField="Nombre" DataValueField="EstadoSolicitudId">
        </asp:DropDownList>
        <br /><br />

        <label>Observaciones:</label><br />
        <asp:TextBox ID="txtObs" runat="server" TextMode="MultiLine" Width="300"></asp:TextBox>
        <br /><br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Solicitud" OnClick="btnGuardar_Click" />
        <br /><br />

        <hr />

        <h3>Solicitudes Registradas</h3>
        <asp:GridView ID="GridViewSolicitudes" runat="server"
    AutoGenerateColumns="true"
    DataSourceID="SqlSolicitudes"
    DataKeyNames="SolicitudPasaporteId"
    AutoGenerateEditButton="True">
</asp:GridView>
                <!-- DataSource para insertar y listar solicitudes -->
        <asp:SqlDataSource ID="SqlSolicitudes" runat="server"
            ConnectionString="<%$ ConnectionStrings:dbPasaportes %>"
            SelectCommand="SELECT * FROM SolicitudPasaporte"
            InsertCommand="INSERT INTO SolicitudPasaporte(PersonaId, TipoPasaporteId, EstadoSolicitudId, Observaciones)
                           VALUES (@PersonaId, @TipoPasaporteId, @EstadoSolicitudId, @Observaciones)"
            UpdateCommand="UPDATE SolicitudPasaporte
                           SET PersonaId = @PersonaId,
                               TipoPasaporteId = @TipoPasaporteId,
                               EstadoSolicitudId = @EstadoSolicitudId,
                               Observaciones = @Observaciones,
                               NumeroPasaporte = @NumeroPasaporte,
                               FechaEmision = @FechaEmision,
                               FechaEntrega = @FechaEntrega
                           WHERE SolicitudPasaporteId = @SolicitudPasaporteId">
        </asp:SqlDataSource>


    </form>
</body>
</html>
