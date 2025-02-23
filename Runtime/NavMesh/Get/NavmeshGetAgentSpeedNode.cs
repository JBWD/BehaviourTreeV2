using UnityEngine;
using UnityEngine.AI;

namespace Halcyon.BT
{
    [NodeTitle("NavMesh:\n Get Agent Speed")]
    [NodeMenuName("NavMesh: Get Agent Speed")]
    [NodeMenuPath("NavMesh")]
    [NodeIcon(NodeIcons.save)]
    [CreateBBVariable("AgentMovementSpeed", BBVariableType.Number)]
    [System.Serializable]
    public class NavmeshGetAgentSpeedNode : ActionNode
    {
        [BlackboardValueOnly] public NodeProperty<NumericProperty> agentMovementSpeed;
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (context.agent != null)
            {
                agentMovementSpeed.Value.FloatValue = context.agent.speed;
                return State.Success;
            }

            return State.Failure;
        }
    }
}