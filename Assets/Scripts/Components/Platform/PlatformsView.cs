using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Mediation;

namespace Components.Platform
{
    [Mediator(typeof(PlatformsMediator))]
    public sealed class PlatformsView : UnityViewDispatcher
    {
        
    }
}