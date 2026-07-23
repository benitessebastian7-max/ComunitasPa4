<%@ Page Title="Communitas Libros | Proveedores" Language="C#" MasterPageFile="~/templates/Plantilla.Master" AutoEventWireup="true" CodeBehind="FormProveedor.aspx.cs" Inherits="pe.com.communitas.ui.proveedor.FormProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .page-title { font-family: 'Playfair Display', serif; color: #2c3e50; font-weight: 700; text-transform: uppercase; letter-spacing: 1px; border-bottom: 2px solid #d35400; display: inline-block; padding-bottom: 10px; }
        .admin-card { background-color: #ffffff; border: 1px solid #eae1d5; border-radius: 12px; box-shadow: 0 10px 30px rgba(0,0,0,0.05); padding: 30px 20px; }
        .form-label-custom { color: #4a4a4a; font-size: 0.95rem; font-family: 'Lora', serif; }
        .form-control, .form-select { border: 1px solid #dcd3c6; border-radius: 6px; background-color: #fdfbf7; font-family: 'Lora', serif; transition: all 0.3s ease; }
        .form-control:focus, .form-select:focus { border-color: #d35400; box-shadow: 0 0 0 0.2rem rgba(211, 84, 0, 0.15); }
        
        .btn-action { font-family: 'Lora', serif; font-weight: 600; padding: 10px 24px; border-radius: 6px; transition: all 0.3s; text-transform: uppercase; font-size: 0.85rem; }
        .btn-nuevo { background-color: #7f8c8d; color: white; border: none; } .btn-nuevo:hover { background-color: #636e72; color: white; transform: translateY(-2px); }
        .btn-registrar { background-color: #2c3e50; color: white; border: none; } .btn-registrar:hover { background-color: #1a252f; color: white; transform: translateY(-2px); }
        .btn-actualizar { background-color: #d35400; color: white; border: none; } .btn-actualizar:hover { background-color: #a84300; color: white; transform: translateY(-2px); }
        .btn-eliminar { background-color: #c0392b; color: white; border: none; } .btn-eliminar:hover { background-color: #962d22; color: white; transform: translateY(-2px); }
        .btn-habilitar { background-color: #27ae60; color: white; border: none; } .btn-habilitar:hover { background-color: #1e8449; color: white; transform: translateY(-2px); }
        
        .custom-table { background-color: white; border: 1px solid #eae1d5; border-radius: 8px; box-shadow: 0 4px 15px rgba(0,0,0,0.03); overflow: hidden; }
        .custom-table thead th { background-color: #2c3e50 !important; color: #ffffff !important; font-family: 'Playfair Display', serif; font-weight: 600; border: none; padding: 15px; }
        .custom-table tbody tr:hover { background-color: #f9efe1 !important; }
        .custom-table td { vertical-align: middle; color: #555; border-bottom: 1px solid #eae1d5; padding: 12px; font-family: 'Lora', serif; }
        .btn-seleccionar { background-color: #f39c12; color: white; border: none; border-radius: 4px; padding: 5px 15px; font-size: 0.85rem; } .btn-seleccionar:hover { background-color: #d68910; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-4 mb-5 px-4">
        
        <div class="text-center mb-4">
            <h2 class="page-title"><i class="fa-solid fa-truck-fast me-2"></i>Gestión de Proveedores</h2>
        </div>

        <div class="admin-card mx-auto mb-4" style="max-width: 850px;">
            <div class="row">
                <!-- Columna Izquierda -->
                <div class="col-md-6 pe-md-4">
                    <div class="mb-3 row align-items-center">
                        <label class="col-sm-4 col-form-label text-end fw-bold form-label-custom"><i class="fa-solid fa-hashtag me-1 text-muted"></i>Código:</label>
                        <div class="col-sm-8"><asp:TextBox ID="txtCod" runat="server" CssClass="form-control"></asp:TextBox></div>
                    </div>
                    <div class="mb-3 row align-items-center">
                        <label class="col-sm-4 col-form-label text-end fw-bold form-label-custom"><i class="fa-solid fa-building me-1 text-muted"></i>Nombre:</label>
                        <div class="col-sm-8"><asp:TextBox ID="txtNom" runat="server" CssClass="form-control"></asp:TextBox></div>
                    </div>
                    <div class="mb-3 row align-items-center">
                        <label class="col-sm-4 col-form-label text-end fw-bold form-label-custom"><i class="fa-solid fa-id-card-clip me-1 text-muted"></i>RUC:</label>
                        <div class="col-sm-8"><asp:TextBox ID="txtRuc" runat="server" CssClass="form-control"></asp:TextBox></div>
                    </div>
                    <div class="mb-3 row align-items-center">
                        <label class="col-sm-4 col-form-label text-end fw-bold form-label-custom"><i class="fa-solid fa-location-dot me-1 text-muted"></i>Dirección:</label>
                        <div class="col-sm-8"><asp:TextBox ID="txtDir" runat="server" CssClass="form-control"></asp:TextBox></div>
                    </div>
                </div>

                <!-- Columna Derecha -->
                <div class="col-md-6 ps-md-4">
                    <div class="mb-3 row align-items-center">
                        <label class="col-sm-4 col-form-label text-end fw-bold form-label-custom"><i class="fa-solid fa-phone me-1 text-muted"></i>Teléfono:</label>
                        <div class="col-sm-8"><asp:TextBox ID="txtTel" runat="server" CssClass="form-control"></asp:TextBox></div>
                    </div>
                    <div class="mb-3 row align-items-center">
                        <label class="col-sm-4 col-form-label text-end fw-bold form-label-custom"><i class="fa-regular fa-envelope me-1 text-muted"></i>Correo:</label>
                        <div class="col-sm-8"><asp:TextBox ID="txtCor" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox></div>
                    </div>
                    
                    <div class="mb-2 row align-items-center mt-4">
                        <div class="col-sm-8 offset-sm-4">
                            <div class="form-check mt-2 p-2 bg-light rounded border border-light-subtle text-center">
                                <asp:CheckBox ID="chkEst" runat="server" Text=" Proveedor Activo" CssClass="form-check-input ms-1 fw-bold text-success" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="d-flex justify-content-center flex-wrap gap-3 mb-5">
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn-action btn-nuevo" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn-action btn-registrar" OnClick="btnRegistrar_Click" />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn-action btn-actualizar" OnClick="btnActualizar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn-action btn-eliminar" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Quieres eliminar este proveedor?');" />
            <asp:Button ID="btnHabilitar" runat="server" Text="Habilitar" CssClass="btn-action btn-habilitar" OnClick="btnHabilitar_Click" />
        </div>
        
        <div class="table-responsive mx-auto" style="max-width: 1000px;">
            <asp:GridView ID="gvProveedor" runat="server" OnRowCommand="gvProveedor_RowCommand" AutoGenerateColumns="false" CssClass="table custom-table table-hover align-middle text-center" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="codigo" HeaderText="Cód" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="ruc" HeaderText="RUC" />
                    <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="correo" HeaderText="Correo" />

                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <span class='<%# Convert.ToBoolean(Eval("estado")) ? "badge bg-success" : "badge bg-danger" %>'>
                                <%# Convert.ToBoolean(Eval("estado")) ? "Activo" : "Inactivo" %>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:ButtonField Text="Seleccionar" CommandName="Seleccionar" ControlStyle-CssClass="btn-seleccionar" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>