<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="VentaAdmin.aspx.cs" Inherits="MiCRM.VentaAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container mt-5">
       <h1>Ventas</h1>

       <!-- Sección para buscar y seleccionar cliente -->
       <div class="mb-3">
           <label for="txtCliente">Buscar Cliente:</label>
           <asp:TextBox ID="txtCliente" runat="server" CssClass="form-control" placeholder="Ingrese el nombre del cliente"></asp:TextBox>
           <asp:Button ID="btnBuscarCliente" runat="server" Text="Buscar Cliente" CssClass="btn btn-outline-primary" OnClick="btnBuscarCliente_Click" />
       </div>

       <!-- GridView para mostrar resultados de búsqueda de clientes -->
       <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvClientes_SelectedIndexChanged" DataKeyNames="ClienteID" CssClass="table table-striped">
           <Columns>
               <asp:BoundField DataField="ClienteID" HeaderText="ClienteID" />
               <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
               <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
               <asp:BoundField DataField="Contacto" HeaderText="Contacto" />
               <asp:ButtonField ButtonType="Button" Text="Seleccionar" CommandName="Select" />
           </Columns>
       </asp:GridView>

       <!-- Detalles del Cliente -->
       <h3>Detalles del Cliente:</h3>
       <asp:FormView ID="fvCliente" runat="server" CssClass="table table-striped" DefaultMode="ReadOnly">
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

       <!-- Sección para agregar productos a la venta -->
       <div class="mt-3">
           <h3>Agregar Producto a la Venta:</h3>
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
           
           <asp:Button ID="btnAgregarProductos" runat="server" Text="Agregar más productos" OnClick="btnAgregarProductos_Click" CssClass="btn btn-success" />
           <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
       </div>

       <!-- GridView para mostrar detalles de la venta -->
       <h3>Detalles de la Venta:</h3>

       <asp:GridView ID="gvDetallesVenta" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductoID" CssClass="table table-striped" OnRowDeleting="gvDetallesVenta_RowDeleting">
           <Columns>
               
               <asp:TemplateField HeaderText="Producto">
    <ItemTemplate>
      
        <%# ObtenerNombreProducto(Convert.ToInt32(Eval("ProductoID"))) %>
    </ItemTemplate>
</asp:TemplateField>


               <asp:BoundField DataField="ProductoID" HeaderText="ProductoID" />

               <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
               <asp:BoundField DataField="PrecioVenta" HeaderText="Precio Unitario" />
               <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
               <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" />
           </Columns>
       </asp:GridView>


       <!-- Sección para el total de la venta -->
       <div class="mt-3">
           <h3>Total de la Venta:</h3>
           <asp:Label ID="lblTotalVenta" runat="server" CssClass="h4 text-success"></asp:Label>
       </div>

       <!-- Botón para finalizar la venta -->
       <asp:Button ID="btnFinalizarVenta" runat="server" Text="Finalizar Venta" OnClick="btnFinalizarVenta_Click" CssClass="btn btn-danger mt-3" />

   </div>
</asp:Content>
