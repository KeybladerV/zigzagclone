using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Unity.App.Modules.Logging;
using UnityEngine;

namespace Build1.PostMVC.Unity.App.Modules.FullScreen.Impl
{
    internal sealed class FullScreenController : IFullScreenController
    {
        [Log(LogLevel.Warning)] public ILog             Log        { get; set; }
        [Inject]                public IEventDispatcher Dispatcher { get; set; }

        public bool IsInFullScreen => Screen.fullScreen;

        public void ToggleFullScreen()
        {
            if (Application.isEditor)
            {
                Log.Warn("Full screen is not supported in Editor.");
                return;
            }

            var fullScreen = !Screen.fullScreen;
            Screen.fullScreen = fullScreen;
            
            Dispatcher.Dispatch(FullScreenEvent.Changed, fullScreen);
        }
    }
}