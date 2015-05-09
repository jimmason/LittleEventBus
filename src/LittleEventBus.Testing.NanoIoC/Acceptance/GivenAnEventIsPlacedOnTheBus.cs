using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LittleEventBus.Testing.Infrastructure;
using LittleEventBus.Testing.Infrastructure.Events;
using NanoIoC;

namespace LittleEventBus.Testing.NanoIoC.Acceptance
{
    public sealed class GivenAnEventIsPlacedOnTheBus : NanoIoCSpecification
    {
        private PizzaOrdered @event;
        private Type handlerType;

        protected override void Given()
        {
            base.Given();

            this.@event = new PizzaOrdered();

            this.handlerType = typeof(IEventHandler<>).MakeGenericType(this.@event.GetType());
        }

        protected override void When()
        {
            Container.Global.Resolve<IEventBus>().PublishEvent(@event);
        }

        [Then]
        public void ThenTheCorrectAmountEventHandlersShouldBeReturnedFromTheResolver()
        {
            var eventHandlers = Container.Global.Resolve<IEventHandlerResolver>().Resolve(handlerType);

            eventHandlers.Count.ShouldEqual(2);
        }

        [Then]
        public void AndTheEventHandlersShouldBeOfTheCorrectType()
        {
            var eventHandlers = Container.Global.Resolve<IEventHandlerResolver>().Resolve(handlerType);

            foreach (var eventHandler in eventHandlers)
            {
                eventHandler.ShouldBeOfType(handlerType);
            }
        }
    }
}
