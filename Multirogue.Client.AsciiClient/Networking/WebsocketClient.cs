using System;
using Multirogue.Common.Commands;
using Multirogue.Common.Events;
using Multirogue.Server.PlayerInterface.Networking;
using Newtonsoft.Json;
using WebSocketSharp;

public class WebsocketClient : IDisposable
{
    private readonly WebSocket _websocket;
    
    public event EventHandler<Event> OnEventReceived;


    public WebsocketClient()
    {
        _websocket = new WebSocket("ws://127.0.0.1:8182/");
        _websocket.OnMessage += HandleMessage;
    }

    public void Start()
    {
        _websocket.Connect();
    }

    public void SendMessage(Command command)
    {
        var json = JsonConvert.SerializeObject(command);
        _websocket.Send(json);
    }

    private void HandleMessage(object sender, MessageEventArgs e)
    {
        var message = JsonEventDeserialiser.DeserialiseMessage(e.Data);
        OnEventReceived?.Invoke(this, message);
    }

    public void Dispose()
    {

    }
}