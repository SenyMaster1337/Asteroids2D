using MVVM;
using TMPro;
using UnityEngine;

namespace Code.UI.Views
{
    public class RotationAngleView : MonoBehaviour
    {
        [Data("RotationAngle")]
        public TMP_Text Text;
    }
}