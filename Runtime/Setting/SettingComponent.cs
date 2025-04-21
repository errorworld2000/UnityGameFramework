using GameFramework.Base;
using GameFramework.Setting;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.Runtime
{

    /// <summary>
    /// ��Ϸ���������
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Setting")]
    public sealed class SettingComponent : UnityGameFrameworkComponent
    {
        private ISettingManager m_SettingManager = null;

        [SerializeField]
        private string m_SettingHelperTypeName = "UnityGameFramework.Runtime.DefaultSettingHelper";

        [SerializeField]
        private SettingHelperBase m_CustomSettingHelper = null;

        /// <summary>
        /// ��ȡ��Ϸ������������
        /// </summary>
        public int Count
        {
            get
            {
                return m_SettingManager.Count;
            }
        }

        /// <summary>
        /// ��Ϸ��������ʼ����
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            m_SettingManager = GameFrameworkEntry.GetModule<ISettingManager>();
            if (m_SettingManager == null)
            {
                Log.Fatal("Setting manager is invalid.");
                return;
            }

            SettingHelperBase settingHelper = Helper.CreateHelper(m_SettingHelperTypeName, m_CustomSettingHelper);
            if (settingHelper == null)
            {
                Log.Error("Can not create setting helper.");
                return;
            }

            settingHelper.name = "Setting Helper";
            Transform transform = settingHelper.transform;
            transform.SetParent(this.transform);
            transform.localScale = Vector3.one;

            m_SettingManager.SetSettingHelper(settingHelper);
        }

        private void Start()
        {
            if (!m_SettingManager.Load())
            {
                Log.Error("Load settings failure.");
            }
        }

        /// <summary>
        /// ������Ϸ���á�
        /// </summary>
        public void Save()
        {
            m_SettingManager.Save();
        }

        /// <summary>
        /// ��ȡ������Ϸ����������ơ�
        /// </summary>
        /// <returns>������Ϸ����������ơ�</returns>
        public string[] GetAllSettingNames()
        {
            return m_SettingManager.GetAllSettingNames();
        }

        /// <summary>
        /// ��ȡ������Ϸ����������ơ�
        /// </summary>
        /// <param name="results">������Ϸ����������ơ�</param>
        public void GetAllSettingNames(List<string> results)
        {
            m_SettingManager.GetAllSettingNames(results);
        }

        /// <summary>
        /// ����Ƿ����ָ����Ϸ�����
        /// </summary>
        /// <param name="settingName">Ҫ�����Ϸ����������ơ�</param>
        /// <returns>ָ������Ϸ�������Ƿ���ڡ�</returns>
        public bool HasSetting(string settingName)
        {
            return m_SettingManager.HasSetting(settingName);
        }

        /// <summary>
        /// �Ƴ�ָ����Ϸ�����
        /// </summary>
        /// <param name="settingName">Ҫ�Ƴ���Ϸ����������ơ�</param>
        public void RemoveSetting(string settingName)
        {
            m_SettingManager.RemoveSetting(settingName);
        }

        /// <summary>
        /// ���������Ϸ�����
        /// </summary>
        public void RemoveAllSettings()
        {
            m_SettingManager.RemoveAllSettings();
        }

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ����ֵ��
        /// </summary>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <returns>��ȡ�Ĳ���ֵ��</returns>
        public bool GetBool(string settingName)
        {
            return m_SettingManager.GetBool(settingName);
        }

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ����ֵ��
        /// </summary>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <param name="defaultValue">��ָ������Ϸ���������ʱ�����ش�Ĭ��ֵ��</param>
        /// <returns>��ȡ�Ĳ���ֵ��</returns>
        public bool GetBool(string settingName, bool defaultValue)
        {
            return m_SettingManager.GetBool(settingName, defaultValue);
        }

        /// <summary>
        /// ��ָ����Ϸ������д�벼��ֵ��
        /// </summary>
        /// <param name="settingName">Ҫд����Ϸ����������ơ�</param>
        /// <param name="value">Ҫд��Ĳ���ֵ��</param>
        public void SetBool(string settingName, bool value)
        {
            m_SettingManager.SetBool(settingName, value);
        }

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ����ֵ��
        /// </summary>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <returns>��ȡ������ֵ��</returns>
        public int GetInt(string settingName)
        {
            return m_SettingManager.GetInt(settingName);
        }

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ����ֵ��
        /// </summary>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <param name="defaultValue">��ָ������Ϸ���������ʱ�����ش�Ĭ��ֵ��</param>
        /// <returns>��ȡ������ֵ��</returns>
        public int GetInt(string settingName, int defaultValue)
        {
            return m_SettingManager.GetInt(settingName, defaultValue);
        }

        /// <summary>
        /// ��ָ����Ϸ������д������ֵ��
        /// </summary>
        /// <param name="settingName">Ҫд����Ϸ����������ơ�</param>
        /// <param name="value">Ҫд�������ֵ��</param>
        public void SetInt(string settingName, int value)
        {
            m_SettingManager.SetInt(settingName, value);
        }

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ������ֵ��
        /// </summary>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <returns>��ȡ�ĸ�����ֵ��</returns>
        public float GetFloat(string settingName)
        {
            return m_SettingManager.GetFloat(settingName);
        }

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ������ֵ��
        /// </summary>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <param name="defaultValue">��ָ������Ϸ���������ʱ�����ش�Ĭ��ֵ��</param>
        /// <returns>��ȡ�ĸ�����ֵ��</returns>
        public float GetFloat(string settingName, float defaultValue)
        {
            return m_SettingManager.GetFloat(settingName, defaultValue);
        }

        /// <summary>
        /// ��ָ����Ϸ������д�븡����ֵ��
        /// </summary>
        /// <param name="settingName">Ҫд����Ϸ����������ơ�</param>
        /// <param name="value">Ҫд��ĸ�����ֵ��</param>
        public void SetFloat(string settingName, float value)
        {
            m_SettingManager.SetFloat(settingName, value);
        }

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ�ַ���ֵ��
        /// </summary>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <returns>��ȡ���ַ���ֵ��</returns>
        public string GetString(string settingName)
        {
            return m_SettingManager.GetString(settingName);
        }

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ�ַ���ֵ��
        /// </summary>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <param name="defaultValue">��ָ������Ϸ���������ʱ�����ش�Ĭ��ֵ��</param>
        /// <returns>��ȡ���ַ���ֵ��</returns>
        public string GetString(string settingName, string defaultValue)
        {
            return m_SettingManager.GetString(settingName, defaultValue);
        }

        /// <summary>
        /// ��ָ����Ϸ������д���ַ���ֵ��
        /// </summary>
        /// <param name="settingName">Ҫд����Ϸ����������ơ�</param>
        /// <param name="value">Ҫд����ַ���ֵ��</param>
        public void SetString(string settingName, string value)
        {
            m_SettingManager.SetString(settingName, value);
        }

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ����
        /// </summary>
        /// <typeparam name="T">Ҫ��ȡ��������͡�</typeparam>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <returns>��ȡ�Ķ���</returns>
        public T GetObject<T>(string settingName)
        {
            return m_SettingManager.GetObject<T>(settingName);
        }

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ����
        /// </summary>
        /// <param name="objectType">Ҫ��ȡ��������͡�</param>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <returns>��ȡ�Ķ���</returns>
        public object GetObject(Type objectType, string settingName)
        {
            return m_SettingManager.GetObject(objectType, settingName);
        }

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ����
        /// </summary>
        /// <typeparam name="T">Ҫ��ȡ��������͡�</typeparam>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <param name="defaultObj">��ָ������Ϸ���������ʱ�����ش�Ĭ�϶���</param>
        /// <returns>��ȡ�Ķ���</returns>
        public T GetObject<T>(string settingName, T defaultObj)
        {
            return m_SettingManager.GetObject(settingName, defaultObj);
        }

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ����
        /// </summary>
        /// <param name="objectType">Ҫ��ȡ��������͡�</param>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <param name="defaultObj">��ָ������Ϸ���������ʱ�����ش�Ĭ�϶���</param>
        /// <returns>��ȡ�Ķ���</returns>
        public object GetObject(Type objectType, string settingName, object defaultObj)
        {
            return m_SettingManager.GetObject(objectType, settingName, defaultObj);
        }

        /// <summary>
        /// ��ָ����Ϸ������д�����
        /// </summary>
        /// <typeparam name="T">Ҫд���������͡�</typeparam>
        /// <param name="settingName">Ҫд����Ϸ����������ơ�</param>
        /// <param name="obj">Ҫд��Ķ���</param>
        public void SetObject<T>(string settingName, T obj)
        {
            m_SettingManager.SetObject(settingName, obj);
        }

        /// <summary>
        /// ��ָ����Ϸ������д�����
        /// </summary>
        /// <param name="settingName">Ҫд����Ϸ����������ơ�</param>
        /// <param name="obj">Ҫд��Ķ���</param>
        public void SetObject(string settingName, object obj)
        {
            m_SettingManager.SetObject(settingName, obj);
        }
    }

}