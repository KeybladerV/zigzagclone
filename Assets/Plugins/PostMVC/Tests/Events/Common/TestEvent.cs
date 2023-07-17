using System;
using Build1.PostMVC.Core.MVCS.Events;

namespace Build1.PostMVC.Core.Tests.Events.Common
{
    public abstract class TestEvent
    {
        public static readonly Event                    Event00   = new Event(typeof(TestEvent), nameof(Event00));
        public static readonly Event<int>               Event01   = new Event<int>(typeof(TestEvent), nameof(Event01));
        public static readonly Event<int, string>       Event02   = new Event<int, string>(typeof(TestEvent), nameof(Event02));
        public static readonly Event<int, string, bool> Event03   = new Event<int, string, bool>(typeof(TestEvent), nameof(Event03));
        public static readonly Event<Exception>         EventFail = new Event<Exception>(typeof(TestEvent), nameof(Event00));
    }
}