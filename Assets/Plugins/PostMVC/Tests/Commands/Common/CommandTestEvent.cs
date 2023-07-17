using System;
using Build1.PostMVC.Core.MVCS.Events;

namespace Build1.PostMVC.Core.Tests.Commands.Common
{
    public abstract class CommandTestEvent
    {
        public static readonly Event                           Event00 = new Event(typeof(CommandTestEvent), nameof(Event00));
        public static readonly Event<int>                      Event01 = new Event<int>(typeof(CommandTestEvent), nameof(Event01));
        public static readonly Event<int, string>              Event02 = new Event<int, string>(typeof(CommandTestEvent), nameof(Event02));
        public static readonly Event<int, string, CommandData> Event03 = new Event<int, string, CommandData>(typeof(CommandTestEvent), nameof(Event03));
        
        public static readonly Event                           Event00Copy01 = new Event(typeof(CommandTestEvent), nameof(Event00Copy01));
        public static readonly Event<int>                      Event01Copy01 = new Event<int>(typeof(CommandTestEvent), nameof(Event01Copy01));
        public static readonly Event<int, string>              Event02Copy01 = new Event<int, string>(typeof(CommandTestEvent), nameof(Event02Copy01));
        public static readonly Event<int, string, CommandData> Event03Copy01 = new Event<int, string, CommandData>(typeof(CommandTestEvent), nameof(Event03Copy01));

        public static readonly Event                           Event00Copy02 = new Event(typeof(CommandTestEvent), nameof(Event00Copy02));
        public static readonly Event<int>                      Event01Copy02 = new Event<int>(typeof(CommandTestEvent), nameof(Event01Copy02));
        public static readonly Event<int, string>              Event02Copy02 = new Event<int, string>(typeof(CommandTestEvent), nameof(Event02Copy02));
        public static readonly Event<int, string, CommandData> Event03Copy02 = new Event<int, string, CommandData>(typeof(CommandTestEvent), nameof(Event03Copy02));

        public static readonly Event                           Event00Complete = new Event(typeof(CommandTestEvent), nameof(Event00Complete));
        public static readonly Event<int>                      Event01Complete = new Event<int>(typeof(CommandTestEvent), nameof(Event01Complete));
        public static readonly Event<int, string>              Event02Complete = new Event<int, string>(typeof(CommandTestEvent), nameof(Event02Complete));
        public static readonly Event<int, string, CommandData> Event03Complete = new Event<int, string, CommandData>(typeof(CommandTestEvent), nameof(Event03Complete));
        
        public static readonly Event                           Event00Break = new Event(typeof(CommandTestEvent), nameof(Event00Break));
        public static readonly Event<int>                      Event01Break = new Event<int>(typeof(CommandTestEvent), nameof(Event01Break));
        public static readonly Event<int, string>              Event02Break = new Event<int, string>(typeof(CommandTestEvent), nameof(Event02Break));
        public static readonly Event<int, string, CommandData> Event03Break = new Event<int, string, CommandData>(typeof(CommandTestEvent), nameof(Event03Break));

        public static readonly Event<Exception> EventFail = new Event<Exception>(typeof(CommandTestEvent), nameof(EventFail));
    }
}