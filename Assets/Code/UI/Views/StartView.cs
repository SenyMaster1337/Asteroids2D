using MVVM;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Views
{
    public class StartView : MonoBehaviour
    {
        [Data("StartGame")] 
        [SerializeField] private Button _button;
    }
}