using System;
using Multirogue.Common.Commands;

namespace Multirogue.Server.PlayerInterface.Networking
{
    public class CommandReceivedEventArgs : EventArgs
    {
        public CommandReceivedEventArgs(string clientId, Command command)
        {
            ClientId = clientId;
            Command = command;
        }

        public string ClientId {get; }
        public Command Command { get; }
    }
}