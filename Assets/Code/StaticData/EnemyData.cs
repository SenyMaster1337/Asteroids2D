using System;
using UnityEngine;

namespace Code.StaticData
{
    [Serializable]
    public class EnemyData
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}