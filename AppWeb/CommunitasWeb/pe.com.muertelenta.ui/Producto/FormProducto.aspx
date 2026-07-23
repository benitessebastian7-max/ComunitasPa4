<%@ Page Title="Communitas Libros | Inventario" Language="C#" MasterPageFile="~/templates/Plantilla.Master" AutoEventWireup="true" CodeBehind="FormProducto.aspx.cs" Inherits="pe.com.communitas.ui.producto.FormProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .page-title {
            font-family: 'Playfair Display', serif;
            color: #2c3e50;
            font-weight: 700;
            text-transform: uppercase;
            letter-spacing: 1px;
            border-bottom: 2px solid #d35400;
            display: inline-block;
            padding-bottom: 10px;
        }

        .admin-card {
            background-color: #ffffff;
            border: 1px solid #eae1d5;
            border-radius: 12px;
            box-shadow: 0 10px 30px rgba(0,0,0,0.05);
            padding: 30px 20px;
        }

        .form-label {
            color: #4a4a4a;
            font-weight: 600;
            font-size: 0.95rem;
            font-family: 'Lora', serif;
        }

        .form-control, .form-select {
            border: 1px solid #dcd3c6;
            border-radius: 6px;
            background-color: #fdfbf7;
            transition: all 0.3s ease;
            font-family: 'Lora', serif;
        }

        .form-control:focus, .form-select:focus {
            border-color: #d35400;
            box-shadow: 0 0 0 0.2rem rgba(211, 84, 0, 0.15);
            background-color: #ffffff;
        }

        .btn-action {
            font-family: 'Lora', serif;
            font-weight: 600;
            padding: 10px 24px;
            border-radius: 6px;
            transition: all 0.3s;
            text-transform: uppercase;
            font-size: 0.85rem;
            letter-spacing: 0.5px;
        }
        
        .btn-nuevo { background-color: #7f8c8d; color: white; border: none; }
        .btn-nuevo:hover { background-color: #636e72; color: white; transform: translateY(-2px); }
        
        .btn-registrar { background-color: #2c3e50; color: white; border: none; }
        .btn-registrar:hover { background-color: #1a252f; color: white; transform: translateY(-2px); }
        
        .btn-actualizar { background-color: #d35400; color: white; border: none; }
        .btn-actualizar:hover { background-color: #a84300; color: white; transform: translateY(-2px); }
        
        .btn-eliminar { background-color: #c0392b; color: white; border: none; }
        .btn-eliminar:hover { background-color: #962d22; color: white; transform: translateY(-2px); }
        
        .btn-habilitar { background-color: #27ae60; color: white; border: none; }
        .btn-habilitar:hover { background-color: #1e8449; color: white; transform: translateY(-2px); }

        .custom-table {
            background-color: white;
            border: 1px solid #eae1d5;
            border-radius: 8px;
            overflow: hidden;
            box-shadow: 0 4px 15px rgba(0,0,0,0.03);
        }
        
        .custom-table thead th {
            background-color: #2c3e50 !important;
            color: #ffffff !important;
            font-family: 'Playfair Display', serif;
            font-weight: 600;
            border: none;
            padding: 15px;
            letter-spacing: 0.5px;
        }
        
        .custom-table tbody tr:hover { background-color: #f9efe1 !important; }
        .custom-table td { vertical-align: middle; color: #555; border-bottom: 1px solid #eae1d5; padding: 12px; }

        .custom-table .btn-seleccionar {
            background-color: #f39c12; color: white; border: none; border-radius: 4px; padding: 5px 15px; font-size: 0.85rem; transition: background-color 0.2s;
        }
        .custom-table .btn-seleccionar:hover { background-color: #d68910; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-2 px-4">
        
        <div class="text-center mb-5">
            <h2 class="page-title"><i class="fa-solid fa-swatchbook me-2"></i>Inventario de Libros</h2>
        </div>

        <div class="admin-card mx-auto mb-5">
            <div class="row">
                <!-- Columna 1: Información Principal -->
                <div class="col-md-4">
                    <div class="mb-3">
                        <label class="form-label"><i class="fa-solid fa-hashtag me-1 text-muted"></i>Código:</label>
                        <asp:TextBox ID="txtCod" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label class="form-label"><i class="fa-solid fa-barcode me-1 text-muted"></i>ISBN:</label>
                        <asp:TextBox ID="txtIsbn" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label class="form-label"><i class="fa-solid fa-book-open me-1 text-muted"></i>Título:</label>
                        <asp:TextBox ID="txtTit" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label class="form-label"><i class="fa-solid fa-align-left me-1 text-muted"></i>Descripción:</label>
                        <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                    </div>
                </div>

                <!-- Columna 2: Precios y Fechas -->
                <div class="col-md-4">
                    <div class="mb-3">
                        <label class="form-label"><i class="fa-solid fa-file-invoice-dollar me-1 text-muted"></i>Precio Compra (S/):</label>
                        <asp:TextBox ID="txtPreCom" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label class="form-label"><i class="fa-solid fa-tag me-1 text-muted"></i>Precio Venta (S/):</label>
                        <asp:TextBox ID="txtPreVen" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label class="form-label"><i class="fa-regular fa-calendar-alt me-1 text-muted"></i>Fecha Publicación:</label>
                        <asp:TextBox ID="txtFecPub" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <div class="form-check mt-4 p-3 bg-light rounded border border-light-subtle">
                            <asp:CheckBox ID="chkEst" runat="server" Text=" Producto Disponible" CssClass="form-check-input ms-1 fw-bold text-success"/>
                        </div>
                    </div>
                </div>

                <!-- Columna 3: Clasificación e Inventario -->
                <div class="col-md-4">
                    <div class="mb-3">
                        <label class="form-label"><i class="fa-solid fa-bookmark me-1 text-muted"></i>Categoría:</label>
                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label class="form-label"><i class="fa-solid fa-building me-1 text-muted"></i>Editorial:</label>
                        <asp:DropDownList ID="ddlEditorial" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label class="form-label"><i class="fa-solid fa-truck-fast me-1 text-muted"></i>Proveedor:</label>
                        <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>

        <div class="d-flex justify-content-center flex-wrap gap-3 mb-5">
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn-action btn-nuevo" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn-action btn-registrar" OnClick="btnRegistrar_Click" />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn-action btn-actualizar" OnClick="btnActualizar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn-action btn-eliminar" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Estás seguro de eliminar este libro del inventario?');" />
            <asp:Button ID="btnHabilitar" runat="server" Text="Habilitar" CssClass="btn-action btn-habilitar" OnClick="btnHabilitar_Click" />
        </div>
        
        <div class="table-responsive mb-5">
            <asp:GridView ID="gvProducto" runat="server" OnRowCommand="gvProducto_RowCommand" AutoGenerateColumns="false" CssClass="table custom-table table-hover align-middle text-center" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="codigo" HeaderText="Cód" />
                    <asp:BoundField DataField="isbn" HeaderText="ISBN" />
                    <asp:BoundField DataField="titulo" HeaderText="Título" />
                    <asp:BoundField DataField="precioVenta" HeaderText="Precio Venta" DataFormatString="{0:C2}" />
                    <asp:BoundField DataField="categoria.nombre" HeaderText="Categoría" />
                    <asp:BoundField DataField="editorial.nombre" HeaderText="Editorial" />
                    
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