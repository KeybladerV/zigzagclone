using System;
using Build1.PostMVC.Core.Extensions;
using Build1.PostMVC.Core.MVCS;
using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Unity.App.Contexts;
using Build1.PostMVC.Unity.App.Contexts.Impl;
using Build1.PostMVC.Unity.App.Events;
using Build1.PostMVC.Unity.App.Events.Impl.Bus;
using Build1.PostMVC.Unity.App.Events.Impl.Map;
using Build1.PostMVC.Unity.App.Mediation.Impl;
using Build1.PostMVC.Unity.App.Modules.Agents;
using Build1.PostMVC.Unity.App.Modules.Agents.Impl;
using Build1.PostMVC.Unity.App.Modules.App;
using Build1.PostMVC.Unity.App.Modules.App.Impl;
using Build1.PostMVC.Unity.App.Modules.Assets;
using Build1.PostMVC.Unity.App.Modules.Assets.Impl;
using Build1.PostMVC.Unity.App.Modules.Async;
using Build1.PostMVC.Unity.App.Modules.Async.Impl;
using Build1.PostMVC.Unity.App.Modules.Coroutines;
using Build1.PostMVC.Unity.App.Modules.Coroutines.Impl;
using Build1.PostMVC.Unity.App.Modules.Device;
using Build1.PostMVC.Unity.App.Modules.FullScreen;
using Build1.PostMVC.Unity.App.Modules.InternetReachability;
using Build1.PostMVC.Unity.App.Modules.Logging;
using Build1.PostMVC.Unity.App.Modules.UI;
using Build1.PostMVC.Unity.App.Modules.Update;
using Build1.PostMVC.Unity.App.Modules.Update.Impl;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Build1.PostMVC.Unity.App
{
    public sealed class UnityAppExtension : Extension
    {
        public const string RootGameObjectName = "[PostMVC]";

        private GameObject _contextViewGameObject;
        
        /*
         * Public.
         */

        public override void Initialize()
        {
            // TODO: manage multiple contexts and core modules sharing
            if (!Context.IsRootContext)
                return;
            
            var injectionBinder = GetDependentExtension<MVCSExtension>().InjectionBinder;
            
            // Rebinding EventBus to a Unity specific one.
            injectionBinder.Rebind<IEventBus, EventBusUnity>();
            
            // Unbinding default EventMap and binding the Unity specific one.
            injectionBinder.Unbind<IEventMapCore>();
            injectionBinder.Bind<IEventMap, EventMapProviderUnity, Inject>();
            
            // General tools.
            injectionBinder.Bind<UnityViewEventProcessor>();
            injectionBinder.Bind<IAgentsController, AgentsController>();
            injectionBinder.Bind<IAppController, AppController>().ConstructOnStart();
            injectionBinder.Bind<IAssetsController, AssetsController>();
            injectionBinder.Bind<IAsyncResolver, AsyncResolver>().ConstructOnStart();
            injectionBinder.Bind<ICoroutineProvider, CoroutineProvider>();
            injectionBinder.Bind<IUpdateController, UpdateController>();

            #if UNITY_ANDROID || UNITY_EDITOR
                AddModule<Modules.Android.AndroidModule>();
            #endif
            
            AddModule<DeviceModule>();
            AddModule<FullScreenModule>();
            AddModule<InternetReachabilityModule>();
            AddModule<LogModule>();
            AddModule<UIModule>();
        }

        public override void Setup()
        {
            var viewGameObject = GetViewGameObject(null);
            var viewAgent = viewGameObject.AddComponent<ContextViewUnity>();
            viewAgent.SetContext(Context);

            Object.DontDestroyOnLoad(viewGameObject);

            var injectionBinder = GetDependentExtension<MVCSExtension>().InjectionBinder;
            injectionBinder.Rebind<IContextView>(viewAgent);

            if (Context.IsRootContext)
            {
                viewGameObject.name = string.IsNullOrWhiteSpace(Context.Name) ? RootGameObjectName : Context.Name;
            }
            else
            {
                viewGameObject.name = string.IsNullOrWhiteSpace(Context.Name) ? $"[Context{Context.Id:D2}]" : Context.Name;

                if (RootContext.HasExtension<MVCSExtension>())
                {
                    var rootInjectionBinder = RootContext.GetExtension<MVCSExtension>().InjectionBinder;
                    if (rootInjectionBinder.GetBinding<IContextView>() != null)
                    {
                        var rootView = rootInjectionBinder.GetInstance<IContextView>();
                        var rootGameObject = rootView.As<GameObject>();
                        viewGameObject.transform.SetParent(rootGameObject.transform);
                    }
                }
            }

            _contextViewGameObject = viewGameObject;
        }

        public override void Dispose()
        {
            // We don't need to unbind anything. MVCSExtension does it.
            // But we need to remove Context View Game Object.
            Object.Destroy(_contextViewGameObject);
            _contextViewGameObject = null;
        }

        /*
         * Private.
         */

        private static GameObject GetViewGameObject(object view)
        {
            switch (view)
            {
                case null:                    return new GameObject();
                case GameObject gameObject:   return gameObject;
                case MonoBehaviour behaviour: return behaviour.gameObject;
                default:
                    throw new Exception($"Specified view is not a GameObject or MonoBehavior. [{view.GetType()}]");
            }
        }
    }
}