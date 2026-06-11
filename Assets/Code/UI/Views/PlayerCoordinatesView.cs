using MVVM;
using TMPro;
using UnityEngine;

namespace Code.UI.Views
{
    public class PlayerCoordinatesView : MonoBehaviour
    {
        [Data("Coordinates")]
        [SerializeField] private TMP_Text _text;
    }
}