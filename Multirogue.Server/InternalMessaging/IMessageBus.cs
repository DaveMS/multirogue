using System;

namespace Multirogue.Server.InternalMessaging
{
    public interface IMessageBus
    {
        event EventHandler<MessageEventArgs> OnMessage;
        void PublishMessage(Message message);
    }
}