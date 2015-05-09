using StructureMap.Configuration.DSL;

namespace LittleEventBus.StructureMap
{
    public sealed class LittleEventBusRegistry : Registry
    {
        public LittleEventBusRegistry()
        {

            Scan(x =>
            {
                x.AssembliesFromApplicationBaseDirectory();
                x.ConnectImplementationsToTypesClosing(typeof (IEventHandler<>));
            });

            this.For<IEventHandlerResolver>().Use<StructureMapEventHandlerResolver>();
            this.For<IEventBus>().Use<LittleEventBus>();
        }
    }
}
