using GameFramework.Base;
using GameFramework.Base.DataProvider;
using GameFramework.Localization;
using GameFramework.Localization.Args;
using GameFramework.Resource;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// ���ػ������
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Localization")]
    public sealed class LocalizationComponent : UnityGameFrameworkComponent
    {
        private const int DefaultPriority = 0;

        private ILocalizationManager m_LocalizationManager = null;
        private EventComponent m_EventComponent = null;

        [SerializeField]
        private bool m_EnableLoadDictionaryUpdateEvent = false;

        [SerializeField]
        private bool m_EnableLoadDictionaryDependencyAssetEvent = false;

        [SerializeField]
        private string m_LocalizationHelperTypeName = "UnityGameFramework.Runtime.DefaultLocalizationHelper";

        [SerializeField]
        private LocalizationHelperBase m_CustomLocalizationHelper = null;

        [SerializeField]
        private int m_CachedBytesSize = 0;

        /// <summary>
        /// ��ȡ�����ñ��ػ����ԡ�
        /// </summary>
        public Language Language
        {
            get
            {
                return m_LocalizationManager.Language;
            }
            set
            {
                m_LocalizationManager.Language = value;
            }
        }

        /// <summary>
        /// ��ȡϵͳ���ԡ�
        /// </summary>
        public Language SystemLanguage
        {
            get
            {
                return m_LocalizationManager.SystemLanguage;
            }
        }

        /// <summary>
        /// ��ȡ�ֵ�������
        /// </summary>
        public int DictionaryCount
        {
            get
            {
                return m_LocalizationManager.DictionaryCount;
            }
        }

        /// <summary>
        /// ��ȡ������������Ĵ�С��
        /// </summary>
        public int CachedBytesSize
        {
            get
            {
                return m_LocalizationManager.CachedBytesSize;
            }
        }

        /// <summary>
        /// ��Ϸ��������ʼ����
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            m_LocalizationManager = GameFrameworkEntry.GetModule<ILocalizationManager>();
            if (m_LocalizationManager == null)
            {
                Log.Fatal("Localization manager is invalid.");
                return;
            }

            m_LocalizationManager.ReadDataSuccess += OnReadDataSuccess;
            m_LocalizationManager.ReadDataFailure += OnReadDataFailure;

            if (m_EnableLoadDictionaryUpdateEvent)
            {
                m_LocalizationManager.ReadDataUpdate += OnReadDataUpdate;
            }

            if (m_EnableLoadDictionaryDependencyAssetEvent)
            {
                m_LocalizationManager.ReadDataDependencyAsset += OnReadDataDependencyAsset;
            }
        }

        private void Start()
        {
            BaseComponent baseComponent = UnityGameFrameworkEntry.GetComponent<BaseComponent>();
            if (baseComponent == null)
            {
                Log.Fatal("Base component is invalid.");
                return;
            }

            m_EventComponent = UnityGameFrameworkEntry.GetComponent<EventComponent>();
            if (m_EventComponent == null)
            {
                Log.Fatal("Event component is invalid.");
                return;
            }

            if (baseComponent.EditorResourceMode)
            {
                m_LocalizationManager.SetResourceManager(baseComponent.EditorResourceHelper);
            }
            else
            {
                m_LocalizationManager.SetResourceManager(GameFrameworkEntry.GetModule<IResourceManager>());
            }

            LocalizationHelperBase localizationHelper = Helper.CreateHelper(m_LocalizationHelperTypeName, m_CustomLocalizationHelper);
            if (localizationHelper == null)
            {
                Log.Error("Can not create localization helper.");
                return;
            }

            localizationHelper.name = "Localization Helper";
            Transform transform = localizationHelper.transform;
            transform.SetParent(this.transform);
            transform.localScale = Vector3.one;

            m_LocalizationManager.SetDataProviderHelper(localizationHelper);
            m_LocalizationManager.SetLocalizationHelper(localizationHelper);
            m_LocalizationManager.Language = baseComponent.EditorResourceMode && baseComponent.EditorLanguage != Language.Unspecified ? baseComponent.EditorLanguage : m_LocalizationManager.SystemLanguage;
            if (m_CachedBytesSize > 0)
            {
                EnsureCachedBytesSize(m_CachedBytesSize);
            }
        }

        /// <summary>
        /// ȷ������������������㹻��С���ڴ沢���档
        /// </summary>
        /// <param name="ensureSize">Ҫȷ������������������ڴ�Ĵ�С��</param>
        public void EnsureCachedBytesSize(int ensureSize)
        {
            m_LocalizationManager.EnsureCachedBytesSize(ensureSize);
        }

        /// <summary>
        /// �ͷŻ���Ķ���������
        /// </summary>
        public void FreeCachedBytes()
        {
            m_LocalizationManager.FreeCachedBytes();
        }

        /// <summary>
        /// ��ȡ�ֵ䡣
        /// </summary>
        /// <param name="dictionaryAssetName">�ֵ���Դ���ơ�</param>
        public void ReadData(string dictionaryAssetName)
        {
            m_LocalizationManager.ReadData(dictionaryAssetName);
        }

        /// <summary>
        /// ��ȡ�ֵ䡣
        /// </summary>
        /// <param name="dictionaryAssetName">�ֵ���Դ���ơ�</param>
        /// <param name="priority">�����ֵ���Դ�����ȼ���</param>
        public void ReadData(string dictionaryAssetName, int priority)
        {
            m_LocalizationManager.ReadData(dictionaryAssetName, priority);
        }

        /// <summary>
        /// ��ȡ�ֵ䡣
        /// </summary>
        /// <param name="dictionaryAssetName">�ֵ���Դ���ơ�</param>
        /// <param name="userData">�û��Զ������ݡ�</param>
        public void ReadData(string dictionaryAssetName, object userData)
        {
            m_LocalizationManager.ReadData(dictionaryAssetName, userData);
        }

        /// <summary>
        /// ��ȡ�ֵ䡣
        /// </summary>
        /// <param name="dictionaryAssetName">�ֵ���Դ���ơ�</param>
        /// <param name="priority">�����ֵ���Դ�����ȼ���</param>
        /// <param name="userData">�û��Զ������ݡ�</param>
        public void ReadData(string dictionaryAssetName, int priority, object userData)
        {
            m_LocalizationManager.ReadData(dictionaryAssetName, priority, userData);
        }

        /// <summary>
        /// �����ֵ䡣
        /// </summary>
        /// <param name="dictionaryString">Ҫ�������ֵ��ַ�����</param>
        /// <returns>�Ƿ�����ֵ�ɹ���</returns>
        public bool ParseData(string dictionaryString)
        {
            return m_LocalizationManager.ParseData(dictionaryString);
        }

        /// <summary>
        /// �����ֵ䡣
        /// </summary>
        /// <param name="dictionaryString">Ҫ�������ֵ��ַ�����</param>
        /// <param name="userData">�û��Զ������ݡ�</param>
        /// <returns>�Ƿ�����ֵ�ɹ���</returns>
        public bool ParseData(string dictionaryString, object userData)
        {
            return m_LocalizationManager.ParseData(dictionaryString, userData);
        }

        /// <summary>
        /// �����ֵ䡣
        /// </summary>
        /// <param name="dictionaryBytes">Ҫ�������ֵ����������</param>
        /// <returns>�Ƿ�����ֵ�ɹ���</returns>
        public bool ParseData(byte[] dictionaryBytes)
        {
            return m_LocalizationManager.ParseData(dictionaryBytes);
        }

        /// <summary>
        /// �����ֵ䡣
        /// </summary>
        /// <param name="dictionaryBytes">Ҫ�������ֵ����������</param>
        /// <param name="userData">�û��Զ������ݡ�</param>
        /// <returns>�Ƿ�����ֵ�ɹ���</returns>
        public bool ParseData(byte[] dictionaryBytes, object userData)
        {
            return m_LocalizationManager.ParseData(dictionaryBytes, userData);
        }

        /// <summary>
        /// �����ֵ䡣
        /// </summary>
        /// <param name="dictionaryBytes">Ҫ�������ֵ����������</param>
        /// <param name="startIndex">�ֵ������������ʼλ�á�</param>
        /// <param name="length">�ֵ���������ĳ��ȡ�</param>
        /// <returns>�Ƿ�����ֵ�ɹ���</returns>
        public bool ParseData(byte[] dictionaryBytes, int startIndex, int length)
        {
            return m_LocalizationManager.ParseData(dictionaryBytes, startIndex, length);
        }

        /// <summary>
        /// �����ֵ䡣
        /// </summary>
        /// <param name="dictionaryBytes">Ҫ�������ֵ����������</param>
        /// <param name="startIndex">�ֵ������������ʼλ�á�</param>
        /// <param name="length">�ֵ���������ĳ��ȡ�</param>
        /// <param name="userData">�û��Զ������ݡ�</param>
        /// <returns>�Ƿ�����ֵ�ɹ���</returns>
        public bool ParseData(byte[] dictionaryBytes, int startIndex, int length, object userData)
        {
            return m_LocalizationManager.ParseData(dictionaryBytes, startIndex, length, userData);
        }

        /// <summary>
        /// �����ֵ�������ȡ�ֵ������ַ�����
        /// </summary>
        /// <param name="key">�ֵ�������</param>
        /// <returns>Ҫ��ȡ���ֵ������ַ�����</returns>
        public string GetString(string key)
        {
            return m_LocalizationManager.GetString(key);
        }

        /// <summary>
        /// �����ֵ�������ȡ�ֵ������ַ�����
        /// </summary>
        /// <param name="key">�ֵ�������</param>
        /// <param name="arg0">�ֵ���� 0��</param>
        /// <returns>Ҫ��ȡ���ֵ������ַ�����</returns>
        public string GetString(string key, object arg0)
        {
            return m_LocalizationManager.GetString(key, arg0);
        }

        /// <summary>
        /// �����ֵ�������ȡ�ֵ������ַ�����
        /// </summary>
        /// <param name="key">�ֵ�������</param>
        /// <param name="arg0">�ֵ���� 0��</param>
        /// <param name="arg1">�ֵ���� 1��</param>
        /// <returns>Ҫ��ȡ���ֵ������ַ�����</returns>
        public string GetString(string key, object arg0, object arg1)
        {
            return m_LocalizationManager.GetString(key, arg0, arg1);
        }

        /// <summary>
        /// �����ֵ�������ȡ�ֵ������ַ�����
        /// </summary>
        /// <param name="key">�ֵ�������</param>
        /// <param name="arg0">�ֵ���� 0��</param>
        /// <param name="arg1">�ֵ���� 1��</param>
        /// <param name="arg2">�ֵ���� 2��</param>
        /// <returns>Ҫ��ȡ���ֵ������ַ�����</returns>
        public string GetString(string key, object arg0, object arg1, object arg2)
        {
            return m_LocalizationManager.GetString(key, arg0, arg1, arg2);
        }

        /// <summary>
        /// �����ֵ�������ȡ�ֵ������ַ�����
        /// </summary>
        /// <param name="key">�ֵ�������</param>
        /// <param name="args">�ֵ������</param>
        /// <returns>Ҫ��ȡ���ֵ������ַ�����</returns>
        public string GetString(string key, params object[] args)
        {
            return m_LocalizationManager.GetString(key, args);
        }

        /// <summary>
        /// �Ƿ�����ֵ䡣
        /// </summary>
        /// <param name="key">�ֵ�������</param>
        /// <returns>�Ƿ�����ֵ䡣</returns>
        public bool HasRawString(string key)
        {
            return m_LocalizationManager.HasRawString(key);
        }

        /// <summary>
        /// �����ֵ�������ȡ�ֵ�ֵ��
        /// </summary>
        /// <param name="key">�ֵ�������</param>
        /// <returns>�ֵ�ֵ��</returns>
        public string GetRawString(string key)
        {
            return m_LocalizationManager.GetRawString(key);
        }

        /// <summary>
        /// �Ƴ��ֵ䡣
        /// </summary>
        /// <param name="key">�ֵ�������</param>
        /// <returns>�Ƿ��Ƴ��ֵ�ɹ���</returns>
        public bool RemoveRawString(string key)
        {
            return m_LocalizationManager.RemoveRawString(key);
        }

        /// <summary>
        /// ��������ֵ䡣
        /// </summary>
        public void RemoveAllRawStrings()
        {
            m_LocalizationManager.RemoveAllRawStrings();
        }

        private void OnReadDataSuccess(object sender, ReadDataSuccessEventArgs e)
        {
            m_EventComponent.Fire(this, LoadDictionarySuccessEventArgs.Create(e));
        }

        private void OnReadDataFailure(object sender, ReadDataFailureEventArgs e)
        {
            Log.Warning("Load dictionary failure, asset name '{0}', error message '{1}'.", e.DataAssetName, e.ErrorMessage);
            m_EventComponent.Fire(this, LoadDictionaryFailureEventArgs.Create(e));
        }

        private void OnReadDataUpdate(object sender, ReadDataUpdateEventArgs e)
        {
            m_EventComponent.Fire(this, LoadDictionaryUpdateEventArgs.Create(e));
        }

        private void OnReadDataDependencyAsset(object sender, ReadDataDependencyAssetEventArgs e)
        {
            m_EventComponent.Fire(this, LoadDictionaryDependencyAssetEventArgs.Create(e));
        }
    }
}
