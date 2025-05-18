// Archivo: ec.edu.monster.controlador/LoginHandler.cs
using _02._CLICON.ec.edu.monster.controlador;
using _02._CLICON.ec.edu.monster.modelo;
using _02._CLICON.ec.edu.monster.vista;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace _02._CLICON.ec.edu.monster.controlador
{
    public static class LoginHandler
    {
        public static async Task MostrarLoginAsync()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("═════════════════════════════════════════════════════");
                Console.WriteLine("█               SISTEMA DE ACCESO - MONSTER         █");
                Console.WriteLine("═════════════════════════════════════════════════════\n");
                Console.ResetColor();

                Console.Write(" Usuario: ");
                string usuario = Console.ReadLine();

                Console.Write(" Contraseña: ");
                string password = "";
                ConsoleKeyInfo key;

                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        password += key.KeyChar;
                        Console.Write("*");
                    }
                    else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password[..^1];
                        Console.Write("\b \b");
                    }
                } while (key.Key != ConsoleKey.Enter);

                Console.WriteLine();

                try
                {
                    var controlador = new ConversionControlador();
                    var user = new Usuario { usuario = usuario, password = password };
                    bool login = await controlador.LoginAsync(user);

                    if (login)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n¡Acceso concedido! Bienvenido, " + usuario);
                        Console.ResetColor();

                        Console.Write("\nCargando sistema");
                        for (int i = 0; i < 3; i++)
                        {
                            Thread.Sleep(500);
                            Console.Write(".");
                        }

                        continuar = false;
                        Console.Clear();
                        var vista = new VistaPrincipal();
                        await vista.IniciarAsync();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nUsuario o contraseña incorrectos.");
                        Console.ResetColor();

                        Console.WriteLine("\nPresione una tecla para intentar de nuevo...");
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n Error: {ex.Message}");
                    Console.ResetColor();

                    Console.WriteLine("\nPresione una tecla para intentar de nuevo...");
                    Console.ReadKey();
                }
            }
        }
    }
}
