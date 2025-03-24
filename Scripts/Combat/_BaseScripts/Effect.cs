using UnityEngine;

namespace Halcyon.Combat
{   
    public enum EffectType
        {
            Instant,
            OverTime,
            AfterTime,
            Condition,
            StackingCondition
            
        } 
    [CreateAssetMenu(menuName = "Halcyon/Effect", fileName = "New Effect" )]
    public class Effect : ScriptableObject
    {
        public EffectType effectType;
        public string effectName;
        [ShowIfEnum("effectType", EffectType.Instant)]
        public float minHeal, maxHeal;
        [ShowIfEnum("effectType", EffectType.Instant)] 
        public float minDamage, maxDamage;
        [ShowIfEnum("effectType", EffectType.Instant)]
        public Effect appliedInstantEffect;
        
        
        [ShowIfEnum("effectType", (EffectType.Condition))] //Attribute Change
        public float duration = 0;
        [ShowIfEnum("effectType",  EffectType.StackingCondition)]
        public float stackDuration = 0;
        [ShowIfEnum("effectType",  EffectType.StackingCondition)] //Attribute Change Per Stack
        public int stackSize = 0;
        
        [ShowIfEnum("effectType", EffectType.OverTime)]
        public float healPerTick;
        [ShowIfEnum("effectType", EffectType.OverTime)]
        public int numberOfTicks = 0;
        [ShowIfEnum("effectType", EffectType.OverTime)]
        public float damagePerTick;
      
        [ShowIfEnum("effectType", EffectType.OverTime)]
        public Effect appliedOverTimeEffectOnComplete;

        [ShowIfEnum("effectType", EffectType.AfterTime)]
        public float timeUntilActivation;
        [ShowIfEnum("effectType", EffectType.AfterTime)]
        public float minActivationDamage;
        [ShowIfEnum("effectType", EffectType.AfterTime)]
        public float maxActivationDamage;
        [ShowIfEnum("effectType", EffectType.AfterTime)]
        public float minActivationHeal;
        [ShowIfEnum("effectType", EffectType.AfterTime)]
        public float maxActivationHeal;
        [ShowIfEnum("effectType", EffectType.AfterTime)]
        public Effect appliedAfterTimeEffect;

    }
}