namespace Build1.PostMVC.Unity.App.Modules.Logging
{
    public static class Logging
    {
        public static bool     ForceAll       = false;
        public static bool     Print          = true;
        public static LogLevel PrintLevel     = LogLevel.Warning;
        public static bool     Record         = false;
        public static LogLevel RecordLevel    = LogLevel.Warning;
        public static bool     SaveToFile     = false;
        public static byte     FlushThreshold = 128;
        public static byte     RecordsHistory = 10;
    }
}