using UnityEngine;

namespace Halcyon.BT
{
    
    [BehaviourTreeNode(menuPath = "NavMesh", menuName = "NavMesh: Is Agent Moving", nodeTitle = "NavMesh:\n Is Agent Moving", nodeColor = NodeColors.yellow, nodeIcon = NodeIcons.condition)]
    [System.Serializable]
    public class NavMeshIsMoving : DecoratorNode
    {

        public NodeProperty<bool> desiredState;
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (context.agent == null)
            {
                return state = State.Failure;
            }

            if ((context.agent.remainingDistance > context.agent.stoppingDistance && !context.agent.isStopped) ==
                desiredState.Value)
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
                conditionState = ConditionState.True;
                description = $"(Moving) Runs the child if the agent is currently moving.";
            }
            else
            {
                conditionState = ConditionState.False;
                description = $"(Not Moving) Runs the child if the agent is currently not moving.";
            }
            
        }
        
    }
}