using System;
using Code.Core.Interfaces.Input;
using MVVM;

namespace Code.UI.ViewModels
{
    public class DefaultAttackViewModel
    {
        [Data("DefaultAttack")]
        public readonly Action DefaultAttack;

        private readonly IMobileFireInput _mobileFireInput;

        public DefaultAttackViewModel(IMobileFireInput mobileFireInput)
        {
            _mobileFireInput = mobileFireInput;
            DefaultAttack = OnDefaultAttack;
        }

        private void OnDefaultAttack() =>
            _mobileFireInput.SetOrdinaryAttack();
    }
}