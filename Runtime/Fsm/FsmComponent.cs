using GameFramework.Base;
using GameFramework.Fsm;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/FSM")]
    public sealed class FsmComponent : UnityGameFrameworkComponent
    {
        private IFsmManager m_FsmManager = null;
        public int Count => m_FsmManager.Count;
        protected override void Awake()
        {
            base.Awake();
            m_FsmManager = GameFrameworkEntry.GetModule<IFsmManager>();
            if (m_FsmManager == null)
            {
                Log.Error("FSM manager is invalid.");
                return;
            }
        }
        private void Start()
        {

        }
        public bool HasFsm<T>() where T : class => m_FsmManager.HasFsm<T>();
        public bool HasFsm(Type ownerType) => m_FsmManager.HasFsm(ownerType);
        public bool HasFsm<T>(string name) where T : class => m_FsmManager.HasFsm<T>(name);
        public bool HasFsm(Type ownerType, string name) => m_FsmManager.HasFsm(ownerType, name);
        public IFsm<T> GetFsm<T>() where T : class => m_FsmManager.GetFsm<T>();
        public FsmBase GetFsm(Type ownerType) => m_FsmManager.GetFsm(ownerType);
        public IFsm<T> GetFsm<T>(string name) where T : class => m_FsmManager.GetFsm<T>(name);
        public FsmBase GetFsm(Type ownerType, string name) => m_FsmManager.GetFsm(ownerType, name);
        public FsmBase[] GetAllFsms() => m_FsmManager.GetAllFsms();
        public void GetAllFsms(List<FsmBase> results) => m_FsmManager.GetAllFsms(results);
        public IFsm<T> CreateFsm<T>(T owner, IEnumerable<FsmState<T>> states) where T : class => m_FsmManager.CreateFsm(owner, states);
        public IFsm<T> CreateFsm<T>(string name, T owner, IEnumerable<FsmState<T>> states) where T : class => m_FsmManager.CreateFsm(name, owner, states);
        public bool DestroyFsm<T>() where T : class => m_FsmManager.DestroyFsm<T>();
        public bool DestroyFsm(Type ownerType) => m_FsmManager.DestroyFsm(ownerType);
        public bool DestroyFsm<T>(string name) where T : class => m_FsmManager.DestroyFsm<T>(name);
        public bool DestroyFsm(Type ownerType, string name) => m_FsmManager.DestroyFsm(ownerType, name);
        public bool DestroyFsm<T>(IFsm<T> fsm) where T : class => m_FsmManager.DestroyFsm(fsm);
        public bool DestroyFsm(FsmBase fsm) => m_FsmManager.DestroyFsm(fsm);
    }
}