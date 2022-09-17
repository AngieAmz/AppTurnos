<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="App_Turnos.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Administración</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.js"></script>
    <link href="CSS/estiloAdmin.css" rel="stylesheet" />
</head>
<body>
    <form id="formulario_admin" runat="server">
            <div>
                <asp:Label ID="lblNuevoTicket" runat="server" Text="Nuevo tipo de ticket:"></asp:Label>
                <br />
                <asp:TextBox ID="txtAbreviatura" runat="server" placeholder="Abreviatura" Width="101px"></asp:TextBox>
                <asp:TextBox ID="txtTipoticket" runat="server" placeholder="Tipo de ticket" Width="152px"></asp:TextBox>
                <asp:Button ID="btnAgregar" CssClass="btn btn-primary btn-dark" runat="server" OnClick="btnAgregar_Click" Text="Agregar" Width="92px" />
                <asp:Button ID="btnEliminar" CssClass="btn btn-primary btn-dark" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" Width="92px" />
                <br />
                <br />
            </div>
        <div class="contenedor">
                <asp:GridView ID="tablaTickets" CssClass="table table-striped" width="300px" runat="server"></asp:GridView>
        </div>
    </form>

   

</body>
</html>
