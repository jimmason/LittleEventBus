namespace LittleEventBus
{
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : class
    {
        void Handle(TEvent @event);
    }

    public interface IEventHandler
    {
    }
}
