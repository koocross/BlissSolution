namespace Forum.CQRS.Core
{
    public interface IEventHandler<in TEvent> where TEvent : Event
    {
        void Handle(TEvent @event);
    }
}
