using Build1.PostMVC.Core.MVCS.Events;

namespace Modules.GameInput
{
    public sealed class GameInputEvent
    {
        public static readonly Event OnAnyInput = new Event(typeof(GameInputEvent), nameof(OnAnyInput));
    }
}