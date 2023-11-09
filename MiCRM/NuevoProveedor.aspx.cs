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
    public partial class NuevoProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            // Este evento se dispara cuando se hace clic en el botón "Agregar Proveedor".

            // Obtiene los datos ingresados por el usuario
            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            string contacto = txtContacto.Text;
            int dni = Convert.ToInt32(txtDNI.Text);
            string email = txtEmail.Text;

            // Crea un nuevo objeto Proveedor con los datos ingresados
            Proveedor nuevoProveedor = new Proveedor
            {
                Nombre = nombre,
                Direccion = direccion,
                Contacto = contacto,
                DNI = dni,
                Email = email
            };

            // Llama a una función de negocio para agregar el nuevo proveedor a la base de datos
            ProveedorBusiness.AgregarProveedor(nuevoProveedor);

            // Redirige a una página de confirmación o a la lista de proveedores
            Response.Redirect("Admin.aspx");
        }
    }
}