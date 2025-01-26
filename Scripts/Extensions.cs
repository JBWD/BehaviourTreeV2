using UnityEngine;
using UnityEngine.Events;



public static class Extensions{

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
}