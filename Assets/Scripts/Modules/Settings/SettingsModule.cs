using Build1.PostMVC.Core.Modules;
using Build1.PostMVC.Core.MVCS.Injection;
using Modules.Settings.Impl;

namespace Modules.Settings
{
    public class SettingsModule : Module
    {
        [Inject] public IInjectionBinder InjectionBinder { get; set; }
        
        [PostConstruct]
        private void PostConstruct()
        {
            InjectionBinder.Bind<ISettingsController, SettingsController>().ConstructOnStart();
        }
    }
}