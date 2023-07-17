using System;
using Build1.PostMVC.Core.MVCS.Events;
using UnityEngine.Events;
using Event = Build1.PostMVC.Core.MVCS.Events.Event;

namespace Build1.PostMVC.Unity.App.Mediation
{
    public abstract class UnityEventBinding
    {
        internal UnityEventBase unityEvent;

        protected IEventDispatcher _dispatcher;
        
        internal abstract void Unbind();
    }

    public sealed class UnityEventBinding00 : UnityEventBinding
    {
        private UnityEvent       _unityEvent;
        private Event            _event;
        private Action           _action;
        private UnityAction      _listener;
        
        internal UnityEventBinding00 Configure(UnityEvent @event, IEventDispatcher dispatcher)
        {
            unityEvent = @event;
            _unityEvent = @event;
            _dispatcher = dispatcher;
            return this;
        }

        /*
         * Events.
         */

        public UnityEventBinding ToEvent(Event @event)
        {
            _event = @event;
            _listener = DispatchEvent;
            _unityEvent.AddListener(DispatchEvent);
            return this;
        }

        public UnityEventBinding ToEvent<T1>(Event<T1> @event, T1 param01)
        {
            _listener = () => { _dispatcher.Dispatch(@event, param01); };
            _unityEvent.AddListener(_listener);
            return this;
        }

        public UnityEventBinding ToEvent<T1, T2>(Event<T1, T2> @event, T1 param01, T2 param02)
        {
            _listener = () => { _dispatcher.Dispatch(@event, param01, param02); };
            _unityEvent.AddListener(_listener);
            return this;
        }

        public UnityEventBinding ToEvent<T1, T2, T3>(Event<T1, T2, T3> @event, T1 param01, T2 param02, T3 param03)
        {
            _listener = () => { _dispatcher.Dispatch(@event, param01, param02, param03); };
            _unityEvent.AddListener(_listener);
            return this;
        }

        /*
         * Actions.
         */

        public UnityEventBinding ToAction(Action action)
        {
            _action = action;
            _listener = CallAction;
            _unityEvent.AddListener(CallAction);
            return this;
        }

        public UnityEventBinding ToAction<T1>(Action<T1> action, T1 param01)
        {
            _listener = () => { action.Invoke(param01); };
            _unityEvent.AddListener(_listener);
            return this;
        }

        public UnityEventBinding ToAction<T1, T2>(Action<T1, T2> action, T1 param01, T2 param02)
        {
            _listener = () => { action.Invoke(param01, param02); };
            _unityEvent.AddListener(_listener);
            return this;
        }

        public UnityEventBinding ToAction<T1, T2, T3>(Action<T1, T2, T3> action, T1 param01, T2 param02, T3 param03)
        {
            _listener = () => { action.Invoke(param01, param02, param03); };
            _unityEvent.AddListener(_listener);
            return this;
        }

        /*
         * Unbinding.
         */

        internal override void Unbind()
        {
            if (_listener != null)
            {
                _unityEvent.RemoveListener(_listener);
                _unityEvent = null;

                _listener = null;

                _event = null;
                _action = null;
            }
            
            unityEvent = null;
            _unityEvent = null;
            _dispatcher = null;
        }

        /*
         * Private.
         */

        private void DispatchEvent() { _dispatcher.Dispatch(_event); }
        private void CallAction()    { _action?.Invoke(); }
    }

    public sealed class UnityEventBinding01<T1> : UnityEventBinding
    {
        private UnityEvent<T1>  _unityEvent;
        private Event<T1>       _event;
        private Action<T1>      _action;
        private UnityAction<T1> _listener;

        internal UnityEventBinding01<T1> Configure(UnityEvent<T1> @event, IEventDispatcher dispatcher)
        {
            unityEvent = @event;
            _unityEvent = @event;
            _dispatcher = dispatcher;
            return this;
        }
        
        /*
         * Events.
         */

        public UnityEventBinding ToEvent(Event<T1> @event)
        {
            _event = @event;
            _listener = DispatchEvent;
            _unityEvent.AddListener(DispatchEvent);
            return this;
        }
        
