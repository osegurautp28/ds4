using System;
using Laboratorio31;
public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ingrese el radio del circulo:");
        double radio=Convert.ToDouble(Console.ReadLine());
        double area = CalculosMatematicos.calculoArea(radio);

        Console.WriteLine($"El area total del circulo es de {area}");
    }
}