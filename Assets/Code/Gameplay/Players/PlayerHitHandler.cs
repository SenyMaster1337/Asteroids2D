using System.Threading;
using Code.Core.Interfaces.Input;
using Code.Gameplay.Effects;
using Code.Gameplay.Physics;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Players
{
    public class PlayerHitHandler : MonoBehaviour
    {
        private float _invincibilityDuration;
        private bool _isHitProcessing;

        private Player _player;
        private PlayerCollisionDetection _playerCollisionDetection;
        private InvulnerabilityEffect _invulnerabilityEffect;
        private IInputLocker _inputLocker;
        private KnockbackToCollision _knockbackToCollision;

        [Inject]
        public void Construct(IInputLocker inputLocker) 
            => _inputLocker = inputLocker;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _playerCollisionDetection = GetComponent<PlayerCollisionDetection>();
            _knockbackToCollision = GetComponent<KnockbackToCollision>();
            _invulnerabilityEffect = GetComponentInChildren<InvulnerabilityEffect>();
        }

        private void OnEnable()
            => _knockbackToCollision.Knocked += OnKnocked;

        private void OnDisable()
            => _knockbackToCollision.Knocked -= OnKnocked;

        public void Init(float invincibilityDuration) 
            => _invincibilityDuration = invincibilityDuration;

        private void OnKnocked()
        {
            if (_isHitProcessing)
                return;

            OnHitAsync(destroyCancellationToken).Forget();
        }

        private async UniTaskVoid OnHitAsync(CancellationToken token)
        {
            _isHitProcessing = true;

            await UniTask.WaitForSeconds(0.2f, cancellationToken: token);

            _player.Health.TakeDamage();
            _inputLocker.Lock();
            _playerCollisionDetection.DisableDetection();
            _invulnerabilityEffect.Play();

            await UniTask.WaitForSeconds(_invincibilityDuration, cancellationToken: token);

            _inputLocker.Unlock();
            _playerCollisionDetection.EnableDetection();
            _invulnerabilityEffect.Stop();

            _isHitProcessing = false;
        }
    }
}