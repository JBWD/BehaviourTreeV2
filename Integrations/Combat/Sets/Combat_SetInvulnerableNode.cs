using Halcyon.BT;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [BehaviourTreeNode(menuPath = "Combat/Set", menuName = "Combat: Set Invunerable",
        nodeTitle = "Combat:\n Set Invunerable", nodeColor = NodeColors.pink, nodeIcon = NodeIcons.save)]
    public class Combat_SetInvulnerableNode : ActionNode
    {
        [BlackboardValueOnly]
        public NodeProperty<bool> isInvulnerable;
        public NodeProperty<bool> desiredState;
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
          
        }

        protected override State OnUpdate()
        {
            isInvulnerable.Value = desiredState.Value;
            return State.Success;
        }
    }
}