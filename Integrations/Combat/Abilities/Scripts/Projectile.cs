using System;
using UnityEngine;

namespace Halcyon.BT.Integrations.Combat
{
    public class Projectile : MonoBehaviour
    {

        public float projectileSpeed = 10f;
        public GameObject target = null;
        public GameObject owner = null;

        public Ability ability = null;

        public void InitializeProjectile(GameObject owner, GameObject target)
        {
            this.target = target; 
            this.owner = owner;
            this.ability = ability;
        }
        
        // Update is called once per frame
        void Update()
        {

        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == target)
            {
                var em = target.GetComponent<EffectManager>();
                if (em != null)
                {
                    foreach (var effect in ability.effects)
                    {
                        em.ApplyEffect(effect, owner);
                    }
                }
            }
        }
    }
}