using Code.Core.Interfaces.Input;
using Code.Core.Interfaces.Spawners;
using R3;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Lasers
{
    public class PlayerLaserShooter : MonoBehaviour
    {
        private const float SpawnOffset = 15f;

        public ReactiveProperty<int> Charges { get; } = new();
        public ReactiveProperty<float> CooldownRemaining { get; } = new();

        private int _maxCharges;
        private float _cooldownDuration;
        private float _fireRate;
        private float _fireTimer;

        private ILaserSpawnerService _laserSpawner;
        private IInputService _inputService;

        [Inject]
        public void Construct(IInputService inputService, ILaserSpawnerService laserSpawner)
        {
            _inputService = inputService;
            _laserSpawner = laserSpawner;
        }

        private void Update()
        {
            _fireTimer -= Time.deltaTime;
            TickCooldown();

            if (_inputService.IsLaserAttack && _fireTimer <= 0f && Charges.Value > 0)
            {
                _laserSpawner.Spawn(
                    position: transform.position + transform.up * SpawnOffset,
                    direction: transform.up);

                Charges.Value--;
                _fireTimer = _fireRate;

                if (CooldownRemaining.Value <= 0f)
                    CooldownRemaining.Value = _cooldownDuration;
            }
        }

        public void Init(int maxCharges, float cooldownDuration, float fireRate)
        {
            _maxCharges = maxCharges;
            _cooldownDuration = cooldownDuration;
            _fireRate = fireRate;

            Charges.Value = _maxCharges;
        }

        private void TickCooldown()
        {
            if (Charges.Value >= _maxCharges)
                return;

            CooldownRemaining.Value -= Time.deltaTime;

            if (CooldownRemaining.Value <= 0f)
            {
                Charges.Value++;
                CooldownRemaining.Value = Charges.Value < _maxCharges ? _cooldownDuration : 0f;
            }
        }
    }
}