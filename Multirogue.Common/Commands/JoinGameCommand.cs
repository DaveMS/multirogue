using System;

namespace Multirogue.Common.Commands
{
    public class JoinGameCommand : Command
    {
        public JoinGameCommand()
        {
            CommandType = CommandType.JoinGame;
        }

        public Guid PlayerId {  get; set; }
        public string Name { get; set; }
    }
}
