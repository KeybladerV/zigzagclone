using Build1.PostMVC.Core.Modules;
using Build1.PostMVC.Core.MVCS.Injection;
using Modules.Platforms.Impl;

namespace Modules.Platforms
{
    public sealed class PlatformsModule : Module
    {
        [Inject] public IInjectionBinder InjectionBinder { get; set; }
        
        [PostConstruct]
        private void PostConstruct()
        {
            InjectionBinder.Bind<IPlatformsController, PlatformsController>();
        }
    }
}