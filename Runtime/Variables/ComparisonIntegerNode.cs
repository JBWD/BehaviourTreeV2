using System;
using UnityEngine;

namespace Halcyon.BT
{
     [BehaviourTreeNode(menuPath = "Variable", menuName = "Variable: Compare Integers",
        nodeTitle = "Variables:\nCompare Integers",
        nodeIcon = NodeIcons.condition, nodeColor = NodeColors.yellow)]
    [System.Serializable]
    public class ComparisonIntegerNode : DecoratorNode
    {

        public ComparisionOperator operation;
        public NodeProperty<int> firstValue;
        public NodeProperty<int> secondValue;


        protected override void OnStart()
        {

        }

        protected override void OnStop()
        {

        }


        protected override State OnUpdate()
        {
            state = State.Success;
            switch (operation)
            {
                case ComparisionOperator.LessThan:
                    if (firstValue.Value < secondValue.Value)
                    {
                        if (child != null)
                            child.Update();
                    }
                    else
                        state = State.Failure;
                    break;
                case ComparisionOperator.GreaterThan:
                    if (firstValue.Value > secondValue.Value)
                    {
                        if (child != null)
                            child.Update();
                    }
                    else
                        state = State.Failure;
                    break;
                case ComparisionOperator.Equal:
                    if (firstValue.Value == secondValue.Value)
                    {
                        if (child != null)
                            child.Update();
                    }
                    else
                        state = State.Failure;
                    break;
                case ComparisionOperator.LessThanOrEqual:
                    if (firstValue.Value <= secondValue.Value)
                    {
                        if (child != null)
                            child.Update();
                    }
                    else
                        state = State.Failure;
                    break;
                case ComparisionOperator.GreaterThanOrEqual:
                    if (firstValue.Value >= secondValue.Value)
                    {
                        if (child != null)
                            child.Update();
                    }
                    else
                        state = State.Failure;
                    break;
                default:
                    state = State.Failure;
                    break;
            }

            return state;
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