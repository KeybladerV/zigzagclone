using Build1.PostMVC.Core.MVCS.Commands;
using Build1.PostMVC.Core.MVCS.Injection;

namespace Build1.PostMVC.Unity.App.Modules.UI.Popups.Commands
{
    [Poolable]
    public sealed class PopupTryCloseCommand : Command<PopupBase>
    {
        [Inject] public IPopupController PopupController { get; set; }

        public override void Execute(PopupBase popupBase)
        {
            if (PopupController.CheckPopupOpen(popupBase))
                PopupController.Close(popupBase, false);
        }
    }
}