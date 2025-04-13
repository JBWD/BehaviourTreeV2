using System;
using System.Collections.Generic;
using Halcyon.Combat;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Halcyon.BT;
using Random = UnityEngine.Random;

namespace Halcyon.Combat
{
    [RequireComponent(typeof(Health))]
    public class EffectManager : MonoBehaviour
    {
        private List<ActiveEffect> activeEffects = new List<ActiveEffect>();
        private Health health;
        public static Action<Effect> OnEffectAddedAction;
        public static Action<Effect> OnEffectRemovedAction;
        public Action<EffectManager> OnDeathAction;


        private void Start()
        {
            health = GetComponent<Health>();
            health.OnDeathAction += OnDeath;
        }

        private void OnDestroy()
        {
            health.OnDeathAction -= OnDeath;
        }


        private void OnDeath()
        {
            OnDeathAction?.Invoke(this);
        }
        private void Update()
        {
            for (int i = activeEffects.Count - 1; i >= 0; i--)
            {
                var activeEffect = activeEffects[i];
                switch (activeEffect.effect.effectType)
                {
                    case EffectType.Instant:
                        break;
                    case EffectType.OverTime:
                        if (activeEffect.duration <= activeEffect.ticksRemaining * activeEffect.timeBetweenTicks)
                        {
                            activeEffect.ApplyOverTimeTick();
                        }
                        else
                        {
                            activeEffect.RemoveOverTimeOnCompletedDuration();
                            activeEffect.Remove();
                            activeEffects.RemoveAt(i);
                        }
                        break;
                    case EffectType.AfterTime:
                        activeEffect.activationTime -= Time.deltaTime;
                        if ( activeEffect.activationTime <= 0)
                        {
                            activeEffect.Remove();
                            activeEffects.RemoveAt(i);
                        }
                        break;
                    case EffectType.Condition:
                        activeEffect.duration -= Time.deltaTime;
                        if ( activeEffect.duration <= 0)
                        {
                            activeEffect.Remove();
                            activeEffects.RemoveAt(i);
                        }
                        break;
                    case EffectType.StackingCondition:
                        activeEffect.duration -= Time.deltaTime;
                        if ( activeEffect.duration <= 0)
                        {
                            activeEffect.Remove();
                            activeEffects.RemoveAt(i);
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                

                
            }
        }
        

        public void ApplyEffect(Effect effect, GameObject casterGO)
        {
            ApplyEffect(effect, casterGO.GetComponent<EffectManager>());
        }
        
        public void ApplyEffect(Effect effect, EffectManager caster = null)
        {
            if(effect is null)
                return;
            
            if (ContainsEffect(effect))
            {
                if (effect.effectType == EffectType.StackingCondition)
                {
                    TryIncreaseStackSize(effect);
                }
                RefreshDurations(effect);
            }
            else
            {
                AddNewActiveEffect(effect, caster);
            }
            
        }

        private bool TryIncreaseStackSize(Effect effect)
        {
            foreach (ActiveEffect activeEffect in activeEffects)
            {
                if (effect == activeEffect.effect)
                {
                    if(effect.effectType == EffectType.StackingCondition  &&  activeEffect.stackSize < effect.stackSize)
                        activeEffect.StackSizeIncrease();
                    return true;
                }
            }
            return false;
        }

        private int GetStackCount(Effect effect)
        {
            foreach (ActiveEffect activeEffect in activeEffects)
            {
                if (effect == activeEffect.effect)
                {
                    return activeEffect.stackSize;
                  
                    
                }
            }
            return 0;
        }

        private void RefreshDurations(Effect effect)
        {
            foreach (ActiveEffect activeEffect in activeEffects)
            {
                if (activeEffect.effect == effect)
                {
                    activeEffect.duration = effect.duration;
                }
            }
        }

        private void AddNewActiveEffect(Effect effect, EffectManager caster)
        {
            ActiveEffect newEffect = new ActiveEffect(effect, this, caster );
            if (effect.effectType == EffectType.Instant)
            {
                newEffect.Apply();
            }
            else
            {
                activeEffects.Add(newEffect);
                
            }
        }

        public bool ContainsEffect(Effect effect)
        {

            bool containsEffect = false;
            for (int i = 0; i < activeEffects.Count; i++)
            {
                if (activeEffects[i].effect == effect)
                {
                    containsEffect = true;
                }
            }
            return containsEffect;
        }

        public float GetCurrentHealth()
        {
            return health.currentHealth;
        }
    }

    
    
    
    
    
    /// <summary>
    /// Wrapper class for Effects since they are scriptable objects.
    /// </summary>
    [Serializable]
    internal class ActiveEffect
    {
        
        public int stackSize { get; private set; }
        public Effect effect;
        public float duration;
        public float timeBetweenTicks { get; private set; }
        public int ticksRemaining { get; private set; }
        private EffectManager caster;
        private EffectManager target;
        public float activationTime;
        
        public ActiveEffect(Effect effect, EffectManager target, EffectManager caster)
        {
            this.effect = effect;
            this.duration = effect.effectType == EffectType.StackingCondition ? effect.stackDuration : effect.duration;
            this.caster = caster;
            this.target = target;
            stackSize = 1;
            activationTime = effect.timeUntilActivation;
            if (effect.effectType == EffectType.OverTime)
            {
                ticksRemaining = effect.numberOfTicks;
                timeBetweenTicks = effect.duration / effect.numberOfTicks;
            }
            
        }

        public void Apply()
        {
            var targetHealth = target.GetComponent<Health>();
            
            if(effect.effectType == EffectType.Instant)
            {
                targetHealth.Heal(Random.Range(effect.minHeal, effect.maxHeal));
                targetHealth.TakeDamage(Random.Range(effect.minDamage, effect.maxDamage));
                if (effect.appliedInstantEffect != null)
                {
                    target.ApplyEffect(effect.appliedInstantEffect);
                }
            }
        }
        public void StackSizeIncrease()
        {
            Apply();
        }

        public void ApplyOverTimeTick()
        {
            if(effect.effectType ==EffectType.OverTime)
            {
                var targetHealth = target.GetComponent<Health>();   
                targetHealth.Heal(effect.healPerTick);
                targetHealth.TakeDamage(effect.damagePerTick);
            }
        }

        public void RemoveOverTimeOnCompletedDuration()
        {
            if (effect.appliedAfterTimeEffect != null)
            {
                target.ApplyEffect(effect.appliedAfterTimeEffect);
            }
        }

        public void Remove()
        {
            if (effect.effectType == EffectType.AfterTime)
            {
                var targetHealth = target.GetComponent<Health>();
                targetHealth.Heal(Random.Range(effect.minActivationHeal, effect.maxActivationHeal));
                targetHealth.TakeDamage(Random.Range(effect.minActivationDamage, effect.maxActivationDamage));
                
                if (effect.appliedAfterTimeEffect != null)
                {
                    target.ApplyEffect(effect.appliedAfterTimeEffect);
                }
            }
        }
        
    }
}