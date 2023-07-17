using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Unity.App.Mediation;
using Components.Screens.Main;
using Models.Settings;
using Modules.Repository;

namespace Modules.Settings.Impl
{
    public sealed class SettingsController : ISettingsController
    {
        private const string FileName = "settings.json";

        [Inject] public IEventDispatcher Dispatcher { get; set; }
        [Inject] public IRepositoryController RepositoryController { get; set; }

        private SettingsModel _settings;
        
        public IReadOnlySettings Settings => _settings;

        [PostConstruct]
        private void PostConstruct()
        {
            _settings = RepositoryController.LoadOrCreate<SettingsModel>(FileName, out var created);
            if (created)
            {
                _settings.Skin = 0;
                _settings.SoundOn = true;
                _settings.AutoOn = false;
            }
        }

        [OnDestroy]
        private void OnDestroying()
        {
            RepositoryController.Save(_settings, FileName);
        }

        public void ChangeSkin(int skin)
        {
            _settings.Skin = skin;
            Dispatcher.Dispatch(SettingsEvents.OnSkinSettingsChanged, skin);
        }

        public void ChangeSound(bool soundOn)
        {
            _settings.SoundOn = soundOn;
            Dispatcher.Dispatch(SettingsEvents.OnSoundSettingsChanged, soundOn);
        }

        public void ChangeAuto(bool autoOn)
        {
            _settings.AutoOn = autoOn;
            Dispatcher.Dispatch(SettingsEvents.OnAutoSettingsChanged, autoOn);
        }
    }
}