using System;
using System.Collections;

namespace LittleEventBus
{
    public interface IEventHandlerResolver
    {
        IList Resolve(Type handlerType);
    }
}
