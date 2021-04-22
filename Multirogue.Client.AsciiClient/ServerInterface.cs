using Multirogue.Common.Commands;
using Multirogue.Common.Events;

public class ServerInterface
{
    private readonly EventHandlerFactory _eventHandlerFactory = new EventHandlerFactory();
    private readonly WebsocketClient _websocketClient = new WebsocketClient();

    public void Start()
    {
        _websocketClient.Start();
        _websocketClient.OnEventReceived += HandleEventReceived;
    }

    public void Stop()
    {
    }

    public void SendCommand(Command command)
    {
        _websocketClient.SendMessage(command);
    }

    private void HandleEventReceived(object sender, Event evt)
    {
        var handler = _eventHandlerFactory.CreateEventHandler(evt.EventType);
        handler.HandleEvent(evt);
    }
}