using GameFramework.Base;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Utility;
using System;
using System.Collections;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Procedure")]
    public sealed class ProcedureComponent : UnityGameFrameworkComponent
    {
        private IProcedureManager m_ProcedureManager = null;
        private ProcedureBase m_EntranceProcedure = null;


        [SerializeField]
        private string[] m_AvailableProcedureTypeNames = null;

        [SerializeField]
        private string m_EntranceProcedureTypeName = null;

        public ProcedureBase CurrentProcedure => m_ProcedureManager.CurrentProcedure;

        public float CurrentProcedureTime => m_ProcedureManager.CurrentProcedureTime;

        protected override void Awake()
        {
            base.Awake();
            m_ProcedureManager = GameFrameworkEntry.GetModule<IProcedureManager>();
            if (m_ProcedureManager == null)
            {
                Log.Error("Procedure manager is invalid.");
                return;
            }
        }

        private IEnumerator Start()
        {
            ProcedureBase[] procedures = new ProcedureBase[m_AvailableProcedureTypeNames.Length];
            for (int i = 0; i < m_AvailableProcedureTypeNames.Length; i++)
            {
                Type procedureType = Assembly.GetType(m_AvailableProcedureTypeNames[i]);
                if (procedureType == null)
                {
                    Log.Error("Can not find procedure '{0}'.", m_AvailableProcedureTypeNames[i]);
                    yield break;
                }
                procedures[i] = (ProcedureBase)Activator.CreateInstance(procedureType);
                if (procedures[i] == null)
                {
                    Log.Error("Can not create procedure instance '{0}'.", m_AvailableProcedureTypeNames[i]);
                    yield break;
                }
                if (m_EntranceProcedureTypeName == m_AvailableProcedureTypeNames[i])
                {
                    m_EntranceProcedure = procedures[i];
                }
            }
            if (m_EntranceProcedure == null)
            {
                Log.Error("Entrance procedure is invalid.");
                yield break;
            }
            m_ProcedureManager.Initialize(GameFrameworkEntry.GetModule<IFsmManager>(), procedures);
            yield return new WaitForEndOfFrame();
            m_ProcedureManager.StartProcedure(m_EntranceProcedure.GetType());
        }
        
        public bool HasProcedure<T>() where T : ProcedureBase
        {
            return m_ProcedureManager.HasProcedure<T>();
        }

        public bool HasProcedure(Type procedureType)
        {
            return m_ProcedureManager.HasProcedure(procedureType);
        }

        public ProcedureBase GetProcedure<T>() where T : ProcedureBase
        {
            return m_ProcedureManager.GetProcedure<T>();
        }

        public ProcedureBase GetProcedure(Type procedureType)
        {
            return m_ProcedureManager.GetProcedure(procedureType);
        }
    }
}
