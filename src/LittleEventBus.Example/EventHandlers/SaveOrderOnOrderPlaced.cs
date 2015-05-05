using System;
using LittleEventBus.Example.Events;

namespace LittleEventBus.Example.EventHandlers
{
    public sealed class SaveOrderOnOrderPlaced : IEventHandler<OrderPlaced>
    {
        public void Handle(OrderPlaced @event)
        {
            Console.WriteLine("SaveOrderOnOrderPlaced Event Handler");
        }
    }
}
