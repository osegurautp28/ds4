using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio81
{
    public class Trabajador:Persona
    {
        
    // Campo de cada objeto Trabajador que almacena cuánto gana
    public int Sueldo;

        // Constructor de Trabajador que llama al constructor base de Persona
        public Trabajador(string nombre, int edad, string nif, int sueldo)
            : base(nombre, edad, nif)
        {
            // Inicializamos el campo Sueldo
            Sueldo = sueldo;
        }
    }


}

