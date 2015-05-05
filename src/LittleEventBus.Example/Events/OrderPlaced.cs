using System;

namespace LittleEventBus.Example.Events
{
    public sealed class OrderPlaced : Event
    {
        public OrderPlaced(Guid id)
        {
            base.EventId = id;
        }
    }
}
