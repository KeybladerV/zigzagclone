using System;

namespace Build1.PostMVC.Unity.App.Modules.Logging
{
    public interface ILogWarn
    {
        void Warn(string message);
        void Warn(Exception exception);
    }
}