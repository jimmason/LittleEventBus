using System;
using System.Collections;
using System.Collections.Generic;
using StructureMap;

namespace LittleEventBus.StructureMap
{
    public sealed class StructureMapEventHandlerResolver : IEventHandlerResolver
    {
        private readonly IContainer container;

        public StructureMapEventHandlerResolver(IContainer container)
        {
            this.container = container;
        }

        public IList Resolve(Type handlerType)
        {
            return container.GetAllInstances(handlerType);
        }
    }
}
