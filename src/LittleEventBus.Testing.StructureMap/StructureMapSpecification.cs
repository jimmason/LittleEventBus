using LittleEventBus.StructureMap;
using LittleEventBus.Testing.Infrastructure;
using LittleEventBus.Testing.Infrastructure.EventHandlers;
using StructureMap;

namespace LittleEventBus.Testing.StructureMap
{
    public abstract class StructureMapSpecification : Specification
    {
        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();

            ObjectFactory.Configure(x =>
            {
                 x.AddRegistry(new LittleEventBusRegistry(typeof(EmailUserOnPizzaOrdered)));
            });
        }
    }
}
