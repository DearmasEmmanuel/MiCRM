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
    public partial class ModificarClienteAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargamos la lista de clientes en el DropDownList
                ddlClientes.DataSource = ClienteBusiness.List();
                ddlClientes.DataTextField = "Nombre";
                ddlClientes.DataValueField = "ClienteID"; // Necesitamos el valor del ClienteID
                ddlClientes.DataBind();
            }

        }

        protected void ddlClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int clienteID = Convert.ToInt32(ddlClientes.SelectedValue);

            // Obtener y cargar los datos del cliente seleccionado
            Cliente cliente = ClienteBusiness.ObtenerClientePorID(clienteID);

            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtDireccion.Text = cliente.Direccion;
                txtContacto.Text = cliente.Contacto;
            }
        }

        protected void btnModificarCliente_Click(object sender, EventArgs e)
        {
            int clienteID = Convert.ToInt32(ddlClientes.SelectedValue); // Obtenemos el ClienteID del DropDownList

            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            string contacto = txtContacto.Text;

            // Crear un objeto Cliente con los datos modificados
            Cliente clienteModificado = new Cliente
            {
                ClienteID = clienteID,
                Nombre = nombre,
                Direccion = direccion,
                Contacto = contacto
            };

            // Llama a un método de negocio para actualizar el cliente
            ClienteBusiness.EditarCliente(clienteModificado);

            // Redirige a la página de confirmación o a la lista de clientes
            Response.Redirect("Admin.aspx");
        }
        protected void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            // Obtén el ID del cliente seleccionado del DropDownList
            int clienteID = Convert.ToInt32(ddlClientes.SelectedValue);

            // Llama a la función de negocio para eliminar el cliente
            ClienteBusiness.EliminarCliente(clienteID);

            // Puedes redirigir a una página de confirmación o a la lista de clientes
            Response.Redirect("Admin.aspx");
        }
    }
}
