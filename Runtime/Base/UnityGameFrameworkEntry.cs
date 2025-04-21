using GameFramework.Base;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public static class UnityGameFrameworkEntry
    {
        private readonly static GameFrameworkLinkedList<UnityGameFrameworkComponent> s_GameFrameworkComponents = new GameFrameworkLinkedList<UnityGameFrameworkComponent>();

        internal const int GameFrameworkSceneId = 0;
        public static T GetComponent<T>() where T : UnityGameFrameworkComponent => (T)GetComponent(typeof(T));

        private static UnityGameFrameworkComponent GetComponent(Type type)
        {
            LinkedListNode<UnityGameFrameworkComponent> current = s_GameFrameworkComponents.First;
            while (current != null)
            {
                if (current.Value.GetType() == type)
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return null;
        }

        public static UnityGameFrameworkComponent GetComponent(string typeName)
        {
            LinkedListNode<UnityGameFrameworkComponent> current = s_GameFrameworkComponents.First;
            while (current != null)
            {
                Type type = current.Value.GetType();
                if (type.FullName == typeName || type.Name == typeName)
                {
                    return current.Value;
                }

                current = current.Next;
            }

            return null;
        }

        public static void Shutdown(ShutdownType shutdownType)
        {
            Log.Info("Shutdown Game Framework ({0})...", shutdownType.ToString());
            BaseComponent baseComponent = GetComponent<BaseComponent>();
            if (baseComponent != null)
            {
                baseComponent.Shutdown();
                baseComponent = null;
            }
            s_GameFrameworkComponents.Clear();
            if (shutdownType == ShutdownType.None)
            {
                return;
            }
            else if (shutdownType == ShutdownType.Restart)
            {
                Log.Info("Restarting...");
                UnityEngine.SceneManagement.SceneManager.LoadScene(GameFrameworkSceneId);
                return;
            }
            else if (shutdownType == ShutdownType.Quit)
            {
                Log.Info("Quitting...");
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                return;
            }
        }

        internal static void RegisterComponent(UnityGameFrameworkComponent component)
        {
            if (component == null)
            {
                Log.Error("UnityGameFrameworkComponent is invalid.");
            }
            Type type = component.GetType();
            LinkedListNode<UnityGameFrameworkComponent> current = s_GameFrameworkComponents.First;
            while (current != null)
            {
                if (current.Value.GetType() == type)
                {
                    Log.Error("UnityGameFrameworkComponent type '{0}' is already exist.", type.FullName);
                    return;
                }
                current = current.Next;
            }
            s_GameFrameworkComponents.AddLast(component);
        }
    }

}