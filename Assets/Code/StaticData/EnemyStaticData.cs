using UnityEngine;

namespace Code.StaticData
{
    [CreateAssetMenu(fileName = "EnemyStaticData", menuName = "StaticData/EnemyStaticData")]
    public class EnemyStaticData : ScriptableObject
    {
        [field: SerializeField] public EnemyType Type { get; private set; }
        [field: SerializeField] public EnemyData EnemyData { get; private set; }
    }
}