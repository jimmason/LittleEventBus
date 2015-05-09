using System;
using LittleEventBus.Testing.Infrastructure;
using LittleEventBus.Testing.Infrastructure.Events;
using StructureMap;

namespace LittleEventBus.Testing.StructureMap.Acceptance
{
    public sealed class GivenAnEventIsPlacedOnTheBus : StructureMapSpecification
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
            ObjectFactory.GetInstance<IEventBus>().PublishEvent(this.@event);
        }

        [Then]
        public void ThenTheCorrectAmountEventHandlersShouldBeReturnedFromTheResolver()
        {   
            var eventHandlers = ObjectFactory.GetInstance<IEventHandlerResolver>().Resolve(handlerType);

            eventHandlers.Count.ShouldEqual(2);    
        }

        [Then]
        public void AndTheEventHandlersShouldBeOfTheCorrectType()
        {
            var eventHandlers = ObjectFactory.GetInstance<IEventHandlerResolver>().Resolve(handlerType);

            foreach (var eventHandler in eventHandlers)
            {
                eventHandler.ShouldBeOfType(handlerType);
            }
        }
    }
}
