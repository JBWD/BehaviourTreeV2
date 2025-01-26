using System;
using Unity.Properties;
using UnityEngine;

namespace Halcyon.BT
{
   
    [NodeMenuPath( "Math")]
    [NodeTitle("Math:\nNumeric Add Numeric")]
    [NodeMenuName("Math: Numeric Add Numeric")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.math)]
    [CreateBBVariable("BaseNumericValue", BBVariableType.Number)]
    [CreateBBVariable("AddNumericValue", BBVariableType.Number)]
    [CreateBBVariable("SaveNumericValue", BBVariableType.Number)]
    [Serializable]
    public class NumericAddNumericNode : ActionNode
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