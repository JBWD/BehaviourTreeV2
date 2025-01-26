using UnityEngine;

namespace Halcyon.BT
{
    
    [NodeMenuName("Transform: Is Null")]
    [NodeMenuPath("Transform")]
    [NodeTitle("Transform:\n Is Null")]
    [CreateBBVariable("Transform Value", BBVariableType.Transform)]
    public class TransformIsNull : ComparisonNode
    {
        [BlackboardValueOnly]
        public NodeProperty<Transform> TransformValue;
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        public override bool CheckComparison()
        {
            if (TransformValue == null)
                return false;
            return TransformValue.Value == null;
        }

        public override void UpdateDescription()
        {
            description = "Checks if the transform is null then compares to the desired state";
            
        }
    }
}

