using Newtonsoft.Json;
using UnityEngine;

namespace Modules.Repository.Impl
{
    public sealed class RepositoryController : IRepositoryController
    {
        public T LoadOrCreate<T>(string fileName, out bool isNew) where T : class, new()
        {
            var path = $"{Application.persistentDataPath}/{fileName}";
            isNew = false;
            
            if (!System.IO.File.Exists(path))
            {
                isNew = true;
                return new T();
            }
            
            var json = System.IO.File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }
        
        public void Save<T>(T obj, string fileName) where T : class
        {
            var path = $"{Application.persistentDataPath}/{fileName}";
            var json = JsonConvert.SerializeObject(obj);
            if(!System.IO.File.Exists(path))
                System.IO.File.Create(path).Close();
            System.IO.File.WriteAllText(path, json);
        }
    }
}