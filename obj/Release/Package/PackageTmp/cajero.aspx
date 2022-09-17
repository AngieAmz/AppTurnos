<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cajero.aspx.cs" Inherits="App_Turnos.cajero" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cajero</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
     <script src="https://code.jquery.com/jquery-3.6.1.min.js"></script>
    <link href="CSS/estilosCajero.css" rel="stylesheet" />
</head>
<body>
    <form id="formCaja" runat="server">
        <div class="container">
            <div class="select">
            <asp:Label ID="lblModulo" runat="server" Text="Numero de caja:"></asp:Label>
            <asp:TextBox ID="txtModulo" CssClass="hola" runat="server" Width="62px" Enabled="false"></asp:TextBox>
            <asp:DropDownList ID="listaPc" runat="server" OnSelectedIndexChanged="btnActualizarPc_Click">
                <asp:ListItem>-</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnActualizarPc" runat="server" OnClick="btnActualizarPc_Click" Text="Actualizar"/>
        </div>
        <br />
            <div class="select">
                <asp:DropDownList ID="slcTurno" runat="server" AutoPostBack="true" OnSelectedIndexChanged="slcTurno_SelectedIndexChanged">
                    <asp:ListItem Value="0">-Seleccione tipo de turno-</asp:ListItem>
                </asp:DropDownList>
            </div>
                <br />
                <br />
            <div>
                <asp:GridView ID="tablaTurnos" CssClass="table table-striped" OnRowDataBound="ocultarID" runat="server"></asp:GridView>
            </div>
        </div>

        <div class="botones">

            <asp:Button ID="btnSiguiente" CssClass="btn btn-primary btn-dark" runat="server" Text="Llamar Turno" OnClick="btnSiguiente_Click" />
            <asp:Button ID="btnEliminarTurno" CssClass="btn btn-primary btn-dark" runat="server" Text="Atendido" OnClick="btnEliminarTurno_Click" />
           
        </div>
         <div class="btnlimpiar">
            <asp:Button ID="btnLimpiar" CssClass="btn btn-primary btn-dark" runat="server" Text="Limpiar Pantalla" OnClick="btnLimpiar_Click" />
         </div>
    </form>


</body>
</html>
