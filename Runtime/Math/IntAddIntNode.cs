using System;
using Unity.Properties;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Math/Integer", menuName = "Integer: Add Integer", nodeTitle = "Float Integer:\nAdd Integer", nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [Serializable]
    public class IntAddIntNode : ActionNode
    {
        
        public NodeProperty<int> baseValue;
        public NodeProperty<int> addValue;
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