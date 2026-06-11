using MVVM;
using TMPro;
using UnityEngine;

namespace Code.UI.Views
{
    public class PlayerVelocityView : MonoBehaviour
    {
        [Data("Velocity")]
        [SerializeField] private TMP_Text _text;
    }
}