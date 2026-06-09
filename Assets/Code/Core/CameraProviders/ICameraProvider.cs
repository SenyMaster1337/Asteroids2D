using UnityEngine;

namespace Code.Core.CameraProviders
{
    public interface ICameraProvider
    {
        Camera Camera { get; }
        void SetCamera(Camera camera);
    }
}