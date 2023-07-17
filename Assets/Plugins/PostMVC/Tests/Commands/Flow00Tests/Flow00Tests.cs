using System;
using System.Collections.Generic;
using Build1.PostMVC.Core.MVCS.Commands;
using Build1.PostMVC.Core.MVCS.Commands.Impl;
using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Core.MVCS.Events.Impl;
using Build1.PostMVC.Core.MVCS.Injection.Impl;
using Build1.PostMVC.Core.Tests.Commands.Command00Tests.Commands;
using Build1.PostMVC.Core.Tests.Commands.Common;
using Build1.PostMVC.Core.Tests.Events.Common;
using NUnit.Framework;

namespace Build1.PostMVC.Core.Tests.Commands.Flow00Tests
{
    public sealed class Flow00Tests
    {
        private ICommandBinder   _binder;
        private IEventDispatcher _dispatcher;

        [SetUp]
        public void SetUp()
        {
            Command00.OnExecute = null;
            Command00Copy.OnExecute = null;
            Command00DoubleDeinit.OnExecute = null;
            Command00DoubleDeinit.OnPostConstruct = null;
            Command00DoubleDeinit.OnPreDestroy = null;
            Command00Exception.OnExecute = null;
            Command00Fail.OnExecute = null;
            Command00Retain.OnExecute = null;
            Command00Retain.OnFail = null;
            Command00RetainCopy.OnExecute = null;
            Command00RetainCopy.OnFail = null;
            Command00RetainExceptionInstant.OnExecute = null;
            Command00RetainFailInstant.OnExecute = null;
            Command00RetainReleaseInstant.OnExecute = null;
            CommandFailHandler.OnExecute = null;

            var binder = new CommandBinder();

            _binder = binder;
            _dispatcher = new EventDispatcherWithCommandProcessing(binder);

            binder.InjectionBinder = new InjectionBinder();
            binder.Dispatcher = _dispatcher;
        }

        [Test]
        public void ExecutionText()
        {
            var count = 0;
            var order = new List<int>(2);
            
            Command00.OnExecute += () =>
            {
                count++;
                order.Add(0);
            };
            Command00Copy.OnExecute += () =>
            {
                count++;
                order.Add(1);
            };
            
            _binder.Flow()
                   .To<Command00>()
                   .To<Command00Copy>()
                   .InSequence()
                   .Execute();
            
            Assert.AreEqual(2, count);
            Assert.AreEqual(0, order[0]);
            Assert.AreEqual(1, order[1]);
        }

        [Test]
        public void CompleteTest()
        {
            var count = 0;
            
            _dispatcher.AddListener(TestEvent.Event00, () =>
            {
                count++;
            });
            
            _binder.Flow()
                   .To<Command00>()
                   .To<Command00Copy>()
                   .OnComplete(TestEvent.Event00)
                   .InSequence()
                   .Execute();
            
            Assert.AreEqual(1, count);
        }
        
        [Test]
        public void BreakTest()
        {
            var count = 0;
            
            _dispatcher.AddListener(TestEvent.Event00, () =>
            {
                count++;
            });
            
            _binder.Flow()
                   .To<Command00Retain>()
                   .To<Command00Copy>()
                   .OnBreak(TestEvent.Event00)
                   .InSequence()
                   .Execute();
            
            Assert.AreEqual(0, count);
            
            Command00Retain.Instance.BreakImpl();
            
            Assert.AreEqual(1, count);
        }
        
        [Test]
        public void FailTest()
        {
            var count = 0;
            Exception exception = null;

            _dispatcher.AddListener(TestEvent.EventFail, e =>
            {
                count++;
                exception = e;
            });
            
            _binder.Flow()
                   .To<Command00Retain>()
                   .To<Command00Copy>()
                   .OnFail(TestEvent.EventFail)
                   .InSequence()
                   .Execute();
            
            Assert.AreEqual(0, count);
            
            Command00Retain.Instance.FailImpl();
            
            Assert.AreEqual(1, count);
            Assert.AreEqual(Command00Retain.Exception, exception);
        }
    }
}