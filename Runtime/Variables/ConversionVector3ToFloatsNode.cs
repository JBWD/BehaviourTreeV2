using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Variable/Conversion", menuName = "Conversion: Vector3 To Floats", nodeTitle = "Conversion:\nVector3 To Floats", 
        nodeColor = NodeColors.pink, nodeIcon = NodeIcons.repeat)]
    [System.Serializable]
    public class ConversionVector3ToFloatsNode: ActionNode
    {

        public NodeProperty<Vector3> baseValue;
        [BlackboardValueOnly]
        public NodeProperty<float> xSaveFloatValue;
        [BlackboardValueOnly]
        public NodeProperty<float> ySaveFloatValue;
        [BlackboardValueOnly]
        public NodeProperty<float> zSaveFloatValue;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        
        protected override State OnUpdate()
        {
            xSaveFloatValue.Value = baseValue.Value.x;
            ySaveFloatValue.Value = baseValue.Value.y;
            xSaveFloatValue.Value = baseValue.Value.z;
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