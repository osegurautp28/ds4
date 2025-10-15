using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese el valor de n (debe ser par):");
        int n = int.Parse(Console.ReadLine());

        if (n % 2 != 0)
        
            {
                Console.WriteLine("El numero debe ser par");
        }
        else { 

            int[,] arreglo = new int[n, n];
            Random rnd = new Random();
            int suma = 0;


            // Llenar el arreglo
            for (int f = 0; f < n; f++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (f == c && f != 0 && f != n - 1)
                    {
                        arreglo[f, c] = rnd.Next(101, 201);
                        suma += arreglo[f, c];
                    }
                    else
                    {
                        arreglo[f, c] = 0;
                    }
                }
            }

            // Imprimir el arreglo
            for (int f = 0; f < n; f++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write(arreglo[f, c] + "\t");
                }
                Console.WriteLine();
            }

            // Imprimir la suma
            Console.WriteLine("\nSuma diagonal: " + suma);
        }
       
    }
}

