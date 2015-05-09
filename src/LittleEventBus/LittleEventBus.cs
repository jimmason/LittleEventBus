using System.Collections.Generic;

namespace LittleEventBus
{
    public sealed class LittleEventBus : IEventBus
    {
        private readonly IEventHandlerResolver eventHandlerResolver;

        public LittleEventBus(IEventHandlerResolver eventHandlerResolver)
        {
            this.eventHandlerResolver = eventHandlerResolver;
        }

        public void PublishEvent(Event @event)
        {
            this.Publish(@event);
        }

        public void PublishEvents(IEnumerable<Event> events)
        {
            foreach (var @event in events)
            {
                this.Publish(@event);
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
