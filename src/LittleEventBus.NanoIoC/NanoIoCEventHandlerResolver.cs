using System;
using System.Collections.Generic;
using System.Linq;
using NanoIoC;

namespace LittleEventBus.NanoIoC
{
    public sealed class NanoIoCEventHandlerResolver : IEventHandlerResolver
    {
        public IEnumerable<object> Resolve(Type handlerType)
        {
            return Container.Global.ResolveAll(typeof (IEventHandler))
                .Cast<object>().Where(eventHandler => eventHandler.GetType().GetInterfaces().Contains(handlerType));
        }
    }
}
