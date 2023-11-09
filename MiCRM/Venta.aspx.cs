using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiCRM
{
    public partial class Venta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Carga la lista de clientes en el DropDownList
                ddlClientes.DataSource = ClienteBusiness.List();
                ddlClientes.DataTextField = "Nombre";
                ddlClientes.DataValueField = "ClienteID";
                ddlClientes.DataBind();

                // Carga la lista de productos en el DropDownList
                ddlProductos.DataSource = ProductoBusiness.List();
                ddlProductos.DataTextField = "Nombre";
                ddlProductos.DataValueField = "ProductoID";
                ddlProductos.DataBind();
            }
        }

        protected void btnCargarVenta_Click(object sender, EventArgs e)
        {
            int clienteID = Convert.ToInt32(ddlClientes.SelectedValue);
            int productoID = Convert.ToInt32(ddlProductos.SelectedValue);
            int cantidad = Convert.ToInt32(txtCantidad.Text);

            // Realiza la lógica para cargar la venta con los datos seleccionados
            // Puedes llamar a un método de negocio para realizar esta acción.
            Venta venta = new Venta
            {
                //ClienteID = clienteID,
                //ProductoID = productoID,
                //Cantidad = cantidad
            };

            // Llama a un método de negocio para cargar la venta
            //VentaBusiness.CargarVenta(venta);

            // Puedes redirigir a una página de confirmación o a la lista de ventas
            Response.Redirect("Ventas.aspx");
        }

        protected void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            int clienteID = Convert.ToInt32(ddlClientes.SelectedValue);
            int productoID = Convert.ToInt32(ddlProductos.SelectedValue);
            int cantidad = Convert.ToInt32(txtCantidad.Text);


            // Realiza la lógica para cargar la venta con los datos seleccionados
            // Puedes llamar a un método de negocio para realizar esta acción.
            Venta venta = new Venta
            {
                //ClienteID = clienteID,
                //ProductoID = productoID,
                //Cantidad = cantidad
            };

            // Llama a un método de negocio para cargar la venta
            //VentaBusiness.CargarVenta(venta);


        }
    }
}