using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DetalleCompraBusiness
    {
        public static List<DetalleCompras> ListarDetallesCompraPorCompraID(int compraID)
        {
            List<DetalleCompras> detallesCompra = new List<DetalleCompras>();
            AccessData data = new AccessData();
            try
            {
                
                string query = "SELECT DetalleCompraID, CompraID, ProductoID, Cantidad, PrecioCompra FROM DetallesCompra WHERE CompraID = @CompraID";
                data.SetQuery(query);
                data.AddParameter("@CompraID", compraID);

                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    // Construye objetos DetalleCompra con los datos obtenidos de la base de datos
                    DetalleCompras detalleCompra = new DetalleCompras
                    {
                        DetalleCompraID = (int)data.Reader["DetalleCompraID"],
                        CompraID = (int)data.Reader["CompraID"],
                        ProductoID = (int)data.Reader["ProductoID"],
                        Cantidad = (int)data.Reader["Cantidad"],
                        PrecioCompra = (decimal)data.Reader["PrecioCompra"]
                    };
                    detallesCompra.Add(detalleCompra);
                }

                return detallesCompra;
            }
            catch (Exception ex)
            {
                // Manejo de errores (personalizar según tus necesidades)
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }

        public static void AgregarDetalleCompra(DetalleCompras detalleCompra)
        {
            AccessData data = new AccessData();
            try
            {
                // Define la consulta SQL para agregar un detalle de compra
                string query = "INSERT INTO DetallesCompra (CompraID, ProductoID, Cantidad, PrecioCompra) VALUES (@CompraID, @ProductoID, @Cantidad, @PrecioCompra)";
                data.SetQuery(query);
                data.AddParameter("@CompraID", detalleCompra.CompraID);
                data.AddParameter("@ProductoID", detalleCompra.ProductoID);
                data.AddParameter("@Cantidad", detalleCompra.Cantidad);
                data.AddParameter("@PrecioCompra", detalleCompra.PrecioCompra);

                data.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Manejo de errores (personalizar según tus necesidades)
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }

        // Puedes agregar funciones adicionales según tus necesidades, como editar o eliminar detalles de compra.
    }
}