using Forum.CQRS.Core;
using Forum.CQRS.Storage;
using Forum.Domain.Domains;

namespace Forum.Domain.Commands
{
    public class CreateTopicCommand : Command
    {
        public CreateTopicCommand(string author, string title, string content) {
            Author = author;
            Title = title;
            Content = content;
        }
        
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public sealed class CreateTopicCommandHandler : ICommandHandler<CreateTopicCommand>
    {
        private readonly IRepository<Topic> repository;

        public CreateTopicCommandHandler(IRepository<Topic> repository) {
            this.repository = repository;
        }

        public void Execute(CreateTopicCommand command) {
            var newTopic = new Topic("1", command.Author, command.Title, command.Content);
            repository.Save(newTopic);
        }
    }
}
