using Code.UI.Binders;
using UnityEditor;
using UnityEngine;

namespace Code.Editor
{
    [CustomEditor(typeof(MonoViewBinder))]
    public class MonoViewBinderEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            MonoViewBinder binder = (MonoViewBinder)target;

            EditorGUI.BeginChangeCheck();

            binder.ViewBinding = (MonoViewBinder.BindingMode)EditorGUILayout.EnumPopup(
                "View Binding", binder.ViewBinding);

            if (binder.ViewBinding == MonoViewBinder.BindingMode.FromInstance)
            {
                binder.View = EditorGUILayout.ObjectField(
                    "View", binder.View, typeof(Object), true);
            }

            if (binder.ViewBinding == MonoViewBinder.BindingMode.FromResolve)
            {
                binder.ViewType = (MonoScript)EditorGUILayout.ObjectField(
                    "View Type", binder.ViewType, typeof(MonoScript), false);
            }

            EditorGUILayout.Space(8);

            binder.ViewModelBinding = (MonoViewBinder.BindingMode)EditorGUILayout.EnumPopup(
                "View Model Binding", binder.ViewModelBinding);

            if (binder.ViewModelBinding == MonoViewBinder.BindingMode.FromInstance)
            {
                binder.ViewModel = EditorGUILayout.ObjectField(
                    "View Model", binder.ViewModel, typeof(Object), true);
            }

            if (binder.ViewModelBinding == MonoViewBinder.BindingMode.FromResolve)
            {
                binder.ViewModelType = (MonoScript)EditorGUILayout.ObjectField(
                    "View Model Type", binder.ViewModelType, typeof(MonoScript), false);
            }

            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(binder);
        }
    }
}