using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Variable/Conversion", menuName = "Conversion: Floats to Vector2", 
        nodeTitle = "Conversion:\nFloats to Vector2", nodeColor = NodeColors.pink, nodeIcon = NodeIcons.repeat)]
    [System.Serializable]
    public class ConversionFloatsToVector2Node: ActionNode
    {
        
        public NodeProperty<float> xValue;
        public NodeProperty<float> yValue;
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
            saveValue.Value = new Vector2(xValue.Value, yValue.Value);
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