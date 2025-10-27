using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio12
{
    internal class Metodos
    {
        public static double CalcularDistancia (string v, string t)
        {
            double velocidad,  tiempo;
            velocidad=Convert.ToDouble(v);
            tiempo=Convert.ToDouble(t);
            return velocidad * tiempo;
            
        }

        public static void LimpiarTxt(TextBox txtVelocidad, TextBox txtTiempo, TextBox txtResultado)
        {
            txtVelocidad.Clear();
            txtTiempo.Clear();
            txtResultado.Clear();

        }

        public static void CerrarApp()
        {
            Application.Exit();
        }

        
            
     

          
    }
}
