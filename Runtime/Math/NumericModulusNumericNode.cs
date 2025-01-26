using System;
using Unity.Properties;
using UnityEngine;

namespace Halcyon.BT
{
   
    [NodeMenuPath( "Math")]
    [NodeTitle("Math:\nNumeric Modulus Numeric")]
    [NodeMenuName("Math: Numeric Modulus Numeric")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.math)]
    [CreateBBVariable("BaseNumericValue", BBVariableType.Number)]
    [CreateBBVariable("ModulusNumericValue", BBVariableType.Number)]
    [CreateBBVariable("SaveNumericValue", BBVariableType.Number)]
    [Serializable]
    public class NumericModulusNumericNode : ActionNode
    {
        
        /*
        public NodeProperty<float> baseValue;
        public NodeProperty<float> addValue;
        [BlackboardValueOnly]
        public NodeProperty<float> saveValue;*/

        
        [Space]
        public NodeProperty<NumericProperty> baseNumericValue;
        public NodeProperty<NumericProperty> modulusNumericValue;
        public NodeProperty<NumericProperty> saveNumericValue;
        

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            saveNumericValue.Value.IntegerValue = (int)(saveNumericValue.Value.FloatValue % modulusNumericValue.Value.IntegerValue);
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
                        $"Divides '{baseNumericValue.Value.FloatValue}' % '{modulusNumericValue}' and saves the answer in '{saveNumericValue}'";
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