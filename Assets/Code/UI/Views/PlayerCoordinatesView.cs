using MVVM;
using TMPro;
using UnityEngine;

namespace Code.UI.Views
{
    public class PlayerCoordinatesView : MonoBehaviour
    {
        [Data("Coordinates")]
        public TMP_Text Text;
    }
}