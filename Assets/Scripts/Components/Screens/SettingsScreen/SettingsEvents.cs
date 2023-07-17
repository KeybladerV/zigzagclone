using Build1.PostMVC.Core.MVCS.Events;

namespace Components.Screens.Main
{
    public static class SettingsEvents
    {
        public static readonly Event<bool> OnSoundSettingsChanged = new Event<bool>();
        public static readonly Event<bool> OnAutoSettingsChanged = new Event<bool>();
        public static readonly Event<int> OnSkinSettingsChanged = new Event<int>();
    }
}