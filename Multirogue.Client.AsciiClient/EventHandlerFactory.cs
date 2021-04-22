using System;
using Multirogue.Common.Events;

public class EventHandlerFactory
{
    public IEventHandler CreateEventHandler(EventType eventType)
    {
        return eventType switch
        {
            EventType.PlayerJoined => new PlayerJoinedEventHandler(),
            EventType.GameStarted => new GameStartedEventHandler(),
            _ => throw new InvalidOperationException($"Unknown event: {eventType}"),
        };
    }
}