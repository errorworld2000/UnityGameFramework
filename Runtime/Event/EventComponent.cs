using GameFramework.Base;
using GameFramework.Event;
using System;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Event")]
    public sealed class EventComponent : UnityGameFrameworkComponent
    {
        private IEventManager m_EventManager = null;

        public int EventHandlerCount => m_EventManager.EventHandlerCount;

        public int EventCount => m_EventManager.EventCount;

        protected override void Awake()
        {
            base.Awake();
            m_EventManager = GameFrameworkEntry.GetModule<IEventManager>();
            if (m_EventManager == null)
            {
                Log.Fatal("Event manager is invalid.");
                return;
            }
        }

        public int Count(int id) => m_EventManager.Count(id);

        public bool Check(int id, EventHandler<GameEventArgs> handler) => m_EventManager.Check(id, handler);

        public void Subscribe(int id, EventHandler<GameEventArgs> handler) => m_EventManager.Subscribe(id, handler);

        public void Unsubscribe(int id, EventHandler<GameEventArgs> handler) => m_EventManager.Unsubscribe(id, handler);

        public void SetDefaultHandler(EventHandler<GameEventArgs> handler) => m_EventManager.SetDefaultHandler(handler);

        public void Fire(object sender, GameEventArgs e) => m_EventManager.Fire(sender, e);

        public void FireNow(object sender, GameEventArgs e) => m_EventManager.FireNow(sender, e);
    }
}