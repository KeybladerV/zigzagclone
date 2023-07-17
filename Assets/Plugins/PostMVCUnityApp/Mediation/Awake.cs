using System;
using Build1.PostMVC.Core.MVCS.Injection;

namespace Build1.PostMVC.Unity.App.Mediation
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class Awake : PostConstruct
    {
    }
}