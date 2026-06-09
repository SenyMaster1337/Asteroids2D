using System;
using System.Collections.Generic;
using System.Linq;
using Code.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService, IInitializable
    {
        private const string EnemiesStaticDataPath = "StaticData/Enemies";

        private Dictionary<EnemyType, EnemyStaticData> _enemyStaticData;

        public void Initialize()
        {
            Load();
        }

        private void Load()
        {
            _enemyStaticData = Resources
                .LoadAll<EnemyStaticData>(EnemiesStaticDataPath)
                .ToDictionary(x => x.Type, x => x);
        }

        public EnemyData GetEnemyData(EnemyType enemyType)
        {
            if (_enemyStaticData.TryGetValue(enemyType, out EnemyStaticData staticData))
                return staticData.EnemyData;

            throw new InvalidOperationException(
                $"EnemyData for type '{enemyType}' not found. Check Resources/{EnemiesStaticDataPath}.");
        }
    }
}