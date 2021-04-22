using System;
using Multirogue.Common.Events;
using Multirogue.Server.PlayerInterface.Networking;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Multirogue.Server.PlayerInterface.Networking.Websocket
{
    public class MultirogueWebsocketBehaviour : WebSocketBehavior
    {
        public event EventHandler<CommandReceivedEventArgs> OnMessageReceived;

        public MultirogueWebsocketBehaviour()
        {

        }

        public void SendMessageToClient<T>(string clientId, T message) where T : Event
        {
            var json = JsonConvert.SerializeObject(message);
            Sessions.SendTo(json, clientId);
        }

        public void SendMessageToAll<T>(T message) where T : Event
        {
            var json = JsonConvert.SerializeObject(message);
            Sessions.Broadcast(json);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            var message = JsonCommandDeserialiser.DeserialiseMessage(e.Data);
            OnMessageReceived?.Invoke(this, new CommandReceivedEventArgs(ID, message));
        }


        protected override void OnOpen()
        {
            base.OnOpen();
        }

        protected override void OnClose(CloseEventArgs e)
        {
            base.OnClose(e);
        }

        protected override void OnError(ErrorEventArgs e)
        {
            base.OnError(e);
        }
    }
}
