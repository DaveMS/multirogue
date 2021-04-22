using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Multirogue.Client.AsciiClient.UI;
using Multirogue.Common.Commands;
using SadConsole;
using SadConsole.Input;
using Console = SadConsole.Console;

namespace Multirogue.Client.AsciiClient
{
    class GameLoop
    {
        public const int GameWidth = 80;
        public const int GameHeight = 25;

        // Managers
        public static UIManager UIManager;
        public static World World;
        public ServerInterface _ServerInterface;

        public void Start()
        {
            // Setup the engine and create the main window.
            SadConsole.Game.Create(GameWidth, GameHeight);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = Init;

            // Hook the update event that happens each frame so we can trap keys and respond.
            SadConsole.Game.OnUpdate = Update;
                        
            // Start the game.
            SadConsole.Game.Instance.Run();

            //
            // Code here will not run until the game window closes.
            //
            
            SadConsole.Game.Instance.Dispose();
        }
        
        private void Update(GameTime time)
        {
            
        }

        private void Init()
        {
            //Instantiate the UIManager
            UIManager = new UIManager();

            // Build the world!
            World = new World();

            // Now let the UIManager create its consoles
            // so they can use the World data
            UIManager.Init();

            _ServerInterface = new ServerInterface();
            _ServerInterface.Start();

            _ServerInterface.SendCommand(new JoinGameCommand(){ PlayerId = new Guid("215903d3-88e8-4203-a034-affcbc66af89"), Name = "Dave"});
        }
    }
}