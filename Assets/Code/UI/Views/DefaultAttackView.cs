using MVVM;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Views
{
    public class DefaultAttackView : MonoBehaviour
    {
        [Data("DefaultAttack")] 
        [SerializeField] private Button _button;
    }
}