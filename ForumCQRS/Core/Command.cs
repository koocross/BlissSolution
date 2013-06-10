using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace Forum.CQRS.Core
{
    public interface ICommand
    {
        void Send();
    }

    public abstract class Command : ICommand
    {
        public void Send() {
            var commandBus = ObjectFactory.GetInstance<CommandBus>();
            commandBus.Recieve(this);
        }
    }
}
