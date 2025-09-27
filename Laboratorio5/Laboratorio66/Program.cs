internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, string> paisesCapitales = new Dictionary<string, string>
        {
            {"Francia", "Paris"},
            {"España", "Madrid" },
            {"Italia","Roma"}
        };
        foreach(KeyValuePair<string,string> par in paisesCapitales)
        {
            Console.WriteLine("La capital de" + par.Key+"es"+par.Value+".");
        }
    }
}