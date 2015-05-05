using System.Collections.Generic;

namespace LittleEventBus
{
    public interface IEventBus
    {
        void PublishEvent(Event @event);
        void PublishEvents(IEnumerable<Event> domainEvents);
    }
}
