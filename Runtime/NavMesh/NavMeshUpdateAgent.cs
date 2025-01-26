using UnityEngine;

namespace Halcyon.BT
{
    [NodeTitle("NavMesh:\n Update Agent")]
    [NodeMenuName("NavMesh: Update Agent")]
    [NodeMenuPath("NavMesh")]
    [NodeIcon(NodeIcons.ai)]
    [CreateBBVariable("Speed" ,BBVariableType.Number)]
    [CreateBBVariable("StoppingDistance" ,BBVariableType.Number)]
    [CreateBBVariable("Acceleration" ,BBVariableType.Number)]
    [CreateBBVariable("UpdateRotation" ,BBVariableType.Boolean)]
    [System.Serializable]
    public class NavMeshUpdateAgent : ActionNode {

        [Tooltip("How fast to move")]
        public NodeProperty<NumericProperty> speed = new NodeProperty<NumericProperty> { Value = new NumericProperty(){ DoubleValue = 5.0 }};

        [Tooltip("Stop within this distance of the target")]
        public NodeProperty<NumericProperty> stoppingDistance = new NodeProperty<NumericProperty> { Value = new NumericProperty(){ DoubleValue = .1 }};

        [Tooltip("Updates the agents rotation along the path")]
        public NodeProperty<bool> updateRotation = new NodeProperty<bool> { defaultValue = true };

        [Tooltip("Maximum acceleration when following the path")]
        public NodeProperty<NumericProperty> acceleration = new NodeProperty<NumericProperty> { Value = new NumericProperty(){ DoubleValue = 40 }};
        
        protected override void OnStart()
        {
            if (context.agent != null)
            {
                context.agent.speed = speed.Value.FloatValue;
                context.agent.stoppingDistance = stoppingDistance.Value.FloatValue;
                context.agent.updateRotation = updateRotation.Value;
                context.agent.acceleration = acceleration.Value.FloatValue;
                state = State.Success;
            }
            else
            {
                state = State.Failure;
            }
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {



            return state;
            ;
        }
    }
}