using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Variable")]
    [NodeTitle("Variable:\nNumeric to Vector2")]
    [NodeMenuName("Variable: Numeric to Vector2")] 
    [NodeIcon(NodeIcons.repeat)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("xNumericValue", BBVariableType.Number)]
    [CreateBBVariable("yNumericValue", BBVariableType.Number)]
    [CreateBBVariable("SaveVector2Value", BBVariableType.Vector2)]
   
    [System.Serializable]
    public class ConversionNumericToVector2Node: ActionNode
    {
        
        public NodeProperty<NumericProperty> xValue;
        public NodeProperty<NumericProperty> yValue;
        [BlackboardValueOnly]
        public NodeProperty<Vector2> saveValue;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }
        
        protected override State OnUpdate()
        {
            saveValue.Value = new Vector2(xValue.Value.FloatValue, yValue.Value.FloatValue);
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
                        $"Saves X:'{xValue.Value}' and Y:'{yValue.Value}' in the 'SaveValue'.";
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