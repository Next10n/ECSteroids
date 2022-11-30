using System;
using Core.Game.Components;
using Core.Game.Components.Enemies;

namespace StaticData
{
    [Serializable]
    public class EnemyStaticData
    {
        public EnemyType EnemyType;
        public float MinVelocity;
        public float MaxVelocity;
        public string AssetPath;
        public int Score;
        public string DestroyAsset;
    }
}