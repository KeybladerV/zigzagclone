using System;

namespace Build1.PostMVC.Unity.App.Modules.UI
{
    [Flags]
    public enum UIBehavior
    {
        /// Control will be pre instantiated on initialization.
        /// UIControlsController.Initialize method must be called. 
        PreInstantiate = 1 << 1,
        
        /// Control will be destroyed on deactivation.
        DestroyOnDeactivation = 1 << 2,
        
        /// Only one instance if this screen will be created and used. 
        SingleInstance = 1 << 3
    }
}