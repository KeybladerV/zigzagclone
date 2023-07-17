namespace Build1.PostMVC.Unity.App.Modules.Logging
{
    internal interface ILogProvider
    {
        public ILog CreateLogInstance(string prefix, LogLevel level, ILogController logController);
    }
}