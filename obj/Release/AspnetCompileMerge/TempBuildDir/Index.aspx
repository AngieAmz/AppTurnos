 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="App_Turnos.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Pagina Principal</title>
    <link href="CSS/estilospagprincipal.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.2/css/all.min.css" 
        integrity="sha512-1sCRPdkRXhBV2PBLUdRb4tMg1w2YPf37qatUFeS7zlBy7jJI8Lf4VHwWfZZfpXtYSLy85pkm9GaYVYMfw5BC1A==" 
        crossorigin="anonymous" referrerpolicy="no-referrer" />
</head>
<body>
    <form id="formulario_principal" runat="server">
        <div>
            <ul class="options">
                <li class="option">
                    <a href="scTicket.cshtml" target="_blank">
                        <i class="fa-solid fa-ticket"></i>
                        <span>ticket</span>
                    </a>
                </li>
                <li class="option">
                    <a href="cajero.aspx" target="_blank">
                        <i class="fa-solid fa-cash-register"></i>
                        <span>Cajero</span>
                    </a>
                </li>
                <li class="option">
                    <a href="Pantalla.aspx" target="_blank">
                        <i class="fa-solid fa-desktop"></i>
                        <span>Pantalla</span>
                    </a>
                </li>
                <li class="option">
                    <a href="Login.aspx">
                        <i class="fa-solid fa-screwdriver-wrench"></i>
                        <span>Administrador</span>
                    </a>
                </li>
            </ul>
        </div>
    </form>
</body>
</html>
