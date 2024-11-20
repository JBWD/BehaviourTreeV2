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
        public NumericProperty baseNumericValue;
        public NumericProperty addNumericValue;
        public NumericProperty saveNumericValue;
        

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            saveNumericValue.SetValue(baseNumericValue.FloatValue + addNumericValue.FloatValue);
            //saveValue.Value = baseValue.Value + addValue.Value;
            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            errored = false;
            try
            {
                if (saveNumericValue.Reference() != null)
                {
                    
                    description =
                        $"Adds '{baseNumericValue.FloatValue}' + '{addNumericValue.FloatValue}' and saves the total in '{saveNumericValue.Reference().name}'";
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