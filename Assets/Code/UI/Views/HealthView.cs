using System.Collections.Generic;
using MVVM;
using UnityEngine;

namespace Code.UI.Views
{
    public class HealthView : MonoBehaviour
    {
        [Data("Health")] 
        [SerializeField] private List<GameObject> _hearts;

        public void AddHeart(GameObject heart)
        {
            if (_hearts == null)
                return;

            _hearts.Add(heart);
        }
    }
}