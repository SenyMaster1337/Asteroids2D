using Code.Core.CameraProviders;
using UnityEngine;
using Zenject;

namespace Code.Gameplay
{
    public class CameraRegister : MonoBehaviour
    {
        private ICameraProvider _cameraProvider;

        [Inject]
        private void Constructor(ICameraProvider cameraProvider) 
            => _cameraProvider = cameraProvider;

        private void Awake() 
            => _cameraProvider.SetCamera(GetComponent<Camera>());
    }
}