
using UnityEngine;

namespace Halcyon.BT
{
    [NodeTitle("NavMesh AI:\n Set Current State")]
    [NodeMenuName("NavMesh AI: Set Current State")]
    [NodeMenuPath("AI/NavMesh")]
    [NodeIcon(NodeIcons.ai)]
    
    public class NavMeshAISetCurrentStateNode : ActionNode
    {
        public AIStates desiredState = AIStates.Idle;

        protected override void OnStart()
        {

        }

        protected override void OnStop()
        {

        }

        protected override State OnUpdate()
        {
            context.CurrentState = desiredState;
            return State.Success;
        }
    }
}