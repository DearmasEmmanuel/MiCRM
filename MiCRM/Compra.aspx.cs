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
    public partial class Compras : System.Web.UI.Page
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
            if (!(txtCantidad.Text.Equals("")))
            {
                // Lógica para cargar la compra con el producto seleccionado
                int productoID = Convert.ToInt32(ddlProductos.SelectedValue);
                int cantidad = Convert.ToInt32(txtCantidad.Text);

                // Agregar el detalle de la compra
                CompraBusiness.AgregarDetalleCompra(productoID, cantidad);

                // Actualizar el GridView de detalles de la compra
                ActualizarGridViewDetallesCompra();

                // Calcular y mostrar el total de la compra
                CalcularTotalCompra();
            }
        }
        protected void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            // Obtener los valores seleccionados antes de limpiar los campos
            if (!(txtCantidad.Text is null))
            {
                int productoID = Convert.ToInt32(ddlProductos.SelectedValue);
                int cantidad = Convert.ToInt32(txtCantidad.Text);

                // Limpiar los campos después de obtener los valores
                ddlProductos.SelectedIndex = 0; // Restablecer el DropDownList
                txtCantidad.Text = String.Empty; // Limpiar el campo de cantidad

                // Validar la cantidad antes de agregar el detalle de la compra
                if (cantidad > 0)
                {
                    // Agregar el detalle de la compra
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
        }
        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            // Generamos la compra
            int proveedor;

            // Accede a los controles dentro del ItemTemplate
            Label lblProveedor = (Label)fvProveedor.FindControl("lblProveedorId");

            // Obtiene los valores de los controles
            proveedor = Convert.ToInt32(lblProveedor.Text);

            // Generamos la compra en la DB

            Compra compra = new Compra()
            {
                ProveedorID = proveedor
            };

            int compraId = CompraBusiness.CargarCompra(compra);


            // Lógica para finalizar la compra
            foreach (GridViewRow row in gvDetallesCompra.Rows)
            {
                // Accede a los valores de las celdas en cada fila
                int productoID = Convert.ToInt32((Label)row.FindControl("lblProductoID"));
                int cantidad = Convert.ToInt32((Label)row.FindControl("lblCantidad"));
                decimal precioCompra = Convert.ToInt32((Label)row.FindControl("lblPrecioCompra"));
                //string subtotal = ((Label)row.FindControl("lblSubtotal")).Text;

                // Aquí puedes realizar operaciones o validaciones con los datos si es necesario
                DetalleCompras detallecompra = new DetalleCompras()
                {
                    CompraID = compraId,
                    ProductoID = productoID,
                    Cantidad = cantidad,
                    PrecioCompra = precioCompra
                };
                DetalleCompraBusiness.AgregarDetalleCompra(detallecompra);
            }

        }
        private void InicializarGridViewDetallesCompra()
        {
            // Inicializar el GridView de detalles de la compra
            gvDetallesCompra.DataSource = new List<DetalleCompras>();
            gvDetallesCompra.DataBind();
        }
        private void ActualizarGridViewDetallesCompra()
        {
            // Actualizar el GridView de detalles de la compra
            List<DetalleCompras> detallesCompra = CompraBusiness.ObtenerDetallesCompra();
            gvDetallesCompra.DataSource = detallesCompra;
            gvDetallesCompra.DataBind();
        }
        private void CalcularTotalCompra()
        {
            // Calcular y mostrar el total de la compra
            decimal totalCompra = CompraBusiness.CalcularTotalCompra();
            lblTotalCompra.Text = $"Total: {totalCompra:C}";
        }

        protected void gvDetallesCompra_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Obtén el índice de la fila que se está eliminando
            int rowIndex = e.RowIndex;

            // Accede a los datos de esa fila (por ejemplo, el ID del producto)
            string productoID = gvDetallesCompra.DataKeys[rowIndex]["ProductoID"].ToString();

        }
    }
}