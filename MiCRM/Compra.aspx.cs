using System;
using System.Collections.Generic;
using System.Data;
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
        protected void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            // Obtener los valores seleccionados antes de limpiar los campos
            if (!(txtCantidad.Text.Equals("")))
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
            if (GridViewDetallesCompraVacio()) //Comprobamos si la grilla esta vacia
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

                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        string productoId = row.Cells[0].Text; // Obtener el ProductoID de la primera celda
                        string cantidad = row.Cells[1].Text; // Obtener la Cantidad de la segunda celda
                        string precioCompra = row.Cells[2].Text; // Obtener el Precio de Compra de la tercera celda
                        string subtotal = row.Cells[3].Text; // Obtener el Subtotal de la cuarta celda

                        DetalleCompras detallecompra = new DetalleCompras()
                        {
                            CompraID = compraId,
                            ProductoID = int.Parse(productoId),
                            Cantidad = int.Parse(cantidad),
                            PrecioCompra = decimal.Parse(precioCompra),
                            Subtotal = decimal.Parse(subtotal)
                        };
                        DetalleCompraBusiness.AgregarDetalleCompra(detallecompra);
                        ProductoBusiness.SumarStockActual(int.Parse(productoId), int.Parse(cantidad));
                    }
                }
                BorrarGridViewDetallesCompra();
                InicializarGridViewDetallesCompra();
                CalcularTotalCompra();
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
        private void BorrarGridViewDetallesCompra()
        {
            // Borrar el GridView de detalles de la compra
            List<DetalleCompras> detallesCompra = CompraBusiness.ObtenerDetallesCompra();
            foreach (GridViewRow row in gvDetallesCompra.Rows)
            {
                detallesCompra.RemoveAt(0); //Borramos el row 0 ya que se actualiza este con cada vuelta del foreach
            }
            gvDetallesCompra.DataSource = detallesCompra;
            gvDetallesCompra.DataBind();
        }
        private bool GridViewDetallesCompraVacio()
        {
            // Comprobar el GridView de detalles de la compra si esta vacio
            List<DetalleCompras> detallesCompra = CompraBusiness.ObtenerDetallesCompra();
            foreach (GridViewRow row in gvDetallesCompra.Rows)
            {
                return true;
            }
            return false;
        }
        private void CalcularTotalCompra()
        {
            // Calcular y mostrar el total de la compra
            decimal totalCompra = CompraBusiness.CalcularTotalCompra();
            lblTotalCompra.Text = $"Total: {totalCompra:C}";
        }
        protected void gvDetallesCompra_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex; // Obtener el índice de la fila que se está eliminando

            List<DetalleCompras> detallesCompra = CompraBusiness.ObtenerDetallesCompra();

            // Aquí puedes acceder a los datos asociados a esa fila en tu fuente de datos
            // Por ejemplo, si tu GridView está vinculado a una lista de objetos llamada 'detallesCompraList':
            detallesCompra.RemoveAt(rowIndex); // Eliminar el elemento de la lista en el índice específico

            // Volver a enlazar los datos al GridView después de eliminar la fila
            gvDetallesCompra.DataSource = detallesCompra; // Reasignar la lista modificada como origen de datos
            gvDetallesCompra.DataBind();

            CalcularTotalCompra();
        }
    }
}