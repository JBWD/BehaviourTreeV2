using System;
using Unity.Properties;
using UnityEngine;

namespace Halcyon.BT
{
   
    [NodeMenuPath( "Math")]
    [NodeTitle("Math:\nNumeric Multiply Numeric")]
    [NodeMenuName("Math: Numeric Multiply Numeric")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.math)]
    [CreateBBVariable("BaseNumericValue", BBVariableType.Number)]
    [CreateBBVariable("MultiplyNumericValue", BBVariableType.Number)]
    [CreateBBVariable("SaveNumericValue", BBVariableType.Number)]
    [Serializable]
    public class NumericMultiplyNumericNode : ActionNode
    {
        
        /*
        public NodeProperty<float> baseValue;
        public NodeProperty<float> addValue;
        [BlackboardValueOnly]
        public NodeProperty<float> saveValue;*/

        
        [Space]
        public NodeProperty<NumericProperty> baseNumericValue;
        public NodeProperty<NumericProperty> MultiplyNumericValue;
        public NodeProperty<NumericProperty> saveNumericValue;
        

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            saveNumericValue.Value.FloatValue += MultiplyNumericValue.Value.FloatValue;
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
                        $"Adds '{baseNumericValue.Value.FloatValue}' * '{MultiplyNumericValue}' and saves the total in '{saveNumericValue}'";
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