using LittleEventBus.Testing.Infrastructure.Events;

namespace LittleEventBus.Testing.Infrastructure.EventHandlers
{
    public sealed class EmailUserOnPizzaOrdered : IEventHandler<PizzaOrdered>
    {
        public void Handle(PizzaOrdered @event)
        {
            
        }
    }
}
