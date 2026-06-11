using UnityEngine;

namespace Code.Gameplay.Cameras
{
    public class CameraZoom : MonoBehaviour
    {
        private Camera _camera;

        private void Awake() =>
            _camera = GetComponent<Camera>();

        public void Init(float worldWidth, float worldHeight)
        {
            float halfHeight = worldHeight / 2f;
            float halfWidth = worldWidth / 2f;
            float aspectRatio = (float)Screen.width / Screen.height;

            _camera.orthographicSize = halfWidth / aspectRatio > halfHeight
                ? halfWidth / aspectRatio
                : halfHeight;
        }
    }
}