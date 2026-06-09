using System.Collections.Generic;
using MVVM;
using UnityEngine;

namespace Code.UI.Views
{
    public class HealthView : MonoBehaviour
    {
        [Data("Health")]
        public List<GameObject> Hearts;
    }
}