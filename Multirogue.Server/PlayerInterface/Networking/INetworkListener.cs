using System;
using Multirogue.Common.Events;
using Multirogue.Server.PlayerInterface.Networking;

namespace Multirogue.Server.PlayerInterface.Networking
{
    public interface INetworkListener
    {
         void Start();
         void Stop();

         event EventHandler OnConnected;
         event EventHandler OnDisconnected;

         event EventHandler<CommandReceivedEventArgs> OnCommandReceived;

        void SendEvent<T>(string clientId, T ev) where T : Event;
        void SendEvent<T>(T ev) where T : Event;

    }
}