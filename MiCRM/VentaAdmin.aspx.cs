using Business;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiCRM
{
    public partial class VentaAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar lista de productos en el DropDownList
                ddlProductos.DataSource = ProductoBusiness.List();
                ddlProductos.DataTextField = "Nombre";
                ddlProductos.DataValueField = "ProductoID";
                ddlProductos.DataBind();

                // Inicializar GridView de detalles de la venta

                InicializarGridViewDetallesVenta();
            }
        }
        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string nombreCliente = txtCliente.Text;
            List<Cliente> clientes = ClienteBusiness.BuscarClientesPorNombre(nombreCliente);
            gvClientes.DataSource = clientes;
            gvClientes.DataBind();
            gvClientes.Visible = true;
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int clienteID = (int)gvClientes.SelectedDataKey.Value;
            Cliente clienteSeleccionado = ClienteBusiness.ObtenerClientePorID(clienteID);
            Session["ClienteSeleccionado"] = clienteSeleccionado;
            fvCliente.DataSource = new List<Cliente> { clienteSeleccionado };
            fvCliente.DataBind();
            gvClientes.Visible = false;

        }



        protected void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            // Obtener los valores seleccionados antes de limpiar los campos
            int productoID = Convert.ToInt32(ddlProductos.SelectedValue);
            int cantidad = Convert.ToInt32(txtCantidad.Text);

            // Limpiar los campos después de obtener los valores
            ddlProductos.SelectedIndex = 0; // Restablecer el DropDownList
            txtCantidad.Text = string.Empty; // Limpiar el campo de cantidad

            // Validar la cantidad antes de agregar el detalle de la venta
            if (cantidad > 0)
            {
                // Agregar el detalle de la venta
                VentaBusiness.AgregarDetalleVenta(productoID, cantidad);
                ActualizarGridViewDetallesVenta();
                CalcularTotalVenta();

                // Puedes usar un control de Label o mostrar mensajes de alerta según tu preferencia
                lblMensaje.Text = "Productos agregados exitosamente.";
            }
            else
            {
                lblMensaje.Text = "La cantidad debe ser mayor que cero.";
            }
        }


        protected void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            Cliente clienteSeleccionado = Session["ClienteSeleccionado"] as Cliente;

            if (clienteSeleccionado != null && GridViewDetallesVentaNoVacio()) // Comprobamos si la grilla de detalles de venta no está vacía
            {
                // Crear una nueva venta
                Venta venta = new Venta
                {
                    ClienteID = clienteSeleccionado.ClienteID,
                    // Otras propiedades de la venta...
                };

                // Generar la venta en la base de datos
                int ventaID = VentaBusiness.CargarVenta(venta);

                // Lógica para finalizar la venta
                foreach (GridViewRow row in gvDetallesVenta.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        string productoId = row.Cells[1].Text; // Obtener el ProductoID de la primera celda
                        string cantidad = row.Cells[2].Text; // Obtener la Cantidad de la segunda celda
                        string precioVenta = row.Cells[3].Text; // Obtener el Precio de Compra de la tercera celda
                        string subtotal = row.Cells[4].Text; // Obtener el Subtotal de la cuarta celda

                        // Crear un nuevo detalle de venta con los datos de la fila
                        DetalleVentas detalle = new DetalleVentas
                        {
                            ProductoID = int.Parse(productoId),
                            VentaID = ventaID,
                            PrecioVenta = decimal.Parse(precioVenta),
                            Cantidad = int.Parse(cantidad),
                            Subtotal = decimal.Parse(subtotal)
                        };


                        DetalleVentaBusiness.AgregarDetalleVenta(detalle);
                    }
                }
                // Limpiar y actualizar la GridView de detalles de venta
                BorrarGridViewDetallesVenta();
                InicializarGridViewDetallesVenta();
                CalcularTotalVenta();
            }
        }





        protected bool GridViewDetallesVentaNoVacio()
        {
            return gvDetallesVenta.Rows.Count > 0;
        }


        private void InicializarGridViewDetallesVenta()
        {
            // Inicializar el GridView de detalles de la venta
            gvDetallesVenta.DataSource = new List<DetalleVentas>();
            gvDetallesVenta.DataBind();
        }

        private void ActualizarGridViewDetallesVenta()
        {
            // Actualizar el GridView de detalles de la venta
            List<DetalleVentas> detallesVenta = VentaBusiness.ObtenerDetallesVenta();
            gvDetallesVenta.DataSource = detallesVenta;
            gvDetallesVenta.DataBind();
        }

        private void CalcularTotalVenta()
        {
            // Calcular y mostrar el total de la venta
            decimal totalVenta = VentaBusiness.CalcularTotalVenta();
            lblTotalVenta.Text = $"Total: {totalVenta:C}";
        }
        protected string ObtenerNombreProducto(int productoID)
        {
            // Crear una instancia de ProductoBusiness
            ProductoBusiness productoBusiness = new ProductoBusiness();

            // Lógica para obtener el nombre del producto basándote en su ID
            string nombreProducto = productoBusiness.ObtenerNombreProducto(productoID);

            return !string.IsNullOrEmpty(nombreProducto) ? nombreProducto : "Producto no encontrado";
        }

        protected void gvDetallesVenta_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productoID = -1;

            if (e.RowIndex >= 0 && e.RowIndex < gvDetallesVenta.Rows.Count)
            {

                productoID = Convert.ToInt32(gvDetallesVenta.DataKeys[e.RowIndex].Values["ProductoID"]);



                VentaBusiness.EliminarDetalleVenta(productoID);


                ActualizarGridViewDetallesVenta();


                CalcularTotalVenta();
            }
        }

        private void BorrarGridViewDetallesVenta()
        {
            // Limpia el GridView de detalles de la venta
            List<DetalleVentas> detallesVenta = VentaBusiness.ObtenerDetallesVenta();
            detallesVenta.Clear(); // Borra todos los elementos de la lista

            gvDetallesVenta.DataSource = detallesVenta;
            gvDetallesVenta.DataBind();
        }

    }
}
