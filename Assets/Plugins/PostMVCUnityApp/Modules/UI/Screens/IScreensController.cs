namespace Build1.PostMVC.Unity.App.Modules.UI.Screens
{
    public interface IScreensController
    {
        ScreenBase CurrentScreen   { get; }
        bool       HasShownScreens { get; }

        void Show(Screen screen);
        void Show(Screen screen, ScreenBehavior behavior);

        void Show<T>(Screen<T> screen, T data);
        void Show<T>(Screen screen, T data, ScreenBehavior behavior);

        void Hide(ScreenBase screen);

        bool CheckScreenIsActive(ScreenBase screen);
        bool CheckScreenIsCurrent(ScreenBase screen);
    }
}