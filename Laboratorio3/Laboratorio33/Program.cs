using Laboratorio31;
using System;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ingrese el valor de la base del rectangulo:");
        double labase = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Ingrese el valor de la altura del rectangulo:");
        double laaltura = Convert.ToDouble(Console.ReadLine());

        double perimetro=CalculosMatematicos.calculoPerimetro(labase, laaltura);

        Console.WriteLine($"El perimetro del rectangulo es:{perimetro} cm");


    }
}