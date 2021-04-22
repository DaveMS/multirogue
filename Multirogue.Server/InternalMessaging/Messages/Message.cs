using System;

namespace Multirogue.Server.InternalMessaging
{
    public class Message
    {
        public Message(MessageType type, Guid? toEntity = null)
        {
            MessageType = type;
            ToEntity = toEntity;
        }
        
        public MessageType MessageType { get; }
        public Guid? ToEntity { get; }
    }
}