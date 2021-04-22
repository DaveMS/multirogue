using System;
using Multirogue.Common.Events;
using Newtonsoft.Json;

namespace Multirogue.Server.PlayerInterface.Networking
{
    public static class JsonEventDeserialiser
    {
        public static Event DeserialiseMessage(string json)
        {
            dynamic evt = JsonConvert.DeserializeObject(json);
            var eventType = (EventType)evt.EventType;

            return eventType switch
            {
                EventType.PlayerJoined => JsonConvert.DeserializeObject<PlayerJoinedEvent>(json),
                EventType.GameStarted => JsonConvert.DeserializeObject<GameStartedEvent>(json),
                _ => throw new InvalidOperationException($"Can not deserialise message with event type {evt.EventType}"),
            };
        }
    }
}