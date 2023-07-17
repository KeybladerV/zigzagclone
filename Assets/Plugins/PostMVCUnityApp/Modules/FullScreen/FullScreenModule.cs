using Build1.PostMVC.Core.Modules;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Unity.App.Modules.FullScreen.Impl;

namespace Build1.PostMVC.Unity.App.Modules.FullScreen
{
    public sealed class FullScreenModule : Module
    {
        [Inject] public IInjectionBinder InjectionBinder { get; set; }
        
        [PostConstruct]
        public void PostConstruct()
        {
            InjectionBinder.Bind<IFullScreenController, FullScreenController>();
        }
    }
}