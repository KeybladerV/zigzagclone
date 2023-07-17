using Build1.PostMVC.Core.Modules;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Unity.App.Modules.UI.Layers;
using Build1.PostMVC.Unity.App.Modules.UI.Layers.Impl;
using Build1.PostMVC.Unity.App.Modules.UI.Popups;
using Build1.PostMVC.Unity.App.Modules.UI.Popups.Impl;
using Build1.PostMVC.Unity.App.Modules.UI.Screens;
using Build1.PostMVC.Unity.App.Modules.UI.Screens.Impl;

namespace Build1.PostMVC.Unity.App.Modules.UI
{
    public sealed class UIModule : Module
    {
        [Inject] public IInjectionBinder InjectionBinder { get; set; }
        
        [PostConstruct]
        public void PostConstruct()
        {
            InjectionBinder.Bind<IPopupController, PopupController>();
            InjectionBinder.Bind<IScreensController, ScreensController>();
            InjectionBinder.Bind<IUILayersController, UILayersController>();
        }   
    }
}