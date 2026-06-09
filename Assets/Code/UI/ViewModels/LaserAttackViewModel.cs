using System;
using Code.Core.Interfaces.Input;
using MVVM;

namespace Code.UI.ViewModels
{
    public class LaserAttackViewModel
    {
        [Data("LaserAttack")]
        public readonly Action LaserAttack;

        private readonly IMobileFireInput _mobileFireInput;

        public LaserAttackViewModel(IMobileFireInput mobileFireInput)
        {
            _mobileFireInput = mobileFireInput;
            LaserAttack = OnLaserAttack;
        }

        private void OnLaserAttack() =>
            _mobileFireInput.SetLaserAttack();
    }
}