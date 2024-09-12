using Halcyon.BT;
using Halcyon.BT.Integrations.Combat;
using UnityEngine;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [BehaviourTreeNode(menuName = "Tower Defense: Take Projectile Damage", menuPath = "Tower Defense", nodeColor = NodeColors.green, nodeIcon = NodeIcons.action, nodeTitle = "Tower Defense:\nTake Projectile Damage")]
    public class TakeProjectileDamage : ActionNode
    {
        [BlackboardValueOnly] public NodeProperty<GameObject> projectileGameObject;
        [BlackboardValueOnly] public NodeProperty<int> currentHealth;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (projectileGameObject == null) return state = State.Failure;

            Projectile projectile = projectileGameObject.Value.GetComponent<Projectile>();
            if (projectile != null)
            {
                currentHealth.Value -= (int)projectile.GetDamage();
                
            }
            else
            {
                return state = State.Failure; 
            }

            return state = State.Success;
        }
    }
}