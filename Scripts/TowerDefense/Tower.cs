using System;
using System.Collections.Generic;
using Halcyon.Combat;
using UnityEngine;

namespace Halcyon.TowerDefense
{
    [RequireComponent(typeof(AbilityManager))]
    public class Tower : MonoBehaviour
    {
        public TowerData data;
        /// <summary>
        /// Target chosen by the player to have the tower prioritise if in range.
        /// </summary>
       
        private AbilityManager _abilityManager;
       

        public void Start()
        {
            if (data == null)
            {
                Debug.LogError("Tower data not set");
                return;
            }

            _abilityManager = GetComponent<AbilityManager>();
            if (data.AutoAttack == null)
            {
                Debug.LogWarning($"{gameObject.name}: Auto Attack in {data.fullName} is null!");
            }
            else
            {
                _abilityManager.autoAttack = data.AutoAttack;
            }
           
            if(data.SpecialAbility != null)
                _abilityManager.abilities.Add(data.SpecialAbility);
        }


        public void FireWeapon()
        {
            _abilityManager.TryAutoUse();
        }
        
        public void ApplyUpgrade1()
        {
            if (data.upgrade1Prefab != null)
            {
                Instantiate(data.upgrade1Prefab,transform.position,Quaternion.identity);
                Destroy(gameObject);
            }
        }

        public void ApplyUpgrade2()
        {
            if (data.upgrade2Prefab != null)
            {
                Instantiate(data.upgrade2Prefab,transform.position,Quaternion.identity);
                Destroy(gameObject);
            }
        }

        public void ApplyUpgrade3()
        {
            if (data.upgrade3Prefab != null)
            {
                Instantiate(data.upgrade3Prefab,transform.position,Quaternion.identity);
                Destroy(gameObject);
            }
        }

        public void SellTower()
        {
            if (data.soldPrefab != null)
            {
                Instantiate(data.soldPrefab,transform.position,Quaternion.identity);
            }
            Destroy(gameObject);
        }

        
    }
}