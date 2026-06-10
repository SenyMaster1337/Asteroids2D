using System;
using MVVM;
using UnityEditor;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Code.UI.Binders
{
    public class MonoViewBinder : MonoBehaviour
    {
        public enum BindingMode
        {
            FromInstance = 0,
            FromResolve = 1,
        }

        public BindingMode ViewBinding;
        public Object View;
        public MonoScript ViewType;

        [Space(8)] 
        public BindingMode ViewModelBinding;
        public Object ViewModel;
        public MonoScript ViewModelType;

        private DiContainer _diContainer;
        private IBinder _binder;

        [Inject]
        private void Construct(DiContainer diContainer)
            => _diContainer = diContainer;

        private void Awake()
            => _binder = CreateBinder();

        private void OnEnable()
            => _binder.Bind();

        private void OnDisable()
            => _binder.Unbind();

        private IBinder CreateBinder()
        {
            object view = ViewBinding switch
            {
                BindingMode.FromInstance => this.View,
                BindingMode.FromResolve => _diContainer.Resolve(ViewType.GetClass()),
                _ => throw new Exception($"Binding type of View {ViewBinding} is not found!")
            };

            object model = ViewModelBinding switch
            {
                BindingMode.FromInstance => ViewModel,
                BindingMode.FromResolve => _diContainer.Resolve(ViewModelType.GetClass()),
                _ => throw new Exception($"Binding type of View {ViewModelBinding} is not found!")
            };

            return BinderFactory.CreateComposite(view, model);
        }
    }
}