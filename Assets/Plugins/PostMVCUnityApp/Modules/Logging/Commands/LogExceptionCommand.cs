using System;
using Build1.PostMVC.Core.MVCS.Commands;

namespace Build1.PostMVC.Unity.App.Modules.Logging.Commands
{
    [Poolable]
    public sealed class LogExceptionCommand : Command<Exception>
    {
        private static readonly ILog _log = LogProvider.GetLog(LogLevel.Warning);
        
        public override void Execute(Exception exception)
        {
            _log.Error(exception);
        }
    }
}