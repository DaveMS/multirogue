using System;
using Multirogue.Common.Commands;

namespace Multirogue.Server.PlayerInterface.CommandHandlers
{
    public interface ICommandHandler
    {
        void HandleCommand(Guid fromPlayer, Command message);
    }
}