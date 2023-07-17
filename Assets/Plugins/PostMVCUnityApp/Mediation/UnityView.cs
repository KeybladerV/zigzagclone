using Build1.PostMVC.Core.Contexts;
using Build1.PostMVC.Core.MVCS;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Contexts.Impl;
using Build1.PostMVC.Unity.App.Mediation.Impl;
using UnityEngine;

namespace Build1.PostMVC.Unity.App.Mediation
{
    [DisallowMultipleComponent]
    public abstract class UnityView : MonoBehaviour, IUnityView
    {
        public IMediator Mediator { get; private set; }

        public bool Initialized { get; private set; }
        public bool Enabled     => gameObject.activeInHierarchy;

        private IContext                _context;
        private IMediationBinder        _mediationBinder;
        private UnityViewEventProcessor _viewEventProcessor;

        /*
         * Mono Behavior.
         */

        protected virtual void Awake()
        {
            if (TryFindContext(out var context))
                ProcessContextIntegration(context);
            else
                Core.PostMVC.OnContextStarted += ProcessContextIntegration;
        }

        protected virtual void OnEnable()
        {
            if (Initialized)
                _viewEventProcessor?.ProcessOnEnable(this);
        }

        protected virtual void Start()
        {
            if (Initialized)
                _viewEventProcessor?.ProcessStart(this);
        }

        protected virtual void OnDisable()
        {
            if (Initialized)
                _viewEventProcessor?.ProcessOnDisable(this);
        }

        protected virtual void OnDestroy()
        {
            DisposeContextIntegration();
        }

        /*
         * Public.
         */

        public void Destroy()
        {
            Destroy(gameObject);
        }

        /*
         * Context.
         */

        private void ProcessContextIntegration(IContext context)
        {
            Core.PostMVC.OnContextStarted -= ProcessContextIntegration;

            _context = context;
            _context.OnStopping += OnContextStopping;

            var mvcs = _context.GetExtension<MVCSExtension>();
            _viewEventProcessor = mvcs.InjectionBinder.GetInstance<UnityViewEventProcessor>();

            _mediationBinder = mvcs.MediationBinder;
            _mediationBinder.OnViewAdd(this);

            Initialized = true;
        }

        private void DisposeContextIntegration()
        {
            Core.PostMVC.OnContextStarted -= ProcessContextIntegration;

            if (_mediationBinder != null)
            {
                _mediationBinder?.OnViewRemove(this);
                _mediationBinder = null;
            }

            if (_context != null)
            {
                _context.OnStopping -= OnContextStopping;
                _context = null;
            }

            _viewEventProcessor = null;
            Initialized = false;
        }

        private void OnContextStopping(IContext context)
        {
            // Once view finds it's context, it listens to Stop event.
            // If context is stopped, all initialized views are destroyed.
            Destroy(gameObject);
        }

        /*
         * Mediator.
         */

        public void SetMediator(IMediator mediator)
        {
            Mediator = mediator;
        }

        /*
         * Static.
         */

        private static bool TryFindContext(out IContext context)
        {
            GameObject contextGameObject = null;

            try
            {
                contextGameObject = GameObject.Find(UnityAppExtension.RootGameObjectName);
            }
            catch
            {
                // Ignored.
                // It throws exception on application quit in Editor. 
            }

            if (contextGameObject != null)
            {
                context = contextGameObject.GetComponent<ContextViewUnity>().Context;
                return true;
            }

            context = null;
            return false;
        }
    }
}