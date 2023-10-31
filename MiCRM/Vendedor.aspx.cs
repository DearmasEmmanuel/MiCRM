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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["NombreUsuario"] != null)
                {
                    lblUsuario.Text = Session["NombreUsuario"].ToString();
                }
                else
                {

                }
                ProductoBusiness productoBusiness = new ProductoBusiness();
                gvStock.DataSource = productoBusiness.List();
                gvStock.DataBind();
                ddlClientes.DataSource = ClienteBusiness.List();
                ddlClientes.DataTextField = "Nombre";
                ddlClientes.DataBind();
            }
        }

        protected void btnCargarCliente_Click(object sender, EventArgs e)
        {

        }

        protected void btnRealizarCompra_Click(object sender, EventArgs e)
        {

        }
    }
}