using System;
using LittleEventBus.Example.Events;

namespace LittleEventBus.Example.EventHandlers
{
    public sealed class EmailCustomerOnOrderPlaced : IEventHandler<OrderPlaced>
    {
        public void Handle(OrderPlaced @event)
        {
            Console.WriteLine("EmailCustomerOnOrderPlaced Event Handler");
        }
    }
}
