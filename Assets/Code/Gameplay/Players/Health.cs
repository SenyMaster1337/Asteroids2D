using System;
using R3;

namespace Code.Gameplay.Players
{
    public class Health
    {
        public ReadOnlyReactiveProperty<int> Current => _current;

        private readonly ReactiveProperty<int> _current = new();
        
        public void Init(int maxHealth) 
            => _current.Value = maxHealth;

        public void TakeDamage()
            => _current.Value = Math.Max(0, _current.Value - 1);
    }
}