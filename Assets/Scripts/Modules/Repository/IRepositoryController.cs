namespace Modules.Repository
{
    public interface IRepositoryController
    {
        T LoadOrCreate<T>(string fileName, out bool isNew) where T : class, new();
        void Save<T>(T obj, string fileName) where T : class;
    }
}