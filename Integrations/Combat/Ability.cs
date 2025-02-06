using System.Collections.Generic;
using UnityEngine;

namespace Halcyon.BT.Integrations.Combat
{


    public abstract class Ability : ScriptableObject
    {
        public string abilityName;
        public float cooldown;
        public float range;
        public float castTime;
        public bool usesResource;
        public int resourceCost;
        public int priority;
        public bool canBeInterrupted = true;
        public List<Effect> effects; 

        private float lastUsedTime = -Mathf.Infinity;

        public bool IsOnCooldown() => Time.time - lastUsedTime < cooldown;

        public void Use(GameObject user, GameObject target)
        {
            lastUsedTime = Time.time;
            ApplyEffects(user, target);
            Activate(user, target);
        }

        private void ApplyEffects(GameObject user, GameObject target)
        {
            foreach (var effect in effects)
            {
                effect.Apply(target);
            }
        }

        public abstract void Activate(GameObject user, GameObject target);
    }
}