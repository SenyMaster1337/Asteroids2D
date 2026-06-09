using Code.Core.Interfaces.Input;
using Code.Core.Interfaces.Spawners;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Players
{
    public class PlayerBulletShooter : MonoBehaviour
    {
        private const float SpawnOffset = 1.5f;

        private float _fireRate;
        private float _timer;

        private IBulletSpawnerService _bulletSpawner;
        private IInputService _inputService;

        [Inject]
        public void Construct(IInputService inputService, IBulletSpawnerService bulletSpawner)
        {
            _inputService = inputService;
            _bulletSpawner = bulletSpawner;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;

            if (_inputService.IsOrdinaryAttack && _timer <= 0f)
            {
                _bulletSpawner.Spawn(
                    position: transform.position + transform.up * SpawnOffset,
                    direction: transform.up);

                _timer = _fireRate;
            }
        }

        public void Init(float fireRate) 
            => _fireRate = fireRate;
    }
}