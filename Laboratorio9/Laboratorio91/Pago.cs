using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio91
{
    internal class Pago
    {
        public double monto;

        public Pago(double monto)
        {
            this.monto = monto;
            Console.WriteLine("El total es de:"); 
        }
}
