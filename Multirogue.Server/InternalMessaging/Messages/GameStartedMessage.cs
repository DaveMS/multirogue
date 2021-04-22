using System;

namespace Multirogue.Server.InternalMessaging
{
    public class GameStartedMessage : Message
    {
        public GameStartedMessage() : base(MessageType.GameStarted)
        {

        }
    }
}