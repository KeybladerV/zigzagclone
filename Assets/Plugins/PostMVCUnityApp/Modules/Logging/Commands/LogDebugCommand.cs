using Build1.PostMVC.Core.MVCS.Commands;

namespace Build1.PostMVC.Unity.App.Modules.Logging.Commands
{
    [Poolable]
    public sealed class LogDebugCommand : Command<string>
    {
        private static readonly ILog _log = LogProvider.GetLog(LogLevel.Debug);
        
        public override void Execute(string message)
        {
            _log.Debug(message);
        }
    }
}