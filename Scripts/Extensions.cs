using System;
using UnityEngine;
using UnityEngine.Events;


namespace Halcyon.BT
{


    public static class Extensions
    {

        /// <summary>
        /// Extension method to check if a layer is in a LayerMask
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static bool Contains(this LayerMask mask, int layer)
        {
            return mask == (mask | (1 << layer));
        }

        public static bool HasFlagFast<T>(this T value, T flag) where T : Enum
        {
            var valueInt = Convert.ToInt64(value);
            var flagInt = Convert.ToInt64(flag);
            return (valueInt & flagInt) == flagInt;
        }
    }
}