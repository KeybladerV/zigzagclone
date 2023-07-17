using System;
using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Unity.App.Mediation;

namespace Build1.PostMVC.Unity.App.Events
{
    public interface IEventMap : IEventMapCore
    {
        /*
         * Map.
         */

        void Map(UnityViewDispatcher dispatcher, Event @event, Action listener);
        void Map<T1>(UnityViewDispatcher dispatcher, Event<T1> @event, Action<T1> listener);
        void Map<T1, T2>(UnityViewDispatcher dispatcher, Event<T1, T2> @event, Action<T1, T2> listener);
        void Map<T1, T2, T3>(UnityViewDispatcher dispatcher, Event<T1, T2, T3> @event, Action<T1, T2, T3> listener);

        /*
         * Map Once.
         */

        void MapOnce(UnityViewDispatcher dispatcher, Event @event, Action listener);
        void MapOnce<T1>(UnityViewDispatcher dispatcher, Event<T1> @event, Action<T1> listener);
        void MapOnce<T1, T2>(UnityViewDispatcher dispatcher, Event<T1, T2> @event, Action<T1, T2> listener);
        void MapOnce<T1, T2, T3>(UnityViewDispatcher dispatcher, Event<T1, T2, T3> @event, Action<T1, T2, T3> listener);

        /*
         * Unmap.
         */
        
        void Unmap(UnityViewDispatcher dispatcher, Event @event, Action listener);
        void Unmap<T1>(UnityViewDispatcher dispatcher, Event<T1> @event, Action<T1> listener);
        void Unmap<T1, T2>(UnityViewDispatcher dispatcher, Event<T1, T2> @event, Action<T1, T2> listener);
        void Unmap<T1, T2, T3>(UnityViewDispatcher dispatcher, Event<T1, T2, T3> @event, Action<T1, T2, T3> listener);
        
        /*
         * Map Info.
         */

        bool ContainsMapInfo(UnityViewDispatcher dispatcher, Event @event, Action listener);
        bool ContainsMapInfo<T1>(UnityViewDispatcher dispatcher, Event<T1> @event, Action<T1> listener);
        bool ContainsMapInfo<T1, T2>(UnityViewDispatcher dispatcher, Event<T1, T2> @event, Action<T1, T2> listener);
        bool ContainsMapInfo<T1, T2, T3>(UnityViewDispatcher dispatcher, Event<T1, T2, T3> @event, Action<T1, T2, T3> listener);
    }
}