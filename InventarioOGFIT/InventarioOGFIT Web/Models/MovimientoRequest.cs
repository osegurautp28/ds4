using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioOGFITWeb.Models
{
    public class MovimientoRequest
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public string Nota { get; set; }
    }
}