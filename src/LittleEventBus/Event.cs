using System;

namespace LittleEventBus
{
    public abstract class Event
    {
        public Guid EventId { get; set; }
    }
}
