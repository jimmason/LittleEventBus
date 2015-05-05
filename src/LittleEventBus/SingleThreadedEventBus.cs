using System.Collections.Generic;
using System.Linq;
using NanoIoC;

namespace LittleEventBus
{
    public sealed class SingleThreadedEventBus : IEventBus
    {
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

            //todo : This is not efficient at all. Register the closed generic types in the IoC container
            foreach (var eventHandler in Container.Global.ResolveAll(typeof(IEventHandler))
                .Cast<object>().Where(eventHandler => eventHandler.GetType().GetInterfaces().Contains(handler)))
            {
                handler.GetMethod("Handle").Invoke(eventHandler, new object[] { @event });
            }
        }
    }
}
