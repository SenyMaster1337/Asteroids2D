using MVVM;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Views
{
    public class LaserAttackView : MonoBehaviour
    {
        [Data("LaserAttack")] 
        [SerializeField] private Button _button;
    }
}