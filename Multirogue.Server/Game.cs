using System.Threading.Tasks;
using Multirogue.Server.InternalMessaging;
using Multirogue.Server.PlayerInterface;
using Multirogue.Server.WorldMap;

namespace Multirogue.Server
{
    public class Game
    {
        private readonly IPlayerInterface _playerInterface;
        private readonly IMessageBus _messageBus;
        private readonly World _world;
        private readonly IOptions _options;

        private bool _gameRunning = false;

        public Game()
        {
            _options = new Options();
            _messageBus = new MessageBus();
            _messageBus.OnMessage += HandleMessage;

            _world = new World();

            var commandHandlerFactory = new CommandHandlerFactory(_world, _options, _messageBus);

            _playerInterface = new NetworkPlayerInterface(_messageBus, commandHandlerFactory);
        }

        public async Task Start()
        {
            // start network listener(s);
            _playerInterface.Start();

            // wait for all players to connect
            while(!_gameRunning)
            {
                await Task.Delay(250);
            }

            var mapGenerationParameters = new MapGenerationParameters()
            {
                Width = 20,
                Height = 20
            };

            var mapGenerator = new MapGenerator(mapGenerationParameters);
            _world.GenerateMap(mapGenerator);

            // start game
            _messageBus.PublishMessage(new GameStartedMessage());

            // while game has not complete`
            // enumerate through entities to take turns
            while (_gameRunning)
            {
            }
            
        }

        private void HandleMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            switch(message.MessageType)
            {
                case MessageType.AllPlayersJoined:
                    _gameRunning = true;
                break;
            }
        }
    }
}
