using Build1.PostMVC.Core.MVCS.Commands;
using Build1.PostMVC.Core.MVCS.Injection;

namespace Build1.PostMVC.Unity.App.Modules.UI.Popups.Commands
{
    public sealed class PopupOpenWith1ParamCommand<T> : Command<Popup<T>, T>
    {
        [Inject] public IPopupController PopupController { get; set; }
        
        public override void Execute(Popup<T> popup, T param)
        {
            PopupController.Open(popup, param);
        }
    }
}