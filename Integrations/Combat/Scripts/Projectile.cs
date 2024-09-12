 using System;
using UnityEngine;

 namespace Halcyon.BT.Integrations.Combat
 {
     public class Projectile : MonoBehaviour, IAttack
     {



         public Transform target;
         public Vector3 targetPosition;
         public float moveSpeed = 2f;

         public void Instantiate(Transform target)
         {
             this.target = target;
         }

         public void Instantiate(Vector3 targetPosition)
         {
             this.targetPosition = targetPosition;
         }

         public void Update()
         {
             if (target != null)
             {
                 transform.position =
                     Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
             }
             else
             {
                 transform.position =
                     Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
             }
         }

         public void OnTriggerEnter(Collider other)
         {

         }

         public float GetDamage()
         {
             return 0;
         }

         public float GetAdjustedDamage(ArmorType armorType, int armorAmount)
         {
             return 0;
         }

         public Attacker Attacker { get; set; }
     }
 }