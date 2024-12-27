using UnityEngine;

namespace Halcyon.BT
{
    
    [NodeMenuName("Transform: Is Null")]
    [NodeMenuPath("Transform")]
    [NodeTitle("Transform:\n Is Null")]
    public class TransformIsNull : ComparisonNode
    {
        [BlackboardValueOnly]
        public NodeProperty<Transform> TransformProperty;
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        public override bool CheckComparison()
        {
            if (TransformProperty == null)
                return false;
            return TransformProperty.Value != null;
        }

        public override void UpdateDescription()
        {
            description = "Checks if the transform is null then compares to the desired state";
            
        }
    }
}

