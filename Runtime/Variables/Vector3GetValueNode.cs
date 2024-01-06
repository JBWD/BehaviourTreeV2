using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuPath = "Variable/Conversion", menuName = "Vector3: To Floats", nodeTitle = "Vector3 Conversion:\nTo Floats", nodeColor = NodeColors.green, nodeIcon = NodeIcons.action)]
    [System.Serializable]
    public class Vector3ToFloatsNode: ActionNode
    {

        public NodeProperty<Vector3> baseValue;
        public NodeProperty<float> xSaveFloatValue;
        public NodeProperty<float> ySaveFloatValue;
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