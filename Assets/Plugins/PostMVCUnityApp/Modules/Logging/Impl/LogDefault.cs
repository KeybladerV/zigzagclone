using System;

namespace Build1.PostMVC.Unity.App.Modules.Logging.Impl
{
    internal sealed class LogDefault : LogBase
    {
        public LogDefault(string prefix, LogLevel level, ILogController logController) : base(prefix, level, logController)
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
            
            if (print)
                UnityEngine.Debug.Log(FormatMessage(message));
            else if (record)
                _logController.RecordMessage(FormatMessage(message), LogLevel.Debug, false);
        }

        public override void Debug(Exception exception)
        {
            if (!CheckLevel(LogLevel.Debug))
                return;
            
            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Debug;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Debug;

            if (print)
                UnityEngine.Debug.Log(FormatException(exception));
            else if (record)
                _logController.RecordMessage(FormatException(exception), LogLevel.Debug, false);
        }

        public override void Debug(Func<string> callback)
        {
            if (!CheckLevel(LogLevel.Debug))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Debug;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Debug;
            
            if (print)
                UnityEngine.Debug.Log(FormatMessage(callback.Invoke()));
            else if (record)
                _logController.RecordMessage(FormatMessage(callback.Invoke()), LogLevel.Debug, false);
        }

        public override void Debug<T1>(Func<T1, string> callback, T1 param01)
        {
            if (!CheckLevel(LogLevel.Debug))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Debug;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Debug;
            
            if (print)
                UnityEngine.Debug.Log(FormatMessage(callback.Invoke(param01)));
            else if (record)
                _logController.RecordMessage(FormatMessage(callback.Invoke(param01)), LogLevel.Debug, false);
        }

        public override void Debug<T1, T2>(Func<T1, T2, string> callback, T1 param01, T2 param02)
        {
            if (!CheckLevel(LogLevel.Debug))
                return;
            
            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Debug;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Debug;

            if (print)
                UnityEngine.Debug.Log(FormatMessage(callback.Invoke(param01, param02)));
            else if (record)
                _logController.RecordMessage(FormatMessage(callback.Invoke(param01, param02)), LogLevel.Debug, false);
        }

        public override void Debug<T1, T2, T3>(Func<T1, T2, T3, string> callback, T1 param01, T2 param02, T3 param03)
        {
            if (!CheckLevel(LogLevel.Debug))
                return;
            
            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Debug;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Debug;

            if (print)
                UnityEngine.Debug.Log(FormatMessage(callback.Invoke(param01, param02, param03)));
            else if (record)
                _logController.RecordMessage(FormatMessage(callback.Invoke(param01, param02, param03)), LogLevel.Debug, false);
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
            
            if (print)
                UnityEngine.Debug.LogWarning(FormatMessage(message));
            else if (record)
                _logController.RecordMessage(FormatMessage(message), LogLevel.Warning, false);
        }

        public override void Warn(Exception exception)
        {
            if (!CheckLevel(LogLevel.Warning))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Warning;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Warning;
            
            if (print)
                UnityEngine.Debug.LogWarning(FormatException(exception));
            else if (record)
                _logController.RecordMessage(FormatException(exception), LogLevel.Warning, false);
        }

        public override void Warn(Func<string> callback)
        {
            if (!CheckLevel(LogLevel.Warning))
                return;
            
            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Warning;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Warning;

            if (print)
                UnityEngine.Debug.LogWarning(FormatMessage(callback.Invoke()));
            else if (record)
                _logController.RecordMessage(FormatMessage(callback.Invoke()), LogLevel.Warning, false);
        }

        public override void Warn<T1>(Func<T1, string> callback, T1 param01)
        {
            if (!CheckLevel(LogLevel.Warning))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Warning;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Warning;
            
            if (print)
                UnityEngine.Debug.LogWarning(FormatMessage(callback.Invoke(param01)));
            else if (record)
                _logController.RecordMessage(FormatMessage(callback.Invoke(param01)), LogLevel.Warning, false);
        }

        public override void Warn<T1, T2>(Func<T1, T2, string> callback, T1 param01, T2 param02)
        {
            if (!CheckLevel(LogLevel.Warning))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Warning;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Warning;
            
            if (print)
                UnityEngine.Debug.LogWarning(FormatMessage(callback.Invoke(param01, param02)));
            else if (record)
                _logController.RecordMessage(FormatMessage(callback.Invoke(param01, param02)), LogLevel.Warning, false);
        }

        public override void Warn<T1, T2, T3>(Func<T1, T2, T3, string> callback, T1 param01, T2 param02, T3 param03)
        {
            if (!CheckLevel(LogLevel.Warning))
                return;

            if (Logging.Print && Logging.PrintLevel > LogLevel.None)
                UnityEngine.Debug.LogWarning(FormatMessage(callback.Invoke(param01, param02, param03)));
            else if (Logging.Record && Logging.RecordLevel > LogLevel.None)
                _logController.RecordMessage(FormatMessage(callback.Invoke(param01, param02, param03)), LogLevel.Warning, false);
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

            if (print)
                UnityEngine.Debug.LogError(FormatMessage(message));
            else if (record)
                _logController.RecordMessage(FormatMessage(message), LogLevel.Error, true);
        }

        public override void Error(Exception exception)
        {
            if (!CheckLevel(LogLevel.Error))
                return;
            
            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Error;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Error;

            if (print)
                UnityEngine.Debug.LogError(FormatException(exception));
            else if (record)
                _logController.RecordMessage(FormatException(exception), LogLevel.Error, true);
        }

        public override void Error(Func<string> callback)
        {
            if (!CheckLevel(LogLevel.Error))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Error;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Error;
            
            if (print)
                UnityEngine.Debug.LogError(FormatMessage(callback.Invoke()));
            else if (record)
                _logController.RecordMessage(FormatMessage(callback.Invoke()), LogLevel.Error, true);
        }

        public override void Error<T1>(Func<T1, string> callback, T1 param01)
        {
            if (!CheckLevel(LogLevel.Error))
                return;
            
            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Error;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Error;

            if (print)
                UnityEngine.Debug.LogError(FormatMessage(callback.Invoke(param01)));
            else if (record)
                _logController.RecordMessage(FormatMessage(callback.Invoke(param01)), LogLevel.Error, true);
        }

        public override void Error<T1, T2>(Func<T1, T2, string> callback, T1 param01, T2 param02)
        {
            if (!CheckLevel(LogLevel.Error))
                return;
            
            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Error;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Error;

            if (print)
                UnityEngine.Debug.LogError(FormatMessage(callback.Invoke(param01, param02)));
            else if (record)
                _logController.RecordMessage(FormatMessage(callback.Invoke(param01, param02)), LogLevel.Error, true);
        }

        public override void Error<T1, T2, T3>(Func<T1, T2, T3, string> callback, T1 param01, T2 param02, T3 param03)
        {
            if (!CheckLevel(LogLevel.Error))
                return;

            var print = Logging.Print && Logging.PrintLevel > LogLevel.None && Logging.PrintLevel <= LogLevel.Error;
            var record = Logging.Record && Logging.RecordLevel > LogLevel.None && Logging.RecordLevel <= LogLevel.Error;
            
            if (print)
                UnityEngine.Debug.LogError(FormatMessage(callback.Invoke(param01, param02, param03)));
            else if (record)
                _logController.RecordMessage(FormatMessage(callback.Invoke(param01, param02, param03)), LogLevel.Error, true);
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