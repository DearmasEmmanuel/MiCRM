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
    public partial class ModificarMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMarcas();
            }
        }
            protected void ddlMarcas_SelectedIndexChanged(object sender, EventArgs e)
            {
                int marcaID = Convert.ToInt32(ddlMarcas.SelectedValue);
                // Obtener y mostrar los datos de la marca seleccionada
                Marca marca = MarcaBusiness.ObtenerMarcaPorID(marcaID);

                if (marca != null)
                {
                    txtNombre.Text = marca.Nombre;
                }
            }

            protected void btnModificar_Click(object sender, EventArgs e)
            {
                int marcaID = Convert.ToInt32(ddlMarcas.SelectedValue);
                string nombre = txtNombre.Text;
                // Actualizar la marca en la base de datos
                Marca marcaModificada = new Marca { MarcaID = marcaID, Nombre = nombre };
                MarcaBusiness.EditarMarca(marcaModificada);
                // Redirigir o mostrar un mensaje de éxito
                Response.Redirect("Admin.aspx");
            }

            protected void btnEliminar_Click(object sender, EventArgs e)
            {
                int marcaID = Convert.ToInt32(ddlMarcas.SelectedValue);
                // Eliminar la marca de la base de datos
                MarcaBusiness.EliminarMarca(marcaID);
                // Redirigir o mostrar un mensaje de éxito
                Response.Redirect("Admin.aspx");
            }

            private void CargarMarcas()
            {
                // Cargar las marcas en el DropDownList
                ddlMarcas.DataSource = MarcaBusiness.List();
                ddlMarcas.DataTextField = "Nombre";
                ddlMarcas.DataValueField = "MarcaID";
                ddlMarcas.DataBind();
            }
        }
    }