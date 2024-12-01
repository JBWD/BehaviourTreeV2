using UnityEngine;

namespace Halcyon.BT
{
    
    [NodeMenuName("Transform: Is Null")]
    [NodeMenuPath("Transform/Is Null")]
    [NodeTitle("Transform \n Is Null")]
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
            return ((TransformProperty == null) == DesiredState.Value);
        }

        public override void UpdateDescription()
        {
            description = "Checks if the transform is null then compares to the desired state";
            conditionState = DesiredState.Value? ConditionState.True : ConditionState.False;
        }
    }
}

