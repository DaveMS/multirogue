using Multirogue.Common.Events;

public interface IEventHandler
{
    void HandleEvent(Event evt);
}