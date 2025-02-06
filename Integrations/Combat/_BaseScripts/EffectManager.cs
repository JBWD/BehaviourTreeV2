using System;
using System.Collections.Generic;
using Halcyon.Combat;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Halcyon.BT.Integrations.Combat
{
    [RequireComponent(typeof(Health))]
    public class EffectManager : MonoBehaviour
    {
        private List<ActiveEffect> activeEffects = new List<ActiveEffect>();
        private void Update()
        {
            for (int i = activeEffects.Count - 1; i >= 0; i--)
            {
                activeEffects[i].duration -= Time.deltaTime;
                if (activeEffects[i].duration <= 0)
                {
                    activeEffects[i].Remove();
                    activeEffects.RemoveAt(i);
                }
            }
        }

        public void ApplyEffect(Effect effect)
        {
            ApplyEffect(effect,null);
        }
        public void ApplyEffect(Effect effect, GameObject caster)
        {
            if(effect == null)
                return;
            if (ContainsEffect(effect))
            {
                if (effect.stackable)
                {
                    TryIncreaseStackSize(effect);
                }
                RefreshDurations(effect);
            }
            else
            {
                if (effect.activationTime <= 0) //Instant Cast Effects
                {
                    effect.Apply(gameObject, caster, 1);
                }
                if(effect.duration > 0)
                {
                    AddNewActiveEffect(effect, caster);
                }
            }
            
        }

        private bool TryIncreaseStackSize(Effect effect)
        {
            foreach (ActiveEffect activeEffect in activeEffects)
            {
                if (effect == activeEffect.effect)
                {
                    if(effect.stackable && activeEffect.stackSize < effect.stackSize)
                        activeEffect.IncreaseStackSize();
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

        private void AddNewActiveEffect(Effect effect, GameObject caster)
        {
            ActiveEffect newEffect = new ActiveEffect(effect, gameObject, caster );
            activeEffects.Add(newEffect);
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
        private GameObject caster;
        private GameObject target;
        
        
        public ActiveEffect(Effect effect, GameObject target, GameObject caster)
        {
            this.effect = effect;
            this.duration = effect.duration;
            this.caster = caster;
            this.target = target;
            stackSize = 1;
        }

        public void Apply()
        {
            effect.Apply(target, caster, stackSize);
        }

        public void IncreaseStackSize()
        {
            stackSize++;
            effect.StackSizeIncrease(target, caster);
        }
        
        public void Remove()
        {
            effect.Remove(target,caster, stackSize);
        }
    }
}