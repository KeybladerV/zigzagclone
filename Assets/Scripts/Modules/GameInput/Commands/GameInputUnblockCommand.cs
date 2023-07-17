using Build1.PostMVC.Core.MVCS.Commands;
using Build1.PostMVC.Core.MVCS.Injection;

namespace Modules.GameInput.Commands
{
    [Poolable]
    public sealed class GameInputUnblockCommand : Command<object>
    {
        [Inject] public IGameInputController GameInputController { get; set; }

        public override void Execute(object blocker)
        {
            GameInputController.UnblockInput(blocker);
        }
    }
}