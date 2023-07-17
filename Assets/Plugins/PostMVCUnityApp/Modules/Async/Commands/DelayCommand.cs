using Build1.PostMVC.Core.MVCS.Commands;
using Build1.PostMVC.Core.MVCS.Injection;

namespace Build1.PostMVC.Unity.App.Modules.Async.Commands
{
    [Poolable]
    public sealed class DelayCommand : Command<float>
    {
        [Inject] public IAsyncResolver AsyncResolver { get; set; }
        
        public override void Execute(float delay)
        {
            if (delay <= 0)
                return;
            
            Retain();
            AsyncResolver.DelayedCall(Release, delay);
        }
    }
}