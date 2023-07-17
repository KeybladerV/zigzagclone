using Build1.PostMVC.Core.MVCS.Commands;
using Build1.PostMVC.Core.MVCS.Injection;

namespace Build1.PostMVC.Unity.App.Modules.Assets.Commands
{
    [Poolable]
    public sealed class AssetBundleLoadCommand : Command<AssetBundleInfo>
    {
        [Inject] public IAssetsController AssetsController { get; set; }

        public override void Execute(AssetBundleInfo info)
        {
            Retain();
            AssetsController.LoadBundle(info, _ => Release(), Fail);
        }
    }
}