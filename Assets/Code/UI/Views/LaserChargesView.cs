using MVVM;
using TMPro;
using UnityEngine;

namespace Code.UI.Views
{
    public class LaserChargesView : MonoBehaviour
    {
        [Data("LaserCharges")] 
        [SerializeField] private TMP_Text _text;
    }
}