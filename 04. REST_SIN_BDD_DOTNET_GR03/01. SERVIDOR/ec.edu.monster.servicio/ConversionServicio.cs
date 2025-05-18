using System;
using System.Collections.Generic;
using System.Linq;
using _01.SERVIDOR.ec.edu.monster.modelo;

namespace _01.SERVIDOR.ec.edu.monster.servicio
{
    public class ConversionServicio
    {
        // Simula una "base de datos" de usuarios
        private static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { id = 1, usuario = "MONSTER", password = "MONSTER9" },
            new Usuario { id = 2, usuario = "ADMIN", password = "1234" }
        };

        // Lógica de conversión de temperatura
        public double convertirTemperatura(double valor, string origen, string destino)
        {
            double valorConvertido = 0;

            if (origen.Equals(destino))
            {
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

            return Math.Round(valorConvertido, 3);
        }

        // Lógica de validación de login
        public bool validarLogin(string usuario, string password)
        {
            return usuarios.Any(u => u.usuario == usuario && u.password == password);
        }

        // Obtener lista de usuarios
        public List<Usuario> obtenerUsuarios()
        {
            return usuarios;
        }
    }
}
