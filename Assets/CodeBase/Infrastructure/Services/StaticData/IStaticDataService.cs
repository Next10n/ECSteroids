using System.Collections.Generic;
using Core.Game.Components;
using StaticData;

namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        public PlayerStaticData PlayerStaticData { get; }
        IEnumerable<SpawnerStaticData> SpawnersStaticData { get; }
        int MaxAsteroidFragments { get; }
        int MinAsteroidFragments { get; }
        EnemyStaticData GetEnemyData(EnemyType enemyType);
        void Load();
    }
}