using System;
using Core.Game.Components;

namespace StaticData
{
    [Serializable]
    public class WeaponStaticData
    {
        public bool Teleportable;
        public WeaponType WeaponType;
        public float ProjectileSpeed;
        public float DestroyTime;
        public string AssetPath;
        public string DestroyAsset;
    }
}