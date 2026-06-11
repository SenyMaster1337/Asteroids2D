using MVVM;
using TMPro;
using UnityEngine;

namespace Code.UI.Views
{
    public class RotationAngleView : MonoBehaviour
    {
        [Data("RotationAngle")]
        [SerializeField] private TMP_Text _text;
    }
}