using System.Collections;
using System.Collections.Generic;

namespace Build1.PostMVC.Unity.App.Modules.UI
{
    public abstract class UIControl<T> : IEnumerable<T> where T : UIControlConfiguration
    {
        public readonly string     name;
        public readonly UIBehavior behavior;

        public bool IsSingleInstance        => (behavior & UIBehavior.SingleInstance) == UIBehavior.SingleInstance;
        public bool ToPreInstantiate        => (behavior & UIBehavior.PreInstantiate) == UIBehavior.PreInstantiate;
        public bool ToDestroyOnDeactivation => (behavior & UIBehavior.DestroyOnDeactivation) == UIBehavior.DestroyOnDeactivation;

        private readonly IList<T> _configurations;

        protected UIControl(string name)
        {
            this.name = name;

            _configurations = new List<T>();
        }
        
        protected UIControl(string name, UIBehavior behavior) : this(name)
        {
            this.behavior = behavior;
        }

        public void Add(T configuration)
        {
            _configurations.Add(configuration);
        }

        public T First()
        {
            return _configurations[0];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _configurations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return name;
        }
    }
}