﻿using GameFramework.Base.ReferencePool;
using GameFramework.Base.Variable;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// UnityEngine.Vector3 变量类。
    /// </summary>
    public sealed class VarVector3 : Variable<Vector3>
    {
        /// <summary>
        /// 初始化 UnityEngine.Vector3 变量类的新实例。
        /// </summary>
        public VarVector3()
        {
        }

        /// <summary>
        /// 从 UnityEngine.Vector3 到 UnityEngine.Vector3 变量类的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator VarVector3(Vector3 value)
        {
            VarVector3 varValue = ReferencePool.Acquire<VarVector3>();
            varValue.Value = value;
            return varValue;
        }

        /// <summary>
        /// 从 UnityEngine.Vector3 变量类到 UnityEngine.Vector3 的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator Vector3(VarVector3 value)
        {
            return value.Value;
        }
    }
}
