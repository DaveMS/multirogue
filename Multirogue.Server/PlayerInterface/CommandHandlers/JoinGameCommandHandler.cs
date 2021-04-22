using System;
using System.Linq;
using Multirogue.Common.Commands;
using Multirogue.Server.InternalMessaging;

namespace Multirogue.Server.PlayerInterface.CommandHandlers
{
    public class JoinGameCommandHandler : ICommandHandler
    {
        private readonly World _world;
        private readonly IOptions _options;
        private readonly IMessageBus _messageBus;

        public JoinGameCommandHandler(World world, IOptions options, IMessageBus messageBus)
        {
            _world = world;
            _options = options;
            _messageBus = messageBus;
        }

        public void HandleCommand(Guid fromPlayer, Command message)
        {
            var joinGameMessage = message as JoinGameCommand;
            if(!_options.ExpectedPlayers.Contains(joinGameMessage.PlayerId))
            {
                // TODO: player is not allowed to join this game. Reply with error.
            }


            if(_world.Players.Any(x => x.Id == joinGameMessage.PlayerId))
            {
                // TODO: player already joined. Return error?
                return;
            }

            _world.AddPlayer(joinGameMessage.PlayerId, joinGameMessage.Name);

            // TODO: create player character entities
            

            _messageBus.PublishMessage(new PlayerJoinedMessage() {Id = joinGameMessage.PlayerId, Name = joinGameMessage.Name});

            if( _options.ExpectedPlayers.Count == _world.Players.Count)
            {
                _messageBus.PublishMessage(new AllPlayersJoinedMessage());
            }
        }
    }
}