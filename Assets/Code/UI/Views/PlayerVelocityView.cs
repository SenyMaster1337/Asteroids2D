using MVVM;
using TMPro;
using UnityEngine;

namespace Code.UI.Views
{
    public class PlayerVelocityView : MonoBehaviour
    {
        [Data("Velocity")]
        public TMP_Text Text;
    }
}