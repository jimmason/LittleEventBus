using System.Collections.Generic;

namespace LittleEventBus
{
    public sealed class SingleThreadedEventBus : IEventBus
    {
        private readonly IEventHandlerResolver eventHandlerResolver;

        public SingleThreadedEventBus(IEventHandlerResolver eventHandlerResolver)
        {
            this.eventHandlerResolver = eventHandlerResolver;
        }

        public void PublishEvent(Event @event)
        {
            this.Publish(@event);
        }

        public void PublishEvents(IEnumerable<Event> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                this.Publish(domainEvent);
            }
        }

        private void Publish(Event @event)
        {
            var handler = typeof (IEventHandler<>).MakeGenericType(@event.GetType());

            foreach (var eventHandler in this.eventHandlerResolver.Resolve(handler))
            {
                handler.GetMethod("Handle").Invoke(eventHandler, new object[] { @event });
            }
        }
    }
}
