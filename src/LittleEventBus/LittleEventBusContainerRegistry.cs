using NanoIoC;

namespace LittleEventBus
{
    public sealed class LittleEventBusContainerRegistry : IContainerRegistry
    {
        public void Register(IContainer container)
        {
            container.Register<EventHandlerTypeProcessor>(Lifecycle.Singleton);
        }
    }
}
