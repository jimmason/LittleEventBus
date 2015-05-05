using System;
using LittleEventBus.Extensions;
using NanoIoC;

namespace LittleEventBus
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
