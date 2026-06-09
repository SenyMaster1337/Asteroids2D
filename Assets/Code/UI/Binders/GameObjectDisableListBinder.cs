using System;
using System.Collections.Generic;
using MVVM;
using R3;
using UnityEngine;

namespace Code.UI.Binders
{
    public class GameObjectDisableListBinder : IBinder, IObserver<int>
    {
        private readonly List<GameObject> _hearts;
        private readonly ReadOnlyReactiveProperty<int> _property;
        private IDisposable _handle;

        public GameObjectDisableListBinder(List<GameObject> hearts, ReadOnlyReactiveProperty<int> property)
        {
            _hearts = hearts;
            _property = property;
        }

        public void Bind()
        {
            OnNext(_property.CurrentValue);
            _handle = _property.Subscribe(OnNext);
        }

        public void Unbind()
        {
            _handle?.Dispose();
            _handle = null;
        }

        public void OnNext(int value)
        {
            for (int i = 0; i < _hearts.Count; i++)
                _hearts[i].SetActive(i < value);
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }
    }
}