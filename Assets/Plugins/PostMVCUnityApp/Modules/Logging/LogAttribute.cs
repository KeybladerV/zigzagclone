using System;
using Build1.PostMVC.Core.MVCS.Injection;

namespace Build1.PostMVC.Unity.App.Modules.Logging
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class LogAttribute : Inject
    {
        public readonly LogLevel logLevel;

        public LogAttribute(LogLevel logLevel)
        {
            this.logLevel = logLevel;
        }
    }
}