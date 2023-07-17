using System;
using Build1.PostMVC.Core.MVCS.Commands;

namespace Build1.PostMVC.Unity.App.Modules.Logging.Commands
{
    [Poolable]
    public sealed class LogCommand : Command<LogLevel, string>
    {
        private static readonly ILog _log = LogProvider.GetLog(LogLevel.All);
        
        public override void Execute(LogLevel logLevel, string entry)
        {
            switch (logLevel)
            {
                case LogLevel.None:
                    break;
                case LogLevel.All:
                case LogLevel.Debug:
                    _log.Debug(entry);
                    break;
                case LogLevel.Warning:
                    _log.Warn(entry);
                    break;
                case LogLevel.Error:
                    _log.Error(entry);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }
    }
}