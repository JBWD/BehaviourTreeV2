using System;
using UnityEditor;
using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Variable")]
    [NodeTitle("Variables:\nCompare Numerics")]
    [NodeMenuName("Variable: Compare Numerics")] 
    [CreateBBVariable("FirstValue", BBVariableType.Number)]
    [CreateBBVariable("SecondValue", BBVariableType.Number)]
    [System.Serializable]
    public class ComparisonNumericNode : ComparisonNode
    {

        public ComparisionOperator operation;
        public NodeProperty<NumericProperty> firstValue;
        public NodeProperty<NumericProperty> secondValue;

        protected override void OnStart()
        {
        }

        protected override void OnStop()
        {
        }
        
        public override bool CheckComparison()
        {
            switch (operation)
            {
                case ComparisionOperator.LessThan:
                    return (firstValue.Value.FloatValue < secondValue.Value.FloatValue);
                case ComparisionOperator.GreaterThan:
                    return (firstValue.Value.FloatValue > secondValue.Value.FloatValue);
                case ComparisionOperator.Equal:
                    return (firstValue.Value.IntegerValue == secondValue.Value.IntegerValue);
                case ComparisionOperator.LessThanOrEqual:
                    return (firstValue.Value.FloatValue <= secondValue.Value.FloatValue);
                case ComparisionOperator.GreaterThanOrEqual:
                    return (firstValue.Value.FloatValue >= secondValue.Value.FloatValue);
            }
            return false;
        }

        public override void UpdateDescription()
        {
            errored = false;
            switch (operation)
            {
                case ComparisionOperator.LessThan:
                    description = "Checks if [FirstValue] is less than [SecondValue].";
                    break;
                case ComparisionOperator.GreaterThan:
                    description = "Checks if [FirstValue] is greater than [SecondValue].";
                    break;
                case ComparisionOperator.Equal:
                    description = "Checks if [FirstValue] is equal to [SecondValue].";
                    break;
                case ComparisionOperator.LessThanOrEqual:
                    description = "Checks if [FirstValue] is less than or equal to [SecondValue].";
                    break;
                case ComparisionOperator.GreaterThanOrEqual:
                    description = "Checks if [FirstValue] is greater than or equal to [SecondValue].";
                    break;
            }
        }
    }
}