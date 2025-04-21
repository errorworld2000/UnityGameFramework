using GameFramework.Base.Log;
using System.Diagnostics;

namespace UnityGameFramework.Runtime
{
    public static class Log
    {

        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_DEBUG_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        public static void Debug(object message, params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                GameFrameworkLog.Debug(message.ToString());
            }
            else
            {
                GameFrameworkLog.Debug(string.Format(message.ToString(), args));
            }
        }

        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_INFO_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        [Conditional("ENABLE_INFO_AND_ABOVE_LOG")]
        public static void Info(object message, params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                GameFrameworkLog.Info(message.ToString());
            }
            else
            {
                GameFrameworkLog.Info(string.Format(message.ToString(), args));
            }
        }

        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_WARNING_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        [Conditional("ENABLE_INFO_AND_ABOVE_LOG")]
        [Conditional("ENABLE_WARNING_AND_ABOVE_LOG")]
        public static void Warning(object message, params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                GameFrameworkLog.Warning(message.ToString());
            }
            else
            {
                GameFrameworkLog.Warning(string.Format(message.ToString(), args));
            }
        }

        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_ERROR_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        [Conditional("ENABLE_INFO_AND_ABOVE_LOG")]
        [Conditional("ENABLE_WARNING_AND_ABOVE_LOG")]
        [Conditional("ENABLE_ERROR_AND_ABOVE_LOG")]
        public static void Error(object message, params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                GameFrameworkLog.Error(message.ToString());
            }
            else
            {
                GameFrameworkLog.Error(string.Format(message.ToString(), args));
            }
        }

        [Conditional("ENABLE_LOG")]
        [Conditional("ENABLE_FATAL_LOG")]
        [Conditional("ENABLE_DEBUG_AND_ABOVE_LOG")]
        [Conditional("ENABLE_INFO_AND_ABOVE_LOG")]
        [Conditional("ENABLE_WARNING_AND_ABOVE_LOG")]
        [Conditional("ENABLE_ERROR_AND_ABOVE_LOG")]
        [Conditional("ENABLE_FATAL_AND_ABOVE_LOG")]
        public static void Fatal(object message, params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                GameFrameworkLog.Fatal(message.ToString());
            }
            else
            {
                GameFrameworkLog.Fatal(string.Format(message.ToString(), args));
            }
        }

    }
}