using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Variable")]
    [NodeTitle("Variable:\nNumeric to Vector2")]
    [NodeMenuName("Variable: Numeric to Vector2")] 
    [NodeIcon(NodeIcons.repeat)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("SaveXNumericValue", BBVariableType.Number)]
    [CreateBBVariable("SaveYNumericValue", BBVariableType.Number)]
    [CreateBBVariable("Vector2Value", BBVariableType.Vector2)]
    [System.Serializable]
    public class ConversionVector2ToFloatsNode: ActionNode
    {

        public NodeProperty<Vector2> baseValue;
        [BlackboardValueOnly]
        public NodeProperty<NumericProperty> xSaveFloatValue;
        [BlackboardValueOnly]
        public NodeProperty<NumericProperty> ySaveFloatValue;
        

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }
        
        protected override State OnUpdate()
        {
            xSaveFloatValue.Value.FloatValue = baseValue.Value.x;
            ySaveFloatValue.Value.FloatValue = baseValue.Value.y;
            
            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            errored = false;
            try 
            {
                if (xSaveFloatValue.reference != null || ySaveFloatValue.reference != null)
                {
                    
                    description =
                        $"Retrieves the x,y of '{baseValue.Value}' and saves the values in the corresponding variables.";
                }
                else
                {
                    description = "Does not save any of the values";
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