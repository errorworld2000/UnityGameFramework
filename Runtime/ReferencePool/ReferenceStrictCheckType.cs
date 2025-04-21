namespace UnityGameFramework.Runtime
{
    public enum ReferenceStrictCheckType : byte
    {
        AlwaysEnable = 0,
        OnlyEnableWhenDevelopment = 1,
        OnlyEnableInEditor = 2,
        AlwaysDisable = 3
    }
}