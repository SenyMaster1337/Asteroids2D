using UnityEngine;

namespace Code.StaticData
{
    [CreateAssetMenu(fileName = "EnemyStaticData", menuName = "StaticData/EnemyStaticData")]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyType Type;
        public EnemyData EnemyData;
    }
}