using System;

namespace Build1.PostMVC.Unity.App.Modules.InternetReachability
{
    public interface IInternetReachabilityController
    {
        void Check(Action<bool> onComplete, int timeout);
        void Check(Action<bool> onComplete);
    }
}