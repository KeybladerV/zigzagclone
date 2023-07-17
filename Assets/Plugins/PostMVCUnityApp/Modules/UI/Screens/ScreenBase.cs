using System;

namespace Build1.PostMVC.Unity.App.Modules.UI.Screens
{
    public abstract class ScreenBase : UIControl<ScreenConfig>
    {
        public readonly Type dataType;
        
        protected ScreenBase(string name) : base(name)
        {
        }
        
        protected ScreenBase(string name, UIBehavior behavior) : base(name, behavior)
        {
        }
        
        protected ScreenBase(string name, Type dataType) : base(name)
        {
            this.dataType = dataType;
        }
        
        protected ScreenBase(string name, UIBehavior behavior, Type dataType) : base(name, behavior)
        {
            this.dataType = dataType;
        }
    }
}