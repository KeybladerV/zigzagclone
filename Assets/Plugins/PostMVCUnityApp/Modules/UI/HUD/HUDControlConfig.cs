using System;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Mediation;
using Build1.PostMVC.Unity.App.Modules.Assets;
using Build1.PostMVC.Unity.App.Modules.Device;

namespace Build1.PostMVC.Unity.App.Modules.UI.HUD
{
    public sealed class HUDControlConfig : UIControlConfiguration
    {
        public HUDControlConfig(string asset, int layerId) : base(asset, layerId) { }
        public HUDControlConfig(string asset, int layerId, Enum assetBundleId) : base(asset, layerId, assetBundleId) { }
        public HUDControlConfig(string asset, int layerId, AssetBundleInfo assetBundleInfo) : base(asset, layerId, assetBundleInfo) { }

        /*
         * Platform.
         */

        public HUDControlConfig SetPlatform(DevicePlatform platform)
        {
            DevicePlatform = platform;
            return this;
        }

        /*
         * Device.
         */

        public HUDControlConfig SetDeviceType(DeviceType type)
        {
            DeviceType = type;
            return this;
        }

        /*
         * Bindings.
         */

        public new HUDControlConfig AddBinding<V, M>() where V : IUnityView
                                                       where M : Mediator
        {
            base.AddBinding<V, M>();
            return this;
        }

        public new HUDControlConfig AddBinding<V, I, M>() where V : IUnityView, I
                                                          where M : Mediator
        {
            base.AddBinding<V, I, M>();
            return this;
        }
    }
}