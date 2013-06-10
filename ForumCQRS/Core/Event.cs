using System;
using Forum.CQRS.Util;
using StructureMap;

namespace Forum.CQRS.Core
{
    public interface IEvent
    {
        string EventId { get; }
        DateTime CreateTime { get; }
        bool IsPending { get; }

        void Publish();
    }

    public abstract class Event : IEvent
    {
        protected Event() {
            EventId = IdGenerator.CreateNew();
            CreateTime = DateTime.Now;
            IsPending = true;
        }

        public string EventId { get; private set; }
        public DateTime CreateTime { get; private set; }
        public bool IsPending { get; private set; }

        public void Publish() {
            if (!IsPending)
                return;

            var eventBus = ObjectFactory.GetInstance<IEventBus>();
            var handlers = eventBus.FindSubscribes(this);
            foreach (var handler in handlers) {
                handler.Handle(this);
            }
        }
    }
}
