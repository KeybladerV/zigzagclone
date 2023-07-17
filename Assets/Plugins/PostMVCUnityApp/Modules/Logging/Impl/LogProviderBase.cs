using System.Collections.Generic;
using Build1.PostMVC.Core.MVCS.Injection;

namespace Build1.PostMVC.Unity.App.Modules.Logging.Impl
{
    internal abstract class LogProviderBase : InjectionProvider<ILog, LogAttribute>, ILogProvider
    {
        [Inject] public ILogController LogController { get; set; }
        
        private readonly Stack<ILog> _availableInstances;
        private readonly List<ILog>  _usedInstances;

        protected LogProviderBase()
        {
            _availableInstances = new Stack<ILog>();
            _usedInstances = new List<ILog>();
        }

        /*
         * Provider.
         */

        public override ILog TakeInstance(object owner, LogAttribute attribute)
        {
            ILog log;

            if (_availableInstances.Count > 0)
            {
                log = _availableInstances.Pop();
                log.SetPrefix(owner.GetType().Name);
                log.SetLevel(attribute.logLevel);
                _usedInstances.Add(log);
            }
            else
            {
                log = CreateLogInstance(owner.GetType().Name, attribute.logLevel, LogController);
                _usedInstances.Add(log);
            }

            return log;
        }

        public override void ReturnInstance(ILog instance)
        {
            if (_usedInstances.Remove(instance))
                _availableInstances.Push(instance);
        }
        
        /*
         * Private.
         */

        public abstract ILog CreateLogInstance(string prefix, LogLevel level, ILogController logController);
    }
}