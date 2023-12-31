﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DetalleVentaBusiness
    {
        public static List<DetalleVentas> ListarDetallesVentaPorVentaID(int ventaID)
        {
            List<DetalleVentas> detallesVenta = new List<DetalleVentas>();
            AccessData data = new AccessData();
            try
            {
                // Define la consulta SQL para obtener los detalles de venta por VentaID
                string query = "SELECT DetalleVentaID, VentaID, ProductoID, Cantidad, PrecioVenta FROM DetallesVenta WHERE VentaID = @VentaID";
                data.SetQuery(query);
                data.AddParameter("@VentaID", ventaID);

                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    // Construye objetos DetalleVenta con los datos obtenidos de la base de datos
                    DetalleVentas detalleVenta = new DetalleVentas
                    {
                        DetalleVentaID = (int)data.Reader["DetalleVentaID"],
                        VentaID = (int)data.Reader["VentaID"],
                        ProductoID = (int)data.Reader["ProductoID"],
                        Cantidad = (int)data.Reader["Cantidad"],
                        PrecioVenta = (decimal)data.Reader["PrecioVenta"]
                    };
                    detallesVenta.Add(detalleVenta);
                }

                return detallesVenta;
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
        public static void AgregarDetalleVenta(DetalleVentas detalleVenta)
        {
            AccessData data = new AccessData();
            try
            {
                // Define la consulta SQL para agregar un detalle de venta
                string query = "INSERT INTO DetallesVenta (VentaID, ProductoID, Cantidad, PrecioVenta) VALUES (@VentaID, @ProductoID, @Cantidad, @PrecioVenta)";
                data.SetQuery(query);
                data.AddParameter("@VentaID", detalleVenta.VentaID);
                data.AddParameter("@ProductoID", detalleVenta.ProductoID);
                data.AddParameter("@Cantidad", detalleVenta.Cantidad);
                data.AddParameter("@PrecioVenta", detalleVenta.PrecioVenta);

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
    }
}
