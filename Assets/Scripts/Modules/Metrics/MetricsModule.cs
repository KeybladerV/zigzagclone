﻿using Build1.PostMVC.Core.Modules;
using Build1.PostMVC.Core.MVCS.Injection;
using Modules.Metrics.Impl;

namespace Modules.Metrics
{
    public sealed class MetricsModule : Module
    {
        [Inject] public IInjectionBinder InjectionBinder { get; set; }

        [PostConstruct]
        private void PostConstruct()
        {
            InjectionBinder.Bind<IFPSController, FPSController>().ConstructOnStart();
        }
    }
}