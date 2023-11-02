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

        public static void AgregarProducto(Producto producto)
        {
            AccessData data = new AccessData();
            try
            {
                // Realiza la inserción del nuevo producto en la base de datos
                string query = "INSERT INTO Productos (Nombre, Descripcion, PrecioCompra, PrecioVenta, PorcentajeGanancia, StockActual, StockMinimo, MarcaID, CategoriaID) VALUES (@Nombre, @Descripcion, @PrecioCompra, @PrecioVenta, @PorcentajeGanancia, @StockActual, @StockMinimo, @MarcaID, @CategoriaID)";
                data.SetQuery(query);
                data.AddParameter("@Nombre", producto.Nombre);
                data.AddParameter("@Descripcion", producto.Descripcion);
                data.AddParameter("@PrecioCompra", producto.PrecioCompra);
                data.AddParameter("@PrecioVenta", producto.PrecioVenta);
                data.AddParameter("@PorcentajeGanancia", producto.PorcentajeGanancia);
                data.AddParameter("@StockActual", producto.StockActual);
                data.AddParameter("@StockMinimo", producto.StockMinimo);
                data.AddParameter("@MarcaID", producto.Marca.MarcaID);
                data.AddParameter("@CategoriaID", producto.Categoria.CategoriaID);
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

        public static void EditarProducto(Producto producto)
        {
            AccessData data = new AccessData();
            try
            {
                // Realiza la actualización del producto en la base de datos
                string query = "UPDATE Productos SET Nombre = @Nombre, Descripcion = @Descripcion, PrecioCompra = @PrecioCompra, PrecioVenta = @PrecioVenta, PorcentajeGanancia = @PorcentajeGanancia, StockActual = @StockActual, StockMinimo = @StockMinimo, MarcaID = @MarcaID, CategoriaID = @CategoriaID WHERE ProductoID = @ProductoID";
                data.SetQuery(query);
                data.AddParameter("@ProductoID", producto.ProductoID);
                data.AddParameter("@Nombre", producto.Nombre);
                data.AddParameter("@Descripcion", producto.Descripcion);
                data.AddParameter("@PrecioCompra", producto.PrecioCompra);
                data.AddParameter("@PrecioVenta", producto.PrecioVenta);
                data.AddParameter("@PorcentajeGanancia", producto.PorcentajeGanancia);
                data.AddParameter("@StockActual", producto.StockActual);
                data.AddParameter("@StockMinimo", producto.StockMinimo);
                data.AddParameter("@MarcaID", producto.Marca.MarcaID);
                data.AddParameter("@CategoriaID", producto.Categoria.CategoriaID);
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

        public static void EliminarProducto(int productoID)
        {
            AccessData data = new AccessData();
            try
            {
                // Realiza la eliminación del producto en la base de datos
                string query = "DELETE FROM Productos WHERE ProductoID = @ProductoID";
                data.SetQuery(query);
                data.AddParameter("@ProductoID", productoID);
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
