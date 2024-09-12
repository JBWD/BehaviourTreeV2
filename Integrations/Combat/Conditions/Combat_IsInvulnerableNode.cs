using Halcyon.BT;

namespace Halcyon.BT.Integrations.Combat
{
    [BehaviourTreeNode(menuPath = "Combat/Condition", menuName = "Combat: Is Invulnerable",
        nodeTitle = "Combat:\n Is Invulnerable", nodeColor = NodeColors.yellow, nodeIcon = NodeIcons.condition)]
    public class Combat_IsInvulnerableNode : DecoratorNode
    {
        public NodeProperty<bool> desiredState;
        [BlackboardValueOnly]
        public NodeProperty<bool> isInvulnerable;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if(isInvulnerable.Value == desiredState.Value)
                return State.Success;
            return State.Failure;
        }

        public override void UpdateDescription()
        {
            if (desiredState.Value)
            {
                
                description = "Fires Child nodes if the Unit is stunned.";
                conditionState = ConditionState.True;
                
            }
            else
            {
                description = "Fires Child nodes if the Unit is NOT stunned.";
                conditionState = ConditionState.False;
            }
        }
    }
}