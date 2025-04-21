using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public abstract class UnityGameFrameworkComponent : MonoBehaviour
    {
        protected virtual void Awake()
        {
            UnityGameFrameworkEntry.RegisterComponent(this);
        }
    }
}