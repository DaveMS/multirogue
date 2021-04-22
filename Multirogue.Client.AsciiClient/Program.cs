using System.Reflection.Metadata.Ecma335;
using System.Reflection;
using System.Reflection.Metadata;
using System;

namespace Multirogue.Client.AsciiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameLoop();
            game.Start();
        }
    }
}
