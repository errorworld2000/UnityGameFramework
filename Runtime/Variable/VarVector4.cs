﻿using GameFramework.Base.ReferencePool;
using GameFramework.Base.Variable;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// UnityEngine.Vector4 变量类。
    /// </summary>
    public sealed class VarVector4 : Variable<Vector4>
    {
        /// <summary>
        /// 初始化 UnityEngine.Vector4 变量类的新实例。
        /// </summary>
        public VarVector4()
        {
        }

        /// <summary>
        /// 从 UnityEngine.Vector4 到 UnityEngine.Vector4 变量类的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator VarVector4(Vector4 value)
        {
            VarVector4 varValue = ReferencePool.Acquire<VarVector4>();
            varValue.Value = value;
            return varValue;
        }

        /// <summary>
        /// 从 UnityEngine.Vector4 变量类到 UnityEngine.Vector4 的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator Vector4(VarVector4 value)
        {
            return value.Value;
        }
    }
}
