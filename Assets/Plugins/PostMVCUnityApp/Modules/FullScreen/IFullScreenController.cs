namespace Build1.PostMVC.Unity.App.Modules.FullScreen
{
    public interface IFullScreenController
    {
        bool IsInFullScreen { get; }
        
        void ToggleFullScreen();
    }
}