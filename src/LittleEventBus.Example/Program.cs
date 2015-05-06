using System;
using LittleEventBus.Example.Events;
using NanoIoC;

namespace LittleEventBus.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //Do this in your apps startup
            Container.Global.RunAllTypeProcessors();
            Container.Global.RunAllRegistries();

            //In reality you want to take a IEventBus in the constructor and register this in your IoC
            var eventBus = Container.Global.Resolve<IEventBus>();
            //Create an event
            var @event = new OrderPlaced(Guid.NewGuid());

            //publish the event
            eventBus.PublishEvent(@event);
        }
    }
}
