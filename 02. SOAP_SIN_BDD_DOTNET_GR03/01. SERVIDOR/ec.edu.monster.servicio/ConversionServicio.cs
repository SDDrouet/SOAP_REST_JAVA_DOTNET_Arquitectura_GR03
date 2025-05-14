using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.SERVIDOR.ec.edu.monster.servicio
{
    public class ConversionServicio
    {
        public double convertirTemperatura(double valor, string origen, string destino)
        {
            double valorConvertido = 0;

            if (origen.Equals(destino))
            {
                // No se realiza conversión si la unidad es la misma
                valorConvertido = valor;
            }
            else if (origen.Equals("C") && destino.Equals("F"))
            {
                valorConvertido = (valor * 9 / 5) + 32;
            }
            else if (origen.Equals("F") && destino.Equals("C"))
            {
                valorConvertido = (valor - 32) * 5 / 9;
            }
            else if (origen.Equals("C") && destino.Equals("K"))
            {
                valorConvertido = valor + 273.15;
            }
            else if (origen.Equals("K") && destino.Equals("C"))
            {
                valorConvertido = valor - 273.15;
            }
            else if (origen.Equals("F") && destino.Equals("K"))
            {
                valorConvertido = (valor + 459.67) * 5 / 9;
            }
            else if (origen.Equals("K") && destino.Equals("F"))
            {
                valorConvertido = valor * 9 / 5 - 459.67;
            }

            // Redondear a 3 decimales
            return Math.Round(valorConvertido, 3);
        }
    }
}
