using System;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Math/Float", menuName = "Float: Add Integer", nodeTitle = "Float Math:\nAdd Integer", nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [Serializable]
    public class FloatAddIntNode : ActionNode
    {

        public NodeProperty<float> baseValue;
        public NodeProperty<int> addValue;
        [BlackboardValueOnly]
        public NodeProperty<float> saveValue;


        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            saveValue.Value = baseValue.Value + addValue.Value;
            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            errored = false;
            try
            {
                if (saveValue.reference != null)
                {
                    
                    description =
                        $"Adds '{baseValue.Value}' + '{addValue.Value}' and saves the total in '{saveValue.reference.name}'";
                }
                else
                {
                    description = "Does not save the value";
                    errored = true;
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}