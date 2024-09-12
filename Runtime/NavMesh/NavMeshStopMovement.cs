namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "NavMesh",menuName = "NavMesh: Stop Movement", nodeTitle = "NavMesh:\n Stop Movement", nodeColor = NodeColors.green, nodeIcon = NodeIcons.destination)]
    
    [System.Serializable]
    public class NavMeshStopMovement : ActionNode
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

            context.agent.isStopped = true;
            state = State.Success;

            return state;

            
        }

        public override void UpdateDescription()
        {
            description =
                "Stops the movement of the agent, the agent will only start moving again when StartMovement is called.";
        }
    }
}