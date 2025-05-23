﻿using GameFramework.Base.ReferencePool;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    internal sealed class WWWFormInfo : IReference
    {
        private WWWForm m_WWWForm;
        private object m_UserData;

        public WWWFormInfo()
        {
            m_WWWForm = null;
            m_UserData = null;
        }

        public WWWForm WWWForm
        {
            get
            {
                return m_WWWForm;
            }
        }

        public object UserData
        {
            get
            {
                return m_UserData;
            }
        }

        public static WWWFormInfo Create(WWWForm wwwForm, object userData)
        {
            WWWFormInfo wwwFormInfo = ReferencePool.Acquire<WWWFormInfo>();
            wwwFormInfo.m_WWWForm = wwwForm;
            wwwFormInfo.m_UserData = userData;
            return wwwFormInfo;
        }

        public void Clear()
        {
            m_WWWForm = null;
            m_UserData = null;
        }
    }
}
