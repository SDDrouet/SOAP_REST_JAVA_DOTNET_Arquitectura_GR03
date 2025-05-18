using System;
using System.Collections.Generic;
using _01.SERVIDOR.ec.edu.monster.modelo;
using _01.SERVIDOR.ec.edu.monster.servicio;

namespace _01.SERVIDOR.ec.edu.monster.pruebas
{
    class TestConversionServicio
    {
        static void Main(string[] args)
        {
            ConversionServicio servicio = new ConversionServicio();

            // Test 1: Conversión de Celsius a Fahrenheit
            double resultado1 = servicio.convertirTemperatura(25, "C", "F");
            Console.WriteLine($"25 C a F: {resultado1}"); // Esperado: 77.0

            // Test 2: Conversión de Fahrenheit a Kelvin
            double resultado2 = servicio.convertirTemperatura(32, "F", "K");
            Console.WriteLine($"32 F a K: {resultado2}"); // Esperado: ~273.15

            // Test 3: Conversión sin cambio
            double resultado3 = servicio.convertirTemperatura(100, "K", "K");
            Console.WriteLine($"100 K a K: {resultado3}"); // Esperado: 100.0

            // Test 4: Login correcto
            bool loginCorrecto = servicio.validarLogin("admin", "1234");
            Console.WriteLine($"Login 'admin'/'1234': {loginCorrecto}"); // Esperado: True

            // Test 5: Login incorrecto
            bool loginIncorrecto = servicio.validarLogin("admin", "wrong");
            Console.WriteLine($"Login 'admin'/'wrong': {loginIncorrecto}"); // Esperado: False

            // Test 6: Listar usuarios
            List<Usuario> usuarios = servicio.obtenerUsuarios();
            Console.WriteLine("Usuarios disponibles:");
            foreach (var user in usuarios)
            {
                Console.WriteLine($"ID: {user.id}, Usuario: {user.usuario}");
            }

            Console.WriteLine("\nPruebas completadas.");
            Console.ReadLine(); // Espera para ver resultados en consola
        }
    }
}
