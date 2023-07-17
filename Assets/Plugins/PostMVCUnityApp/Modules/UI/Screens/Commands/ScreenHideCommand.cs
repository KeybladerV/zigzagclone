using Build1.PostMVC.Core.MVCS.Commands;
using Build1.PostMVC.Core.MVCS.Injection;

namespace Build1.PostMVC.Unity.App.Modules.UI.Screens.Commands
{
    [Poolable]
    public sealed class ScreenHideCommand : Command<Screen>
    {
        [Inject] public IScreensController ScreensController { get; set; }
        
        public override void Execute(Screen screen)
        {
            ScreensController.Hide(screen);
        }
    }
}