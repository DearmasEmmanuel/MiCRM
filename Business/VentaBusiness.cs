using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Business
{
   
        public class VentaBusiness
        {
            public static List<Venta> List()
            {
                List<Venta> ventaList = new List<Venta>();
                AccessData data = new AccessData();

                try
                {
                    data.SetQuery("SELECT VentaID, ClienteID, ProductoID, Cantidad, FechaVenta FROM Ventas,Producto");
                    data.ExecuteQuery();

                    while (data.Reader.Read())
                    {
                        Venta venta = new Venta
                        {
                            VentaID = (int)data.Reader["VentaID"],
                            ClienteID = (int)data.Reader["ClienteID"],
                           // ProductoID = (int)data.Reader["ProductoID"],
                            //Cantidad = (int)data.Reader["Cantidad"],
                            FechaVenta = (DateTime)data.Reader["FechaVenta"]
                        };

                        ventaList.Add(venta);
                    }

                    return ventaList;
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

            public void CargarVenta(Venta venta)
            {
                AccessData data = new AccessData();
                try
                {
                    // Realiza la inserción de la venta en la base de datos
                    string query = "INSERT INTO Venta (ClienteID, ProductoID, Cantidad, FechaVenta) VALUES (@ClienteID, @ProductoID, @Cantidad, @FechaVenta)";
                    data.SetQuery(query);
                    data.AddParameter("@ClienteID", venta.ClienteID);
                    //data.AddParameter("@ProductoID", venta.ProductoID);
                   // data.AddParameter("@Cantidad", venta.Cantidad);
                    data.AddParameter("@FechaVenta", DateTime.Now); // Fecha actual
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

            // Puedes agregar más métodos para editar o eliminar ventas si es necesario.
        }
    }
