using System;
using Game.Components;

namespace StaticData
{
    [Serializable]
    public class EnemyStaticData
    {
        public EnemyType EnemyType;
        public float MinVelocity;
        public float MaxVelocity;
        public string AssetPath;
    }
}