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
    public partial class CargarClienteAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCargarCliente_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            string contacto = txtContacto.Text;
            int dni = Convert.ToInt32(txtDNI.Text);
            string email = txtEmail.Text;


            // Lógica para guardar el cliente en la base de datos utilizando la capa de negocio
            Cliente cliente = new Cliente
            {
                Nombre = nombre,
                Direccion = direccion,
                Contacto = contacto,
                DNI = dni,
                Email = email

            };

          

            // Llama a un método de negocio para guardar el cliente
            ClienteBusiness.AgregarCliente(cliente);

            // Redirecciona a una página de confirmación o a la lista de clientes
            Response.Redirect("Admin.aspx");

        }


    }
}