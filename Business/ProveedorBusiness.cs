using System;
using System.Collections.Generic;
using Dominio; 


namespace Business
{
    public class ProveedorBusiness
    {
        public static List<Proveedor> List()
        {
            List<Proveedor> proveedorList = new List<Proveedor>();
            AccessData data = new AccessData();

            try
            {
                data.SetQuery("SELECT ProveedorID, Nombre, Direccion, Contacto, DNI, Email FROM Proveedores");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    Proveedor proveedor = new Proveedor
                    {
                        ProveedorID = (int)data.Reader["ProveedorID"],
                        Nombre = (string)data.Reader["Nombre"],
                        Direccion = (string)data.Reader["Direccion"],
                        Contacto = (string)data.Reader["Contacto"],
                        DNI = Convert.ToInt32(data.Reader["DNI"]),

                        Email = (string)data.Reader["Email"]
                    };
                    proveedorList.Add(proveedor);
                }

                return proveedorList;
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

        public static void AgregarProveedor(Proveedor proveedor)
        {
            AccessData data = new AccessData();
            try
            {
                string query = "INSERT INTO Proveedores (Nombre, Direccion, Contacto, DNI, Email) VALUES (@Nombre, @Direccion, @Contacto,@DNI,@Email)";
                data.SetQuery(query);
                data.AddParameter("@Nombre", proveedor.Nombre);
                data.AddParameter("@Direccion", proveedor.Direccion);
                data.AddParameter("@Contacto", proveedor.Contacto);
                data.AddParameter("@DNI", proveedor.DNI);
                data.AddParameter("@Email", proveedor.Email);
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

        public static void EditarProveedor(Proveedor proveedor)
        {
            AccessData data = new AccessData();
            try
            {
                string query = "UPDATE Proveedores SET Nombre = @Nombre, Direccion = @Direccion, Contacto = @Contacto, DNI = @DNI, Email = @Email WHERE ProveedorID = @ProveedorID";
                data.SetQuery(query);
                data.AddParameter("@ProveedorID", proveedor.ProveedorID);
                data.AddParameter("@Nombre", proveedor.Nombre);
                data.AddParameter("@Direccion", proveedor.Direccion);
                data.AddParameter("@Contacto", proveedor.Contacto);
                data.AddParameter("@DNI", proveedor.DNI);
                data.AddParameter("@Email", proveedor.Email);
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

        public static void EliminarProveedor(int proveedorID)
        {
            AccessData data = new AccessData();
            try
            {
                string query = "DELETE FROM Proveedores WHERE ProveedorID = @ProveedorID";
                data.SetQuery(query);
                data.AddParameter("@ProveedorID", proveedorID);
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
        public static Proveedor ObtenerProveedorPorID(int proveedorID)
        {
            AccessData data = new AccessData();
            try
            {
                // Define la consulta SQL para obtener un proveedor por su ID
                string query = "SELECT ProveedorID, Nombre, Direccion, Contacto, DNI, Email FROM Proveedores WHERE ProveedorID = @ProveedorID";

                // Configura la consulta y agrega el parámetro
                data.SetQuery(query);
                data.AddParameter("@ProveedorID", proveedorID);

                data.ExecuteQuery();

                if (data.Reader.Read())
                {
                    Proveedor proveedor = new Proveedor
                    {
                        ProveedorID = (int)data.Reader["ProveedorID"],
                        Nombre = data.Reader["Nombre"].ToString(),
                        Direccion = data.Reader["Direccion"].ToString(),
                        Contacto = data.Reader["Contacto"].ToString(),
                        DNI = (int)data.Reader["DNI"],
                        Email = data.Reader["Email"].ToString(),
                    };

                    return proveedor;
                }

                return null; // Devuelve null si no se encuentra el proveedor con ese ID
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
