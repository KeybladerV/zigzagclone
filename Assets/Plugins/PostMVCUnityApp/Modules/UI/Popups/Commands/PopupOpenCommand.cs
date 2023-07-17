using Build1.PostMVC.Core.MVCS.Commands;
using Build1.PostMVC.Core.MVCS.Injection;

namespace Build1.PostMVC.Unity.App.Modules.UI.Popups.Commands
{
    public sealed class PopupOpenCommand : Command<Popup>
    {
        [Inject] public IPopupController PopupController { get; set; }

        public override void Execute(Popup popup)
        {
            PopupController.Open(popup);
        }
    }
}