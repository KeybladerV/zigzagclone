using System;
using Build1.PostMVC.Core.MVCS.Commands;

namespace Build1.PostMVC.Unity.App.Modules.Logging.Commands
{
    [Poolable]
    public sealed class LogToLogCommand : Command<ILog, LogLevel, string>
    {
        public override void Execute(ILog log, LogLevel logLevel, string entry)
        {
            switch (logLevel)
            {
                case LogLevel.None:
                    break;
                case LogLevel.All:
                case LogLevel.Debug:
                    log.Debug(entry);
                    break;
                case LogLevel.Warning:
                    log.Warn(entry);
                    break;
                case LogLevel.Error:
                    log.Error(entry);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }
    }
}