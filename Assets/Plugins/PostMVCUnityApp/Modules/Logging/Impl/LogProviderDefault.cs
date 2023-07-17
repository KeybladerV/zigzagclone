namespace Build1.PostMVC.Unity.App.Modules.Logging.Impl
{
    internal sealed class LogProviderDefault : LogProviderBase
    {
        public override ILog CreateLogInstance(string prefix, LogLevel level, ILogController logController)
        {
            return new LogDefault(prefix, level, logController);
        }
    }
}