using Build1.PostMVC.Core.MVCS.Mediation;

namespace Build1.PostMVC.Unity.App.Mediation
{
    public interface IUnityView : IView
    {
        bool Initialized { get; }
        bool Enabled     { get; }
    }
}