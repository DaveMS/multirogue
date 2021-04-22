using System;
using Multirogue.Server;

namespace Multirogue.Server.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Start();
            
            Console.ReadLine();
        }
    }
}
