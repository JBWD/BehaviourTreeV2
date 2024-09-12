using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Transform/Set", menuName = "Transform: Set Local Scale", nodeTitle = "Transform:\nSet Local Scale",
        nodeColor = NodeColors.pink, nodeIcon = NodeIcons.save)]
    [System.Serializable]
    public class TranformSetLocalScaleNode :ActionNode
    {
        public NodeProperty<Transform> transformValue;
        public bool self = true;
        public NodeProperty<Vector3> scaleValue;

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
                context.transform.localScale = scaleValue.Value;
                state = State.Success;
                
            }
            if (transformValue.Value!= null){
                
                transformValue.Value.localScale = scaleValue.Value;
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
            description = $"Sets the [TransformValue] scale in Local Space to {scaleValue.Value}.";
        }
    }
}