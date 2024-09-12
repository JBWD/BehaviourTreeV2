using System;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "NavMesh",menuName = "NavMesh: Start Movement", nodeTitle = "NavMesh:\n Start Movement")]
    [System.Serializable]
    public class NavMeshStartMovement : ActionNode
    {
        protected override void OnStart()
        {
           
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Failure;
            if (context.agent == null)
                return state;

            context.agent.isStopped = false;
            state = State.Success;

            return state;

            
        }

        public override void UpdateDescription()
        {
            description =
                "Starts the movement of the agent, call this node if you ever use the NavMesh: Stop Movement node.";
        }
    }
}