using System;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Modules.Assets;
using Build1.PostMVC.Unity.App.Modules.Device;

namespace Build1.PostMVC.Unity.App.Modules.UI.Popups
{
    public sealed class PopupConfig : UIControlConfiguration
    {
        public PopupConfig(string asset, int layerId) : base(asset, layerId) { }
        public PopupConfig(string asset, int layerId, Enum assetBundleId) : base(asset, layerId, assetBundleId) { }
        public PopupConfig(string asset, int layerId, AssetBundleInfo assetBundleInfo) : base(asset, layerId, assetBundleInfo) { }

        /*
         * Platform.
         */

        public PopupConfig SetPlatform(DevicePlatform platform)
        {
            DevicePlatform = platform;
            return this;
        }

        /*
         * Device.
         */

        public PopupConfig SetDeviceType(DeviceType type)
        {
            DeviceType = type;
            return this;
        }

        /*
         * Bindings.
         */
        
        public new PopupConfig AddBinding<V, M>() where V : IPopupView
                                                  where M : Mediator
        {
            base.AddBinding<V, M>();
            return this;
        }

        public new PopupConfig AddBinding<V, I, M>() where V : IPopupView, I
                                                     where M : Mediator
        {
            base.AddBinding<V, I, M>();
            return this;
        }
    }
}