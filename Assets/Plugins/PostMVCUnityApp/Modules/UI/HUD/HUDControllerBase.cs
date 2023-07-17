namespace Build1.PostMVC.Unity.App.Modules.UI.HUD
{
    public abstract class HUDControllerBase : UIControlsController<HUDControl, HUDControlConfig>
    {
        protected void Show(HUDControl control)
        {
            GetInstance(control, UIControlOptions.Instantiate | UIControlOptions.Activate);
        }

        protected void Hide(HUDControl control)
        {
            Deactivate(control);
        }
    }
}