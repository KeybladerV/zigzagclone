using Build1.PostMVC.Core.MVCS.Commands;
using Build1.PostMVC.Core.MVCS.Injection;

namespace Build1.PostMVC.Unity.App.Modules.UI.Screens.Commands
{
    [Poolable]
    public sealed class ScreenShowCommand : Command<Screen>
    {
        [Inject] public IScreensController ScreensController { get; set; }

        public override void Execute(Screen screen)
        {
            ScreensController.Show(screen);
        }
    }
    
    [Poolable]
    public sealed class ScreenShowOnTopCommand : Command<Screen>
    {
        [Inject] public IScreensController ScreensController { get; set; }

        public override void Execute(Screen screen)
        {
            ScreensController.Show(screen, ScreenBehavior.OpenOnTop);
        }
    }

    [Poolable]
    public sealed class ScreenShowCommand<T> : Command<Screen<T>, T>
    {
        [Inject] public IScreensController ScreensController { get; set; }

        public override void Execute(Screen<T> screen, T data)
        {
            ScreensController.Show(screen, data);
        }
    }
}