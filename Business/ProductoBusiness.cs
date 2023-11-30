using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dominio;


namespace Business
{
    public class ProductoBusiness
    {
        public static List<Producto> List()
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

        public static void SumarStockActual(int productoId, int cantidad)
        {
            //Buscamos el stock actual del producto
            int result;
            result = ProductoBusiness.DevolverStockActual(productoId);

            AccessData data = new AccessData();
            try
            {
                // Realiza la actualización del producto en la base de datos
                string query = "UPDATE Productos SET StockActual = @StockActual WHERE ProductoID = @ProductoID";
                data.SetQuery(query);
                int stockActual = cantidad + result;
                data.AddParameter("@ProductoID", productoId);
                data.AddParameter("@StockActual", stockActual);
                data.ExecuteQuery();
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
        public static int DevolverStockActual(int productoId)
        {
            AccessData data = new AccessData();
            try
            {
                // Realiza la busqueda de la cantidad de stock actual
                string query = "SELECT StockActual FROM Productos WHERE ProductoID = @ProductoID";
                data.SetQuery(query);
                data.AddParameter("@ProductoID", productoId);
                object result = data.ExecuteScalar();
                return (int)result;
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
        public static Producto ObtenerProductoPorID(int productoID)
        {
            // Simulamos la obtención de datos desde la lista de productos
            return List().Find(p => p.ProductoID == productoID);
        }
        public string ObtenerNombreProducto(int productoID)
        {
            // Lógica para obtener el producto basándote en su ID
            Producto producto = ProductoBusiness.ObtenerProductoPorID(productoID);

            // Devolver el nombre del producto si se encuentra, o un mensaje de error si no se encuentra
            return producto != null ? producto.Nombre : "Producto no encontrado";
        }
        public static List<Producto> Filter(string nombre, int marcaID, int categoriaID)
        {
            List<Producto> productosFiltrados = ObtenerTodosLosProductos(); // Obtener todos los productos

            if (!string.IsNullOrEmpty(nombre))
            {
                productosFiltrados = FiltrarPorNombre(productosFiltrados, nombre);
            }

            if (marcaID != 0)
            {
                productosFiltrados = FiltrarPorMarca(productosFiltrados, marcaID);
            }

            if (categoriaID != 0)
            {
                productosFiltrados = FiltrarPorCategoria(productosFiltrados, categoriaID);
            }

            return productosFiltrados;
        }

        private static List<Producto> FiltrarPorNombre(List<Producto> productos, string nombre)
        {
            return productos.Where(p => p.Nombre.Contains(nombre)).ToList();
        }

        private static List<Producto> FiltrarPorMarca(List<Producto> productos, int marcaID)
        {
            return productos.Where(p => p.Marca.MarcaID == marcaID).ToList();
        }

        private static List<Producto> FiltrarPorCategoria(List<Producto> productos, int categoriaID)
        {
            return productos.Where(p => p.Categoria.CategoriaID == categoriaID).ToList();
        }

        // Método auxiliar para obtener todos los productos (sustituye esto por tu lógica real)
        private static List<Producto> ObtenerTodosLosProductos()
        {
            // Lógica para obtener todos los productos
            // Reemplaza esto con tu lógica para obtener la lista de productos
            List<Producto> todosLosProductos = ProductoBusiness.List();
            return todosLosProductos;
        }


    }
}
