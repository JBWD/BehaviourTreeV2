using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Transform/Set")]
    [NodeTitle("Transform:\nSet Local Rotation")]
    [NodeMenuName("Transform: Set Local Rotation")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("TransformValue", BBVariableType.Transform)]
    [CreateBBVariable("RotationValue", BBVariableType.Vector3)]
    [System.Serializable]
    public class TransformSetLocalRotationEulerAngleNode: ActionNode
    {
        public NodeProperty<Transform> transformValue;
        public bool self;
        public NodeProperty<Vector3> rotationValue;


        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            
            if (self || transformValue.Value == null)
            {
                context.transform.localRotation = Quaternion.Euler(rotationValue.Value);
                state = State.Success;
            }
            else if(transformValue.Value != null)
            {
                transformValue.Value.localRotation = Quaternion.Euler(rotationValue.Value);
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
            description = $"Sets the [TransformValue] Rotation in Local Space to {rotationValue.Value}.";
        }
    }
}