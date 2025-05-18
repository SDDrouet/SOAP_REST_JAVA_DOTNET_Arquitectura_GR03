using _02._CLICON.ec.edu.monster.controlador;
using _02._CLICON.ec.edu.monster.modelo;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _02._CLICON.ec.edu.monster.vista
{
    internal class VistaPrincipal
    {
        private ConversionControlador _conversionControlador;

        public VistaPrincipal()
        {
            _conversionControlador = new ConversionControlador();
        }

        public async Task IniciarAsync()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool continuar = true;
            Request _request = new Request();

            while (continuar)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("═══════════════════════════════════════════════════════");
                Console.WriteLine("█           CONVERSOR DE TEMPERATURA - MONSTER        █");
                Console.WriteLine("═══════════════════════════════════════════════════════\n");
                Console.ResetColor();

                double temperatura = 0.0;
                bool entradaValida = false;

                // Ingreso de temperatura
                while (!entradaValida)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" Ingrese la temperatura a convertir: ");
                    string input = Console.ReadLine().Trim();

                    if (input.Count(c => c == '.') > 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("  Formato inválido. Solo un punto decimal permitido.\n");
                        Console.ResetColor();
                        continue;
                    }

                    if (double.TryParse(input, out temperatura))
                        entradaValida = true;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("  Ingrese un valor numérico válido.\n");
                        Console.ResetColor();
                    }
                }

                // Menú de opciones
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSeleccione el tipo de conversión:");
                Console.ResetColor();

                Console.WriteLine("  1. Celsius → Fahrenheit");
                Console.WriteLine("  2. Fahrenheit → Celsius");
                Console.WriteLine("  3. Celsius → Kelvin");
                Console.WriteLine("  4. Kelvin → Celsius");
                Console.WriteLine("  5. Fahrenheit → Kelvin");
                Console.WriteLine("  6. Kelvin → Fahrenheit");
                Console.WriteLine("  7. Cerrar Sesion");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\n Opción: ");
                string opcion = Console.ReadLine();
                Console.ResetColor();

                if (!int.TryParse(opcion, out int seleccion) || seleccion < 1 || seleccion > 7)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  Opción inválida. Intente nuevamente.");
                    Console.ResetColor();
                    Console.WriteLine(" Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                if (seleccion == 7)
                {
                    _conversionControlador.Dispose();

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n Cerrando sesión...");
                    Console.ResetColor();

                    await Task.Delay(1000);
                    await LoginHandler.MostrarLoginAsync(); // ← Ya accesible
                    return;
                }



                string[] origenes = { "C", "F", "C", "K", "F", "K" };
                string[] destinos = { "F", "C", "K", "C", "K", "F" };

                _request.valor = temperatura;
                _request.origen = origenes[seleccion - 1];
                _request.destino = destinos[seleccion - 1];

                try
                {
                    var response = await _conversionControlador.ConvertirAsync(_request);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n Resultado: {_request.valor}° {_request.origen} = {response.valorConvertido}° {_request.destino}");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n  Error: {ex.Message}");
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n───────────────────────────────────────────────────────");
                Console.Write(" Presione una tecla para realizar otra conversión...");
                Console.ResetColor();
                Console.ReadKey();
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nGracias por usar el conversor MONSTER. ¡Hasta pronto!");
            Console.ResetColor();
        }
    }
}
