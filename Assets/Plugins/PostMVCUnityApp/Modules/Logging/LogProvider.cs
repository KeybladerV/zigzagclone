namespace Build1.PostMVC.Unity.App.Modules.Logging
{
    public static class LogProvider
    {
        private static ILogProvider Provider
        {
            get
            {
                _logProvider ??= Core.PostMVC.GetInstance<ILogProvider>();
                return _logProvider;
            }
        }

        private static ILogController Controller
        {
            get
            {
                _logController ??= Core.PostMVC.GetInstance<ILogController>();
                return _logController;
            }
        }

        private static ILogProvider   _logProvider;
        private static ILogController _logController;

        public static ILog GetLog<T>(LogLevel level)
        {
            var log = Provider.CreateLogInstance(typeof(T).Name, level, Controller);

            if (typeof(UnityEngine.MonoBehaviour).IsAssignableFrom(typeof(T)))
            {
                log.Warn("You're getting a logger during MonoBehavior instantiation. " +
                         "This may end up in script instantiation exception on a device. " +
                         "Consider inheriting of component from UnityView and injecting a logger.");
            }

            return log;
        }

        public static ILog GetLog(LogLevel level)
        {
            return Provider.CreateLogInstance(null, level, Controller);
        }

        public static ILog GetLog(string prefix, LogLevel level)
        {
            return Provider.CreateLogInstance(prefix, level, Controller);
        }

        public static ILog GetLog(object owner, LogLevel level)
        {
            return Provider.CreateLogInstance(owner.GetType().Name, level, Controller);
        }
    }
}