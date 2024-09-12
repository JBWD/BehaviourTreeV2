using Halcyon.BT;
using UnityEngine;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [BehaviourTreeNode(menuPath = "Combat/Condition", menuName = "Combat: Can Attack",
        nodeTitle = "Combat:\n Can Attack", nodeColor = NodeColors.yellow, nodeIcon = NodeIcons.condition)]
    public class Combat_CanAttackNode : DecoratorNode
    {

        public NodeProperty<float> attackRange;
        public NodeProperty<Transform> target;
        
        protected override void OnStart()
        {
            
                
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (target.Value == null)
                return State.Failure;
            if (Vector3.Distance(context.transform.position, target.Value.position) < attackRange.Value)
            {
                child.Update();
                return State.Success;
            }
            return State.Failure;
        }
        
        public override void UpdateDescription()
        {
            description = $"(In Range) Runs the child if the unit is within the attack range.";
        }
    }
}