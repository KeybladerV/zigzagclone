namespace Build1.PostMVC.Unity.App.Modules.Android
{
    public static class AndroidUtils
    {
        private static int _apiVersion;
        
        public static int GetCurrentAndroidAPIVersion()
        {
            #if UNITY_ANDROID
            
            if (_apiVersion != 0) 
                return _apiVersion;
            
            var clazz = UnityEngine.AndroidJNI.FindClass("android/os/Build$VERSION");
            var fieldID = UnityEngine.AndroidJNI.GetStaticFieldID(clazz, "SDK_INT", "I");
            _apiVersion = UnityEngine.AndroidJNI.GetStaticIntField(clazz, fieldID);
            
            #endif
            
            return _apiVersion;
        }
    }
}