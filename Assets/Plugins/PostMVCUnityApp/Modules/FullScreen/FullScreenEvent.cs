using Build1.PostMVC.Core.MVCS.Events;

namespace Build1.PostMVC.Unity.App.Modules.FullScreen
{
    public static class FullScreenEvent
    {
        public static readonly Event<bool> Changed = new Event<bool>(typeof(FullScreenEvent), nameof(Changed));
    }
}