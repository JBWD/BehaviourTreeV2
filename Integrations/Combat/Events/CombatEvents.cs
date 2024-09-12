using System;
using UnityEngine;

namespace Halcyon.BT
{
    public static class CombatEvents
    {
        public static Action<GameObject> UnitDied;
        public static Action<string> UnitSpawned;
    }
}