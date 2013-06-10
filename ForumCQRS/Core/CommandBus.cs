using System;
using System.Collections.Generic;
using System.Reflection;
using Forum.CQRS.Exceptions;
using StructureMap;

namespace Forum.CQRS.Core
{
    public interface ICommandBus
    {
        ICommandBus Register(string commandType, string handlerType);
    }

    internal class CommandBus : ICommandBus
    {
        private static readonly IDictionary<string, string> handlers = new Dictionary<string, string>();

        public ICommandBus Register(string commandType, string handlerType) {
            if (handlers.ContainsKey(commandType))
                handlers[commandType] = handlerType;
            else
                handlers.Add(commandType, handlerType);
            return this;
        }

        internal void Recieve<TCommand>(TCommand command) where TCommand : Command {
            var commandType = command.GetType().AssemblyQualifiedName;
            var handlerType = handlers.ContainsKey(commandType) ? Type.GetType(handlers[commandType]) : null;
            if (handlerType == null)
                throw new UnRegisteredCommandException();

            var handler = ObjectFactory.GetInstance(handlerType);
            handlerType.InvokeMember("Execute", BindingFlags.InvokeMethod, null, handler,
                                     new object[] {command});
        }
    }
}
