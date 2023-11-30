using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public int CompraID { get; set; }
        public int ProveedorID { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}
