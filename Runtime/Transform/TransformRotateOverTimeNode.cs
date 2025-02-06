using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuName("Transform: Rotate Over Time"), NodeMenuPath("Transform")]
    [NodeTitle("Transform:\nRotate Over time")]
    [NodeIcon(NodeIcons.time)]
    [CreateBBVariable("RotationsPerSecond", BBVariableType.Number)]
    [CreateBBVariable("Rotation", BBVariableType.Vector3)]
    [System.Serializable]
    public class TransformRotateOverTimeNode : ActionNode
    {
        public NodeProperty<Vector3> rotation;
        public NodeProperty<NumericProperty> rotationsPerSecond;
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
            
        }

        protected override State OnUpdate()
        {
            if (context.transform == null)
                state = State.Failure;
            else
            {
                context.transform.Rotate(rotationsPerSecond.Value.FloatValue * Time.deltaTime * rotation.Value);
                state = State.Success;
            }

            return state;
        }
        
        public override void UpdateDescription()
        {
            description = $"Rotates the object {rotation.Value} degrees in each axis {rotationsPerSecond.Value.FloatValue} times per second.";

        }
    }
}