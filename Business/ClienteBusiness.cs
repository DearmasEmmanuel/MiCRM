using Dominio;
using System;
using System.Collections.Generic;
 

namespace Business
{
    public class ClienteBusiness
    {
        public static List<Cliente> List()
        {
            List<Cliente> clienteList = new List<Cliente>();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT ClienteID, Nombre, Direccion, Contacto FROM Clientes");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    Cliente clienteAux = new Cliente()
                    {
                        ClienteID = (int)data.Reader["ClienteID"],
                        Nombre = (string)data.Reader["Nombre"],
                        Direccion = (string)data.Reader["Direccion"],
                        Contacto = (string)data.Reader["Contacto"],
                    };
                    clienteList.Add(clienteAux);
                }

                return clienteList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }

        public static void AgregarCliente(Cliente cliente)
        {
            AccessData data = new AccessData();
            try
            {
                // Realiza la inserción del nuevo cliente en la base de datos
                string query = "INSERT INTO Clientes (Nombre, Direccion, Contacto) VALUES (@Nombre, @Direccion, @Contacto)";
                data.SetQuery(query);
                data.AddParameter("@Nombre", cliente.Nombre);
                data.AddParameter("@Direccion", cliente.Direccion);
                data.AddParameter("@Contacto", cliente.Contacto);
                data.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }

        public static void EditarCliente(Cliente cliente)
        {
            AccessData data = new AccessData();
            try
            {
                // Realiza la actualización del cliente en la base de datos
                string query = "UPDATE Clientes SET Nombre = @Nombre, Direccion = @Direccion, Contacto = @Contacto WHERE ClienteID = @ClienteID";
                data.SetQuery(query);
                data.AddParameter("@ClienteID", cliente.ClienteID);
                data.AddParameter("@Nombre", cliente.Nombre);
                data.AddParameter("@Direccion", cliente.Direccion);
                data.AddParameter("@Contacto", cliente.Contacto);
                data.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }

        public static void EliminarCliente(int clienteID)
        {
            AccessData data = new AccessData();
            try
            {
                // Realiza la eliminación del cliente en la base de datos
                string query = "DELETE FROM Clientes WHERE ClienteID = @ClienteID";
                data.SetQuery(query);
                data.AddParameter("@ClienteID", clienteID);
                data.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }
    }
}

