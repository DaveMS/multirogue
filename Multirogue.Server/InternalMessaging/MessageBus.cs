using System;

namespace Multirogue.Server.InternalMessaging
{
    public class MessageBus : IMessageBus
    {
        public event EventHandler<MessageEventArgs> OnMessage;
        
        public void PublishMessage(Message message)
        {
            OnMessage?.Invoke(this, new MessageEventArgs(message));
        }
    }
}