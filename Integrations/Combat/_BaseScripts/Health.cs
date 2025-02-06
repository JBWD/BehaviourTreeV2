using System;
using UnityEngine;
using UnityEngine.Events;

namespace Halcyon.BT.Integrations.Combat
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
        [SerializeField] private UnityEvent OnHealthChanged;

        //Used in other classes, allows for better troubleshooting.
        public Action OnDeathAction;
        public Action OnReviveAction;
        public Action OnInvulnerabilityAction;
        public Action OnHitAction;
        public Action<float> OnHealthChangeAction;
        
        
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
            OnHealthChangeAction?.Invoke(Mathf.Clamp(currentHealth,0 , float.MaxValue));
        }

        public void Heal(float heal)
        {
            if (currentHealth + heal > 0)
            {
                OnRevive.Invoke();
                OnReviveAction?.Invoke();
            }
            currentHealth += heal;
            OnHealthChanged?.Invoke();
            OnHealthChangeAction?.Invoke(Mathf.Clamp(currentHealth,0 , float.MaxValue));
        }
        
        
        
    }
}