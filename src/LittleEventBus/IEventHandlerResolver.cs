using System;
using System.Collections.Generic;

namespace LittleEventBus
{
    public interface IEventHandlerResolver
    {
        IEnumerable<object> Resolve(Type handlerType);
    }
}
