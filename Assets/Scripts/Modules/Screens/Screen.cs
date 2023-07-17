using Build1.PostMVC.Unity.App.Modules.UI;
using Build1.PostMVC.Unity.App.Modules.UI.Screens;
using Modules.Assets;
using ScreenInfo = Build1.PostMVC.Unity.App.Modules.UI.Screens.Screen;

namespace Modules.Screens
{
    public static class Screen
    {
        public static readonly ScreenInfo Loading = new ScreenInfo("Loading", UIBehavior.SingleInstance | UIBehavior.DestroyOnDeactivation)
        {
            new ScreenConfig("LoadingScreen.prefab", RootLayer.SystemScreensCanvas, AssetBundle.AppLoading)
        };
        
        public static readonly ScreenInfo MainScreen = new ScreenInfo("MainMenu", UIBehavior.SingleInstance | UIBehavior.DestroyOnDeactivation)
        {
            new ScreenConfig("MainScreen.prefab", RootLayer.OverlayScreensCanvas, AssetBundle.UI)
        };
        
        public static readonly ScreenInfo GameScreen = new ScreenInfo("GameScreen", UIBehavior.SingleInstance | UIBehavior.DestroyOnDeactivation)
        {
            new ScreenConfig("GameScreen.prefab", RootLayer.OverlayScreensCanvas, AssetBundle.UI)
        };
        
        public static readonly ScreenInfo SkinScreen = new ScreenInfo("SkinScreen", UIBehavior.SingleInstance | UIBehavior.DestroyOnDeactivation)
        {
            new ScreenConfig("SkinScreen.prefab", RootLayer.OverlayScreensCanvas, AssetBundle.UI)
        };
        
        public static readonly ScreenInfo SettingsScreen = new ScreenInfo("SettingsScreen", UIBehavior.SingleInstance | UIBehavior.DestroyOnDeactivation)
        {
            new ScreenConfig("SettingsScreen.prefab", RootLayer.OverlayScreensCanvas, AssetBundle.UI)
        };
        
        public static readonly ScreenInfo GameOverScreen = new ScreenInfo("GameOverScreen", UIBehavior.SingleInstance | UIBehavior.DestroyOnDeactivation)
        {
            new ScreenConfig("GameOverScreen.prefab", RootLayer.OverlayScreensCanvas, AssetBundle.UI)
        };
        
        public static readonly ScreenInfo PauseScreen = new ScreenInfo("PauseScreen", UIBehavior.SingleInstance | UIBehavior.DestroyOnDeactivation)
        {
            new ScreenConfig("PauseScreen.prefab", RootLayer.OverlayScreensCanvas, AssetBundle.UI)
        };
    }
}