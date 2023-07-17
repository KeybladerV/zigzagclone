using Build1.PostMVC.Core.MVCS.Events;

namespace Build1.PostMVC.Unity.App.Modules.App
{
    public abstract class AppEvent
    {
        public static readonly Event<bool> Pause      = new Event<bool>(typeof(AppEvent), nameof(Pause));
        public static readonly Event<bool> Focus      = new Event<bool>(typeof(AppEvent), nameof(Focus));
        public static readonly Event       Restarting = new Event(typeof(AppEvent), nameof(Restarting));
        public static readonly Event       Quitting   = new Event(typeof(AppEvent), nameof(Quitting));
    }
}