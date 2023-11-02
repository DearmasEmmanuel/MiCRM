<%@ Page Title="" Language="C#" MasterPageFile="~/Vendedor.Master" AutoEventWireup="true" CodeBehind="Vendedor.aspx.cs" Inherits="MiCRM.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h1 class="mb-4">Bienvenido <asp:Label ID="lblUsuario" runat="server" Text="Label"></asp:Label></h1>
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header bg-primary text-white">
                        Datos del Vendedor
                    </div>
                    <div class="card-body">
                        <!-- Contenido del perfil del vendedor aquí -->
                       
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header bg-success text-white">
                        Estadísticas de Venta
                    </div>
                    <div class="card-body">
                        <!-- Estadísticas de venta aquí -->
                    </div>
                </div>
            </div>
        </div>










    <div class="form-group">
        <label for="txtClienteNombre">Nombre del Cliente:</label>
        <asp:TextBox ID="txtClienteNombre" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <!-- Otros campos del cliente (dirección, contacto, etc.) -->

    <!-- Botón para cargar el cliente -->
    <asp:Button ID="btnCargarCliente" runat="server" Text="Cargar Cliente" CssClass="btn btn-primary" OnClick="btnCargarCliente_Click" />
    <hr>

    <!-- Formulario para realizar una compra -->
    <div class="form-group">
        <label for="ddlClientes">Seleccione un Cliente:</label>
        <asp:DropDownList ID="ddlClientes" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <!-- Agregar otros campos de compra (productos, cantidad, etc.) -->

    <!-- Botón para realizar la compra -->
    <asp:Button ID="btnRealizarCompra" runat="server" Text="Realizar Compra" CssClass="btn btn-success" OnClick="btnRealizarCompra_Click" />



    <hr>

    <!-- Consulta de Stock -->
    <!-- Utiliza un GridView o un control similar para mostrar el stock de productos -->
    <div class="container mt-5">
    <h1>Listado de Productos</h1>
    <div id="productosContainer">
    <asp:GridView ID="gvStock" runat="server" CssClass="table table-bordered">
        
    <Columns>
        <asp:BoundField DataField="Nombre" HeaderText="Nombre del Producto" />
        <asp:BoundField DataField="StockActual" HeaderText="Stock Actual" />
        <asp:BoundField DataField="StockMinimo" HeaderText="Stock Mínimo" />
       
    </Columns>


    </asp:GridView>
   </div>
</div>














    </div>

    
    

</asp:Content>
