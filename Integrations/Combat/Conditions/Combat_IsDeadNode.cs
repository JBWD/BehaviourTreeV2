using Halcyon.BT;
using Unity.VisualScripting;
using UnityEngine;

namespace Halcyon.BT.Integrations.Combat
{
    [BehaviourTreeNode(menuPath = "Combat/Condition", menuName = "Combat: Is Dead",
        nodeTitle = "Combat:\n Is Dead", nodeColor = NodeColors.yellow, nodeIcon = NodeIcons.condition)]
    public class Combat_IsDeadNode : DecoratorNode
    {
        [BlackboardValueOnly] public NodeProperty<float> currentHealth;
        public NodeProperty<bool> desiredCondition;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if ((currentHealth.Value <= 0) == desiredCondition.Value)
            {
                child.Update();
                return state = State.Success;
            }

            return state = State.Failure;
        }


        public override void UpdateDescription()
        {
            if (desiredCondition.Value)
            {
                conditionState = ConditionState.True;
                description = $"(Dead) Runs the child if the current health is less than or equal to 0";
            }
            else
            {
                conditionState = ConditionState.False;
                description = $"(Alive) Runs the child if the current health is greater than 0";
            }
            
        }
    }
}