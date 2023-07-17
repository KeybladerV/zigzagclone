using Build1.PostMVC.Core.Modules;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Unity.App.Modules.InternetReachability.Impl;

namespace Build1.PostMVC.Unity.App.Modules.InternetReachability
{
    internal sealed class InternetReachabilityModule : Module
    {
        [Inject] public IInjectionBinder InjectionBinder { get; set; }
        
        [PostConstruct]
        public void PostConstruct()
        {
            InjectionBinder.Bind<IInternetReachabilityController, InternetReachabilityController>();
        }
    }
}