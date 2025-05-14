using _02._CLICON.ec.edu.monter.vista;
using System;

string username = "MONSTER";
string password = "MONSTER9";
bool continuar = true;

while (continuar)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("═════════════════════════════════════════════════════");
    Console.WriteLine("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█");
    Console.WriteLine("█               SISTEMA DE ACCESO - MONSTER         █");
    Console.WriteLine("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█");
    Console.WriteLine("═════════════════════════════════════════════════════");
    Console.ResetColor();

    Console.Write("\n Usuario: ");
    string inputUsername = Console.ReadLine();

    Console.Write(" Contraseña: ");
    string inputPassword = "";
    ConsoleKeyInfo key;

    do
    {
        key = Console.ReadKey(true);
        if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
        {
            inputPassword += key.KeyChar;
            Console.Write("*");
        }
        else if (key.Key == ConsoleKey.Backspace && inputPassword.Length > 0)
        {
            inputPassword = inputPassword[..^1]; // Substring simplificado con rangos (C# 8+)
            Console.Write("\b \b");
        }
    } while (key.Key != ConsoleKey.Enter);

    if (inputUsername == username && inputPassword == password)
    {
        continuar = false;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n Usuario o contraseña incorrectos. Intente de nuevo.");
        Console.ResetColor();
        Console.WriteLine("Presione cualquier tecla para reintentar...");
        Console.ReadKey();
    }
}

Console.Clear();
VistaPrincipal vistaPrincipal = new VistaPrincipal();
vistaPrincipal.iniciarAsync();
