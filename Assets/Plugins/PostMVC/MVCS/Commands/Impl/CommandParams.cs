using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Core.MVCS.Events.Impl;

namespace Build1.PostMVC.Core.MVCS.Commands.Impl
{
    internal class CommandParams : ICommandParams
    {
        public void DispatchParams(IEventDispatcher dispatcher, EventBase @event)
        {
            if (@event is Event event0)
                dispatcher.Dispatch(event0);
            else
                throw new CommandBinderException(CommandBinderExceptionType.IncompatibleEventType);
        }
    }

    internal class CommandParams<T1> : ICommandParams<T1>
    {
        public T1 Param01 { get; set; }

        public void DispatchParams(IEventDispatcher dispatcher, EventBase @event)
        {
            switch (@event)
            {
                case Event<T1> event1:
                    dispatcher.Dispatch(event1, Param01);
                    break;
                case Event event0:
                    dispatcher.Dispatch(event0);
                    break;
                default:
                    throw new CommandBinderException(CommandBinderExceptionType.IncompatibleEventType);
            }
        }
    }

    internal class CommandParams<T1, T2> : ICommandParams<T1, T2>
    {
        public T1 Param01 { get; set; }
        public T2 Param02 { get; set; }

        public void DispatchParams(IEventDispatcher dispatcher, EventBase @event)
        {
            switch (@event)
            {
                case Event<T1, T2> event2:
                    dispatcher.Dispatch(event2, Param01, Param02);
                    break;
                case Event<T1> event1:
                    dispatcher.Dispatch(event1, Param01);
                    break;
                case Event event0:
                    dispatcher.Dispatch(event0);
                    break;
                default:
                    throw new CommandBinderException(CommandBinderExceptionType.IncompatibleEventType);
            }
        }
    }

    internal class CommandParams<T1, T2, T3> : ICommandParams<T1, T2, T3>
    {
        public T1 Param01 { get; set; }
        public T2 Param02 { get; set; }
        public T3 Param03 { get; set; }

        public void DispatchParams(IEventDispatcher dispatcher, EventBase @event)
        {
            switch (@event)
            {
                case Event<T1, T2, T3> event3:
                    dispatcher.Dispatch(event3, Param01, Param02, Param03);
                    break;
                case Event<T1, T2> event2:
                    dispatcher.Dispatch(event2, Param01, Param02);
                    break;
                case Event<T1> event1:
                    dispatcher.Dispatch(event1, Param01);
                    break;
                case Event event0:
                    dispatcher.Dispatch(event0);
                    break;
                default:
                    throw new CommandBinderException(CommandBinderExceptionType.IncompatibleEventType);
            }
        }
    }
}