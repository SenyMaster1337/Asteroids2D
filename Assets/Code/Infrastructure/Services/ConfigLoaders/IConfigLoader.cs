namespace Code.Core.ConfigLoaders
{
    public interface IConfigLoader
    {
        T Load<T>(string path);
    }
}