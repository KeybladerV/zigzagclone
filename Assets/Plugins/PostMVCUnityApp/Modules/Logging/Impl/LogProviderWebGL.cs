#if UNITY_WEBGL

using System;
using System.Runtime.InteropServices;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Unity.App.Utils.WebGL;

namespace Build1.PostMVC.Unity.App.Modules.Logging.Impl
{
    internal sealed class LogProviderWebGL : LogProviderBase
    {
        [DllImport("__Internal")]
        private static extern void LogDebug(string message);

        [DllImport("__Internal")]
        private static extern void LogError(string message);

        [PostConstruct]
        public void PostConstruct()
        {
            try
            {
                if (QueryStringUtil.TryGetQueryStringParam<string>("logLevel", out var logLevelString))
                {
                    var logLevel = (LogLevel)Enum.Parse(typeof(LogLevel), logLevelString, true);
                    if (Enum.IsDefined(typeof(LogLevel), logLevel))
                    {
                        // Overriding global setting if another log level is set via query string params.
                        Logging.Print = logLevel > LogLevel.None;
                        Logging.PrintLevel = logLevel;

                        LogDebug($"{nameof(LogWebGL)}: Global log level overridden to {logLevel}\n");    
                    }
                }
            }
            catch (Exception exception)
            {
                LogError(LogBase.FormatException(nameof(LogWebGL), exception));
            }
        }
        
        /*
         * Public.
         */
        
        public override ILog CreateLogInstance(string prefix, LogLevel level, ILogController logController)
        {
            return new LogWebGL(prefix, level, logController);
        }
    }
}

#endif