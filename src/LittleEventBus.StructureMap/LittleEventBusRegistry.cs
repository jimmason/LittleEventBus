using System;
using StructureMap.Configuration.DSL;

namespace LittleEventBus.StructureMap
{
    public sealed class LittleEventBusRegistry : Registry
    {
        public LittleEventBusRegistry(Type eventHandlerType)
        {

            Scan(x =>
            {
                x.AssemblyContainingType(eventHandlerType);
                x.ConnectImplementationsToTypesClosing(typeof (IEventHandler<>));
            });

            this.For<IEventHandlerResolver>().Use<StructureMapEventHandlerResolver>();
            this.For<IEventBus>().Use<LittleEventBus>();
        }
    }
}
