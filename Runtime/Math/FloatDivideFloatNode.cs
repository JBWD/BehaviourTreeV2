using System;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Math/Float", menuName = "Float: Divide Float", nodeTitle = "Float Math:\nDivide Float", nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [Serializable]
    public class FloatDivideFloatNode : ActionNode
    {

        public NodeProperty<float> baseValue;
        public NodeProperty<float> divideValue = new NodeProperty<float>(){Value = 1};
        public NodeProperty<float> saveValue;


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
            saveValue.Value = baseValue.Value / divideValue.Value;
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