using System;
using System.Collections;
using System.Linq;
using NanoIoC;

namespace LittleEventBus.NanoIoC
{
    public sealed class NanoIoCEventHandlerResolver : IEventHandlerResolver
    {
        public IList Resolve(Type handlerType)
        {
            return Container.Global.ResolveAll(typeof (IEventHandler))
                .Cast<object>().Where(eventHandler => eventHandler.GetType().GetInterfaces().Contains(handlerType)).ToList();
        }
    }
}
