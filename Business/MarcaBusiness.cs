using Dominio;
using System;
using System.Collections.Generic;

namespace Business
{
    public class MarcaBusiness
    {
        public static List<Marca> List()
        {
            List<Marca> marcaList = new List<Marca>();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT MarcaID, Nombre FROM Marcas");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    Marca marcaAux = new Marca()
                    {
                        MarcaID = (int)data.Reader["MarcaID"],
                        Nombre = (string)data.Reader["Nombre"],
                    };
                    marcaList.Add(marcaAux);
                }

                return marcaList;
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

        public static void AgregarMarca(Marca marca)
        {
            AccessData data = new AccessData();
            try
            {
                // Realiza la inserción de la nueva marca en la base de datos
                string query = "INSERT INTO Marcas (Nombre) VALUES (@Nombre)";
                data.SetQuery(query);
                data.AddParameter("@Nombre", marca.Nombre);
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

        public static void EditarMarca(Marca marca)
        {
            AccessData data = new AccessData();
            try
            {
                // Realiza la actualización de la marca en la base de datos
                string query = "UPDATE Marcas SET Nombre = @Nombre WHERE MarcaID = @MarcaID";
                data.SetQuery(query);
                data.AddParameter("@MarcaID", marca.MarcaID);
                data.AddParameter("@Nombre", marca.Nombre);
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

        public static void EliminarMarca(int marcaID)
        {
            AccessData data = new AccessData();
            try
            {
                // Realiza la eliminación de la marca en la base de datos
                string query = "DELETE FROM Marcas WHERE MarcaID = @MarcaID";
                data.SetQuery(query);
                data.AddParameter("@MarcaID", marcaID);
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


