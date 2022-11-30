using System;
using Core.Game.Components;
using Core.Game.Components.Enemies;

namespace StaticData
{
    [Serializable]
    public class SpawnerStaticData
    {
        public EnemyType EnemyType;
        public float SpawnDelay;
    }
}