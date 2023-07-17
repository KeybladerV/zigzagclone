#if UNITY_WEBGL

using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Web;

namespace Build1.PostMVC.Unity.App.Utils.WebGL
{
    public static class QueryStringUtil
    {
        [DllImport("__Internal")]
        private static extern string GetUrlParameters();
        
        private static NameValueCollection _queryStringParams;
        
        public static bool TryGetQueryStringParam<T>(string key, out T value)
        {
            _queryStringParams ??= HttpUtility.ParseQueryString(GetUrlParameters().ToLower());
            
            var valueString = _queryStringParams[key.ToLower()];
            if (valueString == null)
            {
                value = default;
                return false;
            }

            if (typeof(T) == typeof(string))
            {
                value = (T)(object)valueString;
                return true;
            }

            try
            {
                if (typeof(T) == typeof(int))
                {
                    value = (T)(object)int.Parse(valueString);
                    return true;
                }
                
                if (typeof(T) == typeof(float))
                {
                    value = (T)(object)float.Parse(valueString);
                    return true;
                }
                
                if (typeof(T) == typeof(decimal))
                {
                    value = (T)(object)decimal.Parse(valueString);
                    return true;
                }
                
                if (typeof(T) == typeof(bool))
                {
                    value = (T)(object)bool.Parse(valueString);
                    return true;
                }
            }
            catch
            {
                // ignored
            }

            value = default;
            return false;
        }
    }
}

#endif