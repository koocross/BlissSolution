using System;
using System.Collections.Generic;
using System.Linq;
using StructureMap;

namespace Forum.CQRS.Core
{
    public interface IEventBus
    {
        IEventHandler<TEvent>[] FindSubscribes<TEvent>(TEvent e) where TEvent : Event;
    }

    internal class EventBus : IEventBus
    {
        private readonly Dictionary<string, List<string>> subscribers = new Dictionary<string, List<string>>();

        public void ScanForSubscribers() {
            var assembliesForSubscribe =
                AppDomain.CurrentDomain.GetAssemblies()
                         .Where(a => a.GetTypes().Any(t => t.GetInterfaces().Contains(typeof(IEvent))));
            foreach (var assembly in assembliesForSubscribe) {
                var eventTypes = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IEvent)));
                foreach (var eventType in eventTypes) {
                    var interfaceType = typeof(IEventHandler<>).MakeGenericType(eventType);
                    var eventHanlderTypes = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(interfaceType)).ToArray();
                    var subscriberTypes = eventHanlderTypes.Select(p => p.FullName).ToList();
                    if (subscriberTypes.Count > 0)
                        subscribers.Add(eventType.FullName, subscriberTypes);
                }
            }
        }

        public IEventHandler<TEvent>[] FindSubscribes<TEvent>(TEvent e) where TEvent : Event {
            if (e == null || subscribers.ContainsKey(e.GetType().FullName))
                return new IEventHandler<TEvent>[0];

            var subscribeKey = e.GetType().FullName;
            var subscriberTypes = subscribers[subscribeKey];
            var resultList = subscriberTypes.Select(Type.GetType)
                                            .Select(ObjectFactory.GetInstance)
                                            .OfType<IEventHandler<TEvent>>()
                                            .ToList();
            return resultList.ToArray();
        }
    }
}