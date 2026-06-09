using MVVM;
using TMPro;
using UnityEngine;

namespace Code.UI.Views
{
    public class ScoreView : MonoBehaviour
    {
        [Data("Score")]
        public TMP_Text Text;
    }
}