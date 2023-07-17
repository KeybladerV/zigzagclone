using Build1.PostMVC.Core.MVCS.Events;

namespace Build1.PostMVC.Unity.App.Modules.Developers
{
    public static class DevelopmentEvent
    {
        public static Event<string> Message = new Event<string>();
    }
}