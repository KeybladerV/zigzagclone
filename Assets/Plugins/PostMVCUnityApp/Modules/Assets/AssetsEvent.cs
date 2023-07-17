using System;
using Build1.PostMVC.Core.MVCS.Events;

namespace Build1.PostMVC.Unity.App.Modules.Assets
{
    public static class AssetsEvent
    {
        public static readonly Event<AssetBundleInfo>            BundleLoadingProgress = new Event<AssetBundleInfo>(typeof(AssetsEvent), nameof(BundleLoadingProgress));
        public static readonly Event<AssetBundleInfo>            BundleLoadingSuccess  = new Event<AssetBundleInfo>(typeof(AssetsEvent), nameof(BundleLoadingSuccess));
        public static readonly Event<AssetBundleInfo, Exception> BundleLoadingFail     = new Event<AssetBundleInfo, Exception>(typeof(AssetsEvent), nameof(BundleLoadingFail));
    }
}