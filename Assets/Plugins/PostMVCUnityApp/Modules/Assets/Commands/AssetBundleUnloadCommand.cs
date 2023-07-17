using Build1.PostMVC.Core.MVCS.Commands;
using Build1.PostMVC.Core.MVCS.Injection;

namespace Build1.PostMVC.Unity.App.Modules.Assets.Commands
{
    [Poolable]
    public sealed class AssetBundleUnloadCommand : Command<AssetBundleInfo, bool>
    {
        [Inject] public IAssetsController AssetsController { get; set; }

        public override void Execute(AssetBundleInfo info, bool unloadObjects)
        {
            AssetsController.UnloadBundle(info, unloadObjects);
        }
    }
}