using System;
using System.Threading;
using Code.Core.Interfaces.Input.InputLock;
using Code.Gameplay.Effects;
using Code.Gameplay.Physics;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Players
{
    public class PlayerHitHandler : MonoBehaviour
    {
        private const float DelayBeforeDamage = 0.2f;

        private float _invincibilityDuration;
        private bool _isHitProcessing;

        private Player _player;
        private PlayerCollisionDetection _playerCollisionDetection;
        private InvulnerabilityEffect _invulnerabilityEffect;
        private IInputLockService _inputLockService;
        private KnockbackToCollision _knockbackToCollision;
        private CancellationTokenSource _hitCts;

        [Inject]
        public void Construct(IInputLockService inputLockService)
            => _inputLockService = inputLockService;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _playerCollisionDetection = GetComponent<PlayerCollisionDetection>();
            _knockbackToCollision = GetComponent<KnockbackToCollision>();
            _invulnerabilityEffect = GetComponentInChildren<InvulnerabilityEffect>();
        }

        private void Start()
            => _knockbackToCollision.Knocked += OnKnocked;

        private void OnDestroy()
        {
            _knockbackToCollision.Knocked -= OnKnocked;
            CancelHit();
        }

        public void Init(float invincibilityDuration)
            => _invincibilityDuration = invincibilityDuration;

        private void CancelHit()
        {
            _hitCts?.Cancel();
            _hitCts?.Dispose();
            _hitCts = null;
        }

        private async void OnKnocked()
        {
            if (_isHitProcessing)
                return;

            _isHitProcessing = true;
            CancelHit();
            _hitCts = new CancellationTokenSource();

            await OnHitAsync(_hitCts.Token);
        }

        private async UniTask OnHitAsync(CancellationToken token)
        {
            try
            {
                await UniTask.WaitForSeconds(DelayBeforeDamage, cancellationToken: token);

                _player.Health.TakeDamage();
                _inputLockService.Lock();
                _playerCollisionDetection.DisableDetection();
                _invulnerabilityEffect.Play();

                await UniTask.WaitForSeconds(_invincibilityDuration, cancellationToken: token);
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                if (this != null)
                {
                    _inputLockService.Unlock();
                    _playerCollisionDetection.EnableDetection();
                    _invulnerabilityEffect.Stop();
                    _isHitProcessing = false;
                }
            }
        }
    }
}