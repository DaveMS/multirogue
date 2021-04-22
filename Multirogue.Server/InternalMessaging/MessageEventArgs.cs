using System;

namespace Multirogue.Server.InternalMessaging
{
    public class MessageEventArgs : EventArgs
    {
        public MessageEventArgs(Message message)
        {
            Message = message;
        }

        public Message Message { get; }
    }
}