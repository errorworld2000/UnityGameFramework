
using GameFramework.Utility;
using UnityEditor.Playables;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// ��������������ص�ʵ�ú�����
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// ������������
        /// </summary>
        /// <typeparam name="T">Ҫ�����ĸ��������͡�</typeparam>
        /// <param name="helperTypeName">Ҫ�����ĸ������������ơ�</param>
        /// <param name="customHelper">��Ҫ�����ĸ���������Ϊ��ʱ��ʹ�õ��Զ��帨�������͡�</param>
        /// <returns>�����ĸ�������</returns>
        public static T CreateHelper<T>(string helperTypeName, T customHelper) where T : MonoBehaviour
        {
            return CreateHelper(helperTypeName, customHelper, 0);
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <typeparam name="T">Ҫ�����ĸ��������͡�</typeparam>
        /// <param name="helperTypeName">Ҫ�����ĸ������������ơ�</param>
        /// <param name="customHelper">��Ҫ�����ĸ���������Ϊ��ʱ��ʹ�õ��Զ��帨�������͡�</param>
        /// <param name="index">Ҫ�����ĸ�����������</param>
        /// <returns>�����ĸ�������</returns>
        public static T CreateHelper<T>(string helperTypeName, T customHelper, int index) where T : MonoBehaviour
        {
            T helper = null;
            if (!string.IsNullOrEmpty(helperTypeName))
            {
                System.Type helperType = Assembly.GetType(helperTypeName);
                if (helperType == null)
                {
                    Log.Warning("Can not find helper type '{0}'.", helperTypeName);
                    return null;
                }

                if (!typeof(T).IsAssignableFrom(helperType))
                {
                    Log.Warning("Type '{0}' is not assignable from '{1}'.", typeof(T).FullName, helperType.FullName);
                    return null;
                }

                helper = (T)new GameObject().AddComponent(helperType);
            }
            else if (customHelper == null)
            {
                Log.Warning("You must set custom helper with '{0}' type first.", typeof(T).FullName);
                return null;
            }
            else if (customHelper.gameObject.InScene())
            {
                helper = index > 0 ? Object.Instantiate(customHelper) : customHelper;
            }
            else
            {
                helper = Object.Instantiate(customHelper);
            }

            return helper;
        }
    }
}
