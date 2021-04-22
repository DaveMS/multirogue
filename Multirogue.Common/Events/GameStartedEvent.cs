namespace Multirogue.Common.Events
{
    public class GameStartedEvent : Event
    {
        public GameStartedEvent()
        {
            EventType = EventType.GameStarted;
        }
    }
}