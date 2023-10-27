using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dominio;



namespace Business

{
    public class ProductoBusiness
    {
        public List<Producto> List()
        {
            List<Producto> lista = new List<Producto>();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery("SELECT p.ProductoID, p.Nombre AS ProductoNombre, p.Descripcion, p.PrecioCompra, p.PrecioVenta, p.PorcentajeGanancia, p.StockActual, p.StockMinimo, m.MarcaID, m.Nombre AS MarcaNombre, c.CategoriaID, c.Nombre AS CategoriaNombre FROM Productos p INNER JOIN Marcas m ON p.MarcaID = m.MarcaID INNER JOIN Categorias c ON p.CategoriaID = c.CategoriaID");
                data.ExecuteQuery();
                while (data.Reader.Read())
                {
                    Producto aux = new Producto()
                    {
                        ProductoID = (int)data.Reader["ProductoID"],
                        Nombre = data.Reader["ProductoNombre"].ToString(),
                        Descripcion = data.Reader["Descripcion"].ToString(),
                        PrecioCompra = (decimal)data.Reader["PrecioCompra"],
                        PrecioVenta = (decimal)data.Reader["PrecioVenta"],
                        PorcentajeGanancia = (decimal)data.Reader["PorcentajeGanancia"],
                        StockActual = (int)data.Reader["StockActual"],
                        StockMinimo = (int)data.Reader["StockMinimo"],

                        Marca = new Marca
                        {
                            MarcaID = (int)data.Reader["MarcaID"],
                            Nombre = data.Reader["MarcaNombre"].ToString()
                        },
                        Categoria = new Categoria
                        {
                            CategoriaID = (int)data.Reader["CategoriaID"],
                            Nombre = data.Reader["CategoriaNombre"].ToString()
                        },

                    };
                    lista.Add(aux);
                }
            }
            catch (Exception ex1)
            {
                throw new Exception("Error al listar los artículos.", ex1);
            }
            return lista;
        }

        //        public int Agregar(Producto articulo)
        //        {
        //            AccessData data = new AccessData();
        //            List<SqlParameter> parameters = new List<SqlParameter>();
        //            try
        //            {
        //                string columns, values;
        //                columns = values = "";
        //                if (articulo.Codigo != null && articulo.Codigo != "")
        //                {
        //                    columns += "Codigo,";
        //                    values += $"@Codigo,";
        //                    parameters.Add(new SqlParameter("@Codigo", articulo.Codigo));
        //                }
        //                if (articulo.Nombre != null && articulo.Nombre != "")
        //                {
        //                    columns += "Nombre,";
        //                    values += $"@Nombre,";
        //                    parameters.Add(new SqlParameter("@Nombre", articulo.Nombre));
        //                }
        //                if (articulo.Descripcion != null && articulo.Descripcion != "")
        //                {
        //                    columns += "Descripcion,";
        //                    values += $"@Descripcion,";
        //                    parameters.Add(new SqlParameter("@Descripcion", articulo.Descripcion));
        //                }
        //                if (articulo.Precio != 0)
        //                {
        //                    columns += "Precio,";
        //                    values += $"@Precio,";
        //                    parameters.Add(new SqlParameter("@Precio", articulo.Precio));
        //                }
        //                string query = $@"
        //                    DECLARE @IdGenerado int

        //                    INSERT INTO ARTICULOS 
        //                        ({columns}IdMarca,IdCategoria)
        //                    VALUES
        //                        ({values}@BrandId,@CategoryId)
        //                    SET @IdGenerado = SCOPE_IDENTITY()
        //                    ";

        //                parameters.Add(new SqlParameter("@BrandId", articulo.Marca.Id));
        //                parameters.Add(new SqlParameter("@CategoryId", articulo.Categoria.Id));

        //                int imagesCount = articulo.Imagen is null ? 0 : articulo.Imagen.Count;
        //                if (imagesCount > 0)
        //                {
        //                    query += @"
        //                        INSERT INTO IMAGENES
        //                            (IdArticulo,ImagenUrl)
        //                        VALUES 
        //                        ";
        //                    for (int i = 0; i < imagesCount; i++)
        //                    {
        //                        query += $" (@IdGenerado, @ImagenUrl{i}),";
        //                        parameters.Add(new SqlParameter($"@ImagenUrl{i}", articulo.Imagen[i].ImagenUrl));
        //                    }
        //                    query = query.Remove(query.Length - 1);
        //                }

        //                data.SetQuery(query, parameters);

