using System;
using Unity.Properties;
using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Math/Float", menuName = "Float: Add Float", nodeTitle = "Float Math:\nAdd Float", nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [Serializable]
    public class FloatAddFloatNode : ActionNode
    {
        
        /*
        public NodeProperty<float> baseValue;
        public NodeProperty<float> addValue;
        [BlackboardValueOnly]
        public NodeProperty<float> saveValue;*/

        
        [Space]
        public NodeProperty<NumericProperty> baseNumericValue;
        public NodeProperty<NumericProperty> addNumericValue;
        public NodeProperty<NumericProperty> saveNumericValue;
        

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            saveNumericValue.Value.FloatValue += addNumericValue.Value.FloatValue;
            //saveValue.Value = baseValue.Value + addValue.Value;
            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            errored = false;
            try
            {
                if (saveNumericValue != null)
                {
                    
                    description =
                        $"Adds '{baseNumericValue.Value.FloatValue}' + '{addNumericValue}' and saves the total in '{saveNumericValue}'";
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