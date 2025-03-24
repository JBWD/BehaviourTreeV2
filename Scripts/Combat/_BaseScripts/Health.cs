using System;
using UnityEngine;
using UnityEngine.Events;

namespace Halcyon.Combat
{
    public class Health : MonoBehaviour
    {
        public float currentHealth = 100f;
        public float maxHealth = 100f;
        public bool resetHealthOnEnable = true;
        
        public bool invulnerableOnHit = false;
        public float timeInvulnerable = .5f;

        private DateTime m_OnInvulnerabilityStart;


        //Used internally and shows events to user through the inspector.
        [SerializeField] private UnityEvent OnInvulnerable;
        [SerializeField] private UnityEvent OnDeath;
        [SerializeField] private UnityEvent OnRevive;
        [SerializeField] private UnityEvent OnHit;
        [SerializeField] private UnityEvent<float> OnHealthChanged;
        [SerializeField] private UnityEvent<float> OnTakeDamage;
        [SerializeField] private UnityEvent<float> OnHealDamage;
        

        //Used in other classes, allows for better troubleshooting.
        public Action OnDeathAction;
        public Action OnReviveAction;
        public Action OnInvulnerabilityAction;
        public Action OnHitAction;
        public Action<float> OnHealthChangeAction;
        public Action<float> OnTakeDamageAction;
        public Action<float> OnHealDamageAction;
        public void OnEnable()
        {
            if (resetHealthOnEnable)
            {
                currentHealth = maxHealth;
            }
        }

        public void TakeDamage(float damage)
        {
            if (DateTime.Now.Subtract(m_OnInvulnerabilityStart).TotalSeconds < timeInvulnerable)
            {
                return;
            }
            currentHealth -= damage;

            OnHit?.Invoke();
            OnHitAction?.Invoke();

            if (invulnerableOnHit)
            {
                m_OnInvulnerabilityStart = DateTime.Now;
                OnInvulnerable?.Invoke();
                OnInvulnerabilityAction?.Invoke();
            }
            if (currentHealth <= 0f)
            {
                OnDeath?.Invoke();
                OnDeathAction?.Invoke();
            }
            OnTakeDamage?.Invoke(damage);
            OnTakeDamageAction?.Invoke(damage);
            
            OnHealthChanged?.Invoke(Mathf.Clamp(currentHealth,0 , float.MaxValue));
            OnHealthChangeAction?.Invoke(Mathf.Clamp(currentHealth,0 , float.MaxValue));
        }

        public void Heal(float heal)
        {
            if (currentHealth + heal > 0)
            {
                OnRevive.Invoke();
                OnReviveAction?.Invoke();
            }
            OnHealDamage?.Invoke(heal);
            OnHealDamageAction?.Invoke(heal);
            
            currentHealth += heal;
            OnHealthChanged?.Invoke(Mathf.Clamp(currentHealth,0 , float.MaxValue));
            OnHealthChangeAction?.Invoke(Mathf.Clamp(currentHealth,0 , float.MaxValue));
        }
        
        

        
        
    }
}