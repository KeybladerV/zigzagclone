using Build1.PostMVC.Core.Modules;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Unity.App.Modules.Device.Impl;

namespace Build1.PostMVC.Unity.App.Modules.Device
{
    public sealed class DeviceModule : Module
    {
        [Inject] public IInjectionBinder InjectionBinder { get; set; }
        
        [PostConstruct]
        public void PostConstruct()
        {
            #if UNITY_EDITOR
                InjectionBinder.Bind<IDeviceController, DeviceControllerEditor>().ConstructOnStart();
            #else
                InjectionBinder.Bind<IDeviceController, DeviceControllerRuntime>().ConstructOnStart();
            #endif
        }
    }
}