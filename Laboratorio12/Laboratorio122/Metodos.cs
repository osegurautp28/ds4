using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio122
{
    internal class Metodos
    {
        public static double CalcularProm(double n1,double n2, double n3)
        {
            double promedio = (n1 + n2 + n3) / 3;
            return promedio;
        }

        public static void LimpiarCelda(TextBox n1, TextBox n2, TextBox n3, TextBox prom)
        {
            n1.Clear();
            n2.Clear();
            n3.Clear();
            prom.Clear();
        }

        public static void CerrarApp()
        {
            Application.Exit();
        }
    }
}
