using Build1.PostMVC.Unity.App.Modules.UI;
using Build1.PostMVC.Unity.App.Modules.UI.Popups;
using Components.Popups.Generic;
using Modules.Assets;

namespace Modules.Popups
{
    public static class Popups
    {
        public static readonly Popup<GenericPopupData> Generic = new Popup<GenericPopupData>("GenericPopup", UIBehavior.SingleInstance | UIBehavior.DestroyOnDeactivation)
        {
            new PopupConfig("Prefabs/Popups/Generic/GenericPopup.prefab", RootLayer.SystemPopups)
        };
        
        /*
         * Other.
         */

        public static readonly Popup SettingsLanguageSelection = new Popup("LanguageSelectionPopup", UIBehavior.SingleInstance | UIBehavior.DestroyOnDeactivation)
        {
            new PopupConfig("LanguageSelectionPopup.prefab", RootLayer.OverlayPopups, AssetBundle.UI)
        };
    }
}