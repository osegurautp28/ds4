using System;

namespace Laboratorio2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Client client = new Client();
            client.FirstName = "Omar";
            client.LastName = "Segura";
            client.Age = 15;
            client.Id = 1;

            Console.WriteLine(client.GetFullName());
           
        }

        public class Client
        {
            //Declarando variables de instancia en clase
            public int Id { get;set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public ushort Age { get; set; }


            public string GetFullName()
            {  
                    //Utilizando variables de instancia dentro de los metodos de la clase 
                    return FirstName + " " + LastName;
            }
            
        }

    }
}