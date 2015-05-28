#pragma warning disable 1998

namespace LittleEventBus
{
    /// <summary>
    /// Provides an implementation of the Event Bus that Publishes both Synchronous and Asynchronous Events Synchronously
    /// </summary>
    public sealed class SynchronousEventBus : IEventBus
    {
        private readonly IEventHandlerResolver eventHandlerResolver;

        public SynchronousEventBus(IEventHandlerResolver eventHandlerResolver)
        {
            this.eventHandlerResolver = eventHandlerResolver;
        }

        public void PublishEvent(Event @event)
        { 
            this.Publish(@event);
        }

        public async void PublishEventAsync(Event @event)
        {
            this.Publish(@event);
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
