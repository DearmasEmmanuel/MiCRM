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
                data.SetQuery(@"SELECT CateroriaID, Nombre FROM CATEGORIAS");


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
    }
}