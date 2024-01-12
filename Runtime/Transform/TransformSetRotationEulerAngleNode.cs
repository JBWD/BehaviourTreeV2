using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Transform/Set", menuName = "Transform: Set Global Rotation", nodeTitle = "Transform:\nSet Global Rotation",
        nodeColor = NodeColors.pink, nodeIcon = NodeIcons.save)]
    [System.Serializable]
    public class TransformSetRotationEulerAngleNode: ActionNode
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
            
            if (self && context.transform != null)
            {
                context.transform.rotation = Quaternion.Euler(rotationValue.Value);
                state = State.Success;
            }
            else if(transformValue.Value != null)
            {
                transformValue.Value.rotation = Quaternion.Euler(rotationValue.Value);
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
            description = $"Sets the [TransformValue] Rotation in World Space to {rotationValue.Value}.";
        }
    }
}