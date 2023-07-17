using System;

namespace Build1.PostMVC.Unity.App.Modules.Update
{
    public interface IUpdateController
    {
        void SubscribeForFixedUpdate(Action<float> callback);
        void SubscribeForUpdate(Action<float> callback);
        void SubscribeForLateUpdate(Action<float> callback);
        
        void Unsubscribe(Action<float> updatable);
    }
}