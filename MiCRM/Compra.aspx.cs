using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Dominio;

namespace MiCRM
{
    public partial class Compra : System.Web.UI.Page
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

                // Inicializar GridView de detalles de la compra
                InicializarGridViewDetallesCompra();
            }
        }
        protected void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            string nombreProveedor = txtProveedor.Text;
            List<Proveedor> proveedor = ProveedorBusiness.BuscarProveedorPorNombre(nombreProveedor);
            gvProveedores.DataSource = proveedor;
            gvProveedores.DataBind();
            gvProveedores.Visible = true;
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (gvProveedores.Visible)
            gvProveedores.Visible = false;
        }
        protected void gvProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int proveedorID = (int)gvProveedores.SelectedDataKey.Value;
            Proveedor proveedorSeleccionado = ProveedorBusiness.ObtenerProveedorPorID(proveedorID);

            fvProveedor.DataSource = new List<Proveedor> { proveedorSeleccionado };
            fvProveedor.DataBind();
            gvProveedores.Visible = false;
        }
        protected void btnCargarCompra_Click(object sender, EventArgs e)
        {
            // Lógica para cargar la venta con el producto seleccionado
            int productoID = Convert.ToInt32(ddlProductos.SelectedValue);
            int cantidad = Convert.ToInt32(txtCantidad.Text);

            // Agregar el detalle de la venta
            CompraBusiness.AgregarDetalleCompra(productoID, cantidad);

            // Actualizar el GridView de detalles de la venta
            ActualizarGridViewDetallesCompra();

            // Calcular y mostrar el total de la venta
            CalcularTotalCompra();
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
                CompraBusiness.AgregarDetalleCompra(productoID, cantidad);
                ActualizarGridViewDetallesCompra();
                CalcularTotalCompra();

                // Puedes usar un control de Label o mostrar mensajes de alerta según tu preferencia
                lblMensaje.Text = "Productos agregados exitosamente.";
            }
            else
            {
                lblMensaje.Text = "La cantidad debe ser mayor que cero.";
            }
        }
        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            // Lógica para finalizar la venta
            // Puedes implementar esta lógica según tus necesidades
        }
        private void InicializarGridViewDetallesCompra()
        {
            // Inicializar el GridView de detalles de la compra
            gvDetallesCompra.DataSource = new List<DetalleCompras>();
            gvDetallesCompra.DataBind();
        }
        private void ActualizarGridViewDetallesCompra()
        {
            // Actualizar el GridView de detalles de la venta
            List<DetalleCompras> detallesCompra = CompraBusiness.ObtenerDetallesCompra();
            gvDetallesCompra.DataSource = detallesCompra;
            gvDetallesCompra.DataBind();
        }
        private void CalcularTotalCompra()
        {
            // Calcular y mostrar el total de la venta
            decimal totalVenta = VentaBusiness.CalcularTotalVenta();
            lblTotalCompra.Text = $"Total: {totalVenta:C}";
        }
    }
}