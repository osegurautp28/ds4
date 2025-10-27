using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio123
{
    internal class Metodos
    {
        public static double CalcularSemip(double a, double b, double c)
        {
            double semip=(a + b+ c)/ 2;
            return semip;
        }

        public static double CalcularArea(double a, double b, double c, double semip)
        {
            double area = Math.Sqrt(semip*(semip - a)*(semip - b)*(semip - c));
            return area;
        }

        public static void Reset(TextBox a, TextBox b, TextBox c, TextBox semip, TextBox area)
        {
            a.Clear();
            b.Clear();
            c.Clear();
            semip.Clear();
            area.Clear();   
        }

        public static void CerrarApp()
        {
            Application.Exit();
        }


    }
}
