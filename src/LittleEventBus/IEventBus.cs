
namespace LittleEventBus
{
    public interface IEventBus
    {
        void PublishEvent(Event @event);
        void PublishEventAsync(Event @event);
    }
}
