using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace MiCRM
{
    public partial class Producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["Rol"] is null))
            {       
                
                dgvProductos.DataSource = ProductoBusiness.List();
                dgvProductos.DataBind();

                //dgvProductos.Columns[0].Visible = false;
            }


        }
    }
}