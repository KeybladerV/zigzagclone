using Build1.PostMVC.Core.Modules;
using Build1.PostMVC.Core.MVCS.Injection;
using Modules.Score.Impl;

namespace Modules.Score
{
    public sealed class ScoreModule : Module
    {
        [Inject] public IInjectionBinder InjectionBinder { get; set; }
        
        [PostConstruct]
        private void PostConstruct()
        {
            InjectionBinder.Bind<IScoreController, ScoreController>().ConstructOnStart();
        }
    }
}