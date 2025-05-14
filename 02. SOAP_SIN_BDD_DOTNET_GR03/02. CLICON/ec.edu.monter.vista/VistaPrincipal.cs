using _02._CLICON.ec.edu.monster.controlador;
using ConversionSevicio;
using System;

namespace _02._CLICON.ec.edu.monter.vista
{
    internal class VistaPrincipal
    {
        public VistaPrincipal() { }

        public async void iniciarAsync()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool continuar = true;
            ConversionControlador _conversionControlador = new ConversionControlador();
            Request _request = new Request();

            while (continuar)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("═══════════════════════════════════════════════════════════");
                Console.WriteLine("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█");
                Console.WriteLine("█            CONVERSOR DE TEMPERATURA - MONSTER           █");
                Console.WriteLine("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█");
                Console.WriteLine("═══════════════════════════════════════════════════════════");
                Console.ResetColor();

                double temperatura = 0.0;
                bool entradaValida = false;

                while (!entradaValida)
                {
                    Console.Write("\nIngrese el valor de la temperatura a convertir: ");
                    string input = Console.ReadLine().Trim();

                    // Validación: solo un punto decimal
                    int puntos = input.Count(c => c == '.');
                    if (puntos > 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Formato inválido: hay más de un punto decimal.");
                        Console.ResetColor();
                        continue;
                    }

                    // Intentar convertir
                    if (double.TryParse(input, out temperatura))
                    {
                        entradaValida = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Valor inválido. Por favor, ingrese un número válido (ej: 36.5).");
                        Console.ResetColor();
                    }
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSeleccione el tipo de conversión:");
                Console.ResetColor();

                Console.WriteLine(" [1] Celsius -> Fahrenheit");
                Console.WriteLine(" [2] Fahrenheit -> Celsius");
                Console.WriteLine(" [3] Celsius -> Kelvin");
                Console.WriteLine(" [4] Kelvin -> Celsius");
                Console.WriteLine(" [5] Fahrenheit -> Kelvin");
                Console.WriteLine(" [6] Kelvin -> Fahrenheit");
                Console.WriteLine(" [7] Salir");

                Console.Write("\nIngrese una opción (1-7): ");
                string opcion = Console.ReadLine().Trim();

                if (!int.TryParse(opcion, out int seleccion) || seleccion < 1 || seleccion > 7)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Opción inválida. Por favor, ingrese un número del 1 al 7.");
                    Console.ResetColor();
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                if (seleccion == 7)
                {
                    continuar = false;
                    Console.WriteLine("\nGracias por usar el sistema. ¡Hasta pronto!");
                    break;
                }

                string[] origenes = { "C", "F", "C", "K", "F", "K" };
                string[] destinos = { "F", "C", "K", "C", "K", "F" };

                _request.valor = temperatura;
                _request.origen = origenes[seleccion - 1];
                _request.destino = destinos[seleccion - 1];

                // Validación adicional: temperatura en Kelvin no puede ser negativa
                if ((_request.origen == "K" || _request.destino == "K") && temperatura < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Error: La temperatura en Kelvin no puede ser negativa.");
                    Console.ResetColor();
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                try
                {
                    Response _response = await _conversionControlador.convertirAsync(_request);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n Resultado: {_response.mensaje}");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" Error: {ex.Message}");
                }
                finally
                {
                    Console.ResetColor();
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}
