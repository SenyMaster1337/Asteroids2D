using Code.Core.ConfigLoaders;
using Newtonsoft.Json;
using UnityEngine;

namespace Code.Infrastructure.Services.ConfigLoaders
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