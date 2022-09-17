<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mostrarTicket.aspx.cs" Inherits="App_Turnos.mostrarTicket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Turno</title>
    <link href="CSS/estiloTurno.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">
            <img class="logo" src="img/LogoClinica.png" />
        </div>
        <div class="contenedor">
            <p id="titulo">Su turno es:</p>
        </div>
        <div>
            <asp:Label ID="lblTurno" class="contenedor h1" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="lblDesc" class="contenedor desc"  runat="server" Text="Label"></asp:Label>
        </div>
        <br />

    </form>

    <script>
        window.setInterval(function () {
            window.location.href = "scTicket.cshtml";

        }, 3000);

    </script>
</body>
</html>
