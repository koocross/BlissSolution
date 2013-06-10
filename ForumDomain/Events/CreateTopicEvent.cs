using System;
using Forum.CQRS.Core;

namespace Forum.Domain.Events
{
    public class CreateTopicEvent : Event
    {
        public CreateTopicEvent(Guid aggregateId, string id, string author, string title, string content) {
            AggregateId = aggregateId;
            Id = id;
            Author = author;
            Title = title;
            Content = content;
        }

        public Guid AggregateId { get; private set; }
        public string Id { get; private set; }
        public string Author { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
    }
}
