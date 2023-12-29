using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

namespace TheKiwiCoder
{

    [BehaviourTreeNode(menuPath = "A-Star Pathfinding", nodeTitle = "Is Agent Moving" ,nodeIcon = NodeIcons.condition, nodeColor = NodeColors.yellow)]
    public class IsAgentMoving : DecoratorNode
    {
        
        [Tooltip("The state you desire the node to match. Ex: If (AgentIsMoving == false) then { DetectEnemies() }\n" +
                 "In the example the comparisonState will need to be false as the state does not want the agent to be moving.")]
        public NodeProperty<bool> comparisonState;

        private bool isMoving = false;
        
        protected override void OnStart()
        {
            context.InitializeAStar();
        }

        protected override void OnStop()
        {

        }

        protected override State OnUpdate()
        {
            if (context.aiPath == null)
            {
                Debug.LogWarning("Unable to find Context.aiPath, Please make sure there is an AIPath if using the " +
                                 "IsAgentMoving Node");
                state = State.Failure;
            }
            else
            {
                //Both of these set the condition if the agent is moving to false.
                if (context.aiPath.isStopped || context.aiPath.velocity.magnitude <= .01f)
                {
                    isMoving = false;
                }
                else
                {
                    isMoving = true;
                }
            }

            if (isMoving == comparisonState.Value)
            {
                state = State.Success;
            }
            else
            {
                state = State.Failure;
            }

            return state;
        }

        public override void UpdateDescription()
        {
            description = $"Checks if the agent is currently moving, will call child nodes if '{comparisonState.Value}'";
        }
    }
}