using System;
using LittleEventBus.NanoIoC.Extensions;
using NanoIoC;

namespace LittleEventBus.NanoIoC
{
    public sealed class EventHandlerTypeProcessor : ITypeProcessor
    {
        public void Process(Type type, IContainer container)
        {
            if (typeof(IEventHandler<>).IsAssignableToGenericType(type) && type != typeof(IEventHandler<>))
                container.Register(typeof(IEventHandler), type, Lifecycle.Singleton);
        }
    }
}
