using System;

namespace Multirogue.Server.InternalMessaging
{
    public class AllPlayersJoinedMessage : Message
    {
        public AllPlayersJoinedMessage() : base(MessageType.AllPlayersJoined)
        {

        }
    }
}