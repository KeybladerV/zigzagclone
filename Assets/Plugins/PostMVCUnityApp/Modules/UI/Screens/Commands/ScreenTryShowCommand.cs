using Build1.PostMVC.Core.MVCS.Commands;
using Build1.PostMVC.Core.MVCS.Injection;

namespace Build1.PostMVC.Unity.App.Modules.UI.Screens.Commands
{
    [Poolable]
    public sealed class ScreenTryShowCommand : Command<Screen>
    {
        [Inject] public IScreensController ScreensController { get; set; }
        
        public override void Execute(Screen screen)
        {
            if (!ScreensController.CheckScreenIsActive(screen))
                ScreensController.Show(screen);
        }
    }
    
    [Poolable]
    public sealed class ScreenTryShowCommand<T> : Command<Screen<T>, T>
    {
        [Inject] public IScreensController ScreensController { get; set; }
        
        public override void Execute(Screen<T> screen, T data)
        {
            if (!ScreensController.CheckScreenIsActive(screen))
                ScreensController.Show(screen, data);
        }
    }
}