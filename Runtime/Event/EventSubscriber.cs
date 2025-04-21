using GameFramework.Base;
using GameFramework.Base.ReferencePool;
using GameFramework.Event;
using System;

namespace UnityGameFramework.Runtime.Event
{
    public class EventSubscriber : IReference
    {
        private IEventManager m_EventManager = null;

        private GameFrameworkMultiDictionary<int, EventHandler<GameEventArgs>> dicEventHandler = new GameFrameworkMultiDictionary<int, EventHandler<GameEventArgs>>();

        public object Owner { get; private set; }

        public static EventSubscriber Create(object owner)
        {
            EventSubscriber eventSubscriber = ReferencePool.Acquire<EventSubscriber>();
            eventSubscriber.Owner = owner;
            eventSubscriber.m_EventManager ??= GameFrameworkEntry.GetModule<IEventManager>();

            return eventSubscriber;
        }

        public EventSubscriber()
        {
            Owner = null;
            dicEventHandler = new GameFrameworkMultiDictionary<int, EventHandler<GameEventArgs>>();
        }

        public void Subscribe(int id, EventHandler<GameEventArgs> handler)
        {
            if (handler == null)
            {
                throw new Exception("Event handler is invalid.");
            }

            dicEventHandler.Add(id, handler);
            m_EventManager.Subscribe(id, handler);
        }

        public void Unsubscribe(int id, EventHandler<GameEventArgs> handler)
        {
            if (!dicEventHandler.Remove(id, handler))
            {
                throw new Exception(string.Format("Event '{0}' not exists specified handler.", id.ToString()));
            }

            m_EventManager.Unsubscribe(id, handler);
        }

        public void UnsubscribeAll()
        {
            foreach (var item in dicEventHandler)
            {
                foreach (var eventHandler in item.Value)
                {
                    m_EventManager.Unsubscribe(item.Key, eventHandler);
                }
            }

            dicEventHandler.Clear();
        }

        public void Clear()
        {
            UnsubscribeAll();
            dicEventHandler.Clear();
            m_EventManager = null;
            Owner = null;
        }
    }
}