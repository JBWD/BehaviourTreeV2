﻿using System;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Math/Integer", menuName = "Integer: Divide Float", nodeTitle = "Integer Math:\nDivide Float", nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [Serializable]
    public class IntDivideFloatNode : ActionNode
    {

        public NodeProperty<int> baseValue;
        public NodeProperty<float> divideValue = new NodeProperty<float>(){Value = 1};
        [BlackboardValueOnly]
        public NodeProperty<int> saveValue;


        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (divideValue.Value == 0)
            {
                state = State.Failure;
                return state;
            }
            saveValue.Value = (int)(baseValue.Value / divideValue.Value);
            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            try
            {
                if (divideValue.Value != 0)
                {
                    errored = false;
                    if (saveValue.reference != null)
                    {
                        description =
                            $"Divides '{baseValue.Value}' / '{divideValue.Value}' and saves the total in '{saveValue.reference.name}'";
                    }
                    else
                    {
                        description =
                            $"Does not save the value";
                        errored = true;
                    }
                }
                else
                {
                    errored = true;
                    description = "Divide by Zero Error";
                }
            }
            catch
            {
                // ignored
            }
        }

        
    }
}