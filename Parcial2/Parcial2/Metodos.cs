using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    internal class Metodos
    {
        // Hexadecimal → Decimal
        public static long HexaDec(string hex)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(hex))
                    throw new Exception("El campo está vacío.");

                // Elimina prefijo "0x" si lo tiene
                if (hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                    hex = hex.Substring(2);

                return Convert.ToInt64(hex, 16);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al convertir de Hexadecimal a Decimal: " + ex.Message);
            }
        }

        // Decimal → Hexadecimal
        public static string DecHexa(long dec)
        {
            try
            {
                return dec.ToString("X");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al convertir de Decimal a Hexadecimal: " + ex.Message);
            }
        }

        // Octal → Decimal
        public static long OctDec(string oct)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(oct))
                    throw new Exception("El campo está vacío.");

                return Convert.ToInt64(oct, 8);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al convertir de Octal a Decimal: " + ex.Message);
            }
        }

        // Decimal → Octal
        public static string DecOct(long dec)
        {
            try
            {
                return Convert.ToString(dec, 8);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al convertir de Decimal a Octal: " + ex.Message);
            }
        }
    }
}