using Build1.PostMVC.Core.MVCS.Events;

namespace Build1.PostMVC.Unity.App.Modules.UI.Screens
{
    public static class ScreenEvent
    {
        public static readonly Event<ScreenBase> Created   = new Event<ScreenBase>(typeof(ScreenEvent), nameof(Created));
        public static readonly Event<ScreenBase> Destroyed = new Event<ScreenBase>(typeof(ScreenEvent), nameof(Destroyed));
        public static readonly Event<ScreenBase> Shown     = new Event<ScreenBase>(typeof(ScreenEvent), nameof(Shown));
        public static readonly Event<ScreenBase> Hidden    = new Event<ScreenBase>(typeof(ScreenEvent), nameof(Hidden));
    }
}