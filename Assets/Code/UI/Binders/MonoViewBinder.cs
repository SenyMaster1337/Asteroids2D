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
            FromResolveId = 2
        }

        public BindingMode ViewBinding;
        public Object View;
        public MonoScript ViewType;
        public string ViewId;

        [Space(8)]
        public BindingMode ViewModelBinding;
        public Object ViewModel;
        public MonoScript ViewModelType;
        public string ViewModelId;

        private DiContainer _diContainer;

        [Inject]
        private void Construct(DiContainer diContainer) 
            => _diContainer = diContainer;

        private IBinder _binder;

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
                BindingMode.FromResolveId => _diContainer.ResolveId(ViewType.GetClass(), ViewId),
                _ => throw new Exception($"Binding type of View {ViewBinding} is not found!")
            };

            object model = ViewModelBinding switch
            {
                BindingMode.FromInstance => ViewModel,
                BindingMode.FromResolve => _diContainer.Resolve(ViewModelType.GetClass()),
                BindingMode.FromResolveId => _diContainer.ResolveId(ViewModelType.GetClass(), ViewModelId),
                _ => throw new Exception($"Binding type of View {ViewModelBinding} is not found!")
            };

            return BinderFactory.CreateComposite(view, model);
        }
    }
}