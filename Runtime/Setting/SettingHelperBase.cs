
using GameFramework.Setting;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// ��Ϸ���ø��������ࡣ
    /// </summary>
    public abstract class SettingHelperBase : MonoBehaviour, ISettingHelper
    {
        /// <summary>
        /// ��ȡ��Ϸ������������
        /// </summary>
        public abstract int Count
        {
            get;
        }

        /// <summary>
        /// ������Ϸ���á�
        /// </summary>
        /// <returns>�Ƿ������Ϸ���óɹ���</returns>
        public abstract bool Load();

        /// <summary>
        /// ������Ϸ���á�
        /// </summary>
        /// <returns>�Ƿ񱣴���Ϸ���óɹ���</returns>
        public abstract bool Save();

        /// <summary>
        /// ��ȡ������Ϸ����������ơ�
        /// </summary>
        /// <returns>������Ϸ����������ơ�</returns>
        public abstract string[] GetAllSettingNames();

        /// <summary>
        /// ��ȡ������Ϸ����������ơ�
        /// </summary>
        /// <param name="results">������Ϸ����������ơ�</param>
        public abstract void GetAllSettingNames(List<string> results);

        /// <summary>
        /// ����Ƿ����ָ����Ϸ�����
        /// </summary>
        /// <param name="settingName">Ҫ�����Ϸ����������ơ�</param>
        /// <returns>ָ������Ϸ�������Ƿ���ڡ�</returns>
        public abstract bool HasSetting(string settingName);

        /// <summary>
        /// �Ƴ�ָ����Ϸ�����
        /// </summary>
        /// <param name="settingName">Ҫ�Ƴ���Ϸ����������ơ�</param>
        /// <returns>�Ƿ��Ƴ�ָ����Ϸ������ɹ���</returns>
        public abstract bool RemoveSetting(string settingName);

        /// <summary>
        /// ���������Ϸ�����
        /// </summary>
        public abstract void RemoveAllSettings();

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ����ֵ��
        /// </summary>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <returns>��ȡ�Ĳ���ֵ��</returns>
        public abstract bool GetBool(string settingName);

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ����ֵ��
        /// </summary>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <param name="defaultValue">��ָ������Ϸ���������ʱ�����ش�Ĭ��ֵ��</param>
        /// <returns>��ȡ�Ĳ���ֵ��</returns>
        public abstract bool GetBool(string settingName, bool defaultValue);

        /// <summary>
        /// ��ָ����Ϸ������д�벼��ֵ��
        /// </summary>
        /// <param name="settingName">Ҫд����Ϸ����������ơ�</param>
        /// <param name="value">Ҫд��Ĳ���ֵ��</param>
        public abstract void SetBool(string settingName, bool value);

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ����ֵ��
        /// </summary>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <returns>��ȡ������ֵ��</returns>
        public abstract int GetInt(string settingName);

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ����ֵ��
        /// </summary>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <param name="defaultValue">��ָ������Ϸ���������ʱ�����ش�Ĭ��ֵ��</param>
        /// <returns>��ȡ������ֵ��</returns>
        public abstract int GetInt(string settingName, int defaultValue);

        /// <summary>
        /// ��ָ����Ϸ������д������ֵ��
        /// </summary>
        /// <param name="settingName">Ҫд����Ϸ����������ơ�</param>
        /// <param name="value">Ҫд�������ֵ��</param>
        public abstract void SetInt(string settingName, int value);

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ������ֵ��
        /// </summary>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <returns>��ȡ�ĸ�����ֵ��</returns>
        public abstract float GetFloat(string settingName);

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ������ֵ��
        /// </summary>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <param name="defaultValue">��ָ������Ϸ���������ʱ�����ش�Ĭ��ֵ��</param>
        /// <returns>��ȡ�ĸ�����ֵ��</returns>
        public abstract float GetFloat(string settingName, float defaultValue);

        /// <summary>
        /// ��ָ����Ϸ������д�븡����ֵ��
        /// </summary>
        /// <param name="settingName">Ҫд����Ϸ����������ơ�</param>
        /// <param name="value">Ҫд��ĸ�����ֵ��</param>
        public abstract void SetFloat(string settingName, float value);

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ�ַ���ֵ��
        /// </summary>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <returns>��ȡ���ַ���ֵ��</returns>
        public abstract string GetString(string settingName);

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ�ַ���ֵ��
        /// </summary>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <param name="defaultValue">��ָ������Ϸ���������ʱ�����ش�Ĭ��ֵ��</param>
        /// <returns>��ȡ���ַ���ֵ��</returns>
        public abstract string GetString(string settingName, string defaultValue);

        /// <summary>
        /// ��ָ����Ϸ������д���ַ���ֵ��
        /// </summary>
        /// <param name="settingName">Ҫд����Ϸ����������ơ�</param>
        /// <param name="value">Ҫд����ַ���ֵ��</param>
        public abstract void SetString(string settingName, string value);

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ����
        /// </summary>
        /// <typeparam name="T">Ҫ��ȡ��������͡�</typeparam>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <returns>��ȡ�Ķ���</returns>
        public abstract T GetObject<T>(string settingName);

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ����
        /// </summary>
        /// <param name="objectType">Ҫ��ȡ��������͡�</param>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <returns>��ȡ�Ķ���</returns>
        public abstract object GetObject(Type objectType, string settingName);

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ����
        /// </summary>
        /// <typeparam name="T">Ҫ��ȡ��������͡�</typeparam>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <param name="defaultObj">��ָ������Ϸ���������ʱ�����ش�Ĭ�϶���</param>
        /// <returns>��ȡ�Ķ���</returns>
        public abstract T GetObject<T>(string settingName, T defaultObj);

        /// <summary>
        /// ��ָ����Ϸ�������ж�ȡ����
        /// </summary>
        /// <param name="objectType">Ҫ��ȡ��������͡�</param>
        /// <param name="settingName">Ҫ��ȡ��Ϸ����������ơ�</param>
        /// <param name="defaultObj">��ָ������Ϸ���������ʱ�����ش�Ĭ�϶���</param>
        /// <returns>��ȡ�Ķ���</returns>
        public abstract object GetObject(Type objectType, string settingName, object defaultObj);

        /// <summary>
        /// ��ָ����Ϸ������д�����
        /// </summary>
        /// <typeparam name="T">Ҫд���������͡�</typeparam>
        /// <param name="settingName">Ҫд����Ϸ����������ơ�</param>
        /// <param name="obj">Ҫд��Ķ���</param>
        public abstract void SetObject<T>(string settingName, T obj);

        /// <summary>
        /// ��ָ����Ϸ������д�����
        /// </summary>
        /// <param name="settingName">Ҫд����Ϸ����������ơ�</param>
        /// <param name="obj">Ҫд��Ķ���</param>
        public abstract void SetObject(string settingName, object obj);
    }
}
