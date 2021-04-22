using System;

namespace Multirogue.Server.InternalMessaging
{
    public class PlayerJoinedMessage : Message
    {
        public PlayerJoinedMessage() : base(MessageType.PlayerJoined)
        {

        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}