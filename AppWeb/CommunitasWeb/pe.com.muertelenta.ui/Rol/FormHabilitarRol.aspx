<%@ Page Title="Communitas Libros | Estado de Roles" Language="C#" MasterPageFile="~/templates/Plantilla.Master" AutoEventWireup="true" CodeBehind="FormHabilitarRol.aspx.cs" Inherits="pe.com.communitas.ui.rol.FormHabilitarRol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Mismo CSS de siempre para Habilitar -->
    <style>
        .page-title { font-family: 'Playfair Display', serif; color: #2c3e50; font-weight: 700; text-transform: uppercase; letter-spacing: 1px; border-bottom: 2px solid #d35400; display: inline-block; padding-bottom: 10px; }
        .btn-action { font-family: 'Lora', serif; font-weight: 600; padding: 10px 24px; border-radius: 6px; transition: all 0.3s; text-transform: uppercase; font-size: 0.85rem; letter-spacing: 0.5px; }
        .btn-habilitar { background-color: #27ae60; color: white; border: none; } .btn-habilitar:hover { background-color: #1e8449; color: white; transform: translateY(-2px); box-shadow: 0 4px 10px rgba(39, 174, 96, 0.3); }
        .btn-deshabilitar { background-color: #c0392b; color: white; border: none; } .btn-deshabilitar:hover { background-color: #962d22; color: white; transform: translateY(-2px); box-shadow: 0 4px 10px rgba(192, 57, 43, 0.3); }
        .btn-regresar { background-color: #7f8c8d; color: white; border: none; } .btn-regresar:hover { background-color: #636e72; color: white; transform: translateY(-2px); box-shadow: 0 4px 10px rgba(127, 140, 141, 0.3); }
        .admin-card { background-color: #ffffff; border: 1px solid #eae1d5; border-radius: 12px; box-shadow: 0 10px 30px rgba(0,0,0,0.05); padding: 30px 20px; }
        .custom-table { background-color: white; border: 1px solid #eae1d5; border-radius: 8px; overflow: hidden; box-shadow: 0 4px 15px rgba(0,0,0,0.03); margin-bottom: 0; }
        .custom-table thead th { background-color: #2c3e50 !important; color: #ffffff !important; font-family: 'Playfair Display', serif; font-weight: 600; border: none; padding: 15px; letter-spacing: 0.5px; }
        .custom-table tbody tr:hover { background-color: #f9efe1 !important; }
        .custom-table td { vertical-align: middle; color: #555; border-bottom: 1px solid #eae1d5; padding: 12px; font-family: 'Lora', serif; }
        .btn-seleccionar { background-color: #f39c12; color: white; border: none; border-radius: 4px; padding: 5px 15px; font-size: 0.85rem; transition: background-color 0.2s; }
        .btn-seleccionar:hover { background-color: #d68910; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4 mb-5">
        <div class="text-center mb-5">
            <h2 class="page-title"><i class="fa-solid fa-user-shield me-2"></i>Estado de Roles</h2>
        </div>
        <div class="d-flex justify-content-center gap-3 mb-5">
            <asp:Button ID="btnHabilitar" runat="server" Text="Habilitar" CssClass="btn-action btn-habilitar" OnClick="btnHabilitar_Click" OnClientClick="return confirm('¿Habilitar este rol?');" />
            <asp:Button ID="btnDeshabilitar" runat="server" Text="Deshabilitar" CssClass="btn-action btn-deshabilitar" OnClick="btnDeshabilitar_Click" OnClientClick="return confirm('¿Deshabilitar este rol?');" /> 
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn-action btn-regresar" OnClick="btnRegresar_Click" />
        </div>
        <div class="admin-card mx-auto" style="max-width: 600px;">
            <asp:HiddenField ID="hfCodigoSeleccionado" runat="server" />
            <div class="table-responsive">
                <asp:GridView ID="gvHabilitarRol" runat="server" OnRowCommand="gvHabilitarRol_RowCommand" AutoGenerateColumns="false" CssClass="table custom-table table-hover align-middle text-center" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="codigo" HeaderText="Cód" />
                        <asp:BoundField DataField="nombre" HeaderText="Rol" />
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <span class='<%# Convert.ToBoolean(Eval("estado")) ? "badge bg-success" : "badge bg-danger" %>'>
                                    <%# Convert.ToBoolean(Eval("estado")) ? "Habilitado" : "Deshabilitado" %>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField Text="Seleccionar" CommandName="Seleccionar" ControlStyle-CssClass="btn-seleccionar" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>