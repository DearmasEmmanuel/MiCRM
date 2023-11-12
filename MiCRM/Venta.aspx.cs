using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Business;
using Dominio;

namespace MiCRM
{
    public partial class Ventas : System.Web.UI.Page
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

            fvCliente.DataSource = new List<Cliente> { clienteSeleccionado };
            fvCliente.DataBind();
            gvClientes.Visible = false;

        }

        protected void btnCargarVenta_Click(object sender, EventArgs e)
        {
            // Lógica para cargar la venta con el producto seleccionado
            int productoID = Convert.ToInt32(ddlProductos.SelectedValue);
            int cantidad = Convert.ToInt32(txtCantidad.Text);

            // Agregar el detalle de la venta
            VentaBusiness.AgregarDetalleVenta(productoID, cantidad);

            // Actualizar el GridView de detalles de la venta
            ActualizarGridViewDetallesVenta();

            // Calcular y mostrar el total de la venta
            CalcularTotalVenta();
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
            // Lógica para finalizar la venta
            // Puedes implementar esta lógica según tus necesidades
        }

        private void InicializarGridViewDetallesVenta()
        {
            // Inicializar el GridView de detalles de la venta
            gvDetallesVenta.DataSource = new List<DetalleVenta>();
            gvDetallesVenta.DataBind();
        }

        private void ActualizarGridViewDetallesVenta()
        {
            // Actualizar el GridView de detalles de la venta
            List<DetalleVenta> detallesVenta = VentaBusiness.ObtenerDetallesVenta();
            gvDetallesVenta.DataSource = detallesVenta;
            gvDetallesVenta.DataBind();
        }

        private void CalcularTotalVenta()
        {
            // Calcular y mostrar el total de la venta
            decimal totalVenta = VentaBusiness.CalcularTotalVenta();
            lblTotalVenta.Text = $"Total: {totalVenta:C}";
        }
    }
}
