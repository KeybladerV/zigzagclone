using System;
using Build1.PostMVC.Unity.App.Mediation;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using Event = Build1.PostMVC.Core.MVCS.Events.Event;

namespace Build1.PostMVC.Unity.App.Tests.Mediation
{
    public sealed class UnityViewDispatcherBindingTest
    {
        private UnityViewDispatcherTest _view;

        [SetUp]
        public void SetUp()
        {
            _view = new GameObject().AddComponent<UnityViewDispatcherTest>();
        }

        [Test]
        public void UnityEventToEventTest()
        {
            var count = 0;
            void Listener() { count++; }

            _view.BindUnityEventToEvent();
            _view.AddListener(_view.OnTestEvent, Listener);
            _view.DispatchUnityEvent();

            Assert.AreEqual(count, 1);
        }

        [Test]
        public void UnityEventToActionTest()
        {
            var count = 0;
            void Listener() { count++; }

            _view.OnTestAction += Listener;
            _view.BindUnityEventToAction();
            _view.DispatchUnityEvent();

            Assert.AreEqual(count, 1);
        }
        
        [Test]
        public void UnityEventToActionNotWorkingTest()
        {
            var count = 0;
            void Listener() { count++; }

            _view.BindUnityEventToAction();
            _view.OnTestAction += Listener;
            _view.DispatchUnityEvent();

            Assert.AreEqual(count, 0);
        }

        [Test]
        public void UnityEventUnbindingTest()
        {
            var count = 0;
            void Listener() { count++; }
            
            _view.AddListener(_view.OnTestEvent, Listener);
            _view.OnTestAction += Listener;
            _view.BindUnityEventToEvent();
            _view.BindUnityEventToAction();
            _view.DispatchUnityEvent();

            Assert.AreEqual(count, 2);
            
            _view.UnbindUnityEvents();
            _view.DispatchUnityEvent();
            
            Assert.AreEqual(count, 2);
        }

        [Test]
        public void UnityEventEventUnbindingTest()
        {
            var count = 0;
            void Listener() { count++; }
            
            _view.AddListener(_view.OnTestEvent, Listener);
            _view.OnTestAction += Listener;
            _view.BindUnityEventToEvent();
            _view.BindUnityEventToAction();
            _view.DispatchUnityEvent();

            Assert.AreEqual(count, 2);
            
            _view.UnbindUnityEvent();
            _view.DispatchUnityEvent();
            
            Assert.AreEqual(count, 2);
        }
        
        [Test]
        public void UnityEventActionUnbindingTest()
        {
            var count = 0;
            void Listener() { count++; }
            
            _view.AddListener(_view.OnTestEvent, Listener);
            _view.OnTestAction += Listener;
            _view.BindUnityEventToEvent();
            _view.BindUnityEventToAction();
            _view.DispatchUnityEvent();

            Assert.AreEqual(count, 2);
            
            _view.UnbindUnityEvent();
            _view.DispatchUnityEvent();
            
            Assert.AreEqual(count, 2);
        }

        /*
         * Test View.
         */

        private sealed class UnityViewDispatcherTest : UnityViewDispatcher
        {
            public readonly Event OnTestEvent = new Event(typeof(UnityViewDispatcherTest), nameof(OnTestEvent));

            public event Action OnTestAction;

            private readonly UnityEvent TestUnityEvent = new UnityEvent();

            public void BindUnityEventToEvent()
            {
                BindUnityEvent(TestUnityEvent).ToEvent(OnTestEvent);
            }

            public void BindUnityEventToAction()
            {
                BindUnityEvent(TestUnityEvent).ToAction(OnTestAction);
            }

            public void UnbindUnityEvent()
            {
                UnbindUnityEvent(TestUnityEvent);
            }

            public void UnbindUnityEvents()
            {
                UnbindAllUnityEvents();
            }
            
            public void DispatchUnityEvent()
            {
                TestUnityEvent.Invoke();
            }
        }
    }
}