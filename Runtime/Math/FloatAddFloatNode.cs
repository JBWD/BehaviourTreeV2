using System;
using Unity.Properties;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Math/Float", menuName = "Float: Add Float", nodeTitle = "Float Math:\nAdd Float", nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [Serializable]
    public class FloatAddFloatNode : ActionNode
    {
        
        public NodeProperty<float> baseValue;
        public NodeProperty<float> addValue;
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