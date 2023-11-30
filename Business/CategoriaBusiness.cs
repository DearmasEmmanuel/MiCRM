using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;

namespace Business
{
    public class CategoriaBusiness
    {
        public static List<Categoria> List()
        {

            List<Categoria> categoriaList = new List<Categoria>();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT CategoriaID, Nombre FROM CATEGORIAS");


                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    Categoria cateAux = new Categoria()
                    {
                        CategoriaID = (int)data.Reader["CategoriaID"],
                        Nombre = (string)data.Reader["Nombre"],
                    };
                    categoriaList.Add(cateAux);
                }

                return categoriaList;
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
        public static void EditarCategoria(Categoria categoria)
        {
            AccessData data = new AccessData();
            try
            {
                // Realiza la actualización de la categoría en la base de datos
                string query = "UPDATE Categorias SET Nombre = @Nombre WHERE CategoriaID = @CategoriaID";
                data.SetQuery(query);
                data.AddParameter("@CategoriaID", categoria.CategoriaID);
                data.AddParameter("@Nombre", categoria.Nombre);
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

        public static void EliminarCategoria(int categoriaID)
        {
            AccessData data = new AccessData();
            try
            {
                // Realiza la eliminación de la categoría en la base de datos
                string query = "DELETE FROM Categorias WHERE CategoriaID = @CategoriaID";
                data.SetQuery(query);
                data.AddParameter("@CategoriaID", categoriaID);
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