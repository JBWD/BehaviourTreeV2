using System;
using Unity.Properties;
using UnityEngine;

namespace Halcyon.BT
{
   
    [NodeMenuPath( "Math")]
    [NodeTitle("Math:\nNumeric Subtract Numeric")]
    [NodeMenuName("Math: Numeric Subtract Numeric")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.math)]
    [CreateBBVariable("BaseNumericValue", BBVariableType.Number)]
    [CreateBBVariable("subtractNumericValue", BBVariableType.Number)]
    [CreateBBVariable("SaveNumericValue", BBVariableType.Number)]
    [Serializable]
    public class NumericSubtractNumericNode : ActionNode
    {
        
        /*
        public NodeProperty<float> baseValue;
        public NodeProperty<float> addValue;
        [BlackboardValueOnly]
        public NodeProperty<float> saveValue;*/

        
        [Space]
        public NodeProperty<NumericProperty> baseNumericValue;
        public NodeProperty<NumericProperty> subtractNumericValue;
        public NodeProperty<NumericProperty> saveNumericValue;
        

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            saveNumericValue.Value.FloatValue -= subtractNumericValue.Value.FloatValue;
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
                        $"Adds '{baseNumericValue.Value.FloatValue}' - '{subtractNumericValue}' and saves the total in '{saveNumericValue}'";
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