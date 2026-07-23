<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="pe.com.muertelenta.ui.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Muerte Lenta | Ingreso al Sistema</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous" />
    <style>
        body {
            background: linear-gradient(to bottom,#5805C0,#680DD4,#951DC5,#CB65ED,#FFFFFF);
        }
    </style>
</head>
<body>
    <%--inicio del contenedor--%>
    <div class="container d-flex justify-content-center align-items-center vh-100">
        <%--iniciamos el login--%>
        <div class="p-5 rounded-5 shadow-lg" style="max-width: 400px; background-color: white;">
            <h1 class="text-center">Ingreso al Sistema</h1>
            <%--inicio del formulario--%>
            <form id="form1" runat="server" class="g-3 needs-validation" novalidate>
                <div class="mb-3">
                    <asp:Label ID="Label1" runat="server" Text="Usuario:" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtUsu" runat="server" CssClass="form-control" required placeholder="Ingresa el usuario"></asp:TextBox>
                    <div class="invalid-feedback">
                        Ingrese el usuario
                    </div>
                </div>

                <div class="mb-3">
                    <asp:Label ID="Label2" runat="server" Text="Clave:" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtCla" runat="server" CssClass="form-control" TextMode="Password" required placeholder="Ingresa la clave"></asp:TextBox>
                    <div class="invalid-feedback">
                        Ingrese la clave
                    </div>
                </div>

                <div class="d-flex justify-content-center">
                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary w-50" />
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-dark w-50" NavigateUrl="~/FormMenuPrincipal.aspx">Ir al Menu</asp:HyperLink>
                </div>
            </form>
            <%--fin del formulario--%>
        </div>
        <%--fin del login--%>
    </div>
    <%--fin del contenedor--%>

    <%--agregamos el script de validacion--%>
    <script>
        // Example starter JavaScript for disabling form submissions if there are invalid fields
        (() => {
            'use strict'

            // Fetch all the forms we want to apply custom Bootstrap validation styles to
            const forms = document.querySelectorAll('.needs-validation')

            // Loop over them and prevent submission
            Array.from(forms).forEach(form => {
                form.addEventListener('submit', event => {
                    if (!form.checkValidity()) {
                        event.preventDefault()
                        event.stopPropagation()
                    }

                    form.classList.add('was-validated')
                }, false)
            })
        })()
    </script>
    <%--fin del script de validacion--%>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
</body>
</html>

