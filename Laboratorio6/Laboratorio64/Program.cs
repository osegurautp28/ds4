internal class Program
{
    static void checkAge(int age)
    {
        if (age < 18)
        {
            throw new ArithmeticException("Acesso negado-no cumple con el criterio de edad");
        }
        else
        {
            Console.WriteLine("Acesso concedido");
        }
    }
            private static void Main(string[] args)
            {
                checkAge(15);
            }
}