using System.Collections.Generic;
using Game.Components;
using StaticData;

namespace Services.StaticData
{
    public interface IStaticDataService
    {
        public PlayerStaticData PlayerStaticData { get; }
        IEnumerable<SpawnerStaticData> SpawnersStaticData { get; }
        EnemyStaticData GetEnemyData(EnemyType enemyType);
        void Load();
    }
}