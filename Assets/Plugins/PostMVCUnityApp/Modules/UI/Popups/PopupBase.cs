using System;

namespace Build1.PostMVC.Unity.App.Modules.UI.Popups
{
    public abstract class PopupBase : UIControl<PopupConfig>
    {
        public readonly Type dataType;

        protected PopupBase(string name, UIBehavior behavior) : base(name, behavior)
        {
        }
        
        protected PopupBase(string name, UIBehavior behavior, Type dataType) : base(name, behavior)
        {
            this.dataType = dataType;
        }
    }
}