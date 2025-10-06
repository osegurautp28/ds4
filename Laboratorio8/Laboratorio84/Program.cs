using Laboratorio84;

internal class Program
{
        static private void Main(string[] args)
        {
            Empleado empleado = new Empleado();
            empleado.Nombre = "John Doe";
            Console.WriteLine($"Nombre del empleado: {empleado.Nombre}");

            CuentaBancaria cta = new CuentaBancaria();
            cta.Saldo = -200;
            Console.WriteLine($"El saldo del empleado: {cta.Saldo}");
            //Probar despues con un saldo negativo, para ver la excepcion
           

            Cobertura c = new Cobertura(5);
            Console.WriteLine($"Con una cobertura de: {c.Radio}");
        }
    }

