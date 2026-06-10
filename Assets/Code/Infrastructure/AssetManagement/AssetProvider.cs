using System;
using UnityEngine;

namespace Code.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Load(string path)
        {
            var asset = Resources.Load<GameObject>(path);
            
            if (asset == null)
                throw new Exception($"Resource not found at path: {path}");
            
            return asset;
        }
    }
}