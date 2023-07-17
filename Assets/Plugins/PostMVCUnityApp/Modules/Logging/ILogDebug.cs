using System;

namespace Build1.PostMVC.Unity.App.Modules.Logging
{
    public interface ILogDebug
    {
        void Debug(string message);
        void Debug(Exception exception);
    }
}