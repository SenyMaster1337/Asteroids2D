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
            => _hearts.Add(heart);
    }
}