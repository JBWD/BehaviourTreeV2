using System;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Math/Integer", menuName = "Integer: Divide Integer", nodeTitle = "Integer Math:\nDivide Integer", nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [Serializable]
    public class IntDivideIntNode : ActionNode
    {

        public NodeProperty<int> baseValue;
        public NodeProperty<int> divideValue = new NodeProperty<int>(){Value = 1};
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