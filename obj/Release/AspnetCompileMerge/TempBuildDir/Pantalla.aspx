<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pantalla.aspx.cs" Inherits="App_Turnos.Pantalla" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Pantalla</title>
    <link href="CSS/estiloPantalla.css" rel="stylesheet" />
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet"/>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
            <div class="contenedor">
                <img id="logo" src="img/LogoClinica.png" />
            </div>
            <div class="container">
                <div>
                    <asp:GridView ID="tablaLlamada" CssClass="table table-striped tablaTurno" OnRowDataBound="ocultarID" runat="server"></asp:GridView>
                </div>
            </div>
    </form>


</body>
</html>
