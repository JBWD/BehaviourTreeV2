using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Variable")]
    [NodeTitle("Variable:\nVector3 to Numerics")]
    [NodeMenuName("Variable: Vector3 to Numerics")] 
    [NodeIcon(NodeIcons.repeat)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("SaveXNumericValue", BBVariableType.Number)]
    [CreateBBVariable("SaveYNumericValue", BBVariableType.Number)]
    [CreateBBVariable("SaveZNumericValue", BBVariableType.Number)]
    [CreateBBVariable("Vector3Value", BBVariableType.Vector3)]
    [System.Serializable]
    public class ConversionVector3ToFloatsNode: ActionNode
    {

        public NodeProperty<Vector3> baseValue;
        [BlackboardValueOnly]
        public NodeProperty<NumericProperty> xSaveFloatValue;
        [BlackboardValueOnly]
        public NodeProperty<NumericProperty> ySaveFloatValue;
        [BlackboardValueOnly]
        public NodeProperty<NumericProperty> zSaveFloatValue;

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
            xSaveFloatValue.Value.FloatValue = baseValue.Value.z;
            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            errored = false;
            try
            {
                if (xSaveFloatValue.reference != null || ySaveFloatValue.reference != null || zSaveFloatValue.reference != null )
                {
                    
                    description =
                        $"Retrieves the x,y,z of '{baseValue.Value}' and saves the total in the corresponding variables.";
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