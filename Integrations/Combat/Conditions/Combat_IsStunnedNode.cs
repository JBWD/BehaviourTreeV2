using Halcyon.BT;

namespace Halcyon.BT.Integrations.TowerDefense
{
    [BehaviourTreeNode(menuPath = "Combat/Condition", menuName = "Combat: Is Stunned",
        nodeTitle = "Combat:\n Is Stunned", nodeColor = NodeColors.yellow, nodeIcon = NodeIcons.condition)]
    public class Combat_IsStunnedNode: DecoratorNode
    {
        public NodeProperty<bool> desiredState;
        [BlackboardValueOnly]
        public NodeProperty<bool> isStunned;
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (isStunned.Value = desiredState.Value)
            {
                child.Update();
                return state = State.Success;
            }

            return state = State.Failure;
        }
        
        public override void UpdateDescription()
        {
            if (desiredState.Value)
            {
                
                description = "Fires Child nodes if the Unit is Stunned.";
                conditionState = ConditionState.True;
            }
            else
            {
                description = "Fires Child nodes if the Unit is NOT Stunned.";
                conditionState = ConditionState.False;
            }
        }
    }
}