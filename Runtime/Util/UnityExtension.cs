using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.Runtime
{

    public static class UnityExtension
    {
        private static readonly List<Transform> s_CachedTransforms = new List<Transform>();

        /// <summary>
        /// ��ȡ�����������
        /// </summary>
        /// <typeparam name="T">Ҫ��ȡ�����ӵ������</typeparam>
        /// <param name="gameObject">Ŀ�����</param>
        /// <returns>��ȡ�����ӵ������</returns>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            if (component == null)
            {
                component = gameObject.AddComponent<T>();
            }

            return component;
        }

        /// <summary>
        /// ��ȡ�����������
        /// </summary>
        /// <param name="gameObject">Ŀ�����</param>
        /// <param name="type">Ҫ��ȡ�����ӵ�������͡�</param>
        /// <returns>��ȡ�����ӵ������</returns>
        public static Component GetOrAddComponent(this GameObject gameObject, Type type)
        {
            Component component = gameObject.GetComponent(type);
            if (component == null)
            {
                component = gameObject.AddComponent(type);
            }

            return component;
        }

        /// <summary>
        /// ��ȡ GameObject �Ƿ��ڳ����С�
        /// </summary>
        /// <param name="gameObject">Ŀ�����</param>
        /// <returns>GameObject �Ƿ��ڳ����С�</returns>
        /// <remarks>������ true�������� GameObject ��һ�������е�ʵ������������ false�������� GameObject ��һ�� Prefab��</remarks>
        public static bool InScene(this GameObject gameObject)
        {
            return gameObject.scene.name != null;
        }

        /// <summary>
        /// �ݹ�������Ϸ����Ĳ�Ρ�
        /// </summary>
        /// <param name="gameObject"><see cref="GameObject" /> ����</param>
        /// <param name="layer">Ŀ���εı�š�</param>
        public static void SetLayerRecursively(this GameObject gameObject, int layer)
        {
            gameObject.GetComponentsInChildren(true, s_CachedTransforms);
            for (int i = 0; i < s_CachedTransforms.Count; i++)
            {
                s_CachedTransforms[i].gameObject.layer = layer;
            }

            s_CachedTransforms.Clear();
        }

        /// <summary>
        /// ȡ <see cref="Vector3" /> �� (x, y, z) ת��Ϊ <see cref="Vector2" /> �� (x, z)��
        /// </summary>
        /// <param name="vector3">Ҫת���� Vector3��</param>
        /// <returns>ת����� Vector2��</returns>
        public static Vector2 ToVector2(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.z);
        }

        /// <summary>
        /// ȡ <see cref="Vector2" /> �� (x, y) ת��Ϊ <see cref="Vector3" /> �� (x, 0, y)��
        /// </summary>
        /// <param name="vector2">Ҫת���� Vector2��</param>
        /// <returns>ת����� Vector3��</returns>
        public static Vector3 ToVector3(this Vector2 vector2)
        {
            return new Vector3(vector2.x, 0f, vector2.y);
        }

        /// <summary>
        /// ȡ <see cref="Vector2" /> �� (x, y) �͸������� y ת��Ϊ <see cref="Vector3" /> �� (x, ���� y, y)��
        /// </summary>
        /// <param name="vector2">Ҫת���� Vector2��</param>
        /// <param name="y">Vector3 �� y ֵ��</param>
        /// <returns>ת����� Vector3��</returns>
        public static Vector3 ToVector3(this Vector2 vector2, float y)
        {
            return new Vector3(vector2.x, y, vector2.y);
        }

        #region Transform

        /// <summary>
        /// ���þ���λ�õ� x ���ꡣ
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="newValue">x ����ֵ��</param>
        public static void SetPositionX(this Transform transform, float newValue)
        {
            Vector3 v = transform.position;
            v.x = newValue;
            transform.position = v;
        }

        /// <summary>
        /// ���þ���λ�õ� y ���ꡣ
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="newValue">y ����ֵ��</param>
        public static void SetPositionY(this Transform transform, float newValue)
        {
            Vector3 v = transform.position;
            v.y = newValue;
            transform.position = v;
        }

        /// <summary>
        /// ���þ���λ�õ� z ���ꡣ
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="newValue">z ����ֵ��</param>
        public static void SetPositionZ(this Transform transform, float newValue)
        {
            Vector3 v = transform.position;
            v.z = newValue;
            transform.position = v;
        }

        /// <summary>
        /// ���Ӿ���λ�õ� x ���ꡣ
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="deltaValue">x ����ֵ������</param>
        public static void AddPositionX(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.position;
            v.x += deltaValue;
            transform.position = v;
        }

        /// <summary>
        /// ���Ӿ���λ�õ� y ���ꡣ
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="deltaValue">y ����ֵ������</param>
        public static void AddPositionY(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.position;
            v.y += deltaValue;
            transform.position = v;
        }

        /// <summary>
        /// ���Ӿ���λ�õ� z ���ꡣ
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="deltaValue">z ����ֵ������</param>
        public static void AddPositionZ(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.position;
            v.z += deltaValue;
            transform.position = v;
        }

        /// <summary>
        /// �������λ�õ� x ���ꡣ
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="newValue">x ����ֵ��</param>
        public static void SetLocalPositionX(this Transform transform, float newValue)
        {
            Vector3 v = transform.localPosition;
            v.x = newValue;
            transform.localPosition = v;
        }

        /// <summary>
        /// �������λ�õ� y ���ꡣ
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="newValue">y ����ֵ��</param>
        public static void SetLocalPositionY(this Transform transform, float newValue)
        {
            Vector3 v = transform.localPosition;
            v.y = newValue;
            transform.localPosition = v;
        }

        /// <summary>
        /// �������λ�õ� z ���ꡣ
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="newValue">z ����ֵ��</param>
        public static void SetLocalPositionZ(this Transform transform, float newValue)
        {
            Vector3 v = transform.localPosition;
            v.z = newValue;
            transform.localPosition = v;
        }

        /// <summary>
        /// �������λ�õ� x ���ꡣ
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="deltaValue">x ����ֵ��</param>
        public static void AddLocalPositionX(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.localPosition;
            v.x += deltaValue;
            transform.localPosition = v;
        }

        /// <summary>
        /// �������λ�õ� y ���ꡣ
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="deltaValue">y ����ֵ��</param>
        public static void AddLocalPositionY(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.localPosition;
            v.y += deltaValue;
            transform.localPosition = v;
        }

        /// <summary>
        /// �������λ�õ� z ���ꡣ
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="deltaValue">z ����ֵ��</param>
        public static void AddLocalPositionZ(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.localPosition;
            v.z += deltaValue;
            transform.localPosition = v;
        }

        /// <summary>
        /// ������Գߴ�� x ������
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="newValue">x ����ֵ��</param>
        public static void SetLocalScaleX(this Transform transform, float newValue)
        {
            Vector3 v = transform.localScale;
            v.x = newValue;
            transform.localScale = v;
        }

        /// <summary>
        /// ������Գߴ�� y ������
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="newValue">y ����ֵ��</param>
        public static void SetLocalScaleY(this Transform transform, float newValue)
        {
            Vector3 v = transform.localScale;
            v.y = newValue;
            transform.localScale = v;
        }

        /// <summary>
        /// ������Գߴ�� z ������
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="newValue">z ����ֵ��</param>
        public static void SetLocalScaleZ(this Transform transform, float newValue)
        {
            Vector3 v = transform.localScale;
            v.z = newValue;
            transform.localScale = v;
        }

        /// <summary>
        /// ������Գߴ�� x ������
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="deltaValue">x ����������</param>
        public static void AddLocalScaleX(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.localScale;
            v.x += deltaValue;
            transform.localScale = v;
        }

        /// <summary>
        /// ������Գߴ�� y ������
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="deltaValue">y ����������</param>
        public static void AddLocalScaleY(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.localScale;
            v.y += deltaValue;
            transform.localScale = v;
        }

        /// <summary>
        /// ������Գߴ�� z ������
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="deltaValue">z ����������</param>
        public static void AddLocalScaleZ(this Transform transform, float deltaValue)
        {
            Vector3 v = transform.localScale;
            v.z += deltaValue;
            transform.localScale = v;
        }

        /// <summary>
        /// ��ά�ռ���ʹ <see cref="Transform" /> ָ��ָ��Ŀ�����㷨��ʹ���������ꡣ
        /// </summary>
        /// <param name="transform"><see cref="Transform" /> ����</param>
        /// <param name="lookAtPoint2D">Ҫ����Ķ�ά����㡣</param>
        /// <remarks>�ٶ��� forward ����Ϊ <see cref="Vector3.up" />��</remarks>
        public static void LookAt2D(this Transform transform, Vector2 lookAtPoint2D)
        {
            Vector3 vector = lookAtPoint2D.ToVector3() - transform.position;
            vector.y = 0f;

            if (vector.magnitude > 0f)
            {
                transform.rotation = Quaternion.LookRotation(vector.normalized, Vector3.up);
            }
        }

        #endregion Transform
    }

}