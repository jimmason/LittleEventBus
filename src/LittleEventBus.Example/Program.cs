using System;
using LittleEventBus.Example.Events;
using LittleEventBus.StructureMap;

using StructureMap;

namespace LittleEventBus.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //Do this in your apps startup
            ObjectFactory.Configure(x => { x.For<IEventBus>().Use<SingleThreadedEventBus>(); x.AddRegistry(new LittleEventBusRegistry()); });
            //In reality you want to take a IEventBus in the constructor and register this in your IoC
            var eventBus = ObjectFactory.GetInstance<IEventBus>();
            //Create an event
            var @event = new OrderPlaced(Guid.NewGuid());

            //publish the event
            eventBus.PublishEvent(@event);
        }
    }
}
