using System;

namespace Laboratorio31 {
    public class Program
    {
        private static void Main(string[] args)
        {
            int primerNumero, segundoNumero;
            double pi = 3.1416;

            Console.WriteLine("Introduce el primer numero: ");
            primerNumero = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Introduce el segundo numero");
            segundoNumero = Convert.ToInt32(Console.ReadLine());

            int total = CalculosMatematicos.Calcular(primerNumero, segundoNumero);

            Console.WriteLine($"El total de la operacion es de {total}");

        }
    }

    public class CalculosMatematicos
    {
        public static int Calcular(int a,int b)
        {
           return (a+b)*(a-b);
        }

        public static double calculoArea(double r)
        {
            return float.Pi * Math.Pow( r, 2);
        }

        public static double calculoPerimetro(double a, double b)
        {
            return 2 * (a + b);
        }
    }

}