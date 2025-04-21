using UnityEditor;

namespace UnityGameFramework.Editor
{
    public abstract class GameFrameworkInspector : UnityEditor.Editor
    {
        private bool m_IsCompiling = false;

        public override void OnInspectorGUI()
        {
            if (m_IsCompiling && !EditorApplication.isCompiling)
            {
                m_IsCompiling = false;
                OnCompileComplete();
            }
            else if (!m_IsCompiling && EditorApplication.isCompiling)
            {
                m_IsCompiling = true;
                OnCompileStart();
            }
        }
        protected virtual void OnCompileStart()
        {

        }

        protected virtual void OnCompileComplete()
        {
        }

        protected bool IsPrefabInHierarchy(UnityEngine.Object @object)
        {
            if (@object == null)
            {
                return false;
            }
            return PrefabUtility.GetPrefabAssetType(@object) != PrefabAssetType.NotAPrefab;
        }
    }
}