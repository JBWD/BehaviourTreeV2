﻿using System;
using UnityEditor;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Deprecated/Variable", menuName = "Deprecated: Compare Floats",
        nodeTitle = "Deprecated:\nCompare Floats",
        nodeIcon = NodeIcons.condition, nodeColor = NodeColors.red)]
    [System.Serializable]
    public class ComparisonFloatNode : DecoratorNode
    {

        public ComparisionOperator operation;
        public NodeProperty<float> firstValue;
        public NodeProperty<float> secondValue;

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