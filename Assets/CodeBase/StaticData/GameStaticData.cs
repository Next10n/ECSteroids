using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Game", fileName = "GameStaticData")]
    public class GameStaticData : ScriptableObject
    {
        public PlayerStaticData Player;
        public SpawnerStaticData[] Spawners;
        public EnemyStaticData[] Enemies;
        public int MinAsteroidFragments;
        public int MaxAsteroidsFragments;
    }
}