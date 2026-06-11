using MVVM;
using TMPro;
using UnityEngine;

namespace Code.UI.Views
{
    public class ScoreView : MonoBehaviour
    {
        [Data("Score")]
        [SerializeField] private TMP_Text _text;
    }
}