using System;
using Core.Game.Components;

namespace Extensions
{
    public static class WeaponExtensions
    {
        public static WeaponType Next(this WeaponType weaponType)
        {
            WeaponType[] values = (WeaponType[])Enum.GetValues(weaponType.GetType());
            int index = Array.IndexOf<WeaponType>(values, weaponType) + 1;
            return (values.Length==index) ? values[0] : values[index];            
        }
    }
}