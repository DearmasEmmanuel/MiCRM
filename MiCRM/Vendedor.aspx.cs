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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar datos de los DropdownList
                if (Session["NombreUsuario"] != null)
                {
                    lblUsuario.Text = Session["NombreUsuario"].ToString();
                }


                ddlMarca.DataSource = MarcaBusiness.List();
                ddlMarca.DataTextField = "Nombre";
                ddlMarca.DataBind();

                ddlCategoria.DataSource = CategoriaBusiness.List();
                ddlCategoria.DataTextField = "Nombre";
                ddlCategoria.DataBind();


                ActualizarlaGrilla();

            
            }
        }

        protected void btnCargarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("CargarCliente.aspx");
        }


        protected void btnRealizarCompra_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscarProducto_Click(object sender, EventArgs e)
        {

        }

        protected void btnFiltroProducto_Click(object sender, EventArgs e)
        {
            string nombreProducto = txtProducto.Text;
            int marcaSeleccionada = Convert.ToInt32(ddlMarca.SelectedValue);
            int categoriaSeleccionada = Convert.ToInt32(ddlCategoria.SelectedValue);





            gvStock.DataSource = ProductoBusiness.Filter(nombreProducto, marcaSeleccionada, categoriaSeleccionada);
            gvStock.DataBind();


        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)

        {



            int categoriaSeleccionada;
            if (int.TryParse(ddlCategoria.SelectedValue, out categoriaSeleccionada))
            {



                gvStock.DataSource = ProductoBusiness.Filter("", 0, categoriaSeleccionada);
                gvStock.DataBind();

            }
            else
            {
                // El valor no se pudo convertir a un entero
                // Manejar la situación según sea necesario
                // Por ejemplo, mostrar un mensaje de error o tomar otra acción
            }
        }




        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        private void MostrarProductosEnGridView(List<Producto> productos)
        {
            gvStock.DataSource = productos;
            gvStock.DataBind();
        }

        protected void btnBuscarProducto_Click1(object sender, EventArgs e)
        {

        }

        protected void ActualizarlaGrilla()
        {
            // Enlazar los datos al GridView
            gvStock.DataSource = ProductoBusiness.List();
            gvStock.DataBind();

        }
    }
}