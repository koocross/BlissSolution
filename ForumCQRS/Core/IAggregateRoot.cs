using System;
using System.Collections.Generic;

namespace Forum.CQRS.Core
{
    public interface IEventProvider
    {
        IEvent[] GetPendingEvents();

        IEvent[] GetCommitedEvents();
    }

    public interface IAggregateRoot : IEventProvider
    {
        Guid AggregateId { get; }
    }

    public abstract class AggregateRoot : IAggregateRoot
    {
        protected readonly List<Event> events = new List<Event>();

        protected AggregateRoot(Guid aggregateId) {
            AggregateId = aggregateId;
        }

        public Guid AggregateId { get; private set; }

        public IEvent[] GetPendingEvents() {
            throw new NotImplementedException();
        }

        public IEvent[] GetCommitedEvents() {
            throw new NotImplementedException();
        }
    }
}
