using System.Collections.Generic;
using Halcyon.Combat;
using UnityEngine;

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
            if(effect == null)
                return;
            if (ContainsEffect(effect, out int stackCount) )
            {
                if (effect.stackable && effect.stackSize > stackCount)
                {
                       AddNewActiveEffect(effect);
                }
                RefreshDurations(effect);
            }
            else
            {
                AddNewActiveEffect(effect);
            }
            
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

        private void AddNewActiveEffect(Effect effect)
        {
            ActiveEffect newEffect = new ActiveEffect(effect, this);
            activeEffects.Add(newEffect);
            newEffect.Apply();
        }

        public bool ContainsEffect(Effect effect, out int stackCount)
        {
            stackCount = 0;

            for (int i = 0; i < activeEffects.Count; i++)
            {
                if (activeEffects[i].effect == effect)
                {
                    stackCount++;
                }
            }
            return stackCount > 0;
        }
    }

    /// <summary>
    /// Wrapper class for Effects since they are scriptable objects.
    /// </summary>
    internal class ActiveEffect
    {
        public Effect effect;
        public float duration;
        private EffectManager owner;

        public ActiveEffect(Effect effect, EffectManager owner)
        {
            this.effect = effect;
            this.duration = effect.duration;
            this.owner = owner;
        }

        public void Apply()
        {
            effect.Apply(owner.gameObject);
        }

        public void Remove()
        {
            
        }
    }
}