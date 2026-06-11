using MVVM;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Views
{
    public class RestartView : MonoBehaviour
    {
        [Data("RestartGame")]
        [SerializeField] private Button _button;
    }
}