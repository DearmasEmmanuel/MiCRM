<%@ Page Title="" Language="C#" MasterPageFile="~/Vendedor.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="MiCRM.Compra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container mt-5">
        <h1>Compra</h1>

        <!-- Sección para buscar y seleccionar proveedor -->
        <div class="mb-3">
            <label for="txtProveedor">Buscar Porveedor:</label>
            <asp:TextBox ID="txtProveedor" runat="server" CssClass="form-control" placeholder="Ingrese el nombre del Proveedor"></asp:TextBox>
            <asp:Button ID="btnBuscarProveedor" runat="server" Text="Buscar Proveedor" CssClass="btn btn-outline-primary" OnClick="btnBuscarProveedor_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-outline-primary" OnClick="btnCancelar_Click" />
        </div>

        <!-- GridView para mostrar resultados de búsqueda de proveedores -->
        <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvProveedores_SelectedIndexChanged" DataKeyNames="ProveedorID" CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="ProveedorID" HeaderText="ProveedorID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                <asp:BoundField DataField="Contacto" HeaderText="Contacto" />
                <asp:ButtonField ButtonType="Button" Text="Seleccionar" CommandName="Select" />
            </Columns>
        </asp:GridView>

        <!-- Detalles del Proveedor -->
        <h3>Detalles del Proveedor:</h3>
        <asp:FormView ID="fvProveedor" runat="server" CssClass="table table-striped" DefaultMode="ReadOnly">
            <ItemTemplate>
                <div>
                    <strong>Nombre:</strong>
                    <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                </div>
                <div>
                    <strong>Dirección:</strong>
                    <asp:Label ID="lblDireccion" runat="server" Text='<%# Eval("Direccion") %>'></asp:Label>
                </div>
                <div>
                    <strong>Contacto:</strong>
                    <asp:Label ID="lblContacto" runat="server" Text='<%# Eval("Contacto") %>'></asp:Label>
                </div>
            </ItemTemplate>
        </asp:FormView>

        <!-- Sección para agregar productos a la compra -->
        <div class="mt-3">
            <h3>Agregar Producto a la compra:</h3>
            <!-- Dropdown para seleccionar productos -->
            <div class="form-group">
                <label for="ddlProductos">Producto:</label>
                <asp:DropDownList ID="ddlProductos" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <!-- Cantidad de productos -->
            <div class="form-group">
                <label for="txtCantidad">Cantidad:</label>
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number" />
            </div>
            <!-- Botones para cargar la venta -->
            <asp:Button ID="btnCargarCompra" runat="server" Text="Cargar Compra" OnClick="btnCargarCompra_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnAgregarProductos" runat="server" Text="Agregar más productos" OnClick="btnAgregarProductos_Click" CssClass="btn btn-success" />
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </div>

        <!-- GridView para mostrar detalles de la venta -->
        <h3>Detalles de la Compra:</h3>

        <asp:GridView ID="gvDetallesCompra" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="ProductoID" HeaderText="Producto" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="PrecioCompra" HeaderText="Precio Unitario" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
                <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" />
            </Columns>
        </asp:GridView>

        <!-- Sección para el total de la venta -->
        <div class="mt-3">
            <h3>Total de la Compra:</h3>
            <asp:Label ID="lblTotalCompra" runat="server" CssClass="h4 text-success"></asp:Label>
        </div>

        <!-- Botón para finalizar la venta -->
        <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" OnClick="btnFinalizarCompra_Click" CssClass="btn btn-danger mt-3" />

    </div>


</asp:Content>
