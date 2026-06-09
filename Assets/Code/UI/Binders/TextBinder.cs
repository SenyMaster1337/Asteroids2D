using System;
using MVVM;
using R3;
using TMPro;

namespace Code.UI.Binders
{
    public class TextBinder : IBinder, IObserver<string>
    {
        private readonly TMP_Text _view;
        private readonly ReadOnlyReactiveProperty<string> _property;
        private IDisposable _handle;

        public TextBinder(TMP_Text view, ReadOnlyReactiveProperty<string> property)
        {
            _view = view;
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

        public void OnNext(string value)
        {
            _view.text = value;
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }
    }
}