        //                return data.ExecuteNonQuery();
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //            finally
        //            {
        //                data.Close();
        //            }
        //        }
        //        public int Modificar(Producto oldItem, Producto updatedItem)
        //        {
        //            AccessData data = new AccessData();
        //            List<SqlParameter> parameters = new List<SqlParameter>();
        //            try
        //            {
        //                string query = "UPDATE ARTICULOS SET";
        //                parameters.Add(new SqlParameter("@Id", oldItem.Id));
        //                if (oldItem.Nombre != updatedItem.Nombre)
        //                {
        //                    query += " Nombre = @Name,";
        //                    parameters.Add(new SqlParameter("@Name", updatedItem.Nombre));
        //                }
        //                if (oldItem.Descripcion != updatedItem.Descripcion)
        //                {
        //                    query += " Descripcion = @Description,";
        //                    parameters.Add(new SqlParameter("@Description", updatedItem.Descripcion));
        //                }
        //                if (oldItem.Codigo != updatedItem.Codigo)
        //                {
        //                    query += " Codigo = @Code,";
        //                    parameters.Add(new SqlParameter("@Code", updatedItem.Codigo));
        //                }
        //                if (oldItem.Categoria.Id != updatedItem.Categoria.Id)
        //                {
        //                    query += " IdCategoria = @Category,";
        //                    parameters.Add(new SqlParameter("@Category", updatedItem.Categoria.Id));
        //                }
        //                if (oldItem.Marca.Id != updatedItem.Marca.Id)
        //                {
        //                    query += " IdMarca = @Brand,";
        //                    parameters.Add(new SqlParameter("@Brand", updatedItem.Marca.Id));
        //                }
        //                if (oldItem.Precio != updatedItem.Precio)
        //                {
        //                    query += " Precio = @Price,";
        //                    parameters.Add(new SqlParameter("@Price", updatedItem.Precio));
        //                }
        //                int imageUpdate = ImagenBusiness.UpdateList(oldItem.Imagen, updatedItem.Imagen);
        //                Console.WriteLine(imageUpdate);
        //                if (query[query.Length - 1] == ',')
        //                {
        //                    query = query.Remove(query.Length - 1, 1);
        //                }
        //                else
        //                {
        //                    return -1;
        //                }

        //                query += " WHERE Id = @Id";

        //                data.SetQuery(query, parameters);

        //                return data.ExecuteNonQuery();
        //            }
        //            catch (Exception ex)
        //            {
        //                return -1;
        //                throw ex;
        //            }
        //            finally
        //            {
        //                data.Close();
        //            }
        //        }

        //        public int Eliminar(Producto articulo)
        //        {
        //            AccessData data = new AccessData();
        //            List<SqlParameter> parameters = new List<SqlParameter>();
        //            try
        //            {
        //                string query = "DELETE FROM ARTICULOS WHERE Id = @Id";
        //                parameters.Add(new SqlParameter("@Id", articulo.Id));

        //                if (articulo.Imagen.Count > 0)
        //                {
        //                    query += " DELETE FROM IMAGENES WHERE IdArticulo = @Id";
        //                }

        //                data.SetQuery(query, parameters);

        //                return data.ExecuteNonQuery();
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //            finally
        //            {
        //                data.Close();
        //            }
        //        }
        //        public Producto ObtenerArticuloPorId(int id)
        //        {
        //            AccessData data = new AccessData();
        //            try
        //            {
        //                data.SetQuery("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, m.Id AS IdMarca, m.Descripcion AS Marca, c.Id as IdCategoria, c.Descripcion AS Categoria, i.Id AS IdImagen, i.IdArticulo, i.ImagenUrl AS Imagen, a.Precio FROM ARTICULOS a INNER JOIN MARCAS m ON a.IdMarca = m.Id INNER JOIN CATEGORIAS c ON a.IdCategoria = c.Id LEFT JOIN IMAGENES i ON a.Id = i.IdArticulo WHERE a.Id = @Id");
        //                data.AddParameter("@Id", id); // Agrega el parámetro para el ID
        //                data.ExecuteQuery();

        //                if (data.Reader.Read())
        //                {
        //                    Producto articulo = new Producto
        //                    {
        //                        Id = (int)data.Reader["Id"],
        //                        Codigo = data.Reader["Codigo"].ToString(),
        //                        Nombre = data.Reader["Nombre"].ToString(),
        //                        Descripcion = (string)data.Reader["Descripcion"],
        //                        Marca = new Marca
        //                        {
        //                            Id = (int)data.Reader["IdMarca"],
        //                            Descripcion = data.Reader["Marca"].ToString()
        //                        },
        //                        Categoria = new Categoria
        //                        {
        //                            Id = (int)data.Reader["IdCategoria"],
        //                            Descripcion = data.Reader["Categoria"].ToString()
        //                        },
        //                        Precio = Convert.ToDecimal(data.Reader["Precio"]),
        //                        Imagen = ImagenBusiness.List((int)data.Reader["Id"])
        //                    };

        //                    return articulo;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception("Error al obtener el artículo por ID.", ex);
        //            }
        //            finally
        //            {
        //                data.Close();
        //            }
        //            return null; // Retorna null si no se encuentra el artículo
        //        }

        //        public List<Producto> Buscar(string terminoBusqueda)
        //        {
        //            // Realizar la búsqueda en la base de datos y obtener una lista de productos
        //            List<Producto> resultados = BuscarProductosEnBaseDeDatos(terminoBusqueda);

        //            return resultados;
        //        }
        //        private List<Producto> BuscarProductosEnBaseDeDatos(string terminoBusqueda)
        //        {
        //            AccessData data = new AccessData();
        //            data.SetQuery("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, m.Id AS IdMarca, m.Descripcion AS Marca, c.Id as IdCategoria, c.Descripcion AS Categoria, i.Id AS IdImagen, i.IdArticulo, i.ImagenUrl AS Imagen, a.Precio FROM ARTICULOS a INNER JOIN MARCAS m ON a.IdMarca = m.Id INNER JOIN CATEGORIAS c ON a.IdCategoria = c.Id LEFT JOIN IMAGENES i ON a.Id = i.IdArticulo WHERE a.Id = @Id");
        //            data.AddParameter("@Nombre", terminoBusqueda); // Agrega el parámetro para el ID
        //            data.ExecuteQuery();

        //            List<Producto> resultados = new List<Producto>();
        //            // Implementa la búsqueda y llena la lista de resultados

        //            return resultados;
        //        }
    }
}