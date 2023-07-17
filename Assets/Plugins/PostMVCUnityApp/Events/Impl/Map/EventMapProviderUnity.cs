using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Core.MVCS.Events.Impl.Map;
using Build1.PostMVC.Core.MVCS.Injection;

namespace Build1.PostMVC.Unity.App.Events.Impl.Map
{
    internal sealed class EventMapProviderUnity : EventMapProviderCore<IEventMap>
    {
        [Inject] public IEventDispatcher Dispatcher { get; set; }
        [Inject] public IEventBus        EventBus   { get; set; }

        protected override IEventMap CreateMap()
        {
            return new EventMapUnity(Dispatcher, EventBus, _infoPools);
        }

        protected override void OnMapReturn(IEventMap map)
        {
            map.UnmapAll();
        }
    }
}