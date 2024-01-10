using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Variable/Conversion", menuName = "Conversion: Vector2 to Floats", nodeTitle = "Conversion:\nVector2 to Floats", nodeColor = NodeColors.pink, nodeIcon = NodeIcons.action)]
    [System.Serializable]
    public class Vector2ToFloatsNode: ActionNode
    {

        public NodeProperty<Vector2> baseValue;
        [BlackboardValueOnly]
        public NodeProperty<float> xSaveFloatValue;
        [BlackboardValueOnly]
        public NodeProperty<float> ySaveFloatValue;
        

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