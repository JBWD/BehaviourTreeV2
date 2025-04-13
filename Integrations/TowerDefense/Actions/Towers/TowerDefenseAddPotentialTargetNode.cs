
using Halcyon.Combat;
using UnityEngine;

namespace Halcyon.BT.Integrations.Combat.Nodes
{
    
    [NodeMenuPath("Integrations/Tower Defense/Tower")]
    [NodeTitle("Tower:\nAdd Potential Target")]
    [NodeMenuName("Tower: Add Potential Target")]
    [CreateBBVariable("Target", BBVariableType.Transform)]
    public class TowerDefenseAddPotentialTargetNode : ActionNode
    {
        public NodeProperty<Transform> target;
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (target != null)
            {
                var potentialTarget = target.Value.GetComponent<EffectManager>();
                if (potentialTarget != null)
                {
                    context.abilityManager.AddTarget(potentialTarget);
                    return State.Success;
                }
            }

            return State.Failure;
        }
    }
}