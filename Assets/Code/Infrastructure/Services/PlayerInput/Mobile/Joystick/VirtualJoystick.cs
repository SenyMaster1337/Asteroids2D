using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Code.Infrastructure.Services.PlayerInput.Mobile.Joystick
{
    public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private RectTransform _background;
        [SerializeField] private RectTransform _handle;
        [SerializeField] private float _maxRadius;

        private IVirtualJoystickProvider _virtualJoystickProvider;
        private Vector2 _input;
        private Canvas _canvas;

        public float Vertical => _input.y;
        public float Horizontal => _input.x;

        [Inject]
        private void Construct(IVirtualJoystickProvider virtualJoystickProvider)
        {
            _virtualJoystickProvider = virtualJoystickProvider;
        }

        private void Awake()
        {
            _virtualJoystickProvider.SetJoystick(this);
            _canvas = GetComponentInParent<Canvas>();
        }

        public void OnPointerDown(PointerEventData eventData) 
            => OnDrag(eventData);

        public void OnDrag(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _background,
                eventData.position,
                _canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : _canvas.worldCamera,
                out Vector2 localPoint);

            _input = localPoint / _maxRadius;
            _input = Vector2.ClampMagnitude(_input, 1f);

            _handle.anchoredPosition = _input * _maxRadius;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _input = Vector2.zero;
            _handle.anchoredPosition = Vector2.zero;
        }
    }
}