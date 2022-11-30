using System;

namespace StaticData
{
    [Serializable]
    public class PlayerStaticData
    {
        public int MaxLasers;
        public float LaserRestoreTime;
        public float AccelerationSpeed;
        public float Deceleration;
        public float AngularSpeed;
        public string PlayerAssetPath;
        public string DestroyAsset;
    }
}