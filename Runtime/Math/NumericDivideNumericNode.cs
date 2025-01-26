using System;
using Unity.Properties;
using UnityEngine;

namespace Halcyon.BT
{
   
    [NodeMenuPath( "Math")]
    [NodeTitle("Math:\nNumeric Divide Numeric")]
    [NodeMenuName("Math: Numeric Divide Numeric")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.math)]
    [CreateBBVariable("BaseNumericValue", BBVariableType.Number)]
    [CreateBBVariable("DivideNumericValue", BBVariableType.Number)]
    [CreateBBVariable("SaveNumericValue", BBVariableType.Number)]
    [Serializable]
    public class NumericDivideNumericNode : ActionNode
    {
        
        /*
        public NodeProperty<float> baseValue;
        public NodeProperty<float> addValue;
        [BlackboardValueOnly]
        public NodeProperty<float> saveValue;*/

        
        [Space]
        public NodeProperty<NumericProperty> baseNumericValue;
        public NodeProperty<NumericProperty> divideNumericValue;
        public NodeProperty<NumericProperty> saveNumericValue;
        

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            saveNumericValue.Value.FloatValue /= divideNumericValue.Value.FloatValue;
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
                        $"Divides '{baseNumericValue.Value.FloatValue}' / '{divideNumericValue}' and saves the answer in '{saveNumericValue}'";
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