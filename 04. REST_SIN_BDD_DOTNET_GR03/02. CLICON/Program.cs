using _02._CLICON.ec.edu.monster.vista;
using _02._CLICON.ec.edu.monster.controlador;
using _02._CLICON.ec.edu.monster.modelo;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        await LoginHandler.MostrarLoginAsync();
    }
}
