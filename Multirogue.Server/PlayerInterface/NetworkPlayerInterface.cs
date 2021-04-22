using System;
using System.Collections.Generic;
using System.Linq;
using Multirogue.Common.Commands;
using Multirogue.Common.Events;
using Multirogue.Server.InternalMessaging;
using Multirogue.Server.PlayerInterface.Networking;
using Multirogue.Server.PlayerInterface.Networking.Websocket;

namespace Multirogue.Server.PlayerInterface
{
    public class NetworkPlayerInterface : IPlayerInterface
    {
        private readonly IMessageBus _messageBus;
        private readonly List<INetworkListener> _networkListeners = new List<INetworkListener>();
        private readonly Dictionary<Guid, (string clientId, INetworkListener listener)> _playerToClientIdMap = new Dictionary<Guid, (string clientId, INetworkListener listener)>();
        private readonly CommandHandlerFactory _commandHandlerFactory;


        public NetworkPlayerInterface(IMessageBus messageBus, CommandHandlerFactory commandHandlerFactory)
        {
            _messageBus = messageBus;
            _messageBus.OnMessage += HandleInternalMessage;

            var websocketListener = new WebsocketNetworkListener();
            websocketListener.OnCommandReceived += HandleCommandReceived;
            _networkListeners.Add(websocketListener);

            _commandHandlerFactory = commandHandlerFactory;
        }

        public void Start()
        {
            foreach(var networkListener in _networkListeners)
            {
                networkListener.Start();
            }
        }

        public void Stop()
        {
            foreach (var networkListener in _networkListeners)
            {
                networkListener.Stop();
            }
        }

        private void HandleCommandReceived(object sender, CommandReceivedEventArgs e)
        {
            var command = e.Command;
            switch (command.CommandType)
            {
                case CommandType.JoinGame:
                    HandlePlayerJoinCommand(sender as INetworkListener, e.ClientId, command as JoinGameCommand);
                break;
            }

            var handler = _commandHandlerFactory.GetCommandHandler(command.CommandType);
            handler.HandleCommand(GetPlayerIdFromClientId(e.ClientId), command);

        }

        private Guid GetPlayerIdFromClientId(string clientId)
        {
            return _playerToClientIdMap.First(x => x.Value.clientId == clientId).Key;
        }

        private void HandlePlayerJoinCommand(INetworkListener networkListener, string clientId, JoinGameCommand joinGameMessage)
        {
            _playerToClientIdMap[joinGameMessage.PlayerId] = (clientId, networkListener);
        }

        private void HandleInternalMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            switch( message.MessageType)
            {
                case MessageType.PlayerJoined:
                    var playerJoinedMessage = message as PlayerJoinedMessage;
                    BroadcastEvent(new PlayerJoinedEvent() { Name = playerJoinedMessage.Name});
                break;

                case MessageType.GameStarted:
                    BroadcastEvent(new GameStartedEvent());
                break;
            }
        }

        private void BroadcastEvent<T>(T ev) where T : Event
        {
            foreach(var listener in _networkListeners)
            {
                listener.SendEvent(ev);
            }
        }

        private void SendEventToPlayer<T>(T ev, Guid playerId) where T : Event
        {
            var (clientId, listener) = _playerToClientIdMap[playerId];
            listener.SendEvent(clientId, ev);
        }

    }
}