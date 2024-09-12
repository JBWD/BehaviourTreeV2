using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Transform/Set", menuName = "Transform: Set Local Rotation", nodeTitle = "Transform:\nSet Local Rotation",
        nodeColor = NodeColors.pink, nodeIcon = NodeIcons.save)]
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