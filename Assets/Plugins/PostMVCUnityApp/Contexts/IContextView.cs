using Build1.PostMVC.Core.Contexts;

namespace Build1.PostMVC.Unity.App.Contexts
{
    public interface IContextView
    {
        IContext Context { get; }
        object   ViewRaw { get; }

        T As<T>() where T : class;
    }
}