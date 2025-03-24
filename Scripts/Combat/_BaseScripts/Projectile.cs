using System;
using Halcyon.BT.Integrations.Combat;
using UnityEngine;
using UnityEngine.Events;

namespace Halcyon.Combat
{
    [RequireComponent(typeof(Collider))]
    public class Projectile : MonoBehaviour
    {
        public float damage = 10f;
        public float speed = 10f;
        public float lifetime = 5f;
        
        
        public UnityEvent OnInstantiate;
        public UnityEvent OnHit;

        public float _currentTime;
        public Collider _collider;
        public void OnEnable()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = true;
        }
        
        
        public void Initialize(Vector3 position, Quaternion rotation, LayerMask includedLayers)
        {
            _currentTime = 0;
            OnInstantiate.Invoke();
            transform.position = position;
            transform.rotation = rotation;
            gameObject.SetActive(true);
            
            _collider.includeLayers = includedLayers;
            _collider.excludeLayers = ~includedLayers;
        

        }

        public void Update()
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
            if (_currentTime >= lifetime)
            {
                gameObject.SetActive(false);
            }
            _currentTime += Time.deltaTime;
        }
        
        
        //public float GetDamage(ArmorType armorType, float amount){}

        public void OnTriggerEnter(Collider other)
        {
            Health health = other.GetComponent<Health>();
            //Debug.Log("Projectile hit Object");
            if (health != null)
            {
                health.TakeDamage(damage);
                OnHit.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
    
}