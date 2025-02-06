using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Halcyon.BT.Integrations.Combat
{
    public abstract class Effect : ScriptableObject
    {
        public string effectName;
        public float duration; 
        public float activationTime;
        public bool stackable = false;
        public int stackSize = 0;
        
        public abstract void Apply(GameObject target, GameObject owner, int stackSize);
        public abstract void StackSizeIncrease(GameObject target, GameObject owner);
        public abstract void Remove(GameObject target, GameObject owner, int stackSize);
    }
}