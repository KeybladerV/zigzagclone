using System.Collections.Generic;
using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Unity.App.Modules.Logging;

namespace Build1.PostMVC.Unity.App.Modules.UI.Screens.Impl
{
    public sealed class ScreensController : UIControlsController<ScreenBase, ScreenConfig>, IScreensController
    {
        [Log(LogLevel.Warning)] public ILog             Log             { get; set; }
        [Inject]                public IEventDispatcher Dispatcher      { get; set; }
        [Inject]                public IInjectionBinder InjectionBinder { get; set; }

        public ScreenBase CurrentScreen   { get; private set; }
        public bool       HasShownScreens => _openScreens.Count > 0;

        private readonly List<ScreenBase>        _openScreens;
        private readonly Dictionary<int, object> _openScreensData;

        public ScreensController()
        {
            _openScreens = new List<ScreenBase>(4);
            _openScreensData = new Dictionary<int, object>(4);
        }

        /*
         * Show.
         */

        public void Show(Screen screen)
        {
            ShowImpl(screen, null, ScreenBehavior.Replace);
        }

        public void Show(Screen screen, ScreenBehavior behavior)
        {
            ShowImpl(screen, null, behavior);
        }

        public void Show<T>(Screen<T> screen, T data)
        {
            ShowImpl(screen, data, ScreenBehavior.Replace);
        }

        public void Show<T>(Screen screen, T data, ScreenBehavior behavior)
        {
            ShowImpl(screen, data, behavior);
        }

        private void ShowImpl(ScreenBase screen, object data, ScreenBehavior behavior)
        {
            Log.Debug((s, b) => $"Show. {s} {b}", screen, behavior);

            if (screen == CurrentScreen)
            {
                Log.Warn(s => $"Screen already shown: {s}", screen);
                return;
            }

            var previousScreen = CurrentScreen;
            if (behavior == ScreenBehavior.Replace && CurrentScreen != null)
            {
                HideScreenImpl(CurrentScreen);
                CurrentScreen = null;
            }

            IInjectionBinding dataBinding = null;

            if (screen.dataType != null)
                dataBinding = InjectionBinder.Bind(screen.dataType).ToValue(data).ToBinding();
            
            var instance = GetInstance(screen, UIControlOptions.Instantiate | UIControlOptions.Activate, out var isNewInstance);
            if (instance == null)
            {
                Log.Error(s => $"Failed to instantiate screen: {s}", screen);
                return;
            }
            
            if (dataBinding != null)
                InjectionBinder.Unbind(dataBinding);

            if (!_openScreens.Contains(screen))
            {
                if (behavior == ScreenBehavior.OpenOnTop)
                {
                    _openScreens.Insert(0, screen);
                    _openScreensData[0] = data;

                    // No need to move object in hierarchy as it'll be added on top of everything on the layer.
                }
                else
                {
                    _openScreens.Add(screen);
                    _openScreensData[_openScreens.IndexOf(screen)] = data;
                }
            }

            if (isNewInstance)
                Dispatcher.Dispatch(ScreenEvent.Created, screen);

            if (behavior != ScreenBehavior.OpenInBackground)
            {
                CurrentScreen = screen;
                Dispatcher.Dispatch(ScreenEvent.Shown, screen);
            }

            if (behavior == ScreenBehavior.OpenOnTop && previousScreen != null)
                Dispatcher.Dispatch(ScreenEvent.Hidden, previousScreen);
        }
        
        /*
         * Hide.
         */

        public void Hide(ScreenBase screen)
        {
            Log.Debug(s => $"Hide. {s}", screen);

            HideScreenImpl(screen);

            if (CurrentScreen == screen)
                CurrentScreen = null;

            if (_openScreens.Count == 0)
                return;

            _openScreensData.TryGetValue(0, out var data);
            
            ShowImpl(_openScreens[0], data, ScreenBehavior.Replace);
        }

        /*
         * Check.
         */

        public bool CheckScreenIsActive(ScreenBase screen)
        {
            return _openScreens.Contains(screen);
        }

        public bool CheckScreenIsCurrent(ScreenBase screen)
        {
            return CurrentScreen == screen;
        }

        /*
         * Private.
         */

        private void HideScreenImpl(ScreenBase screen)
        {
            Log.Debug(s => $"HideScreenImpl. {s}", screen);

            if (!_openScreens.Contains(screen))
            {
                Log.Error(s => $"Specified screen is not shown: {s}", screen);
                return;
            }

            if (!Deactivate(screen, out var destroyed) || !_openScreens.Remove(screen))
                return;

            Log.Debug((s, d) => $"Hidden: {s} destroyed={d}", screen, destroyed);

            Dispatcher.Dispatch(ScreenEvent.Hidden, screen);

            if (destroyed)
                Dispatcher.Dispatch(ScreenEvent.Destroyed, screen);
        }
    }
}