using System;

namespace LittleEventBus.Testing.Infrastructure.Events
{
    public sealed class PizzaOrdered : Event
    {
        public PizzaOrdered()
        {
            this.EventId = Guid.NewGuid();
        }
    }
}
