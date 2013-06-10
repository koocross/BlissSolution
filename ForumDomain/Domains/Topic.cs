using System;
using System.Collections.Generic;
using Forum.CQRS.Core;
using Forum.Domain.Events;

namespace Forum.Domain.Domains
{
    public class Topic : AggregateRoot, IEventHandler<CreateTopicEvent>
    {
        private readonly List<Reply> replies = new List<Reply>();

        public Topic(string id, string author, string title, string content) : base(Guid.NewGuid()) {
            var createTopicEvent = new CreateTopicEvent(AggregateId, id, author, title, content);
            createTopicEvent.Publish();
        }

        public Topic() : base(Guid.NewGuid()) {

        }

        public string Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Reply[] Replies {
            get { return replies.ToArray(); }
        }

        public void AddReply(string author, string content) {
            var newReply = new Reply {Author = author, Content = content};
            replies.Add(newReply);
        }

        public void Handle(CreateTopicEvent @event) {
            Id = @event.Id;
            Author = @event.Author;
            Title = @event.Title;
            Content = @event.Content;
        }
    }
}
