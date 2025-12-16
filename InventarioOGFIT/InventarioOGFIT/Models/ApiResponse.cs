using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace InventarioOGFIT.Models
{
    public class ApiResponse<T>
    {
        public int Result { get; set; }   // 1 = OK, 0 = Error
        public T Data { get; set; }
        public string Message { get; set; }
    }
}