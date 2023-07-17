using Build1.PostMVC.Core.Modules;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Unity.App.Modules.Logging.Impl;

namespace Build1.PostMVC.Unity.App.Modules.Logging
{
    internal sealed class LogModule : Module
    {
        [Inject] public IInjectionBinder InjectionBinder { get; set; }
        
        [PostConstruct]
        public void PostConstruct()
        {
            InjectionBinder.Bind<ILogController, LogController>().ConstructOnStart();
            
            #if UNITY_WEBGL && !UNITY_EDITOR
            
            InjectionBinder.Bind<ILog, LogProviderWebGL, LogAttribute>();
            InjectionBinder.Bind<ILogProvider, LogProviderWebGL>();

            #else

            InjectionBinder.Bind<ILog, LogProviderDefault, LogAttribute>();
            InjectionBinder.Bind<ILogProvider, LogProviderDefault>();

            #endif
        }
    }
}