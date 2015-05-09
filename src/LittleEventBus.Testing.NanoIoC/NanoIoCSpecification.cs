using LittleEventBus.Testing.Infrastructure;
using NanoIoC;

namespace LittleEventBus.Testing.NanoIoC
{
    public abstract class NanoIoCSpecification : Specification
    {
        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();

            Container.Global.RunAllRegistries();
            Container.Global.RunAllTypeProcessors();
        }
    }
}
