﻿using GameFramework.Base.ReferencePool;
using System;

namespace UnityGameFramework.Runtime
{
    internal sealed class ShowEntityInfo : IReference
    {
        private Type m_EntityLogicType;
        private object m_UserData;

        public ShowEntityInfo()
        {
            m_EntityLogicType = null;
            m_UserData = null;
        }

        public Type EntityLogicType
        {
            get
            {
                return m_EntityLogicType;
            }
        }

        public object UserData
        {
            get
            {
                return m_UserData;
            }
        }

        public static ShowEntityInfo Create(Type entityLogicType, object userData)
        {
            ShowEntityInfo showEntityInfo = ReferencePool.Acquire<ShowEntityInfo>();
            showEntityInfo.m_EntityLogicType = entityLogicType;
            showEntityInfo.m_UserData = userData;
            return showEntityInfo;
        }

        public void Clear()
        {
            m_EntityLogicType = null;
            m_UserData = null;
        }
    }
}
