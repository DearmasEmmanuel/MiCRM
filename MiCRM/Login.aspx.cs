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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UsuarioID"] = null;
            Session["NombreUsuario"] = null;
            Session["Rol"] = null;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text;
            string contraseña = TxtContraseña.Text;

            List<Usuario> usuarios = LoginBusiness.List();

            Usuario usuarioAutenticado = usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contraseña == contraseña);

            if (usuarioAutenticado != null)
            {               
                Session["UsuarioID"] = usuarioAutenticado.UsuarioID;
                Session["NombreUsuario"] = usuarioAutenticado.NombreUsuario;
                Session["Rol"] = usuarioAutenticado.Rol;

                if (usuarioAutenticado.Rol == "Administrador")
                {
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    if(usuarioAutenticado.Rol == "Vendedor")
                    {
                        Response.Redirect("Vendedor.aspx");
                    }
                }
            }
            else
            {            
                lblMensajeError.Text = "Credenciales incorrectas. Intente de nuevo.";
            }
        }
    }
}