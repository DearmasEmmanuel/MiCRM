using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dominio;

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
                data.SetQuery(@"SELECT MarcaID, Nombre FROM MARCAS");
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
        //public static int Add(Marca marca)
        //{
        //    AccessData data = new AccessData();
        //    try
        //    {
        //        string query =
        //            @"IF NOT EXISTS (SELECT 1 FROM MARCAS WHERE Descripcion = @Description)
        //            BEGIN
        //                INSERT INTO MARCAS (Descripcion) VALUES (@Description)
        //            END";

        //        List<SqlParameter> parameters = new List<SqlParameter>() {
        //            new SqlParameter("@Description", marca.Descripcion)
        //        };

        //        data.SetQuery(query, parameters);

        //        if (data.ExecuteNonQuery() > 0)
        //        {
        //            return data.GetLastId("MARCAS");
        //        }
        //        else
        //        {
        //            return -1;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return -1;
        //        throw ex;
        //    }
        //    finally
        //    {
        //        data.Close();
        //    }
        //}
        //public static int Remove(Marca marca)
        //{
        //    AccessData data = new AccessData();
        //    try
        //    {
        //        string query = "DELETE FROM MARCAS WHERE id = @Id";
        //        List<SqlParameter> parameters = new List<SqlParameter>() {
        //            new SqlParameter("@Id", marca.Id)
        //        };
        //        data.SetQuery(query, parameters);

        //        return data.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        return -1;
        //        throw ex;
        //    }
        //    finally
        //    {
        //        data.Close();
        //    }
        //}
        //public static int Update(Marca marca)
        //{
        //    AccessData data = new AccessData();
        //    try
        //    {
        //        string query = "UPDATE MARCAS SET Descripcion = @Description WHERE id = @Id";
        //        List<SqlParameter> parameters = new List<SqlParameter>() {
        //            new SqlParameter("@Description", marca.Descripcion),
        //            new SqlParameter("@Id", marca.Id)
        //        };
        //        data.SetQuery(query, parameters);

        //        return data.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        return -1;
        //        throw ex;
        //    }
        //    finally
        //    {
        //        data.Close();
        //    }
        //}
        //public static int GetMaxID()
        //{
        //    AccessData data = new AccessData();
        //    try
        //    {
        //        data.SetQuery(@"SELECT MAX(Id) FROM MARCAS");
        //        data.ExecuteQuery();
        //        data.Reader.Read();
        //        return (int)data.Reader.GetInt32(0);
        //    }
        //    catch (Exception)
        //    {
        //        return -1;
        //    }
        //    finally
        //    {
        //        data.Close();
        //    }
        //}
    }
}
