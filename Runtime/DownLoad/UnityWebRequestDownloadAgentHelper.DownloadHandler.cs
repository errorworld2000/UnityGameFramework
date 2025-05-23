﻿using GameFramework.Base.ReferencePool;
using GameFramework.Download.Args;
using System;
using UnityEngine.Networking;

namespace UnityGameFramework.Runtime
{
    public partial class UnityWebRequestDownloadAgentHelper : DownloadAgentHelperBase, IDisposable
    {
        private sealed class DownloadHandler : DownloadHandlerScript
        {
            private readonly UnityWebRequestDownloadAgentHelper m_Owner;

            public DownloadHandler(UnityWebRequestDownloadAgentHelper owner)
                : base(owner.m_CachedBytes)
            {
                m_Owner = owner;
            }

            protected override bool ReceiveData(byte[] data, int dataLength)
            {
                if (m_Owner != null && m_Owner.m_UnityWebRequest != null && dataLength > 0)
                {
                    DownloadAgentHelperUpdateBytesEventArgs downloadAgentHelperUpdateBytesEventArgs = DownloadAgentHelperUpdateBytesEventArgs.Create(data, 0, dataLength);
                    m_Owner.m_DownloadAgentHelperUpdateBytesEventHandler(this, downloadAgentHelperUpdateBytesEventArgs);
                    ReferencePool.Release(downloadAgentHelperUpdateBytesEventArgs);

                    DownloadAgentHelperUpdateLengthEventArgs downloadAgentHelperUpdateLengthEventArgs = DownloadAgentHelperUpdateLengthEventArgs.Create(dataLength);
                    m_Owner.m_DownloadAgentHelperUpdateLengthEventHandler(this, downloadAgentHelperUpdateLengthEventArgs);
                    ReferencePool.Release(downloadAgentHelperUpdateLengthEventArgs);
                }

                return base.ReceiveData(data, dataLength);
            }
        }
    }
}
