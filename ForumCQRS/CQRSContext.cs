using System;
using System.Linq;
using System.Reflection;
using Forum.CQRS.Core;
using Forum.CQRS.Storage;
using StructureMap;

namespace Forum.CQRS
{
// ReSharper disable InconsistentNaming
    public class CQRSContext
// ReSharper restore InconsistentNaming
    {
        private static readonly bool isInitilized;
        private static readonly object syncRoot = new object();
        private static readonly ICommandBus commandBus;
        private static readonly IEventBus eventBus;

        static CQRSContext() {
            if (!isInitilized) {
                lock (syncRoot) {
                    BootstrapStructureMap();
                    commandBus = ObjectFactory.GetInstance<ICommandBus>();
                    eventBus = ObjectFactory.GetInstance<IEventBus>();
                    ((EventBus)eventBus).ScanForSubscribers();
                    isInitilized = true;
                }
            }
        }

        private static void BootstrapStructureMap() {
            ObjectFactory.Initialize(x =>
                {
                    x.For<ICommandBus>().Singleton().Use<CommandBus>();
                    x.For<IEventBus>().Singleton().Use<EventBus>();
                    x.For(typeof(IRepository<>)).Singleton().Use(typeof(Repository<>));
                });
        }

        public static ICommandBus CommandBus {
            get { return commandBus; }
        }
    }
}
