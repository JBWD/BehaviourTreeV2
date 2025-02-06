using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Transform/Set")]
    [NodeTitle("Transform:\nSet Local Scale")]
    [NodeMenuName("Transform: Set Local Scale")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("TransformValue", BBVariableType.Transform)]
    [CreateBBVariable("ScaleValue", BBVariableType.Vector3)]
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