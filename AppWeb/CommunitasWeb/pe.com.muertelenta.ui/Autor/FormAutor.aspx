<%@ Page Title="Communitas Libros | Autores" Language="C#" MasterPageFile="~/templates/Plantilla.Master" AutoEventWireup="true" CodeBehind="FormAutor.aspx.cs" Inherits="pe.com.communitas.ui.autor.FormAutor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Tipografía y Título */
        .page-title { font-family: 'Playfair Display', serif; color: #2c3e50; font-weight: 700; text-transform: uppercase; letter-spacing: 1px; border-bottom: 2px solid #d35400; display: inline-block; padding-bottom: 10px; }
        
        /* Tarjeta de Formulario */
        .admin-card { background-color: #ffffff; border: 1px solid #eae1d5; border-radius: 12px; box-shadow: 0 10px 30px rgba(0,0,0,0.05); padding: 30px 20px; }
        
        /* Etiquetas y Campos */
        .form-label-custom { color: #4a4a4a; font-size: 0.95rem; font-family: 'Lora', serif; }
        .form-control { border: 1px solid #dcd3c6; border-radius: 6px; background-color: #fdfbf7; font-family: 'Lora', serif; }
        .form-control:focus { border-color: #d35400; box-shadow: 0 0 0 0.2rem rgba(211, 84, 0, 0.15); }
        
        /* Botones de Acción Elegantes */
        .btn-action { font-family: 'Lora', serif; font-weight: 600; padding: 10px 24px; border-radius: 6px; transition: all 0.3s; text-transform: uppercase; font-size: 0.85rem; }
        .btn-nuevo { background-color: #7f8c8d; color: white; border: none; } .btn-nuevo:hover { background-color: #636e72; color: white; transform: translateY(-2px); box-shadow: 0 4px 10px rgba(127,140,141,0.3); }
        .btn-registrar { background-color: #2c3e50; color: white; border: none; } .btn-registrar:hover { background-color: #1a252f; color: white; transform: translateY(-2px); box-shadow: 0 4px 10px rgba(44,62,80,0.3); }
        .btn-actualizar { background-color: #d35400; color: white; border: none; } .btn-actualizar:hover { background-color: #a84300; color: white; transform: translateY(-2px); box-shadow: 0 4px 10px rgba(211,84,0,0.3); }
        .btn-eliminar { background-color: #c0392b; color: white; border: none; } .btn-eliminar:hover { background-color: #962d22; color: white; transform: translateY(-2px); box-shadow: 0 4px 10px rgba(192,57,43,0.3); }
        .btn-habilitar { background-color: #27ae60; color: white; border: none; } .btn-habilitar:hover { background-color: #1e8449; color: white; transform: translateY(-2px); box-shadow: 0 4px 10px rgba(39,174,96,0.3); }
        
        /* Tabla GridView */
        .custom-table { background-color: white; border: 1px solid #eae1d5; border-radius: 8px; box-shadow: 0 4px 15px rgba(0,0,0,0.03); overflow: hidden; }
        .custom-table thead th { background-color: #2c3e50 !important; color: #ffffff !important; font-family: 'Playfair Display', serif; font-weight: 600; border: none; padding: 15px; }
        .custom-table tbody tr:hover { background-color: #f9efe1 !important; }
        .custom-table td { vertical-align: middle; color: #555; border-bottom: 1px solid #eae1d5; padding: 12px; font-family: 'Lora', serif; }
        .btn-seleccionar { background-color: #f39c12; color: white; border: none; border-radius: 4px; padding: 5px 15px; font-size: 0.85rem; } .btn-seleccionar:hover { background-color: #d68910; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container mt-4 mb-5">
        
        <div class="text-center mb-4">
            <h2 class="page-title"><i class="fa-solid fa-pen-nib me-2"></i>Gestión de Autores</h2>
        </div>

        <div class="admin-card mx-auto mb-4" style="max-width: 600px;">
            <div class="card-body">
                
                <div class="mb-3 row align-items-center">
                    <label class="col-sm-3 col-form-label text-end fw-bold form-label-custom">
                        <asp:Label ID="Label3" runat="server" Text="Código:"></asp:Label>
                    </label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtCod" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="mb-3 row align-items-center">
                    <label class="col-sm-3 col-form-label text-end fw-bold form-label-custom">
                        <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
                    </label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtNom" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="mb-3 row align-items-center">
                    <label class="col-sm-3 col-form-label text-end fw-bold form-label-custom">
                        <asp:Label ID="Label4" runat="server" Text="Apellidos:"></asp:Label>
                    </label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtApe" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="mb-3 row align-items-center">
                    <label class="col-sm-3 col-form-label text-end fw-bold form-label-custom">
                        <asp:Label ID="Label5" runat="server" Text="Nacionalidad:"></asp:Label>
                    </label>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="ddlPais" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>

                <div class="mb-2 row align-items-center">
                    <label class="col-sm-3 col-form-label text-end fw-bold form-label-custom">
                        <asp:Label ID="Label2" runat="server" Text="Estado:"></asp:Label>
                    </label>
                    <div class="col-sm-9">
                        <div class="form-check mt-2">
                            <asp:CheckBox ID="chkEst" runat="server" Text=" Autor Activo" CssClass="form-check-input ms-1 fw-bold text-success" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
        
        <!-- Botones con diseño elegante de biblioteca -->
        <div class="d-flex justify-content-center flex-wrap gap-3 mb-5">
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn-action btn-nuevo" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn-action btn-registrar" OnClick="btnRegistrar_Click" />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn-action btn-actualizar" OnClick="btnActualizar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn-action btn-eliminar" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Quieres eliminar este autor?');" />
            <asp:Button ID="btnHabilitar" runat="server" Text="Habilitar" CssClass="btn-action btn-habilitar" OnClick="btnHabilitar_Click" />
        </div>
        
        <!-- Tabla Centrada -->
        <div class="table-responsive mx-auto" style="max-width: 850px;">
            
            <asp:GridView ID="gvAutor" runat="server" OnRowCommand="gvAutor_RowCommand" AutoGenerateColumns="false" CssClass="table custom-table table-hover align-middle text-center" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="codigo" HeaderText="Cód" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                    <asp:BoundField DataField="pais.nombre" HeaderText="País" />

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