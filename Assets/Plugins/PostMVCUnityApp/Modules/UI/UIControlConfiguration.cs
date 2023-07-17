using System;
using System.Collections;
using System.Collections.Generic;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Mediation;
using Build1.PostMVC.Unity.App.Modules.Assets;
using Build1.PostMVC.Unity.App.Modules.Device;

namespace Build1.PostMVC.Unity.App.Modules.UI
{
    public abstract class UIControlConfiguration : IDeviceDependentConfiguration, IEnumerable<UIControlBinding>
    {
        public DevicePlatform DevicePlatform { get; protected set; } = DevicePlatform.Any;
        public DeviceType     DeviceType     { get; protected set; } = DeviceType.Any;

        public readonly AssetBundleInfo        bundleInfo;
        public readonly Enum                   bundleId;
        public readonly string                 prefabName;
        public readonly int                    appLayerId;
        public readonly List<UIControlBinding> bindings = new List<UIControlBinding>();

        protected UIControlConfiguration(string asset, int layerId)
        {
            prefabName = asset;
            appLayerId = layerId;
        }
        
        protected UIControlConfiguration(string asset, int layerId, Enum assetBundleId)
        {
            prefabName = asset;
            appLayerId = layerId;
            bundleId = assetBundleId;
        }
        
        protected UIControlConfiguration(string asset, int layerId, AssetBundleInfo assetBundleInfo)
        {
            prefabName = asset;
            appLayerId = layerId;
            bundleInfo = assetBundleInfo;
        }
        
        /*
         * Bindings.
         */
        
        protected UIControlConfiguration AddBinding<V>() where V : IUnityView
        {
            bindings.Add(new UIControlBinding(typeof(V)));
            return this;
        }

        protected UIControlConfiguration AddBinding<V, M>() where V : IUnityView
                                                            where M : Mediator
        {
            bindings.Add(new UIControlBinding(typeof(V), typeof(M)));
            return this;
        }

        protected UIControlConfiguration AddBinding<V, I, M>() where V : IUnityView, I
                                                               where M : Mediator
        {
            bindings.Add(new UIControlBinding(typeof(V), typeof(I), typeof(M)));
            return this;
        }
        
        /*
         * Enumeration.
         */

        public IEnumerator<UIControlBinding> GetEnumerator()
        {
            return bindings.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}