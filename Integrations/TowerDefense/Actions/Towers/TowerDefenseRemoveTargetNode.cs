using Halcyon.Combat;
using UnityEngine;

namespace Halcyon.BT.Integrations.Combat.Nodes
{
    [NodeMenuPath("Integrations/Tower Defense/Tower")]
    [NodeTitle("Tower:\nRemove Target")]
    [NodeMenuName("Tower: Remove Target")]
    [CreateBBVariable("Target", BBVariableType.Transform)]
    public class TowerDefenseRemoveTargetNode : ActionNode
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
                    context.abilityManager.RemoveTarget(potentialTarget);
                    return State.Success;
                }
            }

            return State.Failure;
        }
    }
}