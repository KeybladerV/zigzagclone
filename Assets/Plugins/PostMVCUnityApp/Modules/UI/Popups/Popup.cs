namespace Build1.PostMVC.Unity.App.Modules.UI.Popups
{
    public sealed class Popup : PopupBase
    {
        public Popup(string name, UIBehavior behavior) : base(name, behavior)
        {
        }
    }
    
    public sealed class Popup<T> : PopupBase
    {
        public Popup(string name, UIBehavior behavior) : base(name, behavior, typeof(T))
        {
        }
    }
}