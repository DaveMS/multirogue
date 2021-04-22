using Multirogue.Client.AsciiClient;
using Multirogue.Common.Events;

public class GameStartedEventHandler : IEventHandler
{
    public void HandleEvent(Event evt)
    {
        var gameStartedEvent = evt as GameStartedEvent;
        GameLoop.UIManager.MessageLog.Add($"The game has started.");
    }
}