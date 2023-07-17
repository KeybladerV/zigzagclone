#if UNITY_WEBGL

using System;
using System.Runtime.InteropServices;

namespace Build1.PostMVC.Unity.App.Modules.Logging.Impl
{
    internal sealed class LogWebGL : LogBase
    {
        [DllImport("__Internal")]
        private static extern void LogDebug(string message);
        
        [DllImport("__Internal")]
        private static extern void LogWarning(string message);
        
        [DllImport("__Internal")]
        private static extern void LogError(string message);

        public LogWebGL(string prefix, LogLevel level, ILogController logController) : base(prefix, level, logController)
        {
        }

        /*
         * Debug.
         */

        public override void Debug(string message)
        {
            if (!CheckLevel(LogLevel.Debug))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Debug;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Debug;

            if (print || record)
                message = FormatMessage(message);
            
            if (print)
                LogDebug(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Debug, false);
        }

        public override void Debug(Exception exception)
        {
            if (!CheckLevel(LogLevel.Debug))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Debug;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Debug;
            var message = string.Empty;

            if (print || record)
                message = FormatException(exception);
            
            if (print)
                LogDebug(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Debug, false);
        }

        public override void Debug(Func<string> callback)
        {
            if (!CheckLevel(LogLevel.Debug))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Debug;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Debug;
            var message = string.Empty;

            if (print || record)
                message = FormatMessage(callback.Invoke());
            
            if (print)
                LogDebug(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Debug, false);
        }

        public override void Debug<T1>(Func<T1, string> callback, T1 param01)
        {
            if (!CheckLevel(LogLevel.Debug))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Debug;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Debug;
            var message = string.Empty;

            if (print || record)
                message = FormatMessage(callback.Invoke(param01));
            
            if (print)
                LogDebug(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Debug, false);
        }

        public override void Debug<T1, T2>(Func<T1, T2, string> callback, T1 param01, T2 param02)
        {
            if (!CheckLevel(LogLevel.Debug))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Debug;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Debug;
            var message = string.Empty;

            if (print || record)
                message = FormatMessage(callback.Invoke(param01, param02));
            
            if (print)
                LogDebug(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Debug, false);
        }

        public override void Debug<T1, T2, T3>(Func<T1, T2, T3, string> callback, T1 param01, T2 param02, T3 param03)
        {
            if (!CheckLevel(LogLevel.Debug))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Debug;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Debug;
            var message = string.Empty;

            if (print || record)
                message = FormatMessage(callback.Invoke(param01, param02, param03));
            
            if (print)
                LogDebug(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Debug, false);
        }

        public override void Debug(Action<ILogDebug> callback)
        {
            if (CheckLevel(LogLevel.Debug))
                callback.Invoke(this);
        }

        public override void Debug<T1>(Action<ILogDebug, T1> callback, T1 param01)
        {
            if (CheckLevel(LogLevel.Debug))
                callback.Invoke(this, param01);
        }

        public override void Debug<T1, T2>(Action<ILogDebug, T1, T2> callback, T1 param01, T2 param02)
        {
            if (CheckLevel(LogLevel.Debug))
                callback.Invoke(this, param01, param02);
        }

        public override void Debug<T1, T2, T3>(Action<ILogDebug, T1, T2, T3> callback, T1 param01, T2 param02, T3 param03)
        {
            if (CheckLevel(LogLevel.Debug))
                callback.Invoke(this, param01, param02, param03);
        }

        /*
         * Warning.
         */

        public override void Warn(string message)
        {
            if (!CheckLevel(LogLevel.Warning))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Warning;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Warning;

            if (print || record)
                message = FormatMessage(message);
            
            if (print)
                LogWarning(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Warning, false);
        }

        public override void Warn(Exception exception)
        {
            if (!CheckLevel(LogLevel.Warning))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Warning;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Warning;
            var message = string.Empty;

            if (print || record)
                message = FormatException(exception);
            
            if (print)
                LogWarning(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Warning, false);
        }

        public override void Warn(Func<string> callback)
        {
            if (!CheckLevel(LogLevel.Warning))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Warning;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Warning;
            var message = string.Empty;

            if (print || record)
                message = FormatMessage(callback.Invoke());
            
            if (print)
                LogWarning(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Warning, false);
        }

        public override void Warn<T1>(Func<T1, string> callback, T1 param01)
        {
            if (!CheckLevel(LogLevel.Warning))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Warning;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Warning;
            var message = string.Empty;

            if (print || record)
                message = FormatMessage(callback.Invoke(param01));
            
            if (print)
                LogWarning(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Warning, false);
        }

