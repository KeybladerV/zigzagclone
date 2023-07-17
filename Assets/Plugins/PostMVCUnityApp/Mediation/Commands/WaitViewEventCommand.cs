using Build1.PostMVC.Core.MVCS.Commands;
using Build1.PostMVC.Core.MVCS.Events;

namespace Build1.PostMVC.Unity.App.Mediation.Commands
{
    [Poolable]
    public sealed class WaitViewEventCommand<T> : Command<T, Event> where T : UnityViewDispatcher
    {
        public override void Execute(T view, Event @event)
        {
            Retain();
            view.AddListenerOnce(@event, OnEventDispatched);
        }

        private void OnEventDispatched()
        {
            Release();
        }
    }
}