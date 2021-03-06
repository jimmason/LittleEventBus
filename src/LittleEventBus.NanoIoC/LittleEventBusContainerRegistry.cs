﻿using NanoIoC;

namespace LittleEventBus.NanoIoC
{
    public sealed class LittleEventBusContainerRegistry : IContainerRegistry
    {
        public void Register(IContainer container)
        {
            container.Register<IEventBus,LittleEventBus>();
            container.Register<IEventHandlerResolver,NanoIoCEventHandlerResolver>();
        }
    }
}
