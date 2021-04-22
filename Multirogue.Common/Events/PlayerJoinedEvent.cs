using System;

namespace Multirogue.Common.Events
{
    public class PlayerJoinedEvent : Event
    {
        public PlayerJoinedEvent()
        {
            EventType = EventType.PlayerJoined;
        }

        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}