
using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Transform/Set", menuName = "Transform: Set Position", nodeTitle = "Transform:\nSet Position",
        nodeColor = NodeColors.pink, nodeIcon = NodeIcons.save)]
    [System.Serializable]
    public class TransformSetPositionNode: ActionNode
    {
        public NodeProperty<Transform> transformValue;
        public bool self;
        public NodeProperty<Vector3> positionValue;


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
                context.transform.position = positionValue.Value;
                state = State.Success;
            }
            else if(transformValue.Value != null)
            {
                transformValue.Value.position = positionValue.Value;
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
            description = $"Sets the [TransformValue] Position in World Space to {positionValue.Value}.";
        }
    }
}