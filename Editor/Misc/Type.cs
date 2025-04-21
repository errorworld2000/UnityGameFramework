using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.Playables;

namespace UnityGameFramework.Editor
{
    internal static class Type
    {
        private static readonly string[] AssemblyNames = { "UnityGameFramework.Runtime", "Assembly-CSharp" };
        private static readonly string[] EditorAssemblyNames = { "UnityGameFramework.Editor", "Assembly-CSharp" };

        internal static string GetConfigurationPath<T>() where T : ConfigPathAttribute
        {
            foreach (System.Type type in GameFramework.Utility.Assembly.GetTypes())
            {
                if (!type.IsAbstract || !type.IsSealed)
                {
                    continue;
                }

                foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
                {
                    if (fieldInfo.FieldType == typeof(string) && fieldInfo.IsDefined(typeof(T), false))
                    {
                        return (string)fieldInfo.GetValue(null);
                    }
                }

                foreach (PropertyInfo propertyInfo in type.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
                {
                    if (propertyInfo.PropertyType == typeof(string) && propertyInfo.IsDefined(typeof(T), false))
                    {
                        return (string)propertyInfo.GetValue(null, null);
                    }
                }
            }

            return null;
        }

        internal static string[] GetTypeNames(System.Type typeBase)
        {
            return GetTypeNames(typeBase, AssemblyNames);
        }

        internal static string[] GetEditorTypeNames(System.Type typeBase)
        {
            return GetTypeNames(typeBase, EditorAssemblyNames);
        }

        private static string[] GetTypeNames(System.Type typeBase, string[] assemblyNames)
        {
            List<string> typeNames = new List<string>();
            foreach (var assemblyName in assemblyNames)
            {
                Assembly assembly = null;
                try
                {
                    assembly = Assembly.Load(assemblyName);
                }
                catch (Exception)
                {
                    continue;
                }
                if (assembly == null)
                {
                    continue;
                }
                System.Type[] types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.IsClass && !type.IsAbstract && typeBase.IsAssignableFrom(type))
                    {
                        typeNames.Add(type.FullName);
                    }
                }
            }
            typeNames.Sort();
            return typeNames.ToArray();
        }
    }
}