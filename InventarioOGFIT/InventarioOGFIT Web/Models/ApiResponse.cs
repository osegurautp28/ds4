using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventarioOGFITWeb.Models
{
    public class ApiResponse<T>
    {
        public int Result { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}