using UnityEditor;
using UnityEngine;

namespace Halcyon.BT.Integrations.Combat
{
    public abstract class Effect : ScriptableObject
    {
        public string effectName;
        public float duration;
        public bool stackable = false;
        public int stackSize = 0;
        
        public abstract void Apply(GameObject target);
    }
}