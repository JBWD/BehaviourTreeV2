using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Variable")]
    [NodeTitle("Variable:\nNumeric to Vector3")]
    [NodeMenuName("Variable: Numeric to Vector3")] 
    [NodeIcon(NodeIcons.repeat)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("xNumericValue", BBVariableType.Number)]
    [CreateBBVariable("yNumericValue", BBVariableType.Number)]
    [CreateBBVariable("zNumericValue", BBVariableType.Number)]
    [CreateBBVariable("SaveVector3Value", BBVariableType.Vector3)]
    [System.Serializable]
    public class ConversionNumericToVector3Node: ActionNode
    {
        
        public NodeProperty<NumericProperty> xValue;
        public NodeProperty<NumericProperty> yValue;
        public NodeProperty<NumericProperty> zValue;
        [BlackboardValueOnly]
        public NodeProperty<Vector3> saveValue;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }
        
        protected override State OnUpdate()
        {
            saveValue.Value = new Vector3(xValue.Value.FloatValue, yValue.Value.FloatValue, zValue.Value.FloatValue);
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
                        $"Saves X:'{xValue.Value}', Y:'{yValue.Value}' and Z:'{yValue.Value}' in the 'SaveValue'.";
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