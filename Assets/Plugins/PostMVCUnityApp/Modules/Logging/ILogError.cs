using System;

namespace Build1.PostMVC.Unity.App.Modules.Logging
{
    public interface ILogError
    {
        void Error(string message);
        void Error(Exception exception);
    }
}