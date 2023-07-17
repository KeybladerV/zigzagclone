using Models.Settings;

namespace Modules.Settings
{
    public interface ISettingsController
    {
        IReadOnlySettings Settings { get; }
        
        void ChangeSkin(int skin);
        void ChangeSound(bool soundOn);
        void ChangeAuto(bool autoOn);
    }
}