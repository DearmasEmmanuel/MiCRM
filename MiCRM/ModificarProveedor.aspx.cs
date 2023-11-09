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
    public partial class ModificarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Carga la lista de proveedores en el DropDownList
                ddlProveedores.DataSource = ProveedorBusiness.List();
                ddlProveedores.DataTextField = "Nombre";
                ddlProveedores.DataValueField = "ProveedorID";
                ddlProveedores.DataBind();
            }

        }
        protected void ddlProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int proveedorID = Convert.ToInt32(ddlProveedores.SelectedValue);
            Proveedor proveedor = ProveedorBusiness.ObtenerProveedorPorID(proveedorID);

            if (proveedor != null)
            {
                txtNombre.Text = proveedor.Nombre;
                txtDireccion.Text = proveedor.Direccion;
                txtContacto.Text = proveedor.Contacto;
                txtDNI.Text = proveedor.DNI.ToString();
                TxtEmail.Text = proveedor.Email;
               
            }
        }
        protected void btnModificarProveedor_Click(object sender, EventArgs e)
        {
            int proveedorID = Convert.ToInt32(ddlProveedores.SelectedValue);
            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            string contacto = txtContacto.Text;
            int dni = Convert.ToInt32(txtDNI.Text);
            string Email = TxtEmail.Text;

            Proveedor proveedorModificado = new Proveedor
            {
                ProveedorID = proveedorID,
                Nombre = nombre,
                Direccion = direccion,
                Contacto = contacto,
                DNI = dni,
                Email = Email
            };

            ProveedorBusiness.EditarProveedor(proveedorModificado);
            Response.Redirect("Admin.aspx");
        }
        protected void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            int proveedorID = Convert.ToInt32(ddlProveedores.SelectedValue);
            ProveedorBusiness.EliminarProveedor(proveedorID);
            Response.Redirect("Admin.aspx");
        }


    }
}