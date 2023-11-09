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
    public partial class UsuariosAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            // Obtiene los valores ingresados por el usuario
            string nombreUsuario = txtNombreUsuario.Text;
            string contraseña = txtContraseña.Text;
            string rol = ddlRol.SelectedValue;

            // Crea un objeto Usuario con los datos ingresados
            Usuario nuevoUsuario = new Usuario
            {
                NombreUsuario = nombreUsuario,
                Contraseña = contraseña,
                Rol = rol
            };

            try
            {
                // Llama al método de negocio para crear un nuevo usuario
                UsuarioBusiness.CrearUsuario(nuevoUsuario);

                // Redirige a una página de confirmación o a la lista de usuarios
                Response.Redirect("Admin.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
                // Maneja cualquier error que pueda ocurrir durante la creación del usuario
                // Puedes mostrar un mensaje de error o realizar otra acción apropiada.
            }
        }
    }
}