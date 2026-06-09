using UnityEngine;

namespace Code.Core.CameraProviders
{
    public class CameraProvider : ICameraProvider
    {
        public Camera Camera { get; private set; }

        public void SetCamera(Camera camera) =>
            Camera = camera;
    }
}