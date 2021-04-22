using Multirogue.Client.AsciiClient;
using Multirogue.Common.Events;

public class PlayerJoinedEventHandler : IEventHandler
{
    public void HandleEvent(Event evt)
    {
        var playerJoinedEvent = evt as PlayerJoinedEvent;
        GameLoop.World.Players.Add(new Player() { Id = playerJoinedEvent.Id, Name = playerJoinedEvent.Name });
        GameLoop.UIManager.MessageLog.Add($"{playerJoinedEvent.Name} has joined the game.");
    }
}