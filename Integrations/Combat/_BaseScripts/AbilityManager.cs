using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Halcyon.BT.Integrations.Combat
{
    
    public class AbilityManager : MonoBehaviour
    {

        public Ability autoAttack;
        public List<Ability> abilities;
        
        private Dictionary<Ability, float> _abilityLastUsed = new Dictionary<Ability, float>();
        private bool _isCasting;
        private Ability abilityBeingCast = null;
        private float castStartTime; 
        private GameObject castingTarget;
        public void Update()
        {
            if (_isCasting && Time.time - castStartTime > abilityBeingCast.castTime)
            {
                _isCasting = false;
                abilityBeingCast = null;
                _abilityLastUsed.Clear();
                ApplyAbility(abilityBeingCast, castingTarget);
            }
        }

        public bool IsOnCooldown(Ability ability)
        {
            if(!_abilityLastUsed.TryGetValue(ability, out var value))
                return false;

            if (Time.time - value < ability.cooldown)
            {
                return true;
            }
            
            _abilityLastUsed.Remove(ability);
            return false;
        }

        public virtual void Use(Ability ability, GameObject target)
        {
            if (_isCasting)
                return;
            if (IsOnCooldown(ability))
                return;
            if (target == null)
                return;
            if (!InRange(ability, target))
                return;
            if (ability.castTime > 0)
            {
                _isCasting = true;
                abilityBeingCast = ability;
                castStartTime = Time.time;
                castingTarget = target;
                return;
            }
            
           ApplyAbility(ability,target);
        }

        public virtual void Use(int index, GameObject target)
        {
            if (index >= 0 && index < abilities.Count)
            {
                Use(abilities[index], target);
            }
            else
            {
                Debug.LogWarning($"Index out of range (Index: {index}), {gameObject.name}, in Ability Manager."); 
            }
        }


        public virtual void UseAutoAttack(GameObject target)
        {
            if (autoAttack != null)
            {
                Use(autoAttack, target);
            }
            else
            {
                Debug.LogWarning($"Auto attack is null, {gameObject.name}, in Ability Manager."); 
            }
        }

        private void ApplyAbility(Ability ability, GameObject target)
        {
            ApplyEffects(ability, target);
            _abilityLastUsed.Add(ability, Time.time);
        }
        
        
        private void ApplyEffects(Ability ability, GameObject target)
        {
            var em = target.GetComponent<EffectManager>();
            foreach (var effect in ability.effects)
            {
                em.ApplyEffect(effect, gameObject);
            }
        }

        private bool InRange(Ability ability, GameObject target)
        {
            return Vector3.Distance(transform.position, target.transform.position) <= ability.range;
        }
    }
}