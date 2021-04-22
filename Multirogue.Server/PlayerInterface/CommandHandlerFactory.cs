
using System;
using Multirogue.Common.Commands;
using Multirogue.Server.InternalMessaging;
using Multirogue.Server.PlayerInterface.CommandHandlers;

namespace Multirogue.Server.PlayerInterface
{
    public class CommandHandlerFactory
    {
        private World _world;
        private IOptions _options;
        private IMessageBus _messageBus;

        public CommandHandlerFactory(World world, IOptions options, IMessageBus messageBus)
        {
            _options = options;
            _world = world;
            _messageBus = messageBus;
        }

        public ICommandHandler GetCommandHandler(CommandType commandType) 
        {
            return commandType switch
            {
                CommandType.JoinGame => new JoinGameCommandHandler(_world, _options, _messageBus),

                _ => throw new InvalidOperationException($"Unknown command type {commandType}"),
            };
        }
    }
}