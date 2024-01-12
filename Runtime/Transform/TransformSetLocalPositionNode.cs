using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Transform/Set", menuName = "Transform: Set Local Position", nodeTitle = "Transform:\nSet Local Position",
        nodeColor = NodeColors.pink, nodeIcon = NodeIcons.save)]
    [System.Serializable]
    public class TransformSetLocalPositionNode: ActionNode
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
                context.transform.localPosition = positionValue.Value;
                state = State.Success;
            }
            else if(transformValue.Value != null)
            {
                transformValue.Value.localPosition = positionValue.Value;
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
            description = $"Sets the [TransformValue] Position in Local Space to {positionValue.Value}.";
        }
    }
}