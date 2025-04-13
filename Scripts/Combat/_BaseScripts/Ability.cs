using System.Collections.Generic;
using UnityEngine;

namespace Halcyon.Combat
{

    [CreateAssetMenu(menuName = "Halcyon/Ability", fileName = "New Ability" )]
    public class Ability : ScriptableObject
    {
        public AbilityType abilityType;
        public string abilityName;
        public float cooldown;
        public float range;
        public float castTime;
        public bool usesResource;
        public int resourceCost;
        public int priority;
        public bool canBeInterrupted = true;
        public List<Effect> effects; 
        
    }

 
}