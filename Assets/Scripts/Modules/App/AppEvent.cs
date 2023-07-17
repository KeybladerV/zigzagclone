using System;
using Build1.PostMVC.Core.MVCS.Events;

namespace Modules.App
{
    public static class AppEvent
    {
        public static readonly Event            Initialize         = new Event(typeof(AppEvent), nameof(Initialize));
        public static readonly Event            InitializeComplete = new Event(typeof(AppEvent), nameof(InitializeComplete));
        public static readonly Event<Exception> InitializeFail     = new Event<Exception>(typeof(AppEvent), nameof(InitializeFail));

        public static readonly Event            Preload         = new Event(typeof(AppEvent), nameof(Preload));
        public static readonly Event            PreloadComplete = new Event(typeof(AppEvent), nameof(PreloadComplete));
        public static readonly Event<Exception> PreloadFail     = new Event<Exception>(typeof(AppEvent), nameof(PreloadFail));

        public static readonly Event            Load         = new Event(typeof(AppEvent), nameof(Load));
        public static readonly Event            LoadFinished = new Event(typeof(AppEvent), nameof(LoadFinished));
        public static readonly Event<Exception> LoadFail     = new Event<Exception>(typeof(AppEvent), nameof(LoadFail));

        public static readonly Event            PostLoad         = new Event(typeof(AppEvent), nameof(PostLoad));
        public static readonly Event            PostLoadComplete = new Event(typeof(AppEvent), nameof(PostLoadComplete));
        public static readonly Event<Exception> PostLoadFail     = new Event<Exception>(typeof(AppEvent), nameof(PostLoadFail));

        // Game fully loaded and player is presented with game view.
        public static readonly Event Loaded = new Event(typeof(AppEvent), nameof(Loaded));
    }
}