        public UnityEventBinding ToEvent<P1>(Event<P1> @event, P1 param01)
        {
            _listener = _ => { _dispatcher.Dispatch(@event, param01); };
            _unityEvent.AddListener(DispatchEvent);
            return this;
        }

        /*
         * Actions.
         */

        public UnityEventBinding ToAction(Action<T1> action)
        {
            _action = action;
            _listener = CallAction;
            _unityEvent.AddListener(CallAction);
            return this;
        }

        /*
         * Unbinding.
         */

        internal override void Unbind()
        {
            if (_listener != null)
            {
                _unityEvent.RemoveListener(_listener);
                _unityEvent = null;

                _listener = null;

                _event = null;
                _action = null;
            }

            unityEvent = null;
            _unityEvent = null;
            _dispatcher = null;
        }

        /*
         * Event Handlers.
         */

        private void DispatchEvent(T1 param01) { _dispatcher.Dispatch(_event, param01); }
        private void CallAction(T1 param01)    { _action?.Invoke(param01); }
    }

    public sealed class UnityEventBinding02<T1, T2> : UnityEventBinding
    {
        private UnityEvent<T1, T2>  _unityEvent;
        private Event<T1, T2>       _event;
        private Action<T1, T2>      _action;
        private UnityAction<T1, T2> _listener;
        
        internal UnityEventBinding02<T1, T2> Configure(UnityEvent<T1, T2> @event, IEventDispatcher dispatcher)
        {
            unityEvent = @event;
            _unityEvent = @event;
            _dispatcher = dispatcher;
            return this;
        }

        public UnityEventBinding ToEvent(Event<T1, T2> @event)
        {
            _event = @event;
            _listener = DispatchEvent;
            _unityEvent.AddListener(DispatchEvent);
            return this;
        }

        public UnityEventBinding ToAction(Action<T1, T2> action)
        {
            _action = action;
            _listener = CallAction;
            _unityEvent.AddListener(CallAction);
            return this;
        }

        internal override void Unbind()
        {
            if (_listener != null)
            {
                _unityEvent.RemoveListener(_listener);
                _unityEvent = null;

                _listener = null;

                _event = null;
                _action = null;
            }

            unityEvent = null;
            _unityEvent = null;
            _dispatcher = null;
        }

        /*
         * Event Handlers.
         */

        private void DispatchEvent(T1 param01, T2 param02) { _dispatcher.Dispatch(_event, param01, param02); }
        private void CallAction(T1 param01, T2 param02)    { _action?.Invoke(param01, param02); }
    }

    public sealed class UnityEventBinding03<T1, T2, T3> : UnityEventBinding
    {
        private UnityEvent<T1, T2, T3>  _unityEvent;
        private Event<T1, T2, T3>       _event;
        private Action<T1, T2, T3>      _action;
        private UnityAction<T1, T2, T3> _listener;
        
        internal UnityEventBinding03<T1, T2, T3> Configure(UnityEvent<T1, T2, T3> @event, IEventDispatcher dispatcher)
        {
            unityEvent = @event;
            _unityEvent = @event;
            _dispatcher = dispatcher;
            return this;
        }

        public UnityEventBinding ToEvent(Event<T1, T2, T3> @event)
        {
            _event = @event;
            _listener = DispatchEvent;
            _unityEvent.AddListener(DispatchEvent);
            return this;
        }

        public UnityEventBinding ToAction(Action<T1, T2, T3> action)
        {
            _action = action;
            _listener = CallAction;
            _unityEvent.AddListener(CallAction);
            return this;
        }

        internal override void Unbind()
        {
            if (_listener != null)
            {
                _unityEvent.RemoveListener(_listener);
                _unityEvent = null;

                _listener = null;

                _event = null;
                _action = null;
            }

            unityEvent = null;
            _unityEvent = null;
            _dispatcher = null;
        }

        /*
         * Event Handlers.
         */

        private void DispatchEvent(T1 param01, T2 param02, T3 param03) { _dispatcher.Dispatch(_event, param01, param02, param03); }
        private void CallAction(T1 param01, T2 param02, T3 param03)    { _action?.Invoke(param01, param02, param03); }
    }
}