        public override void Warn<T1, T2>(Func<T1, T2, string> callback, T1 param01, T2 param02)
        {
            if (!CheckLevel(LogLevel.Warning))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Warning;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Warning;
            var message = string.Empty;

            if (print || record)
                message = FormatMessage(callback.Invoke(param01, param02));
            
            if (print)
                LogWarning(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Warning, false);
        }

        public override void Warn<T1, T2, T3>(Func<T1, T2, T3, string> callback, T1 param01, T2 param02, T3 param03)
        {
            if (!CheckLevel(LogLevel.Warning))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Warning;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Warning;
            var message = string.Empty;

            if (print || record)
                message = FormatMessage(callback.Invoke(param01, param02, param03));
            
            if (print)
                LogWarning(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Warning, false);
        }

        public override void Warn(Action<ILogWarn> callback)
        {
            if (CheckLevel(LogLevel.Warning))
                callback.Invoke(this);
        }

        public override void Warn<T1>(Action<ILogWarn, T1> callback, T1 param01)
        {
            if (CheckLevel(LogLevel.Warning))
                callback.Invoke(this, param01);
        }

        public override void Warn<T1, T2>(Action<ILogWarn, T1, T2> callback, T1 param01, T2 param02)
        {
            if (CheckLevel(LogLevel.Warning))
                callback.Invoke(this, param01, param02);
        }

        public override void Warn<T1, T2, T3>(Action<ILogWarn, T1, T2, T3> callback, T1 param01, T2 param02, T3 param03)
        {
            if (CheckLevel(LogLevel.Warning))
                callback.Invoke(this, param01, param02, param03);
        }

        /*
         * Error.
         */

        public override void Error(string message)
        {
            if (!CheckLevel(LogLevel.Error))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Error;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Error;

            if (print || record)
                message = FormatMessage(message);
            
            if (print)
                LogError(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Error, false);
        }

        public override void Error(Exception exception)
        {
            if (!CheckLevel(LogLevel.Error))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Error;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Error;
            string message = string.Empty;
            
            if (print || record)
                message = FormatException(exception);
            
            if (print)
                LogError(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Error, false);
        }

        public override void Error(Func<string> callback)
        {
            if (!CheckLevel(LogLevel.Error))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Error;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Error;
            var message = string.Empty;

            if (print || record)
                message = FormatMessage(callback.Invoke());
            
            if (print)
                LogError(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Error, false);
        }

        public override void Error<T1>(Func<T1, string> callback, T1 param01)
        {
            if (!CheckLevel(LogLevel.Error))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Error;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Error;
            var message = string.Empty;

            if (print || record)
                message = FormatMessage(callback.Invoke(param01));
            
            if (print)
                LogError(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Error, false);
        }

        public override void Error<T1, T2>(Func<T1, T2, string> callback, T1 param01, T2 param02)
        {
            if (!CheckLevel(LogLevel.Error))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Error;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Error;
            var message = string.Empty;

            if (print || record)
                message = FormatMessage(callback.Invoke(param01, param02));
            
            if (print)
                LogError(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Error, false);
        }

        public override void Error<T1, T2, T3>(Func<T1, T2, T3, string> callback, T1 param01, T2 param02, T3 param03)
        {
            if (!CheckLevel(LogLevel.Error))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Error;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Error;
            var message = string.Empty;

            if (print || record)
                message = FormatMessage(callback.Invoke(param01, param02, param03));
            
            if (print)
                LogError(message);
            
            if (record)
                _logController.RecordMessage(message, LogLevel.Error, false);
        }

        public override void Error(Action<ILogError> callback)
        {
            if (CheckLevel(LogLevel.Error))
                callback.Invoke(this);
        }

        public override void Error<T1>(Action<ILogError, T1> callback, T1 param01)
        {
            if (CheckLevel(LogLevel.Error))
                callback.Invoke(this, param01);
        }

        public override void Error<T1, T2>(Action<ILogError, T1, T2> callback, T1 param01, T2 param02)
        {
            if (CheckLevel(LogLevel.Error))
                callback.Invoke(this, param01, param02);
        }

        public override void Error<T1, T2, T3>(Action<ILogError, T1, T2, T3> callback, T1 param01, T2 param02, T3 param03)
        {
            if (CheckLevel(LogLevel.Error))
                callback.Invoke(this, param01, param02, param03);
        }
    }
}

#endif