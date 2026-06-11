using MVVM;
using TMPro;
using UnityEngine;

namespace Code.UI.Views
{
    public class LaserCooldownView : MonoBehaviour
    {
        [Data("LaserCooldown")]
        [SerializeField] private TMP_Text _text;
    }
}