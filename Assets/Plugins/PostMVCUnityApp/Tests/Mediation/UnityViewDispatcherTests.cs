using Build1.PostMVC.Unity.App.Mediation;
using NUnit.Framework;
using UnityEngine;
using Event = Build1.PostMVC.Core.MVCS.Events.Event;

namespace Build1.PostMVC.Unity.App.Tests.Mediation
{
    public sealed class UnityViewDispatcherTests
    {
        private UnityViewDispatcherTest _view;

        [SetUp]
        public void SetUp()
        {
            _view = new GameObject().AddComponent<UnityViewDispatcherTest>();
        }

        [Test]
        public void ListenerTest()
        {
            var count = 0;
            void Listener() { count++; }

            _view.AddListener(_view.OnTestEvent, Listener);
            _view.DispatchEvent();
            Assert.AreEqual(count, 1);

            _view.DispatchEvent();
            Assert.AreEqual(count, 2);
        }

        [Test]
        public void ListenerRemovalTest()
        {
            var count = 0;
            void Listener() { count++; }

            _view.AddListener(_view.OnTestEvent, Listener);
            _view.DispatchEvent();
            Assert.AreEqual(count, 1);

            _view.RemoveListener(_view.OnTestEvent, Listener);
            _view.DispatchEvent();
            Assert.AreEqual(count, 1);
        }

        [Test]
        public void ListenerOnceTest()
        {
            var count = 0;
            void Listener() { count++; }

            _view.AddListenerOnce(_view.OnTestEvent, Listener);
            _view.DispatchEvent();
            Assert.AreEqual(count, 1);

            _view.DispatchEvent();
            Assert.AreEqual(count, 1);
        }

        [Test]
        public void ListenerOnceRemovalTest()
        {
            var count = 0;
            void Listener() { count++; }

            _view.AddListenerOnce(_view.OnTestEvent, Listener);
            _view.RemoveListener(_view.OnTestEvent, Listener);
            _view.DispatchEvent();

            Assert.AreEqual(count, 0);
        }

        [Test]
        public void AllListenersRemovalTest()
        {
            var count = 0;
            void Listener() { count++; }

            _view.AddListener(_view.OnTestEvent, Listener);
            _view.AddListenerOnce(_view.OnTestEvent, Listener);
            _view.RemoveAllListeners();
            _view.DispatchEvent();

            Assert.AreEqual(count, 0);
        }

        /*
         * Test View.
         */

        private sealed class UnityViewDispatcherTest : UnityViewDispatcher
        {
            public readonly Event OnTestEvent = new Event(typeof(UnityViewDispatcherTest), nameof(OnTestEvent));

            public void DispatchEvent()
            {
                Dispatch(OnTestEvent);
            }
        }
    }
}