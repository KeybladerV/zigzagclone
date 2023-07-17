namespace Modules.GameInput
{
    public interface IGameInputController
    {
        void BlockInput( object blocker);
        void UnblockInput(object blocker);
    }
}