 
using Unity.VisualScripting;
using UnityEngine;

namespace Halcyon.BT.Integrations.Combat
{
    [CreateAssetMenu(fileName = "Damage Effect", menuName = "Halcyon/Behaviour Tree/Effects/Damage Effect")]
    public class DamageEffect : Effect
    {

        public float minimumDamage;
        public float maximumDamage;
        
        public override void Apply(GameObject target, GameObject owner, int stackSize = 1)
        {
            var health = target.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(Random.Range(minimumDamage, maximumDamage));
            }
        }

        public override void StackSizeIncrease(GameObject target, GameObject owner)
        {
          
        }

        public override void Remove(GameObject target, GameObject owner, int stackSize = 1)
        {
            
        }
    }
}