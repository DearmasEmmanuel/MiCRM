using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Business
{

    public class CompraBusiness
    {
        public static List<Compra> List()
        {
            List<Compra> compraList = new List<Compra>();
            AccessData data = new AccessData();

            try
            {
                data.SetQuery("SELECT CompraID, ProveedorID, ProductoID, Cantidad, FechaCompra FROM Compras,Producto");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    Compra compra = new Compra
                    {
                        CompraID = (int)data.Reader["CompraID"],
                        ProveedorID = (int)data.Reader["ClienteID"],
                        // ProductoID = (int)data.Reader["ProductoID"],
                        //Cantidad = (int)data.Reader["Cantidad"],
                        FechaCompra = (DateTime)data.Reader["FechaCompra"]
                    };

                    compraList.Add(compra);
                }

                return compraList;
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
        public static int CargarCompra(Compra compra)
        {
            AccessData data = new AccessData();
            try
            {
                // Realiza la inserción de la compra en la base de datos
                string query = "INSERT INTO Compras (ProveedorID, FechaCompra) VALUES (@ProveedorID, @FechaCompra); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                data.SetQuery(query);
                data.AddParameter("@ProveedorID", compra.ProveedorID);
                data.AddParameter("@FechaCompra", DateTime.Now); // Fecha actual
                int ultimoID = Convert.ToInt32(data.ExecuteScalar());

                return ultimoID;
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

        private static List<DetalleCompras> detallesCompra = new List<DetalleCompras>();

        public static void AgregarDetalleCompra(int productoID, int cantidad)
        {
            // Obtener información del producto desde tu lógica de negocio
            Producto producto = ProductoBusiness.ObtenerProductoPorID(productoID);
            Compra compra = new Compra();
            compra.FechaCompra = DateTime.Now;

            // Crear un nuevo detalle de compra
            DetalleCompras nuevoDetalle = new DetalleCompras
            {
                ProductoID = productoID,
                CompraID = compra.CompraID,
                PrecioCompra = producto.PrecioCompra,
                Cantidad = cantidad,
            };

            // Agregar el detalle a la lista de detalles de compra
            detallesCompra.Add(nuevoDetalle);
        }

        public static List<DetalleCompras> ObtenerDetallesCompra()
        {
            return detallesCompra;
        }

        public static decimal CalcularTotalCompra()
        {
            decimal totalCompra = 0;

            // Calcular el total sumando los subtotales de cada detalle
            foreach (var detalle in detallesCompra)
            {
                totalCompra += detalle.PrecioCompra;
            }

            return totalCompra;
        }






    }
}
