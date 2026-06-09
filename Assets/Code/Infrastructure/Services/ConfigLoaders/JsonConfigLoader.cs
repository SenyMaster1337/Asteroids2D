using Newtonsoft.Json;
using UnityEngine;

namespace Code.Core.ConfigLoaders
{
    public class JsonConfigLoader : IConfigLoader
    {
        public T Load<T>(string path)
        {
            TextAsset file = Resources.Load<TextAsset>(path);
            
            if (file == null)
                throw new System.Exception($"Config not found at path: {path}");

            return JsonConvert.DeserializeObject<T>(file.text);
        }
    }
}