namespace Halcyon.BT
{
    [NodeTitle("NavMesh:\n Stop Movement")]
    [NodeMenuName("NavMesh: Stop Movement")]
    [NodeMenuPath("NavMesh")]
    [NodeIcon(NodeIcons.ai)]
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