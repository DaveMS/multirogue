using System;
using Multirogue.Common.Events;
using WebSocketSharp.Server;

namespace Multirogue.Server.PlayerInterface.Networking.Websocket
{
    public class WebsocketNetworkListener : INetworkListener
    {

        private readonly WebSocketServer _server;
        private readonly MultirogueWebsocketBehaviour _websocketBehaviour;

        public WebsocketNetworkListener()
        {
            _server = new WebSocketServer(8182);
            _websocketBehaviour = new MultirogueWebsocketBehaviour();
            _websocketBehaviour.OnMessageReceived += HandleMessageReceived;
            _server.AddWebSocketService<MultirogueWebsocketBehaviour>("/", () => _websocketBehaviour);

        }

        public event EventHandler OnConnected;
        public event EventHandler OnDisconnected;
        public event EventHandler<CommandReceivedEventArgs> OnCommandReceived;

        public void SendEvent<T>(string clientId, T message) where T : Event
        {
            _websocketBehaviour.SendMessageToClient(clientId, message);
        }

        public void SendEvent<T>(T message) where T : Event
        {
            _websocketBehaviour.SendMessageToAll(message);
        }

        public void Start()
        {
            _server.Start();

        }

        public void Stop()
        {
            _server.Stop();
        }

        private void HandleMessageReceived(object sender, CommandReceivedEventArgs e)
        {
            OnCommandReceived?.Invoke(this, e);
        }
    }
}